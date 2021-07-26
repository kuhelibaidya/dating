using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Extensions;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string PhotoUrl{ get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Age{ get; set; }
        public string KnownAs { get; set; }
        

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
         public string Introduction { get; set; }
         public string LookingFor { get; set; }
         public string Interests { get; set; }
         public string City { get; set; }
         public string Country { get; set; }
         public ICollection<PhotoDto> Photos { get; set; }
        // public int GetAge(){return DateOfBirth.CalculateAge();}
    
    }
}