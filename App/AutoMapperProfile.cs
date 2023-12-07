using App.Dtos;
using App.Dtos.Product;
using App.Models;
using AutoMapper;

namespace App
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
        }
    }
}
