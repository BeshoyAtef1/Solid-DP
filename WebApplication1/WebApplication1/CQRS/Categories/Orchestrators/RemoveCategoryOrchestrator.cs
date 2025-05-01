using MediatR;
using WebApplication1.CQRS.Products.Command;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;

namespace WebApplication1.CQRS.Categorys.Command
{
    public class RemoveCategoryOrchestrator : IRequest
    {
        public int Id { get; set; }
    }

    public class RemoveCategoryOrchestratorHandler : IRequestHandler<RemoveCategoryOrchestrator>
    {
        IMediator _mediator;

        public RemoveCategoryOrchestratorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(RemoveCategoryOrchestrator request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new RemoveCategoryCommand { Id = request.Id });
            await _mediator.Send(new RemoveProductByCategoryCommand { CategoryId = request.Id });

        }
    }
}
