using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Services.Interfaces;
using Diarna.Data.Domain;
using AutoMapper;
using Diarna.DTOs.Rerservation;
using Diarna.DTOs.RentUser;
using Diarna.DTOs.ReservationDate;
using System.ComponentModel.DataAnnotations;

namespace Diarna.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")] 
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepo _repo;
        private readonly IUnitRepo _unitRepo;
        private readonly IRentUserRepo _rentUserRepo;
        private readonly IReservationDateRepo _reservationDateRepo;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_repo"></param>
        /// <param name="_mapper"></param>
        /// <param name="unitRepo"></param>
        /// <param name="rentUserRepo"></param>
        /// <param name="reservationDateRepo"></param>
        public ReservationsController(IReservationRepo _repo,
            IMapper _mapper,
            IUnitRepo unitRepo,
            IRentUserRepo rentUserRepo,
            IReservationDateRepo reservationDateRepo
            )
        {
            this._repo = _repo;
            this._mapper = _mapper;
            _unitRepo = unitRepo;
            _rentUserRepo = rentUserRepo;
            _reservationDateRepo = reservationDateRepo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllReservations")]
        public async Task<ActionResult> GetAllReservations()
        {
            var result = await _repo.GetAllReservations();
            var mapper = _mapper.Map<IEnumerable<ReadReservationDto>>(result);
            return Ok(mapper);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        [HttpGet("{unitId}",Name = "GetReservationByUnitId")]
        public async Task<ActionResult> GetReservationByUnitId(int unitId)
        {
            var result = await _repo.GetReservationByUnitId(unitId);
            var mapper =  _mapper.Map<IEnumerable<ReadReservationDto>>(result);
            return Ok(mapper);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserveUnit"></param>
        /// <returns></returns>
        [Route("RserveUnit")]
        [HttpPost]
        public async Task<ActionResult> ReserveUnit([FromBody] ReserveUnitDto reserveUnit)
        {
            //check for model first 
            if (!ModelState.IsValid)
            {
                return Ok(reserveUnit);
            }

            //find user first
            var checkUser = await _rentUserRepo.GetRentUserByPhone(reserveUnit.Mobile);
            if (checkUser == null)
            {
                //var newUser = new CreateRentUserDto { Mobile = reserveUnit.Mobile, Name = reserveUnit.RentUserName };
                var newUser = _mapper.Map<CreateRentUserDto>(reserveUnit);
                var insert = await _rentUserRepo.AddRentUser(_mapper.Map<TblRentUser>(newUser));
                if (insert == null)
                {
                    return StatusCode(500, "There is an error when add new User");
                }
                checkUser = insert;
            }
            // find date 
            var checkDate = await _reservationDateRepo.GetReservationDateByStartDateAndEndDate(reserveUnit.StartDate, reserveUnit.EndDate);
            if (checkDate == null)
            {
                var newDate = _mapper.Map<CreateReservationDateDto>(reserveUnit);
                //var newDate = new CreateReservationDateDto { StartDate = reserveUnit.StartDate, EndDate = reserveUnit.EndDate };
                var insert = await _reservationDateRepo.AddReservationDate(_mapper.Map<TblReservationDate>(newDate));
                if (insert == null)
                {
                    return StatusCode(500, "There is an error when add new date");
                }
                checkDate = insert;
            }

            var checkUnit = await _unitRepo.GetUnitById(reserveUnit.UnitId);
            if (checkUnit == null)
                return StatusCode(500, "There is no unit with this id");
            //check unit is not reserved in this date 
            var checkReservation = await _repo.GetReservationByUnitIdAndDateId(reserveUnit.UnitId, checkDate.Id);
            if (checkReservation == null)
            {
                var mapper = _mapper.Map<CreateReservationDto>(reserveUnit);
                mapper.DateId = checkDate.Id;
                mapper.RentUserId = checkUser.Id;
                mapper.ConfirmReservation = 1;
                var addReservation = await _repo.AddReservation(_mapper.Map<TblReservation>(mapper));
                if (addReservation != null)
                {
                    var finalMapping = _mapper.Map<ReadReservationDto>(addReservation);
                    return CreatedAtRoute(nameof(GetAllReservations), new { Id = addReservation.UnitId }, finalMapping);
                }
                return StatusCode(500, "No Reservation Added");
            }
            return StatusCode(500, "The unit is already reserved in this date");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservationDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] CreateReservationDto reservationDto)
        {
            //find unit first 
            var unit = await _unitRepo.GetUnitById(reservationDto.UnitId);
            if (unit == null)
                return StatusCode(500, "No Unit Exist");

            //find date  
            var date = await _reservationDateRepo.GetReservationDateById(reservationDto.DateId);
            if (date == null)
                return StatusCode(500, "NO Date Exist");

            //find user
            var user = await _rentUserRepo.GetRentUserById(reservationDto.RentUserId ?? 0);
            if (user == null)
                return StatusCode(500, "NO User Exist");

            //make sure for primary key (unit id and date id ) 
            var check = await _repo.GetReservationByUnitIdAndDateId(reservationDto.UnitId, reservationDto.DateId);
            if (check != null)
                return StatusCode(500, "The Unit is Already Reserved in this date"); 

            var result = await _repo.AddReservation(_mapper.Map<TblReservation>(reservationDto));
            var mapper = _mapper.Map<ReadReservationDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllReservations), new { Id = result.UnitId }, mapper);
            return StatusCode(500, "No Reservation Added");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="dateId"></param>
        /// <returns></returns>
        [HttpDelete("{unitId}, {dateId}")]
        public async Task<IActionResult> DeleteReservation(int unitId, int dateId)
        {
            var result = await _repo.DeleteReservation(unitId, dateId);
            if (result)
                return Ok("Reservation Deleted Succefully");
            return StatusCode(500, "No Reservation Deleted");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="dateId"></param>
        /// <param name="reservationDto"></param>
        /// <returns></returns>
        [HttpPut("{unitId}, {dateId}")]
        public async Task<IActionResult> EditReservation(int unitId, int dateId,  [FromBody] CreateReservationDto reservationDto)
        {
            //find unit first 
            var unit = await _unitRepo.GetUnitById(reservationDto.UnitId);
            if (unit == null)
                return StatusCode(500, "No Unit Exist");

            //find date  
            var date = await _reservationDateRepo.GetReservationDateById(reservationDto.DateId);
            if (date == null)
                return StatusCode(500, "NO Date Exist");

            //find user
            var user = await _rentUserRepo.GetRentUserById(reservationDto.RentUserId ?? 0);
            if (user == null)
                return StatusCode(500, "NO User Exist");

            //find reservation
            var resultReturned = await _repo.GetReservationByUnitIdAndDateId(unitId, dateId);
            if (resultReturned == null)
                return StatusCode(500, "NO Reservation Exist");

            //should delete old reservation and add new one 
            var delete = await _repo.DeleteReservation(unitId, dateId);
            if (delete)
            {
                var insert =  _mapper.Map<TblReservation>(reservationDto);
                var result = await _repo.AddReservation(insert);
                var mapper = _mapper.Map<ReadReservationDto>(result);
                if (mapper != null)
                    return CreatedAtRoute(nameof(GetAllReservations), new { Id = result.UnitId }, mapper);
            }
            return StatusCode(500, "No Reservation Updated");
        }
    }
}
