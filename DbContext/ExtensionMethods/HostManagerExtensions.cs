using System;
using System.Diagnostics.Contracts;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    public static class HostManagerExtensions
    {
        /// <summary>
        /// Creates the specified host.
        /// </summary>
        /// <typeparam name="THost">The type of the host.</typeparam>
        /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
        /// <typeparam name="TUserRole">The type of the user role.</typeparam>
        /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
        /// <typeparam name="TGroup">The type of the group.</typeparam>
        /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
        /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
        /// <typeparam name="TAudit">The type of the audit.</typeparam>
        /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
        /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
        /// <param name="manager">The manager.</param>
        /// <param name="host">The host.</param>
        public static void Create<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, THost host)
            where THost : HyperHost<TKey, THost, THostDomain>, new()
            where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
            where TKey : struct, IEquatable<TKey>
            where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
            where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(host != null, "host");

            AsyncHelper.RunSync(() => manager.CreateAsync(host));
        }

        /// <summary>
        /// Deletes the specified host.
        /// </summary>
        /// <typeparam name="THost">The type of the host.</typeparam>
        /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
        /// <typeparam name="TUserRole">The type of the user role.</typeparam>
        /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
        /// <typeparam name="TGroup">The type of the group.</typeparam>
        /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
        /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
        /// <typeparam name="TAudit">The type of the audit.</typeparam>
        /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
        /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
        /// <param name="manager">The manager.</param>
        /// <param name="host">The host.</param>
        public static void Delete<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, THost host)
            where THost : HyperHost<TKey, THost, THostDomain>, new()
            where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
            where TKey : struct, IEquatable<TKey>
            where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
            where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(host != null, "host");

            AsyncHelper.RunSync(() => manager.DeleteAsync(host));
        }

        /// <summary>
        /// Updates the specified host.
        /// </summary>
        /// <typeparam name="THost">The type of the host.</typeparam>
        /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
        /// <typeparam name="TUserRole">The type of the user role.</typeparam>
        /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
        /// <typeparam name="TGroup">The type of the group.</typeparam>
        /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
        /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
        /// <typeparam name="TAudit">The type of the audit.</typeparam>
        /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
        /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
        /// <param name="manager">The manager.</param>
        /// <param name="host">The host.</param>
        public static void Update<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, THost host)
            where THost : HyperHost<TKey, THost, THostDomain>, new()
            where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
            where TKey : struct, IEquatable<TKey>
            where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
            where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(host != null, "host");

            AsyncHelper.RunSync(() => manager.UpdateAsync(host));
        }

        /// <summary>
        /// Finds a host by id.
        /// </summary>
        /// <typeparam name="THost">The type of the host.</typeparam>
        /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
        /// <typeparam name="TUserRole">The type of the user role.</typeparam>
        /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
        /// <typeparam name="TGroup">The type of the group.</typeparam>
        /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
        /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
        /// <typeparam name="TAudit">The type of the audit.</typeparam>
        /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
        /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <returns></returns>
        public static THost FindById<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId)
            where THost : HyperHost<TKey, THost, THostDomain>, new()
            where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
            where TKey : struct, IEquatable<TKey>
            where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
            where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)));

            return AsyncHelper.RunSync(() => manager.FindByIdAsync(hostId));
        }

        /// <summary>
        /// Finds a host by name.
        /// </summary>
        /// <typeparam name="THost">The type of the host.</typeparam>
        /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
        /// <typeparam name="TUserRole">The type of the user role.</typeparam>
        /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
        /// <typeparam name="TGroup">The type of the group.</typeparam>
        /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
        /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
        /// <typeparam name="TAudit">The type of the audit.</typeparam>
        /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
        /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
        /// <param name="manager">The manager.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        public static THost FindByName<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string hostName)
            where THost : HyperHost<TKey, THost, THostDomain>, new()
            where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
            where TKey : struct, IEquatable<TKey>
            where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
            where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostName.IsNullOrWhiteSpace(), "hostName");

            return AsyncHelper.RunSync(() => manager.FindByNameAsync(hostName));
        }

        public static THost FindByDomain<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string domainName)
            where THost : HyperHost<TKey, THost, THostDomain>, new()
            where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
            where TKey : struct, IEquatable<TKey>
            where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
            where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!domainName.IsNullOrWhiteSpace(), "domainName");

            return AsyncHelper.RunSync(() => manager.FindByDomainAsync(domainName));
        }

        /// <summary>
        /// Gets the system host.
        /// </summary>
        /// <typeparam name="THost">The type of the host.</typeparam>
        /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
        /// <typeparam name="TUserRole">The type of the user role.</typeparam>
        /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
        /// <typeparam name="TGroup">The type of the group.</typeparam>
        /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
        /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
        /// <typeparam name="TAudit">The type of the audit.</typeparam>
        /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
        /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
        /// <param name="manager">The manager.</param>
        /// <returns></returns>
        public static THost GetSystemHost<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager)
            where THost : HyperHost<TKey, THost, THostDomain>, new()
            where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
            where TKey : struct, IEquatable<TKey>
            where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
            where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
            return AsyncHelper.RunSync(() => manager.GetSystemHostAsync());
        }

        /// <summary>
        /// Adds a domain to a host.
        /// </summary>
        /// <typeparam name="THost">The type of the host.</typeparam>
        /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
        /// <typeparam name="TUserRole">The type of the user role.</typeparam>
        /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
        /// <typeparam name="TGroup">The type of the group.</typeparam>
        /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
        /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
        /// <typeparam name="TAudit">The type of the audit.</typeparam>
        /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
        /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
        /// <param name="manager">The manager.</param>
        /// <param name="host">The host.</param>
        /// <param name="domainName">Name of the domain.</param>
        public static void AddDomain<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, THost host, string domainName)
            where THost : HyperHost<TKey, THost, THostDomain>, new()
            where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
            where TKey : struct, IEquatable<TKey>
            where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
            where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(host != null, "host");
            Contract.Requires<ArgumentNullException>(!domainName.IsNullOrWhiteSpace(), "domainName");

            AsyncHelper.RunSync(() => manager.AddDomainAsync(host, domainName));
        }

        /// <summary>
        /// Removes a domain from a host.
        /// </summary>
        /// <typeparam name="THost">The type of the host.</typeparam>
        /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
        /// <typeparam name="TUserRole">The type of the user role.</typeparam>
        /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
        /// <typeparam name="TGroup">The type of the group.</typeparam>
        /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
        /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
        /// <typeparam name="TAudit">The type of the audit.</typeparam>
        /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
        /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
        /// <param name="manager">The manager.</param>
        /// <param name="domainName">Name of the domain.</param>
        public static void RemoveDomain<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperHostManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string domainName)
            where THost : HyperHost<TKey, THost, THostDomain>, new()
            where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
            where TKey : struct, IEquatable<TKey>
            where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
            where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!domainName.IsNullOrWhiteSpace(), "domainName");

            AsyncHelper.RunSync(() => manager.RemoveDomainAsync(domainName));
        }
    }
}
