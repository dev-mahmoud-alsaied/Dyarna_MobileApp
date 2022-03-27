using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Services.Interfaces;
using Diarna.Data.Domain;
using AutoMapper;
using Diarna.DTOs;

namespace Diarna.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentExpensesController : ControllerBase
    {
        private readonly IRentExpensesRepo _repo;
        private readonly IMapper _mapper;
        public RentExpensesController(IRentExpensesRepo _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }

        [HttpGet(Name = "GetAllRentExpenses")]
        public async Task<ActionResult> GetAllRentExpenses()
        {
            var result = await _repo.GetAllRentExpenses();
            return Ok(_mapper.Map<IEnumerable<ReadRentExpensesDto>>(result));
        }

        [HttpGet("{unitId}", Name = "GetRentExpensesById")]
        public async Task<ActionResult> GetRentExpensesById(int unitId, int itemId)
        {
            var result = await _repo.GetRentExpensesById(unitId, itemId);
            if (result == null)
                return NoContent();
            return Ok(_mapper.Map< IEnumerable<ReadRentExpensesDto>>(result));
        }

        /*[HttpPost]
        public async Task<IActionResult> AddRentedUnit([FromBody] CreateRentedUnitDto createRentedUnitDto)
        {
            var resultChecked = await _repo.CheckUnitExsist((int)createRentedUnitDto.UnitId);
            if (createRentedUnitDto.DeliveryPrice <= 0 || createRentedUnitDto.UnitId <= 0 ||
                (resultChecked != null && DateTime.Compare(DateTime.Parse(DateTime.Now.ToShortDateString()), (DateTime)resultChecked.RentEndDate) <= 0))
                return BadRequest();
            var result = await _repo.AddRentedUnit(_mapper.Map<TblRentedUnit>(createRentedUnitDto));
            if (result != null)
            {
                var returnedData = await _repo.GetRentedUnitById(result.Id);
                return Ok(_mapper.Map<ReadRentedUnitDto>(returnedData));
            }
            return StatusCode(500, "No Item Added");
        }*/

        /*[HttpDelete("{id:int}",Name = "GetRentedUnitById")]
        public async Task<IActionResult> DeleteRentedUnit(int id)
        {
            var result = await _repo.DeleteRentedUnit(id);
            if (result)
                return Ok("item Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }*/

        /*[HttpPut("{id:int}")]
        public async Task<IActionResult> EditRentedUnit(int id, [FromBody] CreateRentedUnitDto createRentedUnitDto)
        {
            var resultChecked = await _repo.CheckUnitExsist((int)createRentedUnitDto.UnitId);
            if (createRentedUnitDto.DeliveryPrice <= 0 || createRentedUnitDto.UnitId <= 0 || resultChecked != null)
                return BadRequest();
            var resultReturned = await _repo.GetRentedUnitById(id);
            _mapper.Map(createRentedUnitDto, resultReturned);
            var result = await _repo.EditRentedUnit(resultReturned);
            var mapper = _mapper.Map<ReadRentedUnitDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetRentedUnitById), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Updated");
        }*/
    }
}
