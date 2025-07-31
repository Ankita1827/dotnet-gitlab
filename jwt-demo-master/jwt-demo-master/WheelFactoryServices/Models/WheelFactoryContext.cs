using Microsoft.EntityFrameworkCore;

namespace WheelFactoryServices.Models
{
    public class WheelFactoryContext:DbContext
    {
        public DbSet<Order> orders;
        public WheelFactoryContext(DbContextOptions<WheelFactoryContext> options):base(options)
        {
            
        }
    }

       
}
