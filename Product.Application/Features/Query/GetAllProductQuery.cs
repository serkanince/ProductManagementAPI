using MediatR;
using Product.Application.Features.ViewModel;

namespace Product.Application.Features.Query
{
    public class GetAllProductQuery : IRequest<IReadOnlyList<ProductVM>>
    {

    }
}
