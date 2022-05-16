using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductCategoriesController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ProductCategoriesController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiResult> Get()
        {
            var categories = await _dataContext.ProductCategories.ProjectTo<ProductCategoriesDto.CategoryData>(_mapper.ConfigurationProvider).OrderBy(x => x.Name)
                .ToListAsync();

            var dto = new ProductCategoriesDto
            {
                Categories = categories,
            };

            return new ApiResult("success", null, dto);
        }
    }
}