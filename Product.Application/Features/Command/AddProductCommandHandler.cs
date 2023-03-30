using AutoMapper;
using MediatR;
using Product.Application.Contract;
using Product.Domain.Entites;

namespace Product.Application.Features.Command
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var _entity = new ProductEntity();

            _mapper.Map(request, _entity, typeof(AddCategoryCommand), typeof(ProductEntity));

            await _productRepository.AddAsync(_entity);

            return Unit.Value;
        }
    }
}
