using App.Dtos;
using App.Dtos.Product;
using App.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        
        private static List<Product> productsList = new List<Product>
        {
           new Product()
           {
               ProductId = 1,
               Name = "Shampoo",
               Quantity = 5,
               Brand = Brands.Loreal,
               Unit = Units.piece
           },
           new Product()
           {
               ProductId = 2,
               Name = "Conditioner",
               Quantity = 5,
               ForSale = true,
               Brand = Brands.BabyLiss,
               Unit = Units.piece
           }
        };

        public ProductService(IMapper autoMapper)
        {
               _mapper = autoMapper;
        }
        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

            bool doesExist = productsList.Any(product => product.Name == newProduct.Name && product.ForSale ==newProduct.ForSale);

            if (doesExist)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product with this name already exists!";
            }
            else
            {
                var product = _mapper.Map<Product>(newProduct);
                productsList.Add(product);

                serviceResponse.Data = productsList
                .Select(c => _mapper.Map<GetProductDto>(c))
                .ToList();
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

            try
            {
                var index = productsList
                   .FindIndex(p => p.ProductId == id);

                if (index == -1)
                {
                    throw new Exception("Prodict witch such Id doesn't exist!");
                }

                productsList.RemoveAt(index);

                serviceResponse.Data = productsList
                .Select(p => _mapper.Map<GetProductDto>(p))
                .ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

            serviceResponse.Data = productsList
               .Select(p => _mapper.Map<GetProductDto>(p))
               .ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductByName(string name, bool forSale)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();

            var product = productsList.FirstOrDefault(product => product.Name == name && product.ForSale == forSale);

            if (product is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product with this name not found!";
            }
            else
            {
                serviceResponse.Data = _mapper.Map<GetProductDto>(product);
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(GetProductDto updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();

            try
            {
                var product = productsList.FirstOrDefault(c => c.ProductId == updatedProduct.ProductId);

                if (product is null)
                {
                    throw new Exception("Character witch such Id doesn't exist!");
                }

                _mapper.Map(updatedProduct, product);

                serviceResponse.Data = _mapper.Map<GetProductDto>(product);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}
