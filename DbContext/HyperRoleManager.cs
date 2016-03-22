using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Exposes role related API for a multi-tenant <c>DbContext</c> having key and host key as <c>TKey</c> data types.
    /// </summary>
    public class HyperRoleManagerGuid<TUser> : HyperRoleManager<TUser, HyperRoleGuid, Guid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperHostGuid, HyperHostDomainGuid, HyperGroupGuid, HyperGroupRoleGuid, HyperGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleManagerGuid" /> class.
        /// </summary>
        /// <param name="store">The <c>RoleStore</c>.</param>
        public HyperRoleManagerGuid(HyperRoleStoreGuid<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");
        }
    }

    /// <summary>
    /// Exposes role related API for a multi-tenant <c>DbContext</c> having key and host key as <c>TKey</c> data types.
    /// </summary>
    public class HyperRoleManagerInt<TUser> : HyperRoleManager<TUser, HyperRoleInt, int, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperHostInt, HyperHostDomainInt, HyperGroupInt, HyperGroupRoleInt, HyperGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleManagerGuid" /> class.
        /// </summary>
        /// <param name="store">The <c>RoleStore</c>.</param>
        public HyperRoleManagerInt(HyperRoleStoreInt<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");
        }
    }

    /// <summary>
    /// Exposes role related API for a multi-tenant <c>DbContext</c> having key and host key as <c>TKey</c> data types.
    /// </summary>
    public class HyperRoleManagerLong<TUser> : HyperRoleManager<TUser, HyperRoleLong, long, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperHostLong, HyperHostDomainLong, HyperGroupLong, HyperGroupRoleLong, HyperGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleManagerGuid" /> class.
        /// </summary>
        /// <param name="store">The <c>RoleStore</c>.</param>
        public HyperRoleManagerLong(HyperRoleStoreLong<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");
        }
    }

    /// <summary>
    /// Exposes role related API for a multi-tenant <c>DbContext</c> which will automatically save changes to the <c>RoleStore</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <typeparam name="TRole">A role type derived from <c>HyperRole{TKey}</c>.</typeparam>
    /// <typeparam name="TKey">The key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    /// <typeparam name="THost">The type of the host.</typeparam>
    /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
    /// <typeparam name="TGroup">The type of the group.</typeparam>
    /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
    /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
    /// <typeparam name="TAudit">The type of the audit.</typeparam>
    /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
    /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
    public class HyperRoleManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> : RoleManager<TRole, TKey>
        where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
        where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TUserLogin : HyperUserLogin<TKey>, IHyperUserLogin<TKey>, new()
        where TUserRole : HyperUserRole<TKey>, IHyperUserRole<TKey>, new()
        where TUserClaim : HyperUserClaim<TKey>, IHyperUserClaim<TKey>, new()
        where THost : HyperHost<TKey, THost, THostDomain>, new()
        where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
        where TGroup : HyperGroup<TKey, TGroupRole, TGroupUser>, new()
        where TGroupRole : HyperGroupRole<TKey>, new()
        where TGroupUser : HyperGroupUser<TKey>, new()
        where TAudit : HyperAudit<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditItem : HyperAuditItem<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditProperty : HyperAuditProperty<TKey, TAudit, TAuditItem, TAuditProperty>, new()
    {
        protected internal readonly HyperRoleStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> HyperRoleStore;
        private bool disposed = false;

        public bool MultiHostEnabled { get { return HyperRoleStore.MultiHostEnabled; } }
        public TKey SystemHostId { get { return HyperRoleStore.SystemHostId; } }
        public TKey HostId { get { return HyperRoleStore.HostId; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleManager{TKey, TRole}" /> class.
        /// </summary>
        /// <param name="store">The <c>RoleStore</c>.</param>
        public HyperRoleManager(HyperRoleStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");

            // new role validator to allow duplicate names--just not for same host
            this.RoleValidator = new HyperRoleValidator<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this);

            this.HyperRoleStore = store;
        }

        /// <summary>
        /// Gets the roles for the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public IQueryable<TRole> GetRoles(TKey hostId)
        {
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");

            ThrowIfDisposed();

            return HyperRoleStore.GetRoles(hostId);
        }

        /// <summary>
        /// Gets the roles for the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public IQueryable<TRole> GetRoles()
        {
            ThrowIfDisposed();

            return HyperRoleStore.GetRoles(this.HostId);
        }

        /// <summary>
        /// Gets the roles for the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public IQueryable<TRole> GetAllRoles()
        {
            ThrowIfDisposed();

            return HyperRoleStore.GetAllRoles();
        }

        /// <summary>
        /// Creates a role for the current host (or global host if global flag set)
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Global roles must belong to system host.</exception>
        public async Task<IdentityResult> CreateAsync(string roleName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            if (global)
            {
                return await CreateAsync(this.SystemHostId, roleName, global);
            }
            else
            {
                return await CreateAsync(this.HostId, roleName, global);
            }
        }

        /// <summary>
        /// Creates a role for the current host
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Global roles must belong to system host.</exception>
        public async Task<IdentityResult> CreateAsync(TKey hostId, string roleName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            var role = new TRole()
            {
                HostId = hostId,
                Name = roleName,
                IsGlobal = global
            };

            return await CreateAsync(role);
        }

        /// <summary>
        /// Creates a role for the host specified in <c>role.HostId</c> or the current host if unspecified.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Global roles must belong to system host.</exception>
        public override async Task<IdentityResult> CreateAsync(TRole role)
        {
            //x Contract.Requires<ArgumentNullException>(role != null, "role");

            ThrowIfDisposed();

            if (role.HostId.Equals(default(TKey)))
            {
                role.HostId = this.HostId;
            }

            if (role.IsGlobal && !role.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global roles must belong to system host.");
            }

            var result = await RoleValidator.ValidateAsync(role).WithCurrentCulture();
            if (!result.Succeeded)
            {
                return result;
            }

            await HyperRoleStore.CreateAsync(role).WithCurrentCulture();

            return IdentityResult.Success;
        }

        /// <summary>
        /// Find a role by name for the current host or global role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public override async Task<TRole> FindByNameAsync(string roleName)
        {
            //x Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await FindByNameAsync(this.HostId, roleName);
        }

        /// <summary>
        ///  Find a role by name. Searches in the specified host, then global roles.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public async Task<TRole> FindByNameAsync(TKey hostId, string roleName)
        {
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await HyperRoleStore.FindByNameAsync(hostId, roleName).WithCurrentCulture();
        }

        /// <summary>
        /// Checks if a role exists for the default host or in global roles.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns><c>true</c> if role exists, otherwise, <c>false</c></returns>
        public override async Task<bool> RoleExistsAsync(string roleName)
        {
            //x Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await RoleExistsAsync(this.HostId, roleName);
        }

        /// <summary>
        /// Checks if a role exists for the specified host or in global roles.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="hostId">The host id.</param>
        /// <returns>
        ///   <c>true</c> if role exists, otherwise, <c>false</c>
        /// </returns>
        public async Task<bool> RoleExistsAsync(TKey hostId, string roleName)
        {
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await FindByNameAsync(hostId, roleName).WithCurrentCulture() != null;
        }

        /// <summary>
        /// Update an existing role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Roles cannot be assigned a new hostId.</exception>
        /// <exception cref="System.ArgumentException">Roles cannot be assigned a new hostId.</exception>
        public override async Task<IdentityResult> UpdateAsync(TRole role)
        {
            //x Contract.Requires<ArgumentNullException>(role != null, "role");

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

            var result = await RoleValidator.ValidateAsync(role).WithCurrentCulture();
            if (!result.Succeeded)
            {
                return result;
            }

            await HyperRoleStore.UpdateAsync(role).WithCurrentCulture();

            return IdentityResult.Success;
        }

        /// <summary>
        /// Deletes an existing role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Roles cannot be assigned a new hostId.</exception>
        /// <exception cref="System.ArgumentException">Roles cannot be assigned a new hostId.</exception>
        public override async Task<IdentityResult> DeleteAsync(TRole role)
        {
            //x Contract.Requires<ArgumentNullException>(role != null, "role");

            ThrowIfDisposed();

            await HyperRoleStore.DeleteAsync(role).WithCurrentCulture();

            return IdentityResult.Success;
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
                    // cache references? if so, release them here

                    this.disposed = true;
                }
            }

            base.Dispose(disposing);
        }
    }
}

