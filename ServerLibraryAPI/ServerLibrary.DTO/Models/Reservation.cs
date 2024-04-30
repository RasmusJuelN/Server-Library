using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.DTO.Models
{
    public class Reservation

    {
        Guid Id { get; set; }
        Guid ServerId { get; set; }
        Guid UserId { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        string? Status { get; set; }
    }
}
