using Entities.Abstracts;

namespace Entities
{
    public class AdminRoleMap : EntityBase
    {
        public long AdminId { get; set; }
        
        public Admin Admin { get; set; }
        
        public long RoleId { get; set; }
        
        public Role Role { get; set; }
    }
}