using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Services.Interfaces;
using Diarna.Data.Domain;
using AutoMapper;
using Diarna.DTOs.ReservationDate;

namespace Diarna.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class ReservationDatesController : ControllerBase
    {
        private readonly IReservationDateRepo _repo;
        private readonly IMapper _mapper;
        public ReservationDatesController(IReservationDateRepo _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }

        [HttpGet(Name = "GetAllReservationDates")]
        public async Task<ActionResult> GetAllReservationDates()
        {
            var result = await _repo.GetAllReservationDates();
            var mapper = _mapper.Map<IEnumerable<ReadReservationDateDto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}",Name = "GetReservationDateById")]
        public async Task<ActionResult> GetReservationDateById(int id)
        {
            var result = await _repo.GetReservationDateById(id);
            var mapper =  _mapper.Map<ReadReservationDateDto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservationDate([FromBody] CreateReservationDateDto reservationDateDto)
        {
            //find date first 
            var date = await _repo.GetReservationDateByStartDateAndEndDate(reservationDateDto.StartDate, reservationDateDto.EndDate);
            if (date != null)
                return StatusCode(500, "Date Already Exist");

            var result = await _repo.AddReservationDate(_mapper.Map<TblReservationDate>(reservationDateDto));
            var mapper = _mapper.Map<ReadReservationDateDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllReservationDates), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Dates Added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationDate(int id)
        {
            var result = await _repo.DeleteReservationDate(id);
            if (result)
                return Ok("Reservation Date Deleted Succefully");
            return StatusCode(500, "No Date Deleted");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditReservation(int id,  [FromBody] CreateReservationDateDto reservationDateDto)
        {
            
            // check if new date exist 
            var check = await _repo.GetReservationDateByStartDateAndEndDate(reservationDateDto.StartDate, reservationDateDto.EndDate);
            if (check != null && check.Id != id)
                return StatusCode(500, "Date Already Exist"); 

            var resultReturned = await _repo.GetReservationDateById(id);
            if (resultReturned == null)
                return StatusCode(500, "NO Date Exist"); 

            _mapper.Map(reservationDateDto, resultReturned);
            var result = await _repo.EditReservationDate(resultReturned);
            var mapper = _mapper.Map<ReadReservationDateDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllReservationDates), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Updated");
        }
    }
}
