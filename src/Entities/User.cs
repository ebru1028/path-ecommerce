using System.Collections.Generic;
using Entities.Abstracts;

namespace Entities
{
    public class User : Account
    {
        #region Collections
        
        public List<Order> Orders { get; set; }

        #endregion

        public User()
        {
            Orders = new List<Order>();
        }
    }
}