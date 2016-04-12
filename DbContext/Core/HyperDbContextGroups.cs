using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Reflection;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure.Annotations;

namespace HyperSlackers.AspNet.Identity.EntityFramework.Core
{
    /// <summary>
    /// DBContext that supports grouping of roles. You can thereby assign a user to a group; which will assign all the
    /// roles in that group to the user. Code in the controllers will still reference the roles. This makes maintaining
    /// user permissions easier (at a courser level)
    /// </summary>
    /// <typeparam name="THost">The type of the host.</typeparam>
    /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <typeparam name="TRole">The type of the role.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    /// <typeparam name="TRoleGroup">The type of the group.</typeparam>
    /// <typeparam name="TRoleGroupRole">The type of the group role.</typeparam>
    /// <typeparam name="TRoleGroupUser">The type of the group user.</typeparam>
    /// <typeparam name="TAudit">The type of the audit.</typeparam>
    /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
    /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
    public class HyperDbContextRoleGroups<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> : HyperDbContextMultiHost<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>
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
        protected internal string RoleGroupsSchemaName;
        protected internal string RoleGroupsGroupsTableName;
        protected internal string RoleGroupsGroupRolesTableName;
        protected internal string RoleGroupsGroupUsersTableName;

        /// <summary>
        /// Gets or sets a value indicating whether role-groups functionality is enabled or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if role-groups is enabled; otherwise, <c>false</c>.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool RoleGroupsEnabled { get; set; }

        //! role-groups dbsets
        public DbSet<TRoleGroup> RoleGroups { get; set; }
        public DbSet<TRoleGroupRole> RoleGroupRoles { get; set; }
        public DbSet<TRoleGroupUser> RoleGroupUsers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperDbContextRoleGroups{THost, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser}" /> class.
        /// </summary>
        protected HyperDbContextRoleGroups()
            : this("DefaultConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperDbContextRoleGroups{THost, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser}" /> class.
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        protected HyperDbContextRoleGroups(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Contract.Requires<ArgumentNullException>(!nameOrConnectionString.IsNullOrWhiteSpace(), "nameOrConnectionString");

            this.MultiHostEnabled = false;
        }

        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // fix up table names, indexes, and identity columns (Guid Id columns are not db-assigned)
            modelBuilder.Entity<TRoleGroup>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TRoleGroupRole>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TRoleGroupUser>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<TRoleGroup>()
                .ToTable((RoleGroupsGroupsTableName.IsNullOrWhiteSpace() ? "AspNetGroups" : RoleGroupsGroupsTableName), (RoleGroupsSchemaName.IsNullOrWhiteSpace() ? "dbo" : RoleGroupsSchemaName));

            modelBuilder.Entity<TRoleGroupRole>()
                .ToTable((RoleGroupsGroupRolesTableName.IsNullOrWhiteSpace() ? "AspNetGroupRoles" : RoleGroupsGroupRolesTableName), (RoleGroupsSchemaName.IsNullOrWhiteSpace() ? "dbo" : RoleGroupsSchemaName));

            modelBuilder.Entity<TRoleGroupUser>()
                .ToTable((RoleGroupsGroupUsersTableName.IsNullOrWhiteSpace() ? "AspNetGroupUsers" : RoleGroupsGroupUsersTableName), (RoleGroupsSchemaName.IsNullOrWhiteSpace() ? "dbo" : RoleGroupsSchemaName));
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry != null && entityEntry.State == EntityState.Added)
            {
                var errors = new List<DbValidationError>();

                if (entityEntry.Entity is TRoleGroup)
                {
                    var group = entityEntry.Entity as TRoleGroup;
                    errors.AddRange(ValidateRoleGroup(group));
                }

                if (errors.Any())
                {
                    return new DbEntityValidationResult(entityEntry, errors);
                }
            }

            return base.ValidateEntity(entityEntry, items);
        }

        private List<DbValidationError> ValidateRoleGroup(TRoleGroup group)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");

            var errors = new List<DbValidationError>();

            // group name is required
            if (string.IsNullOrWhiteSpace(group.Name))
            {
                errors.Add(new DbValidationError("RoleGroup", String.Format("Group name is required.")));
            }

            // check if global group tied to system host
            if (group.IsGlobal)
            {
                if (!group.HostId.Equals(this.SystemHostId))
                {
                    errors.Add(new DbValidationError("RoleGroup", "Global RoleGroups must belong to system host."));
                }
            }

            if (group.IsGlobal)
            {
                // check if the role already exists
                // either as a system role or on any host
                var groupId = group.Id;
                var groupName = group.Name;
                List<TRoleGroup> existingGroups = this.RoleGroups.Where(g => g.Name == groupName).ToList();

                if (existingGroups.Any(g => !g.Id.Equals(groupId)))
                {
                    errors.Add(new DbValidationError("RoleGroup", String.Format("Group '{0}' already exists.", group.Name)));
                }
            }
            else
            {
                // group cannot exist in host
                var groupId = group.Id;
                var groupName = group.Name;
                var hostId = group.HostId;
                List<TRoleGroup> existingHostGroups = this.RoleGroups.Where(g => g.Name == groupName && g.HostId.Equals(hostId)).ToList();

                if (existingHostGroups.Any(g => !g.Id.Equals(groupId)))
                {
                    errors.Add(new DbValidationError("RoleGroup", String.Format("Group '{0}' already exists for host.", groupName)));
                }

                // group cannot exist as global
                List<TRoleGroup> existingGlobalGroups = this.RoleGroups.Where(g => g.Name == groupName && g.IsGlobal == true).ToList();

                if (existingGlobalGroups.Any(g => !g.Id.Equals(groupId)))
                {
                    errors.Add(new DbValidationError("RoleGroup", String.Format("Group '{0}' already exists as global group.", groupName)));
                }
            }

            return errors;
        }
    }
}
