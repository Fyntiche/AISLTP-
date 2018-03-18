using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using AISLTP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AISLTP.Models
{


    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base( "DefaultConnection" )
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Sotr> Sotrs { get; set; }
    }
}