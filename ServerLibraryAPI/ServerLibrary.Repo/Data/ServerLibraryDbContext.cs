using Microsoft.EntityFrameworkCore;
using ServerLibrary.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repo.Data
{
    public class ServerLibraryDbContext : DbContext
    {
        public ServerLibraryDbContext(DbContextOptions<ServerLibraryDbContext> option) : base(option) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


    }
}
