using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.Dtos;
using API.Models.Inputs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.EntityFramework;
using Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = "user")]
    public class OrdersController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public OrdersController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiResult> Get(int page = 1, int size = 10)
        {
            var userId = Convert.ToInt64(User.Claims.SingleOrDefault(x => x.Type == "UserId")?.Value);
            
            var orders = await _dataContext.Orders
                .Where(x=>x.UserId == userId)
                .ProjectTo<OrdersDto.OrderData>(_mapper.ConfigurationProvider).OrderByDescending(x => x.Id)
                .ToPagedListAsync(page, size);

            var dto = new OrdersDto
            {
                Orders = orders.ToList(),
                PageNumber = orders.PageNumber,
                PageSize = orders.PageSize,
                TotalItemCount = orders.TotalItemCount,
                PageCount = orders.PageCount
            };

            return new ApiResult("success", null, dto);
        }

        [HttpPost]
        public async Task<ApiResult> Create(OrderCreateModel model)
        {
            var userId = Convert.ToInt64(User.Claims.SingleOrDefault(x => x.Type == "UserId")?.Value);

            var product = await _dataContext.Products
                .Include(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == model.ProductId);

            if (product.Quantity == 0)
                return new ApiResult("stock-error", "Yetersiz stok.");

            #region Quantity Update

            product.Quantity -= 1;
            _dataContext.Products.Update(product);

            #endregion

            #region Create Order
            
            var order = new Order
            {
                UserId = userId,
                ProductMaps = new List<OrderProductMap>
                {
                    new OrderProductMap
                    {
                        ProductId = product.Id
                    }
                },
                Status = OrderStatus.Waiting,
                ShippingCompanyId = product.Category.ShippingCompanyId
            };

            await _dataContext.Orders.AddAsync(order);
            
            #endregion
            
            await _dataContext.SaveChangesAsync();

            var dto = new OrdersCreateDto
            {
                Order = _mapper.Map<OrdersCreateDto.OrderData>(order)
            };

            return new ApiResult("success", null, dto);
        }
        
        [HttpPost("cancellation")]
        public async Task<ApiResult> Cancellation(OrderCancellationModel model)
        {
            var userId = Convert.ToInt64(User.Claims.SingleOrDefault(x => x.Type == "UserId")?.Value);

            var order = await _dataContext.Orders
                .Include(x=>x.ProductMaps)
                .ThenInclude(x=>x.Product)
                .ThenInclude(x=>x.Category)
                .SingleOrDefaultAsync(x => x.Id == model.OrderId);

            if (order.UserId != userId)
                return new ApiResult("authorize-error", "Yetkisiz işlem.");

            if (order.Status != OrderStatus.Waiting && order.Status != OrderStatus.BeingPrepared)
                return new ApiResult("status-error", "İptal edilmek istenilen sipariş bekleme veya hazırlama durumunda olmalıdır.");

            if (order.ProductMaps.FirstOrDefault()?.Product.Category.IsCancellationRequiresConfirmation == true)
                order.Status = OrderStatus.PendingCancellationConfirmation;
            else
                order.Status = OrderStatus.Cancelled;
            
            await _dataContext.SaveChangesAsync();

            var dto = new OrdersCreateDto
            {
                Order = _mapper.Map<OrdersCreateDto.OrderData>(order)
            };

            return new ApiResult("success", null, dto);
        }
    }
}