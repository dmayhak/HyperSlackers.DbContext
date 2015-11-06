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
    /// <typeparam name="TGroup">The type of the group.</typeparam>
    /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
    /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
    /// <typeparam name="TAudit">The type of the audit.</typeparam>
    /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
    /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
    public class HyperDbContextGroups<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> : HyperDbContextMultiHost<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>
        where THost : HyperHost<TKey, THost, THostDomain>, new()
        where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
        where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
        where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TUserLogin : HyperUserLogin<TKey>, IHyperUserLogin<TKey>, new()
        where TUserRole : HyperUserRole<TKey>, IHyperUserRole<TKey>, new()
        where TUserClaim : HyperUserClaim<TKey>, IHyperUserClaim<TKey>, new()
        where TGroup : HyperGroup<TKey, TGroupRole, TGroupUser>, new()
        where TGroupRole : HyperGroupRole<TKey>, new()
        where TGroupUser : HyperGroupUser<TKey>, new()
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
        public DbSet<TGroup> RoleGroups { get; set; }
        public DbSet<TGroupRole> RoleGroupRoles { get; set; }
        public DbSet<TGroupUser> RoleGroupUsers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperDbContextGroups{THost, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser}" /> class.
        /// </summary>
        protected HyperDbContextGroups()
            : this("DefaultConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperDbContextGroups{THost, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser}" /> class.
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        protected HyperDbContextGroups(string nameOrConnectionString)
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
            modelBuilder.Entity<TGroup>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TGroupRole>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TGroupUser>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<TGroup>()
                .ToTable((RoleGroupsGroupsTableName.IsNullOrWhiteSpace() ? "AspNetGroups" : RoleGroupsGroupsTableName), (RoleGroupsSchemaName.IsNullOrWhiteSpace() ? "dbo" : RoleGroupsSchemaName));

            modelBuilder.Entity<TGroupRole>()
                .ToTable((RoleGroupsGroupRolesTableName.IsNullOrWhiteSpace() ? "AspNetGroupRoles" : RoleGroupsGroupRolesTableName), (RoleGroupsSchemaName.IsNullOrWhiteSpace() ? "dbo" : RoleGroupsSchemaName));

            modelBuilder.Entity<TGroupUser>()
                .ToTable((RoleGroupsGroupUsersTableName.IsNullOrWhiteSpace() ? "AspNetGroupUsers" : RoleGroupsGroupUsersTableName), (RoleGroupsSchemaName.IsNullOrWhiteSpace() ? "dbo" : RoleGroupsSchemaName));
        }
    }
}
