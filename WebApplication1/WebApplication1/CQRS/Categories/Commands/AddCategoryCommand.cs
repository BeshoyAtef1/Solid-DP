using MediatR;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;

namespace WebApplication1.CQRS.Categories.Commands
{
    public class AddCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand>
    {
        IGeneralRepository<Category> _repository;

        public AddCategoryCommandHandler(IGeneralRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(new Category { Name = request.Name });

            await _repository.SaveChangesAsync();
        }
    }
}
