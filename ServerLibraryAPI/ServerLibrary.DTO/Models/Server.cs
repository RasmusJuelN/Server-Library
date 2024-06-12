using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.DTO.Models
{
    public class Server : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
