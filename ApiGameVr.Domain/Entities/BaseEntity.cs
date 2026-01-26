using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get;private set; }
        public BaseEntity()
        {
            this.ModifiedAt = DateTime.Now;
        }
    }
}
