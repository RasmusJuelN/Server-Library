using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.DTO.Models
{
    public class Server
    {
        Guid Id { get; set; }
        string? Name { get; set; }
        string? Description { get; set; }
        bool IsAvailable { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
