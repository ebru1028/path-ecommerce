using System.Collections.Generic;
using AutoMapper;
using Entities;

namespace API.Models.Dtos
{
    public class ProductsDto
    {
        public List<ProductData> Products { get; set; }
        
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; }
        
        public int TotalItemCount { get; set; }
        
        public int PageCount { get; set; }
        
        public class ProductData
        {
            public long Id { get; set; }
        
            public string Name { get; set; }
        
            public string Slug { get; set; }
        
            public string Description { get; set; }
        
            public int Quantity { get; set; }
        }
    }

    public class ProductsDtoProfile : Profile
    {
        public ProductsDtoProfile()
        {
            CreateMap<Product, ProductsDto.ProductData>();
        }
    }
}