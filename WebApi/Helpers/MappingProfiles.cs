using AutoMapper;
using Core.Entities;
using WebApi.Dtos;

namespace WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.ProductType, o => o.MapFrom(p => p.ProductType.Name))
            .ForMember(d => d.ProductBrand, o => o.MapFrom(p => p.ProductBrand.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
