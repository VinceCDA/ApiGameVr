using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiGameVr.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string Email { get; set; }
        public required string Pseudo {  get; set; }
    }
}
