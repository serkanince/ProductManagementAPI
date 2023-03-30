﻿using AutoMapper;
using MediatR;
using Product.Application.Contract;
using Product.Application.Features.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Query
{
    public class GetProductByStockQueryHandler : IRequestHandler<GetProductByStockQuery, IReadOnlyList<ProductVM>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByStockQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IReadOnlyList<ProductVM>> Handle(GetProductByStockQuery request, CancellationToken cancellationToken)
        {
            var _list = _productRepository.GetAll(x => x.Stock >= request.Min && x.Stock <= request.Max);
            return _mapper.Map<IReadOnlyList<ProductVM>>(_list.ToList());

        }
    }
}
