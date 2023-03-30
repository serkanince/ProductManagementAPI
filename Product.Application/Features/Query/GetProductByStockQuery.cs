using MediatR;
using Product.Application.Features.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Query
{
    public class GetProductByStockQuery : IRequest<IReadOnlyList<ProductVM>>
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public GetProductByStockQuery(int min = 0, int max = 0)
        {
            Max = max;
            Min = min;
        }
    }
}
