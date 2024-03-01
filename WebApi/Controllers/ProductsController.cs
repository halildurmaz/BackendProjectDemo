using Business.Abstract;
using Business.Concrete;
using Business.Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Add(ProductAddRequest productAddRequest) 
        {
            var result = _productService.Add(productAddRequest);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(ProductUpdateRequest productUpdateRequest)
        {
            var result = _productService.Update(productUpdateRequest);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(ProductDeleteRequest productDeleteRequest)
        {
            var result = _productService.Delete(productDeleteRequest);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var result = _productService.GetById(id);
            return Ok(result);
        }
    }
}
