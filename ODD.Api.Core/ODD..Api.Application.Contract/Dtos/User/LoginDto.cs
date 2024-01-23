using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Dtos.User
{
    public record LoginDto
    {
        [Required(ErrorMessage ="{0} is requierd!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "{0} is requierd!")]
        public string Password { get; set; }
    }
}
