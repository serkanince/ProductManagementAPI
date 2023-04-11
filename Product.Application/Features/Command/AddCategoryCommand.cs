using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Command
{
    public class AddCategoryCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public int MinimumStock { get; set; }
    }
}
