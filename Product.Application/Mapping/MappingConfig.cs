using AutoMapper;
using Product.Application.Features.Command;
using Product.Application.Features.ViewModel;
using Product.Domain.Entites;

namespace Product.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProductEntity, ProductVM>().ReverseMap();
            CreateMap<CategoryEntity, CategoryVM>().ReverseMap();
            CreateMap<AddCategoryCommand, CategoryEntity>().ReverseMap();
            CreateMap<AddProductCommand, ProductEntity>().ReverseMap();
        }
    }
}
