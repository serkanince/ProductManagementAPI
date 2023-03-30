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
            var _list = _productRepository.GetAll().AsEnumerable();
            var dtoProperties = request.GetType().GetProperties();

            foreach (var property in dtoProperties)
            {
                var value = property.GetValue(request, null);

                if (value != null && !string.IsNullOrEmpty(value.ToString().Trim()))
                {
                    var entityProperty = typeof(ProductEntity).GetProperty(property.Name);
                    _list = _list.Where(e => entityProperty.GetValue(e).ToString().Contains(value.ToString()));
                }
            }

            return _mapper.Map<IReadOnlyList<ProductVM>>(_list.ToList());
        }
    }
}
