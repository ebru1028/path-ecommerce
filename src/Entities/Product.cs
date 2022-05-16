using System.Collections.Generic;
using Entities.Abstracts;

namespace Entities
{
    public class Product : EntityBase
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string Slug { get; set; }
        
        public string Description { get; set; }
        
        public int Quantity { get; set; }

        #region Single
        
        public long CategoryId { get; set; }

        public ProductCategory Category { get; set; }

        #endregion

        #region Collections

        public List<Order> Orders { get; set; }
        
        public List<OrderProductMap> OrderMaps { get; set; }

        #endregion

        public Product()
        {
            Orders = new List<Order>();
            OrderMaps = new List<OrderProductMap>();
        }
    }
}