using ApiGameVr.Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiGameVr.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        public string Pseudo {  get; private set; }

        public User(string email, string pseudo) : base()
        {
            if (!EmailValidation.IsValidEmailWithIdn(email))
            {
                throw new ArgumentException("invalid email");
            }
            Email = email;
            Pseudo = pseudo;
        }
    }
}
