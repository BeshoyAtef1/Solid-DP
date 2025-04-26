using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1.ViewModels.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dst => dst.Notes, opts => opts.MapFrom(src => src.Description))
                .ForMember(dst => dst.ID, opts => opts.Ignore());

            CreateMap<CategoryEditViewModel, Category>().ReverseMap();

        }
    }
}
