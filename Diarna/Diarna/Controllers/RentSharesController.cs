using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Services.Interfaces;
using Diarna.Data.Domain;
using AutoMapper;
using Diarna.DTOs.Unit;
using Diarna.DTOs.RentShare;

namespace Diarna.Controllers 
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/rent/[action]")]
    [ApiController]
    public class RentSharesController : ControllerBase
    {
        private readonly IRentShareRepo _repo;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_repo"></param>
        /// <param name="_mapper"></param>
        public RentSharesController(IRentShareRepo _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllRentShares")]
        public async Task<ActionResult> GetAllRentShares()
        {
            var result = await _repo.GetAllRentShares();
            return Ok(_mapper.Map<IEnumerable<ReadRentSharesDto>>(result));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}",Name = "GetRentShareByShareId")]
        public async Task<ActionResult> GetRentShareByShareId(int id)
        {
            var result = await _repo.GetRentShareByShareId(id);
            if (result == null)
                return NoContent();
            return Ok(_mapper.Map<ReadRentSharesDto>(result));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userShareId"></param>
        /// <returns></returns>
        [HttpGet("{userShareId:int}")]
        public async Task<ActionResult> GetRentShareByUserShareId(int userShareId)
        {
            var returnedResult = await _repo.CheckUserShareExsist(userShareId);
            if (returnedResult == null)
                return BadRequest();
            var result = await _repo.GetRentShareByUserShareId(userShareId);
            if (result == null)
                return NoContent();
            return Ok(_mapper.Map< IEnumerable<ReadRentSharesDto>>(result));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createRentSharesDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddRentShare([FromBody] CreateRentSharesDto createRentSharesDto)
        {
            if (createRentSharesDto.UserCash <= 0 || createRentSharesDto.UserMinProfit <= 0 ||
                createRentSharesDto.Percent <=0 || createRentSharesDto.ShareType <= 0)
                return BadRequest();
            var result = await _repo.AddRentShare(_mapper.Map<TblShare>(createRentSharesDto));
            if (result != null)
            {
                var returnedData = await _repo.GetRentShareByShareId(result.Id);
                return Ok(_mapper.Map<ReadRentSharesDto>(returnedData));
            }
            return StatusCode(500, "No Item Added");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRentShare(int id)
        {
            var result = await _repo.DeleteRentShare(id);
            if (result)
                return Ok("item Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createRentSharesDto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditRentShare(int id, [FromBody] CreateRentSharesDto createRentSharesDto)
        {
            var checkedResult = await _repo.CheckUserShareExsist((int)createRentSharesDto.UserSharesId);
            if (createRentSharesDto.UserSharesId <= 0 || checkedResult == null)
                return BadRequest();
            var resultReturned = await _repo.GetRentShareByShareId(id);
            if(resultReturned == null)
                return BadRequest();
            _mapper.Map(createRentSharesDto, resultReturned);
            var result = await _repo.EditRentShare(resultReturned);
            var mapper = _mapper.Map<ReadRentSharesDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetRentShareByShareId), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Updated");
        }
    }
}
