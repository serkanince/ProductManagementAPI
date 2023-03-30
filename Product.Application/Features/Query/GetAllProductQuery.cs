using MediatR;
using Product.Application.Features.ViewModel;

namespace Product.Application.Features.Query
{
    public class GetAllProductQuery : IRequest<IReadOnlyList<ProductVM>>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public GetAllProductQuery(string title = "", string description = "")
        {
            Title = title;
        }

    }
}
