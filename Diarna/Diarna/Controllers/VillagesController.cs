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
    public class VillagesController : ControllerBase
    {
        private readonly IVillageRepo _repo;
        private readonly IMapper _mapper;
        public VillagesController(IVillageRepo _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }

        [HttpGet(Name = "GetAllVillages")]
        public async Task<ActionResult> GetAllVillages()
        {
            var result = await _repo.GetAllVillages();
            var mapper = _mapper.Map<IEnumerable<ReadVillageDto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id:int}",Name = "GetVillageById")]
        public async Task<ActionResult> GetVillageById(int id)
        {
            var result = await _repo.GetVillageById(id);
            var mapper = _mapper.Map<ReadVillageDto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddVillage([FromBody] CreateVillageDto villageDto)
        {
            var result = await _repo.AddVillage(_mapper.Map<TblVillage>(villageDto));
            var mapper = _mapper.Map<ReadVillageDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllVillages), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Added");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVillage(int id)
        {
            var result = await _repo.DeleteVillage(id);
            if (result)
                return Ok("item Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditVillage(int id, [FromBody] CreateVillageDto createVillageDto)
        {
            var resultReturned = await _repo.GetVillageById(id);
            _mapper.Map(createVillageDto, resultReturned);
            var result = await _repo.EditVillage(resultReturned);
            var mapper = _mapper.Map<ReadVillageDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetVillageById), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Updated");
        }
    }
}
