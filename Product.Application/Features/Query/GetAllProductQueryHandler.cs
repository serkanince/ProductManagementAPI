using AutoMapper;
using MediatR;
using Product.Application.Contract;
using Product.Application.Features.ViewModel;
using Product.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Query
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IReadOnlyList<ProductVM>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IReadOnlyList<ProductVM>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var _list = await _productRepository.GetAllAsync();

            var personViews = _mapper.Map<IReadOnlyList<ProductVM>>(_list);

            return personViews;
        }
    }
}
