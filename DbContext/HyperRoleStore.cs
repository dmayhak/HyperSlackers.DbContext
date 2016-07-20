using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// EntityFramework <c>RoleStore</c> implementation for a multi-tenant <c>DbContext</c> having key and host key data types of <c>TKey</c>.
    /// </summary>
    public class HyperRoleStoreGuid<TUser> : HyperRoleStore<TUser, HyperRoleGuid, Guid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperHostGuid, HyperHostDomainGuid, HyperRoleGroupGuid, HyperRoleGroupRoleGuid, HyperRoleGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleStore{TUser, TKey}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperRoleStoreGuid(HyperDbContextGuid<TUser> context)
            : base(context)
        {
            Helpers.ThrowIfNull(context != null, "context");
        }
    }

    /// <summary>
    /// EntityFramework <c>RoleStore</c> implementation for a multi-tenant <c>DbContext</c> having key and host key data types of <c>TKey</c>.
    /// </summary>
    public class HyperRoleStoreInt<TUser> : HyperRoleStore<TUser, HyperRoleInt, int, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperHostInt, HyperHostDomainInt, HyperRoleGroupInt, HyperRoleGroupRoleInt, HyperRoleGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleStore{TUser, TKey}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperRoleStoreInt(HyperDbContextInt<TUser> context)
            : base(context)
        {
            Helpers.ThrowIfNull(context != null, "context");
        }
    }

    /// <summary>
    /// EntityFramework <c>RoleStore</c> implementation for a multi-tenant <c>DbContext</c> having key and host key data types of <c>TKey</c>.
    /// </summary>
    public class HyperRoleStoreLong<TUser> : HyperRoleStore<TUser, HyperRoleLong, long, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperHostLong, HyperHostDomainLong, HyperRoleGroupLong, HyperRoleGroupRoleLong, HyperRoleGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleStore{TUser, TKey}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperRoleStoreLong(HyperDbContextLong<TUser> context)
            : base(context)
        {
            Helpers.ThrowIfNull(context != null, "context");
        }
    }

    /// <summary>
    /// EntityFramework <c>RoleStore</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <typeparam name="TRole">A role type derived from <c>HyperRole{TKey}</c>.</typeparam>
    /// <typeparam name="TKey">The key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    /// <typeparam name="THost">The type of the host.</typeparam>
    /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
    /// <typeparam name="TRoleGroup">The type of the group.</typeparam>
    /// <typeparam name="TRoleGroupRole">The type of the group role.</typeparam>
    /// <typeparam name="TRoleGroupUser">The type of the group user.</typeparam>
    /// <typeparam name="TAudit">The type of the audit.</typeparam>
    /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
    /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
    public class HyperRoleStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> : RoleStore<TRole, TKey, TUserRole>, IQueryableRoleStore<TRole, TKey>, IRoleStore<TRole, TKey>, IDisposable
        where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroupUser>, IHyperUser<TKey>, new()
        where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TUserLogin : HyperUserLogin<TKey>, IHyperUserLogin<TKey>, new()
        where TUserRole : HyperUserRole<TKey>, IHyperUserRole<TKey>, new()
        where TUserClaim : HyperUserClaim<TKey>, IHyperUserClaim<TKey>, new()
        where THost : HyperHost<TKey, THost, THostDomain>, new()
        where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
        where TRoleGroup : HyperRoleGroup<TKey, TRoleGroupRole, TRoleGroupUser>, new()
        where TRoleGroupRole : HyperRoleGroupRole<TKey>, new()
        where TRoleGroupUser : HyperRoleGroupUser<TKey>, new()
        where TAudit : HyperAudit<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditItem : HyperAuditItem<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditProperty : HyperAuditProperty<TKey, TAudit, TAuditItem, TAuditProperty>, new()
    {
        private bool disposed = false;

        public bool MultiHostEnabled { get { return HyperContext.MultiHostEnabled; } }
        public TKey SystemHostId { get { return HyperContext.SystemHostId; } }
        public TKey CurrentHostId { get { return HyperContext.CurrentHostId; } }

        protected internal readonly HyperDbContext<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> HyperContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleStoreMultiHost{TKey, TKey, TRole}" /> class.
        /// </summary>
        /// <param name="context">The <c>DbContext</c>.</param>
        public HyperRoleStore(HyperDbContext<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> context)
            : base(context)
        {
            Helpers.ThrowIfNull(context != null, "context");

            this.HyperContext = context;
        }

        /// <summary>
        /// Retrieves all <c>Roles</c> for the current host and all global roles.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TRole> GetRoles()
        {
            ThrowIfDisposed();

            return GetRoles(this.CurrentHostId);
        }

        /// <summary>
        /// Retrieves all <c>Roles</c> for the given host and all global roles.
        /// </summary>
        /// <param name="hostId">The host id.</param>
        /// <returns></returns>
        public IQueryable<TRole> GetRoles(TKey hostId)
        {
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");

            ThrowIfDisposed();

            return this.Roles.Where(r => r.HostId.Equals(hostId) || r.IsGlobal == true);
        }

        /// <summary>
        /// Retrieves all <c>Roles</c>.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TRole> GetAllRoles()
        {
            ThrowIfDisposed();

            return Roles;
        }

        /// <summary>
        /// Creates a new role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Global roles must belong to system host.</exception>
        public override async Task CreateAsync(TRole role)
        {
            //x Helpers.ThrowIfNull(role != null, "role");

            ThrowIfDisposed();

            if (role.HostId.Equals(default(TKey)))
            {
                role.HostId = this.CurrentHostId;
            }

            if (role.IsGlobal && !role.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global roles must belong to system host.");
            }

            await base.CreateAsync(role);
        }

        /// <summary>
        /// Finds a role by name for the current host or in global roles.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <returns></returns>
        public new async Task<TRole> FindByNameAsync(string roleName)
        {
            //x Helpers.ThrowIfNull(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await FindByNameAsync(this.CurrentHostId, roleName);
        }

        /// <summary>
        /// Finds a role by name for the current host or in global roles.
        /// </summary>
        /// <param name="hostId">The host id.</param>
        /// <param name="roleName">The role name.</param>
        /// <returns></returns>
        public async Task<TRole> FindByNameAsync(TKey hostId, string roleName)
        {
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await this.Roles.Where(r => r.Name.ToUpper() == roleName.ToUpper() && (r.HostId.Equals(hostId) || r.IsGlobal == true)).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Update an existing role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Roles cannot be assigned a new hostId.</exception>
        /// <exception cref="System.ArgumentException">Global roles must belong to system host.</exception>
        public override async Task UpdateAsync(TRole role)
        {
            //x Helpers.ThrowIfNull(role != null, "role");

            ThrowIfDisposed();

            var existing = await FindByIdAsync(role.Id);

            if (existing != null && !role.HostId.Equals(existing.HostId))
            {
                throw new ArgumentException("Roles cannot be assigned a new hostId.");
            }

            if (role.IsGlobal && !role.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global roles must belong to system host.");
            }

            await base.UpdateAsync(role);
        }

        /// <summary>
        ///     Mark an entity for deletion
        /// </summary>
        /// <param name="role"></param>
        public override Task DeleteAsync(TRole role)
        {
            //x Helpers.ThrowIfNull(role != null, "role");

            return base.DeleteAsync(role);
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // TODO: cache references? if so, release them here

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }
}
