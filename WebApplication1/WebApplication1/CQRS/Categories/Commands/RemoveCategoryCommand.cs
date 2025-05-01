using MediatR;
using WebApplication1.CQRS.Categories;
using WebApplication1.CQRS.Products.Command;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;

namespace WebApplication1.CQRS.Categorys.Command
{
    public class RemoveCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        IGeneralRepository<Category> _repository;
        IMediator _mediator;

        public RemoveCategoryCommandHandler(IGeneralRepository<Category> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            _repository.Remove(request.Id);

            await _mediator.Publish(new CategoryRemovedEvent { ID = request.Id });

        }
    }
}
