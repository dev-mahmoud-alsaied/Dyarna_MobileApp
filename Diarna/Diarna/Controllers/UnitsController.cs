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

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitRepo _repo;
        private readonly IUpdateUnitDataRepo _updateRepo;
        private readonly IBuildingRepo _buildingRepo;
        private readonly IMapper _mapper;
        public UnitsController(IUnitRepo _repo, IMapper _mapper,
            IUpdateUnitDataRepo _updateRepo,
            IBuildingRepo buildingRepo
            )
        {
            this._repo = _repo;
            this._mapper = _mapper;
            this._updateRepo = _updateRepo;
            _buildingRepo = buildingRepo;
        }

        [HttpGet(Name = "GetAllUnits")]
        public async Task<ActionResult> GetAllUnits()
        {
            var result = await _repo.GetAllUnits();
            var mapper = _mapper.Map<IEnumerable<ReadUnitDto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id:int}",Name = "GetUnitById")]
        public async Task<ActionResult> GetUnitById(int id)
        {
            var result = await _repo.GetUnitById(id);
            var mapper = _mapper.Map<ReadUnitDto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddUnit([FromBody] CreateUnitDto unitDto)
        {
            //find building first 
            var building = await _buildingRepo.GetBuildingById(unitDto.BuildingId ?? 0);
            if (building == null)
                return StatusCode(500, "building is not exist");

            //check for name 
            var unit = await _repo.GetUnitByName(unitDto.Name);
            if (unit != null)
                return StatusCode(500, "Unit Name is Already Exist");

            var result = await _repo.AddUnit(_mapper.Map<TblUnit>(unitDto));
            var mapper = _mapper.Map<ReadUnitDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllUnits), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Added");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            var result = await _repo.DeleteUnit(id);
            if (result)
                return Ok("item Deleted Succefully");
            return StatusCode(500, "No Item Deleted");
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditUnit(int id, [FromBody] CreateUnitDto unitDto)
        {
            //find building first 
            var building = await _buildingRepo.GetBuildingById(unitDto.BuildingId ?? 0);
            if (building == null)
                return StatusCode(500, "building is not exist");

            var resultReturned = await _repo.GetUnitById(id);
            if (resultReturned == null)
                return StatusCode(500, "Unit is not exist");

            //check for name exist 
            var unit = await _repo.GetUnitByName(unitDto.Name);
            if (unit != null && resultReturned.Id != unit.Id)
                return StatusCode(500, "Unit Name is Already Exist");

            _mapper.Map(unitDto, resultReturned);
            var result = await _repo.EditUnit(resultReturned);
            var mapper = _mapper.Map<ReadUnitDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllUnits), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Updated");
        }

        [HttpGet("{id:int}", Name = "GetUpdateUnitDataById")]
        public async Task<ActionResult> GetUpdateUnitDataById(int id)
        {
            var result = await _updateRepo.GetUnitDataById(id);
            if (result == null)
                return NoContent();
            return Ok(_mapper.Map<ReadUpdateUnitDataDto>(result));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditUnitData(int id, [FromBody] EditUpdateUnitDataDto editUpdateUnitDataDto)
        { 
            var resultReturned = await _updateRepo.GetUnitDataById(id);
            _mapper.Map(editUpdateUnitDataDto, resultReturned);
            var result = await _updateRepo.EditUnitData(resultReturned);
            var mapper = _mapper.Map<ReadUpdateUnitDataDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetUpdateUnitDataById), new { Id = result.Id }, mapper);
            return StatusCode(500, "No Item Updated");
        }
    }
}
