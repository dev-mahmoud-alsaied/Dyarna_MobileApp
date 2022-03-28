﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Services.Interfaces;
using Diarna.Data.Domain;
using AutoMapper; 
using Diarna.DTOs.Item;

namespace Diarna.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepo _repo;
        private readonly IItemTypeRepo _repo2;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_repo"></param>
        /// <param name="_mapper"></param>
        /// <param name="_repo2"></param>
        public ItemsController(IItemRepo _repo, IMapper _mapper, IItemTypeRepo _repo2)
        {
            this._repo = _repo;
            this._repo2 = _repo2;
            this._mapper = _mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllItems")]
        public async Task<ActionResult> GetAllItems()
        {
            var result = await _repo.GetAllItems();
            return Ok(_mapper.Map<IEnumerable<ReadItemDto>>(result));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllItemsWithDetail")]
        public async Task<ActionResult> GetAllItemsWithDetail()
        {
            var result = await _repo.GetAllItemsWithDetail();
            var mapper = _mapper.Map< IEnumerable<ReadItemDetailDto>>(result);
            return Ok(mapper);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllItemsWithGeneralExpenses")]
        public async Task<ActionResult> GetAllItemsWithGeneralExpenses()
        {
            var result = await _repo.GetAllItemsWithGeneralExpenses();
            var mapper = _mapper.Map<IEnumerable<ReadItemDetailDto>>(result);
            return Ok(mapper);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetItemById")]
        public async Task<ActionResult> GetItemById(int id)
        {
            var result = await _repo.GetItemById(id);
            if (result == null)
                return NoContent();
            return Ok(_mapper.Map<ReadItemDto>(result));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetItemByIdWithDetail")]
        public async Task<ActionResult> GetItemByIdWithDetail(int id)
        {
            var result = await _repo.GetItemByIdWithDetail(id);
            if (result == null)
                return NoContent();
            return Ok(_mapper.Map<ReadItemDetailDto>(result));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createItemDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] CreateItemDto createItemDto)
        {
            var checkResult = await _repo2.GetItemTypeById((int)createItemDto.ItemtypeId);
            if (checkResult == null)
                return StatusCode(404, "please enter item type");
            var result = await _repo.AddItem(_mapper.Map<TblItem>(createItemDto));
            if (result != null)
                return CreatedAtRoute(nameof(GetAllItems), new { Id = result.Id }, result);
            return StatusCode(500, "No Item Added");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _repo.DeleteItem(id);
            if (result)
                return Ok("item Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createItemDto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditItem(int id, [FromBody] CreateItemDto createItemDto)
        {
            var resultReturned = await _repo.GetItemById(id);
            _mapper.Map(createItemDto, resultReturned);
            var result = await _repo.EditItem(resultReturned);
            var mapper = _mapper.Map<ReadItemDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetItemById), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Updated");
        }
    }
}
