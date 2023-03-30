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

    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryVM>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CategoryVM> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var product = await _categoryRepository.GetByIdAsync(request.Id);

            return _mapper.Map<CategoryVM>(product);
        }
    }
}
