using MediatR;
using WebApplication1.CQRS.Categories;

namespace WebApplication1.CQRS.Logs
{
    public class CategoryRemovedEventHandler : INotificationHandler<CategoryRemovedEvent>
    {
        public Task Handle(CategoryRemovedEvent notification, CancellationToken cancellationToken)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }

            return Task.CompletedTask;

        }
    }
}
