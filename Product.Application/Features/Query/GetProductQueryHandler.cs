using AutoMapper;
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
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVM>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<ProductVM> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            return _mapper.Map<ProductVM>(product);
        }
    }
}
