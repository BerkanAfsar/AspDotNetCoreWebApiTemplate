using AspDotNetCoreWebApi.API.DTO;
using AspDotNetCoreWebApi.Core.Entity;
using AutoMapper;

namespace AspDotNetCoreWebApi.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<CategoryWithProductsDto, Category>();

            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
        }
    }
}
