using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Domain.Entities
{
    public class AdminUser : BaseEntity
    {
        public AdminUser() { }
        public string Email { get; set; } = string.Empty;
    }
}
