using Entities.Abstracts;

namespace Entities
{
    public class Account : EntityBase
    {
        public long Id { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}