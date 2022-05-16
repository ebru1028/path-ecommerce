using System;
using System.Collections.Generic;
using AutoMapper;
using Entities;
using Entities.Enums;

namespace AdminAPI.Models.Dtos
{
    public class OrdersDto
    {
        public List<OrderData> Orders { get; set; }
        
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; }
        
        public int TotalItemCount { get; set; }
        
        public int PageCount { get; set; }
        
        public class OrderData
        {
            public long Id { get; set; }
            
            public OrderStatus Status { get; set; }
            
            public ShippingCompanyData ShippingCompany { get; set; }
            
            public List<ProductMapData> ProductMaps { get; set; }
            
            public DateTime CreateDate { get; set; }
        }

        public class ProductMapData
        {
            public ProductData Product { get; set; }
        }

        public class ProductData
        {
            public long Id { get; set; }
            
            public string Name { get; set; }
            
            public string Slug { get; set; }
            
            public ProductCategoryData Category { get; set; }
        }

        public class ProductCategoryData
        {
            public long Id { get; set; }
            
            public string Name { get; set; }
            
            public string Slug { get; set; }
        }

        public class ShippingCompanyData
        {
            public long Id { get; set; }
        
            public string Name { get; set; }
        }
    }

    public class OrdersDtoProfile : Profile
    {
        public OrdersDtoProfile()
        {
            CreateMap<Order, OrdersDto.OrderData>();
            CreateMap<OrderProductMap, OrdersDto.ProductMapData>();
            CreateMap<ProductCategory, OrdersDto.ProductCategoryData>();
            CreateMap<Product, OrdersDto.ProductData>();
            CreateMap<ShippingCompany, OrdersDto.ShippingCompanyData>();
        }
    }
}