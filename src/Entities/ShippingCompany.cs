using System.Collections.Generic;
using Entities.Abstracts;

namespace Entities
{
    public class ShippingCompany : EntityBase
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        #region Collections

        public List<ProductCategory> Categories { get; set; }
        
        public List<Order> Orders { get; set; }

        #endregion

        public ShippingCompany()
        {
            Categories = new List<ProductCategory>();
            Orders = new List<Order>();
        }
    }
}