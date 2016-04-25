using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Data.Entity;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Exposes host related API for a multi-tenant <c>DbContext</c> which will automatically save changes to the <c>RoleStore</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperHostManagerGuid<TUser> : HyperHostManager<HyperHostGuid, HyperHostDomainGuid, Guid, TUser, HyperRoleGuid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperRoleGroupGuid, HyperRoleGroupRoleGuid, HyperRoleGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperHostManager{THost, TKey}"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public HyperHostManagerGuid(HyperHostStoreGuid<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");
        }
    }

    /// <summary>
    /// Exposes host related API for a multi-tenant <c>DbContext</c> which will automatically save changes to the <c>RoleStore</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperHostManagerInt<TUser> : HyperHostManager<HyperHostInt, HyperHostDomainInt, int, TUser, HyperRoleInt, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperRoleGroupInt, HyperRoleGroupRoleInt, HyperRoleGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperHostManager{THost, TKey}"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public HyperHostManagerInt(HyperHostStoreInt<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");
        }
    }

    /// <summary>
    /// Exposes host related API for a multi-tenant <c>DbContext</c> which will automatically save changes to the <c>RoleStore</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperHostManagerLong<TUser> : HyperHostManager<HyperHostLong, HyperHostDomainLong, long, TUser, HyperRoleLong, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperRoleGroupLong, HyperRoleGroupRoleLong, HyperRoleGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperHostManager{THost, TKey}"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public HyperHostManagerLong(HyperHostStoreLong<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");
        }
    }

    /// <summary>
    /// Exposes host related API for a multi-tenant <c>DbContext</c> which will automatically save changes to the <c>RoleStore</c>.
    /// </summary>
    /// <typeparam name="THost">The type of the host.</typeparam>
    /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
    /// <typeparam name="TKey">The key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
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
    public class HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> : IDisposable
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
        protected internal readonly HyperHostStore<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> HyperHostStore;
        private bool disposed = false;

        public bool MultiHostEnabled { get { return HyperHostStore.MultiHostEnabled; } }
        public TKey SystemHostId { get { return HyperHostStore.SystemHostId; } }
        public TKey CurrentHostId { get { return HyperHostStore.CurrentHostId; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperHostManager{THost, TKey}"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public HyperHostManager(HyperHostStore<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");

            this.HyperHostStore = store;
        }

        /// <summary>
        /// Gets the hosts.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public virtual IQueryable<THost> GetHosts()
        {
            ThrowIfDisposed();

            return HyperHostStore.GetHosts();
        }

        /// <summary>
        /// Creates a new <see cref="HyperHost{TKey}"/> object in the data store.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public virtual async Task CreateAsync(THost host)
        {
            Contract.Requires<ArgumentNullException>(host != null, "host");

            ThrowIfDisposed();

            var existing = await FindByNameAsync(host.Name).WithCurrentCulture();

            if (existing != null && !host.Id.Equals(existing.Id))
            {
                throw new ArgumentException(String.Format("Host '{0}' already exists.", host.Name));
            }

            await HyperHostStore.CreateAsync(host);
        }

        /// <summary>
        /// Deletes <see cref="HyperHost{TKey}"/> object from the data store.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(THost host)
        {
            Contract.Requires<ArgumentNullException>(host != null, "host");

            ThrowIfDisposed();

            await HyperHostStore.DeleteAsync(host);
        }

        /// <summary>
        /// Updates <see cref="HyperHost{TKey}"/> object in the data store.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(THost host)
        {
            Contract.Requires<ArgumentNullException>(host != null, "host");

            ThrowIfDisposed();

            var existing = await FindByNameAsync(host.Name).WithCurrentCulture();

            if (existing != null &&!host.Id.Equals(existing.Id))
            {
                throw new ArgumentException(String.Format("Host '{0}' already exists.", host.Name));
            }

            await HyperHostStore.UpdateAsync(host);
        }

        /// <summary>
        /// Finds a <see cref="HyperHost{TKey}"/> by id.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public async Task<THost> FindByIdAsync(TKey hostId)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)));

            ThrowIfDisposed();

            return await HyperHostStore.FindByIdAsync(hostId);
        }

        /// <summary>
        /// Finds a <see cref="HyperHost{TKey}"/> by name.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        public async Task<THost> FindByNameAsync(string hostName)
        {
            Contract.Requires<ArgumentNullException>(!hostName.IsNullOrWhiteSpace(), "hostName");

            ThrowIfDisposed();

            return await HyperHostStore.FindByNameAsync(hostName);
        }

        /// <summary>
        /// Finds a <see cref="HyperHost{TKey}"/> by name.
        /// </summary>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns></returns>
        public async Task<THost> FindByDomainAsync(string domainName)
        {
            Contract.Requires<ArgumentNullException>(!domainName.IsNullOrWhiteSpace(), "domainName");

            ThrowIfDisposed();

            return await HyperHostStore.FindByDomainAsync(domainName);
        }

        /// <summary>
        /// Gets the system <see cref="HyperHost{TKey}"/>.
        /// </summary>
        /// <returns></returns>
        public async Task<THost> GetSystemHostAsync()
        {
            ThrowIfDisposed();

            return await HyperHostStore.GetSystemHostAsync();
        }

        /// <summary>
        /// Gets the domain names for the given <see cref="HyperHost{TKey}"/>.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public async Task<IList<string>> GetDomainsAsync(TKey hostId)
        {
            ThrowIfDisposed();

            return await HyperHostStore.GetDomainsAsync(hostId);
        }

        /// <summary>
        /// Adds a domain name to the specified <see cref="HyperHost{TKey}"/>.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public virtual async Task AddDomainAsync(THost host, string domainName)
        {
            Contract.Requires<ArgumentNullException>(host != null, "host");
            Contract.Requires<ArgumentNullException>(!domainName.IsNullOrWhiteSpace(), "domainName");

            ThrowIfDisposed();

            await HyperHostStore.AddDomainAsync(host, domainName);
        }

        /// <summary>
        /// Removes a domain name from the specified <see cref="HyperHost{TKey}"/>.
        /// </summary>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns></returns>
        public virtual async Task RemoveDomainAsync(string domainName)
        {
            Contract.Requires<ArgumentNullException>(!domainName.IsNullOrWhiteSpace(), "domainName");

            ThrowIfDisposed();

            await HyperHostStore.RemoveDomainAsync(domainName);
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
        protected virtual void Dispose(bool disposing)
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
