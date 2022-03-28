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
using Microsoft.VisualBasic;
using System.Globalization;

namespace Diarna.Controllers 
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RentExpensesController : ControllerBase
    {
        private readonly IRentExpensesRepo _repo;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_repo"></param>
        /// <param name="_mapper"></param>
        public RentExpensesController(IRentExpensesRepo _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllRentExpenses")]
        public async Task<ActionResult> GetAllRentExpenses()
        {
            var result = await _repo.GetAllRentExpenses();
            return Ok(_mapper.Map<IEnumerable<ReadRentExpensesDto>>(result));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        [HttpGet("{unitId}", Name = "GetRentExpensesById")]
        public async Task<ActionResult> GetRentExpensesById(int unitId)
        {
            var result = await _repo.GetRentExpensesById(unitId);
            if (result == null)
                return NoContent();
            return Ok(_mapper.Map<IEnumerable<ReadRentExpensesDto>>(result));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("{startDate:datetime}/{endDate:datetime}", Name = "GetRentExpensesByDate")]
        public async Task<ActionResult> GetRentExpensesByDate(DateTime startDate, DateTime endDate)
        {
            var result = await _repo.GetRentExpensesByDate(startDate, endDate);
            if (result == null)
                return NoContent();
            return Ok(_mapper.Map<IEnumerable<ReadRentExpensesDto>>(result));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createRentExpensesDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRentExpenses([FromBody] CreateRentExpensesDto createRentExpensesDto)
        {
            DateTime date;
            bool chValidity = DateTime.TryParseExact(
            createRentExpensesDto.Date.ToShortDateString(),"yyyy-MM-dd",
            CultureInfo.InvariantCulture,DateTimeStyles.None,out date);

            if (createRentExpensesDto.ItemId > 0 && createRentExpensesDto.UnitId > 0 
                && createRentExpensesDto.ItemValue > 0 && chValidity == true)
            {
                var resultChecked = _repo.CheckUnitAndItemExsist(createRentExpensesDto.UnitId, createRentExpensesDto.ItemId);
                if (resultChecked == 0)
                    return BadRequest();
                var result = await _repo.AddRentExpenses(_mapper.Map<TblRentExpense>(createRentExpensesDto));
                if (result != null)
                {
                    var returnedData = await _repo.GetRentExpensesById(result.UnitId);
                    return Ok(_mapper.Map<IEnumerable<ReadRentExpensesDto>>(returnedData));
                }
                return StatusCode(500, "No Item Added");
            }
            return StatusCode(500, "No Item Added");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="itemId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpDelete("{unitId:int}/{itemId:int}/{date:datetime}")]
        public async Task<IActionResult> DeleteRentExpenses(int unitId,int itemId,DateTime date)
        {
            TblRentExpense tblRentExpense = new TblRentExpense();
            tblRentExpense.UnitId = unitId;
            tblRentExpense.ItemId = itemId;
            tblRentExpense.Date = DateTime.Parse(date.ToShortDateString());
            var result = await _repo.DeleteRentExpenses(tblRentExpense);
            if (result)
                return Ok("item Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createRentExpensesDto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditRentExpenses(int id, [FromBody] CreateRentExpensesDto createRentExpensesDto)
        {
            var resultChecked = _repo.CheckUnitExsist(createRentExpensesDto.UnitId);
            if (resultChecked == 0)
                return BadRequest();
            var resultReturned = await _repo.GetRentExpensesByIdAndDate(_mapper.Map<TblRentExpense>(createRentExpensesDto));
            if(resultReturned == null)
                return BadRequest();
            _mapper.Map(createRentExpensesDto, resultReturned);
            resultReturned.Date = DateTime.Parse(resultReturned.Date.ToShortDateString());
            var result = await _repo.EditRentExpenses(resultReturned);
            var mapper = _mapper.Map<ReadRentExpensesDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetRentExpensesById), new { unitId = result.UnitId }, mapper);
            return StatusCode(500, "No Item Updated");
        }
    }
}
