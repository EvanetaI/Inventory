using App.Dtos;
using App.Dtos.Product;
using App.Models;

namespace App.Services.ProductService
{
    public class ProductService : IProductService
    {
        public Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newCharacter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetProductDto>>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetProductDto>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetProductDto>> UpdateProduct(GetProductDto updatedCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
