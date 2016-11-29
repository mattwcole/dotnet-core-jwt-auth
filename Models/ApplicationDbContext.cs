using Microsoft.EntityFrameworkCore;
using OpenIddict;

namespace AuthDemo.Models
{
    public class ApplicationDbContext : OpenIddictDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
