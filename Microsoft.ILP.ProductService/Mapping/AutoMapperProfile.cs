using AutoMapper;
using Microsoft.ILP.ProductService.DTOs;
using Microsoft.ILP.ProductService.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Microsoft.ILP.ProductService.Mapping
{
    public class AutoMapperProfile : Profile    
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
