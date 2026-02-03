using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiGameVr.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime ModifiedAt { get; protected set; }
        public BaseEntity()
        {
            this.ModifiedAt = DateTime.Now;
        }
    }
}
