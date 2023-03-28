using MediatR;
using Product.Application.Features.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Query
{
    public class GetProductQuery : IRequest<ProductVM>
    {
        public long Id { get; set; }

        public GetProductQuery(long id)
        {
            Id = id;
        }
    }
}
