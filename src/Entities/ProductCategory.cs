using System.Collections.Generic;
using Entities.Abstracts;

namespace Entities
{
    public class ProductCategory : EntityBase
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string Slug { get; set; }
        
        public bool IsCancellationRequiresConfirmation { get; set; }

        #region Single

        public long ShippingCompanyId { get; set; }
        
        public ShippingCompany ShippingCompany { get; set; }

        #endregion

        #region Collections

        public List<Product> Products { get; set; }

        #endregion

        public ProductCategory()
        {
            Products = new List<Product>();
            IsCancellationRequiresConfirmation = false;
        }
    }
}