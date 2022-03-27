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

namespace Diarna.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepo _repo;
        private readonly IUnitRepo _unitRepo;
        private readonly IRentUserRepo _rentUserRepo;
        private readonly IReservationDateRepo _reservationDateRepo;
        private readonly IMapper _mapper;
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

        [HttpGet(Name = "GetAllReservations")]
        public async Task<ActionResult> GetAllReservations()
        {
            var result = await _repo.GetAllReservations();
            var mapper = _mapper.Map<IEnumerable<ReadReservationDto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{unitId}",Name = "GetReservationByUnitId")]
        public async Task<ActionResult> GetReservationByUnitId(int unitId)
        {
            var result = await _repo.GetReservationByUnitId(unitId);
            var mapper =  _mapper.Map<IEnumerable<ReadReservationDto>>(result);
            return Ok(mapper);
        }

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

        [HttpDelete("{unitId}, {dateId}")]
        public async Task<IActionResult> DeleteReservation(int unitId, int dateId)
        {
            var result = await _repo.DeleteReservation(unitId, dateId);
            if (result)
                return Ok("Reservation Deleted Succefully");
            return StatusCode(500, "No Reservation Deleted");
        }
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
