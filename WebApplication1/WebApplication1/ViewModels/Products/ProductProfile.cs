using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1.ViewModels.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dst => dst.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
                //.ForMember(dst => dst.BrandName, opts => opts.MapFrom(src => src.Brand.Name));
        }
    }
}
