using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels.Categories;

namespace WebApplication1.CQRS.Categories.Queries
{
    public class GetCategoryByNameQuery : IRequest<CategoryViewModel>
    {
        public string Name { get; set; }
    }

    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, CategoryViewModel>
    {
        IGeneralRepository<Category> _repository;

        public GetCategoryByNameQueryHandler(IGeneralRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<CategoryViewModel> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(x => x.Name.Contains(request.Name))
                .ProjectTo<CategoryViewModel>()
                .FirstOrDefaultAsync();
        }
    }
}
