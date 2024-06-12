using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.DTO.DTOs.Account
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JWT { get; set; }
    }
}
