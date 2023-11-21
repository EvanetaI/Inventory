using App.Dtos;
using App.Dtos.Product;
using App.Models;

namespace App.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> GetAllProducts();
        Task<ServiceResponse<GetProductDto>> GetProductByName(string name);
        Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newCharacter);
        Task<ServiceResponse<GetProductDto>> UpdateProduct(GetProductDto updatedCharacter);
        Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int id);
    }
}
