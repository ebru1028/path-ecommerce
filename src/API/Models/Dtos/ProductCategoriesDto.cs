using System.Collections.Generic;
using AutoMapper;
using Entities;

namespace API.Models.Dtos
{
    public class ProductCategoriesDto
    {
        public List<CategoryData> Categories { get; set; }
        
        public class CategoryData
        {
            public long Id { get; set; }
            
            public string Name { get; set; }
            
            public string Slug { get; set; }
        }
    }

    public class CategoriesDtoProfile : Profile
    {
        public CategoriesDtoProfile()
        {
            CreateMap<ProductCategory, ProductCategoriesDto.CategoryData>();
        }
    }
}