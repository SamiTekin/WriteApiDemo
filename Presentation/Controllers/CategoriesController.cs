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
    [Route("api/categories")]
    public class CategoriesController:ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoriesController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoryAsync([FromQuery]CategoryParameters categoryParameters)
        {
            var pageResult = await _manager
                .CategoryService.GetAllCategoryAsync(categoryParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pageResult.metaData));
            return Ok(pageResult.categories);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryAsync([FromRoute(Name ="id")] int id)
        {
            var category = await _manager.CategoryService.GetCategoryByIdAsync(id, false);
            return Ok(category);

        }
        [HttpPost]
        public async Task<IActionResult> CreateOneCategoryAsync([FromBody]CategoryDtoForInsertion categoryDto)
        {
            var  category= await _manager.CategoryService.CreateOneCategoryAsync(categoryDto);
            return StatusCode(201,category);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCategoryAsync([FromRoute(Name ="id")]int id,[FromBody]CategoryDtoForUpdate categoryDto)
        {
            await _manager.CategoryService.UpdateOneCategoryAsync(id, categoryDto, false);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCategoryAsync([FromRoute(Name ="id")]int id)
        {
            await _manager.CategoryService.DeleteCategoryByIdAsync(id, false);
            return NoContent();
        }
    }
}
