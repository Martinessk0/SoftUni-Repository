using AutoMapper;
using ProductShop.Dtos.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputDto, User>();
            this.CreateMap<ProductInputDto, Product>();
            this.CreateMap<CategoryInputDto, Category>();
            this.CreateMap<CategoryProductDto, CategoryProduct>();
        }
    }
}
