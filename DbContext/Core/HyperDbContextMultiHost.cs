using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;

using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Reflection;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure.Annotations;
using System.Net.Mail;

namespace HyperSlackers.AspNet.Identity.EntityFramework.Core
{
    /// <summary>
    /// DbContext that supports multi-homed systems--one code base that runs multiple websites.
    /// My reason for creating this was to support multiple sites with similar/same structure, but
    /// different content, etc.
    /// </summary>
    /// <typeparam name="THost">The type of the host.</typeparam>
    /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <typeparam name="TRole">The type of the role.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    /// <typeparam name="TAudit">The type of the audit.</typeparam>
    /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
    /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
    public class HyperDbContextMultiHost<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> : HyperDbContextAuditing<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>
        where THost : HyperHost<TKey, THost, THostDomain>, new()
        where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
        where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroupUser>, IHyperUser<TKey>, new()
        where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TUserLogin : HyperUserLogin<TKey>, IHyperUserLogin<TKey>, new()
        where TUserRole : HyperUserRole<TKey>, IHyperUserRole<TKey>, new()
        where TUserClaim : HyperUserClaim<TKey>, IHyperUserClaim<TKey>, new()
        where TRoleGroup : HyperRoleGroup<TKey, TRoleGroupRole, TRoleGroupUser>, new()
        where TRoleGroupRole : HyperRoleGroupRole<TKey>, new()
        where TRoleGroupUser : HyperRoleGroupUser<TKey>, new()
        where TAudit : HyperAudit<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditItem : HyperAuditItem<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditProperty : HyperAuditProperty<TKey, TAudit, TAuditItem, TAuditProperty>, new()
    {
        //! table/schema renaming
        protected internal string MultiHostSchemaName;
        protected internal string MultiHostUsersTableName;
        protected internal string MultiHostRolesTableName;
        protected internal string MultiHostUserClaimsTableName;
        protected internal string MultiHostUserLoginsTableName;
        protected internal string MultiHostUserRolesTableName;
        protected internal string MultiHostHostsTableName;
        protected internal string MultiHostHostDomainsTableName;

        //! multi-host dbsets
        public DbSet<THost> Hosts { get; set; }
        public DbSet<THostDomain> HostDomains { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingDbContext{TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TAudit, TAuditItem}" /> class.
        /// </summary>
        protected HyperDbContextMultiHost()
            : this("DefaultConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingDbContext{TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TAudit, TAuditItem}" /> class.
        /// </summary>
        /// <param name="nameOrConnectionString">The name or connection string.</param>
        protected HyperDbContextMultiHost(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Helpers.ThrowIfNull(!nameOrConnectionString.IsNullOrWhiteSpace(), "nameOrConnectionString");

            this.MultiHostEnabled = true;
        }

        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // fix up table names, indexes, and identity columns (Guid Id columns are not db-assigned)
            modelBuilder.Entity<THost>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<THostDomain>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TUser>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TRole>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            // TUserClaim (IdentityUserClaim) has int as the data type for Id
            // DRM: UserClaim has PK of int and needs the DB generated option to stay on. MS does not use TKey as the PK for this entity
            //modelBuilder.Entity<TUserClaim>()
            //    .Property(r => r.Id)
            //    .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);




            modelBuilder.Entity<TRole>()
                .ToTable((MultiHostRolesTableName.IsNullOrWhiteSpace() ? "AspNetRoles" : MultiHostRolesTableName), (MultiHostSchemaName.IsNullOrWhiteSpace() ? "dbo" : MultiHostSchemaName));
            // Indexes
            //      HostId, Name ==> IX_Host_Name
            //      IsGlobal, Name ==> IX_Global_Name  -- Can have duplicates when global == false
            modelBuilder.Entity<TRole>()
                .Property(r => r.HostId)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_Host_Name", 0) { IsUnique = true }
                    }));
            modelBuilder.Entity<TRole>()
                .Property(r => r.Name)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_Host_Name", 1) { IsUnique = true },
                        new IndexAttribute("IX_Global_Name", 1)
                    }));
            modelBuilder.Entity<TRole>()
                .Property(r => r.IsGlobal)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_Global_Name", 0)
                    }));

            modelBuilder.Entity<TUserRole>()
                .ToTable((MultiHostUserRolesTableName.IsNullOrWhiteSpace() ? "AspNetUserRoles" : MultiHostUserRolesTableName), (MultiHostSchemaName.IsNullOrWhiteSpace() ? "dbo" : MultiHostSchemaName))
                .HasKey(e => new { e.UserId, e.RoleId, e.HostId });
            // Indexes
            //      UserId, RoleId, HostId, IsGlobal ==> IX_User_Role_Host_Global
            //      RoleId, UserId, HostId, IsGlobal ==> IX_Role_User_Host_Global
            modelBuilder.Entity<TUserRole>()
                .Property(r => r.UserId)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_User_Role_Host_Global", 0) { IsUnique = true },
                        new IndexAttribute("IX_Role_User_Host_Global", 1) { IsUnique = true }
                    }));
            modelBuilder.Entity<TUserRole>()
                .Property(r => r.RoleId)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_User_Role_Host_Global", 1) { IsUnique = true },
                        new IndexAttribute("IX_Role_User_Host_Global", 0) { IsUnique = true }
                    }));
            modelBuilder.Entity<TUserRole>()
                .Property(r => r.HostId)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_User_Role_Host_Global", 2) { IsUnique = true },
                        new IndexAttribute("IX_Role_User_Host_Global", 2) { IsUnique = true }
                    }));
            modelBuilder.Entity<TUserRole>()
                .Property(r => r.IsGlobal)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_User_Role_Host_Global", 3) { IsUnique = true },
                        new IndexAttribute("IX_Role_User_Host_Global", 3) { IsUnique = true }
                    }));

            modelBuilder.Entity<TUser>()
                .ToTable((MultiHostUsersTableName.IsNullOrWhiteSpace() ? "AspNetUsers" : MultiHostUsersTableName), (MultiHostSchemaName.IsNullOrWhiteSpace() ? "dbo" : MultiHostSchemaName));
            // Indexes
            //      HostId, UserName ==> IX_Host_Name
            //      UserName, HostId, IsGlobal ==> IX_Name_Host_Global
            //      Email, HostId, IsGlobal ==> IX_Email_Host_Global
            //      IsGlobal, UserName ==> IX_Global_Name  -- Can have duplicates when global == false
            modelBuilder.Entity<TUser>()
                .Property(u => u.IsGlobal)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_Global_Name", 0),
                        new IndexAttribute("IX_Name_Host_Global", 2) { IsUnique = true },
                        new IndexAttribute("IX_Email_Host_Global", 2) { IsUnique = true }
                    }));
            modelBuilder.Entity<TUser>()
                .Property(u => u.UserName)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_User_Name", 1) { IsUnique = true },
                        new IndexAttribute("IX_Global_Name", 1),
                        new IndexAttribute("IX_Name_Host_Global", 0) { IsUnique = true }
                    }));
            modelBuilder.Entity<TUser>()
                .Property(u => u.HostId)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_User_Name", 0) { IsUnique = true },
                        new IndexAttribute("IX_Name_Host_Global", 1) { IsUnique = true },
                        new IndexAttribute("IX_Email_Host_Global", 1) { IsUnique = true }
                    }));
            modelBuilder.Entity<TUser>()
                .Property(u => u.Email)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_Email_Host_Global", 0) { IsUnique = true }
                    }));

            modelBuilder.Entity<TUserClaim>()
                .ToTable((MultiHostUserClaimsTableName.IsNullOrWhiteSpace() ? "AspNetUserClaims" : MultiHostUserClaimsTableName), (MultiHostSchemaName.IsNullOrWhiteSpace() ? "dbo" : MultiHostSchemaName));

            modelBuilder.Entity<TUserLogin>()
                .ToTable((MultiHostUserLoginsTableName.IsNullOrWhiteSpace() ? "AspNetUserLogins" : MultiHostUserLoginsTableName), (MultiHostSchemaName.IsNullOrWhiteSpace() ? "dbo" : MultiHostSchemaName))
                .HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });
            // Index
            //      LoginProvider, ProviderKey, HostId, IsGlobal ==> IX_Provider_Key_Host_Global
            modelBuilder.Entity<TUserLogin>()
                .Property(u => u.LoginProvider)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_Provider_Key_Host_Global", 0) { IsUnique = true }
                    }));
            modelBuilder.Entity<TUserLogin>()
                .Property(u => u.ProviderKey)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_Provider_Key_Host_Global", 1) { IsUnique = true }
                    }));
            modelBuilder.Entity<TUserLogin>()
                .Property(u => u.HostId)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_Provider_Key_Host_Global", 2) { IsUnique = true }
                    }));
            modelBuilder.Entity<TUserLogin>()
                .Property(u => u.IsGlobal)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[]
                    {
                        new IndexAttribute("IX_Provider_Key_Host_Global", 3) { IsUnique = true }
                    }));

            // hosts tables
            modelBuilder.Entity<THost>()
                .ToTable((MultiHostHostsTableName.IsNullOrWhiteSpace() ? "AspNetHosts" : MultiHostHostsTableName), (MultiHostSchemaName.IsNullOrWhiteSpace() ? "dbo" : MultiHostSchemaName));

            modelBuilder.Entity<THostDomain>()
                 .ToTable((MultiHostHostDomainsTableName.IsNullOrWhiteSpace() ? "AspNetHostDomains" : MultiHostHostDomainsTableName), (MultiHostSchemaName.IsNullOrWhiteSpace() ? "dbo" : MultiHostSchemaName));

        }

        /// <summary>
        /// Validates that UserNames are unique per host and case insensitive.
        /// </summary>
        /// <param name="entityEntry">The entity entry.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry != null && entityEntry.State == EntityState.Added)
            {
                var errors = new List<DbValidationError>();

                if (entityEntry.Entity is TUser)
                {
                    var user = entityEntry.Entity as TUser;

                    errors.AddRange(ValidateUser(user));

                    return new DbEntityValidationResult(entityEntry, errors);
                }
                else if (entityEntry.Entity is TRole)
                {
                    var role = entityEntry.Entity as TRole;

                    errors.AddRange(ValidateRole(role));

                    return new DbEntityValidationResult(entityEntry, errors);
                }
            }

            return base.ValidateEntity(entityEntry, items);
        }

        private List<DbValidationError> ValidateUser(TUser user)
        {
            Helpers.ThrowIfNull(user != null, "user");

            var errors = new List<DbValidationError>();

            // UserName is required
            if (user.UserName.IsNullOrWhiteSpace())
            {
                errors.Add(new DbValidationError("UserName", "UserName required."));
            }

            // email is required
            if (user.Email.IsNullOrWhiteSpace())
            {
                errors.Add(new DbValidationError("Email", "Email address is required."));
            }

            // email must be valid
            try
            {
                var m = new MailAddress(user.Email);
            }
            catch (FormatException)
            {
                errors.Add(new DbValidationError("Email", "Email address is invalid."));
            }

            // check ig global user tied to system host
            if (user.IsGlobal)
            {
                if (!user.HostId.Equals(this.SystemHostId))
                {
                    errors.Add(new DbValidationError("UserName", "Global users must belong to system host."));
                }
            }

            // check user name for uniqueness
            if (user.IsGlobal)
            {
                // global user cannot exist in any hosts
                var userId = user.Id;
                var userName = user.UserName;
                List<TUser> existingUsers = this.Users.Where(u => u.UserName == userName).ToList();

                if (existingUsers.Any(u => !u.Id.Equals(userId)))
                {
                    errors.Add(new DbValidationError("UserNAme", String.Format("UserName '{0}' already exists in system.", user.UserName)));
                }
            }
            else
            {
                // user cannot exist in host
                var userId = user.Id;
                var userName = user.UserName;
                var hostId = user.HostId;
                List<TUser> existingHostUsers = this.Users.Where(u => u.UserName == userName && u.HostId.Equals(hostId)).ToList();

                if (existingHostUsers.Any(u => !u.Id.Equals(userId)))
                {
                    errors.Add(new DbValidationError("UserName", String.Format("User '{0}' already exists for host.", user.UserName)));
                }

                // user cannot exist as global
                List<TUser> existingGlobalUsers = this.Users.Where(u => u.UserName == userName && u.IsGlobal == true).ToList();

                if (existingGlobalUsers.Any(u => !u.Id.Equals(userId)))
                {
                    errors.Add(new DbValidationError("UserName", String.Format("User '{0}' already exists as global user.", user.UserName)));
                }
            }

            return errors;
        }

        private List<DbValidationError> ValidateRole(TRole role)
        {
            Helpers.ThrowIfNull(role != null, "role");

            var errors = new List<DbValidationError>();

            // role name is required
            if (string.IsNullOrWhiteSpace(role.Name))
            {
                errors.Add(new DbValidationError("Name", String.Format("Role name is required.")));
            }

            // check if global role tied to system host
            if (role.IsGlobal)
            {
                if (!role.HostId.Equals(this.SystemHostId))
                {
                    errors.Add(new DbValidationError("Name", "Global roles must belong to system host."));
                }
            }

            if (role.IsGlobal)
            {
                // check if the role already exists
                // either as a system role or on any host
                var roleId = role.Id;
                var roleName = role.Name;
                List<TRole> existingRoles = this.Roles.Where(r => r.Name == roleName).ToList();

                if (existingRoles.Any(r => !r.Id.Equals(roleId)))
                {
                    errors.Add(new DbValidationError("Name", String.Format("Role '{0}' already exists.", role.Name)));
                }
            }
            else
            {
                // role cannot exist in host
                var roleId = role.Id;
                var roleName = role.Name;
                var hostId = role.HostId;
                List<TRole> existingHostRoles = this.Roles.Where(r => r.Name == roleName && r.HostId.Equals(hostId)).ToList();

                if (existingHostRoles.Any(r => !r.Id.Equals(roleId)))
                {
                    errors.Add(new DbValidationError("Name", String.Format("Role '{0}' already exists for host.", roleName)));
                }

                // role cannot exist as global
                List<TRole> existingGlobalRoles = this.Roles.Where(r => r.Name == roleName && r.IsGlobal == true).ToList();

                if (existingGlobalRoles.Any(r => !r.Id.Equals(roleId)))
                {
                    errors.Add(new DbValidationError("Name", String.Format("Role '{0}' already exists as global role.", roleName)));
                }
            }

            return errors;
        }
    }
}
