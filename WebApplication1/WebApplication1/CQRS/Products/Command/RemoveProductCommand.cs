using MediatR;

namespace WebApplication1.CQRS.Products.Command
{
    public class RemoveProductByCategoryCommand : IRequest
    {
        public int CategoryId { get; set; }
    }

    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductByCategoryCommand>
    {
        public Task Handle(RemoveProductByCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
