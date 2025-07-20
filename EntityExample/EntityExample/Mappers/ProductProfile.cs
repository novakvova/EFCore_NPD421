using AutoMapper;
using EntityExample.Data.Entities;
using EntityExample.Models;

namespace EntityExample.Mappers;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductItemModel>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}
