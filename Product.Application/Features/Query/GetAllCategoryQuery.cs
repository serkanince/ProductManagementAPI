﻿using MediatR;
using Product.Application.Features.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Query
{
    public class GetAllCategoryQuery : IRequest<IReadOnlyList<CategoryVM>>
    {
    }
}
