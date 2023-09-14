using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.DataAccessLayer
{
    public class MyAppDBContext:DbContext
    {
        /// <summary>
        /// DBConcext <c>MyAppDBContext</c> For mapping DB to User Model
        /// </summary>
        public MyAppDBContext(DbContextOptions  options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
