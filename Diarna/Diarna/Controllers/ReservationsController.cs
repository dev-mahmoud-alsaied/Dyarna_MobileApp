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
        private readonly IMapper _mapper;
        public ReservationsController(IReservationRepo _repo, IMapper _mapper, IUnitRepo unitRepo)
        {
            this._repo = _repo;
            this._mapper = _mapper;
            _unitRepo = unitRepo;
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
            var mapper =  _mapper.Map<ReadReservationDto>(result);
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

            //find user

            //make sure for primary key (unit id and date id ) 

            var result = await _repo.AddReservation(_mapper.Map<TblReservation>(reservationDto));
            var mapper = _mapper.Map<ReadReservationDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllReservations), new { Id = result.UnitId }, mapper);
            return StatusCode(500, "No Reservation Added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int unitId, int dateId)
        {
            var result = await _repo.DeleteReservation(unitId, dateId);
            if (result)
                return Ok("Reservation Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditReservation(int unitId, int dateId,  [FromBody] CreateReservationDto reservationDto)
        {
            //find unit first 
            var unit = await _unitRepo.GetUnitById(reservationDto.UnitId);
            if (unit == null)
                return StatusCode(500, "No Unit Exist");

            // find date 

            // find user 

            //find reservation
            var resultReturned = await _repo.GetReservationByUnitIdAndDateId(unitId, dateId);
            if (resultReturned == null)
                return StatusCode(500, "NO Reservation Exist"); 

            _mapper.Map(reservationDto, resultReturned);
            var result = await _repo.EditReservation(resultReturned);
            var mapper = _mapper.Map<ReadReservationDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllReservations), new { Id = result.UnitId }, mapper);
            return StatusCode(500, "No Item Updated");
        }
    }
}
