using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Services.Interfaces;
using Diarna.Data.Domain; 
using AutoMapper;
using Diarna.DTOs.ItemType;

namespace Diarna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypesController : ControllerBase
    {
        private readonly IItemTypeRepo _repo;
        private readonly IMapper _mapper;
        public ItemTypesController(IItemTypeRepo _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }

        [HttpGet(Name = "GetAllItemTypes")]
        public async Task<ActionResult> GetAllItemTypes()
        {
            var result = await _repo.GetAllItemTypes();
            return Ok(_mapper.Map<IEnumerable<ReadItemTypeDto>>(result));
        }

        [HttpGet("{id:int}",Name = "GetItemTypeById")]
        public async Task<ActionResult> GetItemTypeById(int id)
        {
            var result = await _repo.GetItemTypeById(id);
            if (result == null)
                return NoContent();
            return Ok(_mapper.Map<ReadItemTypeDto>(result));
        }

        [HttpPost]
        public async Task<IActionResult> AddItemType([FromBody] CreateItemTypeDto itemTypeDto)
        {
            var result = await _repo.AddItemType(_mapper.Map<TblItemType>(itemTypeDto));
            if (result != null)
                return CreatedAtRoute(nameof(GetAllItemTypes), new { Id = result.Id }, result);
            return StatusCode(500, "No Item Added");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteItemType(int id)
        {
            var result = await _repo.DeleteItemType(id);
            if (result)
                return Ok("item Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditItemType(int id, [FromBody] CreateItemTypeDto createItemTypeDto)
        {
            var resultReturned = await _repo.GetItemTypeById(id);
            _mapper.Map(createItemTypeDto,resultReturned);
            var result = await _repo.EditItemType(resultReturned);
            var mapper = _mapper.Map<ReadItemTypeDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetItemTypeById), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Updated");
        }
    }
}
