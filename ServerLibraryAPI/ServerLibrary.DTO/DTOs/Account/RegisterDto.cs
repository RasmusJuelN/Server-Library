using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.DTO.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        public string FirstName{ get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z0-9._%+-]+@([a-zA-Z0-9._%+-]+)?tec\\.dk", ErrorMessage = "Invalid TEC Mail")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        

    }
}
