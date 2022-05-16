using System.Collections.Generic;
using Entities.Abstracts;
using Entities.Enums;

namespace Entities
{
    public class Order : EntityBase
    {
        public long Id { get; set; }
        
        public OrderStatus Status { get; set; }
        
        #region Single
        
        public long UserId { get; set; }
        
        public User User { get; set; }
        
        public long ShippingCompanyId { get; set; }
        
        public ShippingCompany ShippingCompany { get; set; }

        #endregion
        
        #region Collections
        
        public List<OrderProductMap> ProductMaps { get; set; }

        #endregion

        public Order()
        {
            ProductMaps = new List<OrderProductMap>();
        }
    }
}