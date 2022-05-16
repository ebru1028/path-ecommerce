using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Models;
using AdminAPI.Models.Dtos;
using AdminAPI.Models.Inputs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.EntityFramework;
using Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AdminAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = "admin")]
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
            var orders = await _dataContext.Orders.ProjectTo<OrdersDto.OrderData>(_mapper.ConfigurationProvider).OrderByDescending(x => x.Id)
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
        
        [HttpGet("waitingForCancellations")]
        public async Task<ApiResult> WaitingForCancellations(int page = 1, int size = 10)
        {
            var orders = await _dataContext.Orders
                .Where(x=>x.Status == OrderStatus.PendingCancellationConfirmation)
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

        [HttpPost("changeStatus")]
        public async Task<ApiResult> ChangeStatus(OrderChangeStatusModel model)
        {
            var order = await _dataContext.Orders.SingleOrDefaultAsync(x => x.Id == model.OrderId);

            order.Status = model.Status;

            _dataContext.Orders.Update(order);
            await _dataContext.SaveChangesAsync();
            return new ApiResult("success");
        }
    }
}