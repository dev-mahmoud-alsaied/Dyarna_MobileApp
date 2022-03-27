using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diarna.Services.Interfaces;
using Diarna.Data.Domain;
using AutoMapper;
using Diarna.DTOs.RentUser; 

namespace Diarna.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentUsersController : ControllerBase
    {
        private readonly IRentUserRepo _repo;
        private readonly IMapper _mapper;
        public RentUsersController(IRentUserRepo _repo, IMapper _mapper )
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }

        [HttpGet(Name = "GetAllRentUsers")]
        public async Task<ActionResult> GetAllRentUsers()
        {
            var result = await _repo.GetAllRentUsers();
            var mapper = _mapper.Map<IEnumerable<ReadRentUserDto>>(result);
            return Ok(mapper);
        }

        [HttpGet("{id:int}",Name = "GetRentUserById")]
        public async Task<ActionResult> GetRentUserById(int id)
        {
            var result = await _repo.GetRentUserById(id);
            var mapper = _mapper.Map<ReadRentUserDto>(result);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddRentUser([FromBody] CreateRentUserDto rentUserDto)
        {
            
            //check for phone
            var userPhone = await _repo.GetRentUserByName(rentUserDto.Mobile);
            if (userPhone != null)
                return StatusCode(500, "User Phone is Already Exist");

            var result = await _repo.AddRentUser(_mapper.Map<TblRentUser>(rentUserDto));
            var mapper = _mapper.Map<ReadRentUserDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllRentUsers), new { Id = result.Id }, mapper);
            return StatusCode(500, "No User Added");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRentUser(int id)
        {
            var result = await _repo.DeleteRentUser(id);
            if (result)
                return Ok("User Deleted Succefully");
            return StatusCode(500, "No User Deleted");
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditRentUser(int id, [FromBody] CreateRentUserDto userDto)
        {
            
            var resultReturned = await _repo.GetRentUserById(id);
            if (resultReturned == null)
                return StatusCode(500, "User is not exist");

            //check for phone exist 
            var user = await _repo.GetRentUserByPhone(userDto.Mobile);
            if (user != null && resultReturned.Id != user.Id)
                return StatusCode(500, "Unit Phone is Already Exist");

            _mapper.Map(userDto, resultReturned);
            var result = await _repo.EditRentUser(resultReturned);
            var mapper = _mapper.Map<ReadRentUserDto>(result);
            if (mapper != null)
                return CreatedAtRoute(nameof(GetAllRentUsers), new { Id = result.Id }, mapper);
            return StatusCode(500, "No User Updated");
        }
    }
}
