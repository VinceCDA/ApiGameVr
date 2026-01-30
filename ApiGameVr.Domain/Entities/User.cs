using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiGameVr.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Pseudo {  get; set; }
    }
}
