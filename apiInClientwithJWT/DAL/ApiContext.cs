using Microsoft.EntityFrameworkCore;
using apiInClientwithJWT.Models;

namespace apiInClientwithJWT.DAL
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options)
            : base(options)
        {}

        public virtual DbSet<Api> Api { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
