using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Dtos.User
{
    public record SignUpDto
    {
        [MaxLength(10,ErrorMessage ="NationalCode must be 10 digits!")]
        public string Username { get; set; }
        [EmailAddress( ErrorMessage = "Email format is wrong!")]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}
