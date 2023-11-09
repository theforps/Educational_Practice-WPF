using educational_practice.models;
using System.Data.Entity;

namespace educational_practice.data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") 
        {

        }

        public DbSet<Device> devices { get; set; }
        public DbSet<Defect> defects { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<User> users { get; set; }

    }
}
