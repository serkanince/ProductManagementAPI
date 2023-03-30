using AutoMapper;
using MediatR;
using Product.Application.Contract;
using Product.Application.Features.ViewModel;

namespace Product.Application.Features.Query
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IReadOnlyList<CategoryVM>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IReadOnlyList<CategoryVM>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var _list = await _categoryRepository.GetAllAsync();

            var categories = _mapper.Map<IReadOnlyList<CategoryVM>>(_list);

            return categories;
        }
    }
}
