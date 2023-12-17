using App.Dtos;
using App.Dtos.Product;
using App.Models;
using App.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        { 
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> Get()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> AddCharacter(AddProductDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> DeleteCharacter(int id)
        {
            var response = await _productService.DeleteProduct(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> UpdateProduct(GetProductDto product)
        {
            return Ok(await _productService.UpdateProduct(product));
        }
    }
}
