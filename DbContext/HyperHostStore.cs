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
    /// <c>HostStore</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperHostStoreGuid<TUser> : HyperHostStore<HyperHostGuid, HyperHostDomainGuid, Guid, TUser, HyperRoleGuid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperRoleGroupGuid, HyperRoleGroupRoleGuid, HyperRoleGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperHostStoreGuid{TUser}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperHostStoreGuid(HyperDbContextGuid<TUser> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");
        }
    }

    /// <summary>
    /// <c>HostStore</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperHostStoreInt<TUser> : HyperHostStore<HyperHostInt, HyperHostDomainInt, int, TUser, HyperRoleInt, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperRoleGroupInt, HyperRoleGroupRoleInt, HyperRoleGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperHostStoreInt{TUser}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperHostStoreInt(HyperDbContextInt<TUser> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");
        }
    }

    /// <summary>
    /// <c>HostStore</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperHostStoreLong<TUser> : HyperHostStore<HyperHostLong, HyperHostDomainLong, long, TUser, HyperRoleLong, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperRoleGroupLong, HyperRoleGroupRoleLong, HyperRoleGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperHostStoreLong{TUser}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperHostStoreLong(HyperDbContextLong<TUser> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");
        }
    }

    /// <summary>
    ///   <c>HostStore</c> implementation for a multi-tenant <c>DbContext</c>.
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
    public class HyperHostStore<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> : IDisposable
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
       /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        protected internal HyperDbContext<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> HyperContext { get; private set; }
        private bool disposed = false;
        public bool AutoSaveChanges { get; set; }
        private readonly IDbSet<THost> hosts;
        private readonly IDbSet<THostDomain> hostDomains;

        public bool MultiHostEnabled { get { return HyperContext.MultiHostEnabled; } }
        public TKey SystemHostId { get { return HyperContext.SystemHostId; } }
        public TKey CurrentHostId { get { return HyperContext.CurrentHostId; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperHostStore{THost, TKey}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HyperHostStore(HyperDbContext<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");

            this.HyperContext = context;
            this.AutoSaveChanges = false;

            this.hosts = HyperContext.Set<THost>();
            this.hostDomains = HyperContext.Set<THostDomain>();
        }

        // Only call save changes if AutoSaveChanges is true
        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await HyperContext.SaveChangesAsync().WithCurrentCulture();
            }
        }

        /// <summary>
        /// Gets the hosts.
        /// </summary>
        /// <value>
        /// The hosts.
        /// </value>
        public virtual IQueryable<THost> GetHosts()
        {
            ThrowIfDisposed();

            return HyperContext.Set<THost>();
        }

        /// <summary>
        /// Creates a new <see cref="HyperHost{TKey}"/> in the data store.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public virtual async Task CreateAsync(THost host)
        {
            Contract.Requires<ArgumentNullException>(host != null, "host");

            ThrowIfDisposed();

            // TODO: check for existing host and existing domains

            HyperContext.Set<THost>().Add(host);

            await SaveChanges().WithCurrentCulture();
        }

        /// <summary>
        /// Deletes a <see cref="HyperHost{TKey}"/> from the data store.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(THost host)
        {
            Contract.Requires<ArgumentNullException>(host != null, "host");

            ThrowIfDisposed();



            HyperContext.Set<THost>().Remove(host);

            await SaveChanges().WithCurrentCulture();
        }

        /// <summary>
        /// updates an existing <see cref="HyperHost{TKey}"/> in the data store.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(THost host)
        {

            Contract.Requires<ArgumentNullException>(host != null, "host");

            ThrowIfDisposed();

            HyperContext.Entry(host).State = EntityState.Modified;

            await SaveChanges().WithCurrentCulture();
        }

        /// <summary>
        /// Finds a <see cref="HyperHost{TKey}"/> by id.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public async Task<THost> FindByIdAsync(TKey hostId)
        {
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)));

            ThrowIfDisposed();

            return await hosts.FirstOrDefaultAsync(h => h.Id.Equals(hostId)).WithCurrentCulture();
        }

        /// <summary>
        /// Finds a host by name.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        public async Task<THost> FindByNameAsync(string hostName)
        {
            Contract.Requires<ArgumentNullException>(!hostName.IsNullOrWhiteSpace(), "hostName");

            ThrowIfDisposed();

            return await hosts.FirstOrDefaultAsync(h => h.Name.ToUpper() == hostName.ToUpper()).WithCurrentCulture();
        }

        /// <summary>
        /// Finds a host by domain name.
        /// </summary>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns></returns>
        public async Task<THost> FindByDomainAsync(string domainName)
        {
            Contract.Requires<ArgumentNullException>(!domainName.IsNullOrWhiteSpace(), "domainName");

            ThrowIfDisposed();

            var domain = hostDomains.FirstOrDefaultAsync(hd => hd.DomainName.ToUpper() == domainName.ToUpper()).Result;

            if (domain != null)
            {
                var hostId = domain.HostId;

                return await hosts.FirstOrDefaultAsync(h => h.Id.Equals(hostId)).WithCurrentCulture();
            }

            return null;
        }

        /// <summary>
        /// Gets the domains for the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public async Task<IList<string>> GetDomainsAsync(TKey hostId)
        {
            ThrowIfDisposed();

            var host = FindByIdAsync(hostId).Result;

            return await hostDomains.Where(d => d.HostId.Equals(host.Id)).Select(d => d.DomainName).ToListAsync();
        }

        /// <summary>
        /// Finds the system host.
        /// </summary>
        /// <returns></returns>
        public async Task<THost> GetSystemHostAsync()
        {
            ThrowIfDisposed();

            return await hosts.FirstOrDefaultAsync(h => h.IsSystemHost).WithCurrentCulture();
        }

        /// <summary>
        /// Adds a domain to the given host.
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

            // check if domain exists
            if (await hostDomains.AnyAsync(d => d.DomainName.ToUpper() == domainName.ToUpper()))
            {
                throw new ArgumentException(string.Format("Domain '{0}' already exists.", domainName));
            }

            host.Domains.Add(new THostDomain() { DomainName = domainName });
        }

        public virtual async Task RemoveDomainAsync(string domainName)
        {
            Contract.Requires<ArgumentNullException>(!domainName.IsNullOrWhiteSpace(), "domainName");

            ThrowIfDisposed();

            // get domain
            var domain = await hostDomains.SingleOrDefaultAsync(d => d.DomainName.ToUpper() == domainName.ToUpper());

            if (domain != null)
            {
                hostDomains.Remove(domain);
            }
        }

        //private bool AreDomainsLoaded(THost host)
        //{
        //    return Context.Entry(host).Collection(h => h.Domains).IsLoaded;
        //}

        //private async Task EnsureDomainsLoaded(THost host)
        //{
        //    if (!AreDomainsLoaded(host))
        //    {
        //        var hostId = host.Id;
        //        await hostDomains.Where(hd => hd.HostId.Equals(hostId)).LoadAsync().WithCurrentCulture();
        //        Context.Entry(host).Collection(h => h.Domains).IsLoaded = true;
        //    }
        //}

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

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
