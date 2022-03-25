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
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingRepo _repo;
        private readonly IMapper _mapper;
        public BuildingsController(IBuildingRepo _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }

        [HttpGet(Name = "GetAllBuildings")]
        public async Task<ActionResult> GetAllBuildings()
        {
            var result = await _repo.GetAllBuildings();
            var mapper = _mapper.Map<IEnumerable<ReadBuildingDto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id}",Name = "GetBuildingById")]
        public async Task<ActionResult> GetBuildingById(int id)
        {
            var result = await _repo.GetBuildingById(id);
            var mapper =  _mapper.Map<ReadBuildingDto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding([FromBody] CreateBuildingDto buildingDto)
        {
            var result = await _repo.AddBuilding(_mapper.Map<TblBuilding>(buildingDto));
            var mapper = _mapper.Map<ReadBuildingDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllBuildings), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            var result = await _repo.DeleteBuilding(id);
            if (result)
                return Ok("item Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBuilding(int id, [FromBody] CreateBuildingDto buildingDto)
        {
            var resultReturned = await _repo.GetBuildingById(id);
            _mapper.Map(buildingDto, resultReturned);
            var result = await _repo.EditBuilding(resultReturned);
            var mapper = _mapper.Map<ReadBuildingDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllBuildings), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Updated");
        }
    }
}
