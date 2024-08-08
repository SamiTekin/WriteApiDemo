using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public UsersController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserAsync([FromQuery] UserParameters userParameters)
        {
            var pageResult = await _manager
                .UserService.GetAllUserAsync(userParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));
            return Ok(pageResult.user);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneUserAsync([FromRoute(Name ="id")]int id)
        {
            var user = await _manager.UserService.GetUserByIdAsync(id, false);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneUserAsync([FromBody] UserDtoForInsertion userDto)
        {
            var user = await _manager.UserService.CreateOneUserAyns(userDto);
            return StatusCode(201, user);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneUserAsync([FromRoute(Name ="id")]int id,[FromBody] UserDtoForUpdate userDto)
        {
            await _manager.UserService.UpdateOneUserAyns(id, userDto, false);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneUserAsync([FromRoute(Name ="id")]int id)
        {
            await _manager.UserService.DeleteUserByIdAsync(id, false);
            return NoContent();
        }
    }
}
