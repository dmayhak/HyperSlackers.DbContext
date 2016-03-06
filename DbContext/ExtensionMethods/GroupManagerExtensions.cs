using System;
using System.Diagnostics.Contracts;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;
using System.Collections.Generic;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    public static class GroupManagerExtensions
    {
        /// <summary>
        /// Creates a RoleGroup for the specified host (or global).
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
        /// <param name="groupName">Name of the group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        public static void Create<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, string groupName, bool global = false)
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
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            AsyncHelper.RunSync(() => manager.CreateAsync(hostId, groupName, global));
        }

        /// <summary>
        /// Creates a RoleGroup for the current host (or global).
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
        /// <param name="groupName">Name of the group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        public static void Create<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string groupName, bool global = false)
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
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            AsyncHelper.RunSync(() => manager.CreateAsync(groupName, global));
        }

        /// <summary>
        /// Creates a RoleGroup for the current host (or global).
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
        /// <param name="group">The group.</param>
        public static void Create<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TGroup group)
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
            Contract.Requires<ArgumentNullException>(group != null, "group");

            AsyncHelper.RunSync(() => manager.CreateAsync(group));
        }

        /// <summary>
        /// Deletes the specified group.
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
        /// <param name="group">The group.</param>
        public static void Delete<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TGroup group)
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
            Contract.Requires<ArgumentNullException>(group != null, "group");

            AsyncHelper.RunSync(() => manager.DeleteAsync(group));
        }

        /// <summary>
        /// Updates the specified group.
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
        /// <param name="group">The group.</param>
        public static void Update<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TGroup group)
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
            Contract.Requires<ArgumentNullException>(group != null, "group");

            AsyncHelper.RunSync(() => manager.UpdateAsync(group));
        }

        /// <summary>
        /// Finds a group by Id.
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
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public static TGroup FindById<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey groupId)
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
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)), "groupId");

            return AsyncHelper.RunSync(() => manager.FindByIdAsync(groupId));
        }

        /// <summary>
        /// Find a group by name for the current host (or global).
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
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public static TGroup FindByName<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string groupName)
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
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            return AsyncHelper.RunSync(() => manager.FindByNameAsync(groupName));
        }

        /// <summary>
        /// Find a group by name for the current host (or global).
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
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public static TGroup FindByName<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, string groupName)
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
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            return AsyncHelper.RunSync(() => manager.FindByNameAsync(hostId, groupName));
        }

        /// <summary>
        /// Find a group by name for the current host (or global).
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
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public static IList<TRole> GetRoles<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey groupId)
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
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)), "groupId");

            return AsyncHelper.RunSync(() => manager.GetRolesAsync(groupId));
        }

        /// <summary>
        /// Find a group by name for the current host (or global).
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
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public static IList<TUser> GetUsers<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey groupId)
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
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)), "groupId");

            return AsyncHelper.RunSync(() => manager.GetUsersAsync(groupId));
        }

        /// <summary>
        /// Deletes the specified group.
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
        /// <param name="group">The group.</param>
        /// <param name="role">The role.</param>
        public static void AddRole<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TGroup group, TRole role)
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
            Contract.Requires<ArgumentNullException>(group != null, "group");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            AsyncHelper.RunSync(() => manager.AddRoleAsync(group, role));
        }

        /// <summary>
        /// Deletes the specified group.
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
        /// <param name="group">The group.</param>
        /// <param name="role">The role.</param>
        public static void RemoveRole<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperGroupManager<THost, THostDomain, TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TGroup group, TRole role)
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
            Contract.Requires<ArgumentNullException>(group != null, "group");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            AsyncHelper.RunSync(() => manager.RemoveRoleAsync(group, role));
        }

    }
}
