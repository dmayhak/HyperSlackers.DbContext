using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Manager object for maintaining groups of roles and assigning of groups to users.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperRoleGroupManagerGuid<TUser> : HyperRoleGroupManager<HyperHostGuid, HyperHostDomainGuid, Guid, TUser, HyperRoleGuid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperRoleGroupGuid, HyperRoleGroupRoleGuid, HyperRoleGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleGroupManagerGuid{TUser}"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public HyperRoleGroupManagerGuid(HyperRoleGroupStoreGuid<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");
        }
    }

    /// <summary>
    /// Manager object for maintaining groups of roles and assigning of groups to users.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperRoleGroupManagerInt<TUser> : HyperRoleGroupManager<HyperHostInt, HyperHostDomainInt, int, TUser, HyperRoleInt, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperRoleGroupInt, HyperRoleGroupRoleInt, HyperRoleGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleGroupManagerInt{TUser}"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public HyperRoleGroupManagerInt(HyperRoleGroupStoreInt<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");
        }
    }

    /// <summary>
    /// Manager object for maintaining groups of roles and assigning of groups to users.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperRoleGroupManagerLong<TUser> : HyperRoleGroupManager<HyperHostLong, HyperHostDomainLong, long, TUser, HyperRoleLong, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperRoleGroupLong, HyperRoleGroupRoleLong, HyperRoleGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleGroupManagerLong{TUser}"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public HyperRoleGroupManagerLong(HyperRoleGroupStoreLong<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");
        }
    }

    /// <summary>
    /// Manager object for maintaining groups of roles and assigning of groups to users.
    /// </summary>
    /// <typeparam name="THost">The type of the host.</typeparam>
    /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <typeparam name="TRole">The type of the role.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    /// <typeparam name="TRoleGroup">The type of the group.</typeparam>
    /// <typeparam name="TRoleGroupRole">The type of the group role.</typeparam>
    /// <typeparam name="TRoleGroupUser">The type of the group user.</typeparam>
    /// <typeparam name="TAudit">The type of the audit.</typeparam>
    /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
    /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
    public class HyperRoleGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> : IDisposable
        where THost : HyperHost<TKey, THost, THostDomain>, new()
        where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
        where TKey : struct, IEquatable<TKey>
        where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroupUser>, IHyperUser<TKey>, new()
        where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
        protected internal readonly HyperRoleGroupStore<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> HyperRoleGroupStore;
        private bool disposed = false;

        public bool MultiHostEnabled { get { return HyperRoleGroupStore.MultiHostEnabled; } }
        public TKey SystemHostId { get { return HyperRoleGroupStore.SystemHostId; } }
        public TKey CurrentHostId { get { return HyperRoleGroupStore.CurrentHostId; } }
        public bool RoleGroupsEnabled { get { return HyperRoleGroupStore.RoleGroupsEnabled; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleManager{TKey, TRole}" /> class.
        /// </summary>
        /// <param name="store">The <c>RoleStore</c>.</param>
        public HyperRoleGroupManager(HyperRoleGroupStore<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");

            this.HyperRoleGroupStore = store;
        }

        /// <summary>
        /// Gets the system <see cref="HyperRoleGroup{TKey}"/>s.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TRoleGroup> GetSystemRoleGroupsAsync()
        {
            ThrowIfDisabled();
            ThrowIfDisposed();

            return GetRoleGroups(this.SystemHostId);
        }

        /// <summary>
        /// Gets all <see cref="HyperRoleGroup{TKey}" />s for the given host, plus global groups.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public IQueryable<TRoleGroup> GetRoleGroups(TKey hostId)
        {
            ThrowIfDisabled();
            ThrowIfDisposed();

            return HyperRoleGroupStore.GetRoleGroups(hostId);
        }

        /// <summary>
        /// Gets all <see cref="HyperRoleGroup{TKey}" />s for the current host, plus global groups.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public IQueryable<TRoleGroup> GetRoleGroups()
        {
            ThrowIfDisabled();
            ThrowIfDisposed();

            return HyperRoleGroupStore.GetRoleGroups();
        }

        /// <summary>
        /// Gets all <see cref="HyperRoleGroup{TKey}" />s..
        /// </summary>
        /// <returns></returns>
        public IQueryable<TRoleGroup> GetAllRoleGroups()
        {
            ThrowIfDisabled();
            ThrowIfDisposed();

            return HyperRoleGroupStore.GetAllRoleGroups();
        }

        /// <summary>
        /// Creates a group for the current host (or global if global flag set)
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Global groups must belong to system host.</exception>
        public async Task<IdentityResult> CreateAsync(string groupName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            if (global)
            {
                return await CreateAsync(this.SystemHostId, groupName, global);
            }
            else
            {
                return await CreateAsync(this.CurrentHostId, groupName, global);
            }
        }

        /// <summary>
        /// Creates a group for the current host (or global if global flag set)
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="roleName">Name of the group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Global groups must belong to system host.</exception>
        public async Task<IdentityResult> CreateAsync(TKey hostId, string groupName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            var group = new TRoleGroup()
            {
                HostId = hostId,
                Name = groupName,
                IsGlobal = global
            };

            return await CreateAsync(group);
        }

        /// <summary>
        /// Creates a new <see cref="HyperRoleGroup{TKey}"/> object in the data store.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> CreateAsync(TRoleGroup group)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisabled();
            ThrowIfDisposed();

            if (group.HostId.Equals(default(TKey)))
            {
                group.HostId = this.CurrentHostId;
            }

            if (group.IsGlobal && !group.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global groups must belong to system host.");
            }

            var existing = await FindByNameAsync(group.HostId, group.Name).WithCurrentCulture();

            if (existing != null && (!group.Id.Equals(existing.Id) || !group.HostId.Equals(existing.Id)))
            {
                throw new ArgumentException(String.Format("Group '{0}' already exists.", group.Name));
            }

            await HyperRoleGroupStore.CreateAsync(group);

            return IdentityResult.Success;
        }

        /// <summary>
        /// Deletes <see cref="HyperRoleGroup{TKey}"/> object from the data store.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(TRoleGroup group)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisabled();
            ThrowIfDisposed();

            await HyperRoleGroupStore.DeleteAsync(group);
        }

        /// <summary>
        /// Updates <see cref="HyperRoleGroup{TKey}"/> object in the data store.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(TRoleGroup group)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisabled();
            ThrowIfDisposed();

            var existing = await FindByNameAsync(group.HostId, group.Name).WithCurrentCulture();

            if (existing != null && !group.HostId.Equals(existing.HostId))
            {
                throw new ArgumentException("Groups cannot be assigned a new hostId.");
            }

            if (group.IsGlobal && !group.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global roles must belong to system host.");
            }

            if (existing != null && (!group.Id.Equals(existing.Id) && group.HostId.Equals(existing.HostId)))
            {
                throw new ArgumentException(String.Format("Group '{0}' already exists for this host.", group.Name));
            }

            await HyperRoleGroupStore.UpdateAsync(group);
        }

        /// <summary>
        /// Finds a <see cref="HyperRoleGroup{TKey}"/> by id.
        /// </summary>
        /// <param name="hostId">The group identifier.</param>
        /// <returns></returns>
        public async Task<TRoleGroup> FindByIdAsync(TKey groupId)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !groupId.Equals(default(TKey)));

            ThrowIfDisabled();
            ThrowIfDisposed();

            return await HyperRoleGroupStore.FindByIdAsync(groupId);
        }

        /// <summary>
        /// Finds a <see cref="HyperRoleGroup{TKey}"/> by name.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public async Task<TRoleGroup> FindByNameAsync(string groupName)
        {
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisabled();
            ThrowIfDisposed();

            return await FindByNameAsync(this.CurrentHostId, groupName);
        }

        /// <summary>
        /// Finds a <see cref="HyperRoleGroup{TKey}" /> by name.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public async Task<TRoleGroup> FindByNameAsync(TKey hostId, string groupName)
        {
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisabled();
            ThrowIfDisposed();

            return await HyperRoleGroupStore.FindByNameAsync(hostId, groupName);
        }

        /// <summary>
        /// Gets the roles for the specified group.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public async Task<IList<TRole>> GetRolesAsync(TKey groupId)
        {
            Contract.Requires<ArgumentNullException>(groupId.Equals(default(TKey)), "groupId");

            ThrowIfDisabled();
            ThrowIfDisposed();

            var group = FindByIdAsync(groupId).Result;

            if (group != null)
            {
                return await HyperRoleGroupStore.GetRolesAsync(group);
            }

            return null;
        }

        /// <summary>
        /// Gets the users for the specified group.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public async Task<IList<TUser>> GetUsersAsync(TKey groupId)
        {
            Contract.Requires<ArgumentNullException>(groupId.Equals(default(TKey)), "groupId");

            ThrowIfDisabled();
            ThrowIfDisposed();

            var group = FindByIdAsync(groupId).Result;

            if (group != null)
            {
                return await HyperRoleGroupStore.GetUsersAsync(group);
            }

            return null;
        }

        /// <summary>
        /// Adds a role to the given group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public virtual async Task AddRoleAsync(TRoleGroup group, TRole role)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            ThrowIfDisabled();
            ThrowIfDisposed();

            await HyperRoleGroupStore.AddRoleAsync(group, role);
        }

        /// <summary>
        /// Removes a role from the given group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public virtual async Task RemoveRoleAsync(TRoleGroup group, TRole role)
        {
            Contract.Requires<ArgumentNullException>(group != null, "group");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            ThrowIfDisabled();
            ThrowIfDisposed();

            await HyperRoleGroupStore.RemoveRoleAsync(group, role);
        }

        private void ThrowIfDisabled()
        {
            if (!this.RoleGroupsEnabled)
            {
                throw new InvalidOperationException("Groups are not enabled for this context.");
            }
        }

        /// <summary>
        /// Throws an Exception if this object has been disposed.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException"></exception>
        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // TODO: cache references? if so, release them here

                    this.disposed = true;
                }
            }
        }
    }
}
