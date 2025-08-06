using Microsoft.EntityFrameworkCore;

namespace TestingServer2.DB
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        protected ProductContext()
        {
        }
    }

    public class User
    {
    
    }

}
