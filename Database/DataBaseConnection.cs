using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityItI.Models;

namespace IdentityItI.Database
{
    public class DataBaseConnection:IdentityDbContext<ApplicationUser>
    {
        public DataBaseConnection(DbContextOptions<DataBaseConnection> option ):base(option) {
        
       
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Lesson> Lessons { get; set; }
           
       public DbSet<CourseRegistration> Registrations { get; set; }
        
        public DbSet<Sheet> Sheets { get; set; }


       

        public DbSet<Feed> Feed { get; set; }

       

       



    }
}
