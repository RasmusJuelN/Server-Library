using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.DTO.Models
{
    public class User
    {
        Guid Id { get; set; }
        string? Token { get; set; }
        string? Username { get; set; }
        string? Password { get; set; }
        string? Name { get; set; }
        string? Email { get; set; }
        string? Role { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
