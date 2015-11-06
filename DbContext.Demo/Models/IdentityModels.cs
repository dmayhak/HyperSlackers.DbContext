using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using HyperSlackers.AspNet.Identity.EntityFramework;
using HyperSlackers.DbContext.Demo.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HyperSlackers.DbContext.Demo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    // DRM Changed
    //x public class ApplicationUser : IdentityUser
    public class ApplicationUser : HyperUserGuid
    {
        // DRM Added
        public string FavoriteColor { get; set; } // just something to see in DB generation

        //x public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    // DRM Changed
    //x public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    public class ApplicationDbContext : HyperDbContextGuid<ApplicationUser>
    {
        // DRM Added
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        // DRM Added
        private static bool initialized = SetInitializer();

        public ApplicationDbContext()
            // DRM Changed
            //TODO: Do we need the second param?
            //x : base("DefaultConnection", throwIfV1Schema: false)
            : base("DefaultConnection")
        {
            // DRM Added
            this.MultiHostEnabled = true;
            this.RoleGroupsEnabled = true;

            //! Host and SystemHost Ids do not initialize on first run since they don't exist yet
            //! make sure the Seed() method handles it ASAP -- or use some other method if you prefer
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // DRM Added
        private static bool SetInitializer()
        {
            // causes the Configuration.Seed() method to get called on application startup (at first database call)
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());

            return true;
        }

        // DRM Added
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //! FYI   cascade deletes are turned off in the base class
            ////modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            ////modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}