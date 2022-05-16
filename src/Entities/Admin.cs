using System.Collections.Generic;
using Entities.Abstracts;

namespace Entities
{
    public class Admin : Account
    {
        #region Collections
        
        public List<AdminRoleMap> RoleMaps { get; set; } 

        #endregion

        public Admin()
        {
            RoleMaps = new List<AdminRoleMap>();
        }
    }
}