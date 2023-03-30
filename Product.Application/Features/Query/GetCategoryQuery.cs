using MediatR;
using Product.Application.Features.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Query
{
    public class GetCategoryQuery : IRequest<CategoryVM>
    {
        public int Id { get; set; }

        public GetCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
