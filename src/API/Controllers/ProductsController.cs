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
    public class ProductsController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ProductsController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiResult> Get(long? categoryId, int page = 1, int size = 10)
        {
            var query = _dataContext.Products.AsQueryable();

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId);
            
            var products = await query.ProjectTo<ProductsDto.ProductData>(_mapper.ConfigurationProvider).OrderByDescending(x => x.Id)
                .ToPagedListAsync(page, size);

            var dto = new ProductsDto
            {
                Products = products.ToList(),
                PageNumber = products.PageNumber,
                PageSize = products.PageSize,
                TotalItemCount = products.TotalItemCount,
                PageCount = products.PageCount
            };

            return new ApiResult("success", null, dto);
        }
    }
}