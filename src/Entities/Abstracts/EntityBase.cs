using System;

namespace Entities.Abstracts
{
    public class EntityBase
    {
        public DateTime CreateDate { get; set; }

        public EntityBase()
        {
            CreateDate = DateTime.UtcNow;
        }
    }
}