using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.DTO.Models
{
    public class Reservation : BaseModel

    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Status { get; set; }

        public Guid ServerId { get; set; }
        public Server? Server { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
