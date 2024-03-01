using Business.Abstract;
using Business.Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Add(CategoryAddRequest categoryAddRequest)
        {
            var result = _categoryService.Add(categoryAddRequest);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(CategoryUpdateRequest categoryUpdateRequest)
        {
            var result = _categoryService.Update(categoryUpdateRequest);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(CategoryDeleteRequest categoryDeleteRequest)
        {
            var result = _categoryService.Delete(categoryDeleteRequest);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);
            return Ok(result);
        }
    }
}
