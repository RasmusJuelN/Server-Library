//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ServerLibrary.Repo.Data
//{
//    // Created factory to configure DbContext in design-time, rather than run time.
//    // This was neccessary for scaffolding the controllers automatically with Entity Framework.
//    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ServerLibraryDbContext>
//    {
//        public ServerLibraryDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<ServerLibraryDbContext>();
//            optionsBuilder.UseSqlServer("Data Source=d-z240-pc05;Initial Catalog=ServerLibraryDb;Integrated Security=True; Encrypt=False;TrustServerCertificate=False;");

//            return new ServerLibraryDbContext(optionsBuilder.Options);
//        }
//    }
//}
