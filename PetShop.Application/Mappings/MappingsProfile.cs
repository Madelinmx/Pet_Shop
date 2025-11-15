using AutoMapper;
using PetShop.Application.Dtos.Product;
using PetShop.Domain.Entities;

namespace PetShop.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name));

            
            CreateMap<ProductCreateDto, Product>();
        }
    }
}