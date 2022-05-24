
using AssetManagementSystem_WebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem_WebApi.Models
{
    public class AssetDb : IdentityDbContext<ApplicationUser>
    {
        public AssetDb(DbContextOptions<AssetDb> options) : base(options)
        {
       

        }

        public AssetDb()
        {
        }

       protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<RequestAsset> RequestAsset { get; set; }

        public DbSet<Register> Register { get; set; }
        public DbSet<Login> Login { get; set; }

    }
}

 
