using MediatR;
using Product.Application.Features.ViewModel;

namespace Product.Application.Features.Query
{
    public class GetProductByCategoryQuery : IRequest<IReadOnlyList<ProductVM>>
    {
        public string CategoryName { get; set; }

        public GetProductByCategoryQuery(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
