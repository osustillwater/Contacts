using Contacts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.DBContext
{
    public class InfoDBContext: IdentityDbContext<IdentityUser>
    {
        public InfoDBContext(DbContextOptions<InfoDBContext> options) : base(options)
        {

        }
        public DbSet<Info> Infos { get; set; }
    }
}
