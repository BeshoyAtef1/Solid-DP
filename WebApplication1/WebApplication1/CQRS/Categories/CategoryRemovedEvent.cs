using MediatR;

namespace WebApplication1.CQRS.Categories
{
    public class CategoryRemovedEvent : INotification
    {
        public int ID { get; set; }
    }
}
