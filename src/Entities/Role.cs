using System.Collections.Generic;
using Entities.Abstracts;

namespace Entities
{
    public class Role : EntityBase
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        #region Collections
        
        public List<AdminRoleMap> AdminMaps { get; set; }

        #endregion

        public Role()
        {
            AdminMaps = new List<AdminRoleMap>();
        }
    }
}