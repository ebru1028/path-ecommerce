using Entities.Abstracts;

namespace Entities
{
    public class OrderProductMap : EntityBase
    {
        public long OrderId { get; set; }
        
        public  Order Order { get; set; }
        
        public long ProductId { get; set; }
        
        public Product Product { get; set; }
    }
}