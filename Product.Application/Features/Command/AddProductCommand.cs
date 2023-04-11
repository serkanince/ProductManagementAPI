using MediatR;

namespace Product.Application.Features.Command
{
    public class AddProductCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
