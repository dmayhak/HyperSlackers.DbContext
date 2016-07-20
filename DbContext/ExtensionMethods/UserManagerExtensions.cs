using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    public static class UserManagerExtensions
    {
        /// <summary>
        /// Return a user with the specified user name and password (for the specified host) or null if there is no match.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static TUser Find<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, string userName, string password)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userName.IsNullOrWhiteSpace(), "userName");
            Helpers.ThrowIfNull(!password.IsNullOrWhiteSpace(), "password");

            return AsyncHelper.RunSync(() => manager.FindAsync(hostId, userName, password));
        }

        /// <summary>
        /// Return a user with the specified user name and password (for the current host) or null if there is no match.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static TUser Find<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string userName, string password)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userName.IsNullOrWhiteSpace(), "userName");
            Helpers.ThrowIfNull(!password.IsNullOrWhiteSpace(), "password");

            return AsyncHelper.RunSync(() => manager.FindAsync(userName, password));
        }

        /// <summary>
        /// Return a user with the specified login info (for the specified host) or null if there is no match.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public static TUser Find<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, UserLoginInfo login)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(login != null, "login");

            return AsyncHelper.RunSync(() => manager.FindAsync(hostId, login));
        }

        /// <summary>
        /// Return a user with the specified login info (for the current host) or null if there is no match.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public static TUser Find<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, UserLoginInfo login)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(login != null, "login");

            return AsyncHelper.RunSync(() => manager.FindAsync(login));
        }

        /// <summary>
        /// Return a user with the specified login info (for the current host) or null if there is no match.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public static IList<TUser> FindAll<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, UserLoginInfo login)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(login != null, "login");

            return AsyncHelper.RunSync(() => manager.FindAllAsync(login));
        }

        /// <summary>
        /// Find a user by name (for the specified host)
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public static TUser FindByName<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, string userName)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userName.IsNullOrWhiteSpace(), "userName");

            return AsyncHelper.RunSync(() => manager.FindByNameAsync(hostId, userName));
        }

        /// <summary>
        /// Find a user by name (for the current host)
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public static TUser FindByName<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string userName)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userName.IsNullOrWhiteSpace(), "userName");

            return AsyncHelper.RunSync(() => manager.FindByNameAsync(userName));
        }

        /// <summary>
        /// Find a user by name (for the current host)
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public static IList<TUser> FindAllByName<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string userName)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userName.IsNullOrWhiteSpace(), "userName");

            return AsyncHelper.RunSync(() => manager.FindAllByNameAsync(userName));
        }

        /// <summary>
        /// Find a user by email (for the specified host)
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static TUser FindByEmail<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, string email)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!email.IsNullOrWhiteSpace(), "email");

            return AsyncHelper.RunSync(() => manager.FindByEmailAsync(hostId, email));
        }

        /// <summary>
        /// Find a user by email (for the current host)
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static TUser FindByEmail<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string email)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!email.IsNullOrWhiteSpace(), "email");

            return AsyncHelper.RunSync(() => manager.FindByEmailAsync(email));
        }

        /// <summary>
        /// Find a user by email (for the current host)
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static IList<TUser> FindAllByEmail<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, string email)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!email.IsNullOrWhiteSpace(), "email");

            return AsyncHelper.RunSync(() => manager.FindAllByEmailAsync(email));
        }

        /// <summary>
        /// Find a user by email (for the current host)
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static TUser FindById<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.FindByIdAsync(userId));
        }

        /// <summary>
        /// Add a user claim for the specified host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public static IdentityResult AddClaim<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, Claim claim)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(claim != null, "claim");

            return AsyncHelper.RunSync(() => manager.AddClaimAsync(hostId, userId, claim));
        }

        /// <summary>
        /// Add a user claim for the current host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public static IdentityResult AddClaim<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, Claim claim)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(claim != null, "claim");

            return AsyncHelper.RunSync(() => manager.AddClaimAsync(userId, claim));
        }

        /// <summary>
        /// Adds a login to a user.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public static IdentityResult AddLogin<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, UserLoginInfo login)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(login != null, "login");

            return AsyncHelper.RunSync(() => manager.AddLoginAsync(userId, login));
        }

        /// <summary>
        /// Adds a login to a user.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public static IdentityResult AddLogin<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, UserLoginInfo login)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(login != null, "login");

            return AsyncHelper.RunSync(() => manager.AddLoginAsync(hostId, userId, login));
        }

        /// <summary>
        /// Add a user to a group for the specified host. Group must belong to current host or be a global group.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public static IdentityResult AddToRoleGroup<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, TKey groupId, bool global = false)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!groupId.Equals(default(TKey)), "groupId");

            return AsyncHelper.RunSync(() => manager.AddToRoleGroupAsync(hostId, userId, groupId, global));
        }

        /// <summary>
        /// Add a user to a group for the specified host. Group must belong to current host or be a global group.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public static IdentityResult AddToRoleGroup<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, string groupName, bool global = false)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!groupName.IsNullOrWhiteSpace(), "groupName");

            return AsyncHelper.RunSync(() => manager.AddToRoleGroupAsync(hostId, userId, groupName, global));
        }

        /// <summary>
        /// Add a user to a group for the current host. Group must belong to current host or be a global group.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public static IdentityResult AddToRoleGroup<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, TKey groupId, bool global = false)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!groupId.Equals(default(TKey)), "groupId");

            return AsyncHelper.RunSync(() => manager.AddToRoleGroupAsync(userId, groupId, global));
        }

        /// <summary>
        /// Add a user to a group for the current host. Group must belong to current host or be a global group.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public static IdentityResult AddToRoleGroup<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, string groupName, bool global = false)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!groupName.IsNullOrWhiteSpace(), "groupName");

            return AsyncHelper.RunSync(() => manager.AddToRoleGroupAsync(userId, groupName, global));
        }

        /// <summary>
        /// Add a user to multiple groups for the specified host. Groups must belong to current host or be a global group.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public static IdentityResult AddToRoleGroups<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, params TKey[] groupIds)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(groupIds != null, "groupIds");

            return AsyncHelper.RunSync(() => manager.AddToRoleGroupsAsync(hostId, userId, groupIds));
        }

        /// <summary>
        /// Add a user to multiple groups for the specified host. Groups must belong to current host or be a global group.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupNames">The group names.</param>
        /// <returns></returns>
        public static IdentityResult AddToRoleGroups<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, params string[] groupNames)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(groupNames != null, "groupNames");

            return AsyncHelper.RunSync(() => manager.AddToRoleGroupsAsync(hostId, userId, groupNames));
        }

        /// <summary>
        /// Add a user to multiple group for the current host. Groups must belong to current host or be a global group.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupIds">The group ids.</param>
        /// <returns></returns>
        public static IdentityResult AddToRoleGroups<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, params TKey[] groupIds)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(groupIds != null, "groupIds");

            return AsyncHelper.RunSync(() => manager.AddToRoleGroupsAsync(userId, groupIds));
        }

        /// <summary>
        /// Add a user to a group for the current host. Group must belong to current host or be a global group.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupNames">The group names.</param>
        /// <returns></returns>
        public static IdentityResult AddToRoleGroups<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, params string[] groupNames)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(groupNames != null, "groupNames");

            return AsyncHelper.RunSync(() => manager.AddToRoleGroupsAsync(userId, groupNames));
        }

        /// <summary>
        /// Add a user to a role for the current host. Role must belong to current host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public static IdentityResult AddToRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, string roleName, bool global = false)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleName.IsNullOrWhiteSpace(), "roleName");

            return AsyncHelper.RunSync(() => manager.AddToRoleAsync(userId, roleName, global));
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to the specified host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public static IdentityResult AddToRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, string roleName, bool global = false)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleName.IsNullOrWhiteSpace(), "roleName");

            return AsyncHelper.RunSync(() => manager.AddToRoleAsync(hostId, userId, roleName, global));
        }

        /// <summary>
        /// Add a user to a role for the current host. Role must belong to current host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public static IdentityResult AddToRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, TKey roleId, bool global = false)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleId.Equals(default(TKey)), "roleId");

            return AsyncHelper.RunSync(() => manager.AddToRoleAsync(userId, roleId, global));
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to the specified host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public static IdentityResult AddToRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, TKey roleId, bool global = false)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleId.Equals(default(TKey)), "roleId");

            return AsyncHelper.RunSync(() => manager.AddToRoleAsync(hostId, userId, roleId, global));
        }

        /// <summary>
        /// Add a user to multiple roles for the current host. Roles must belong to current host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleNames">The role names.</param>
        /// <returns></returns>
        public static IdentityResult AddToRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, params string[] roleNames)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(roleNames != null, "roleNames");

            return AsyncHelper.RunSync(() => manager.AddToRolesAsync(userId, roleNames));
        }

        /// <summary>
        /// Add a user to multiple roles for the specified host. Roles must belong to the specified host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleNames">The role names.</param>
        /// <returns></returns>
        public static IdentityResult AddToRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, params string[] roleNames)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(roleNames != null, "roleNames");

            return AsyncHelper.RunSync(() => manager.AddToRolesAsync(hostId, userId, roleNames));
        }

        /// <summary>
        /// Add a user to multiple roles for the current host. Roles must belong to current host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public static IdentityResult AddToRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, params TKey[] roleIds)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(roleIds != null, "roleIds");

            return AsyncHelper.RunSync(() => manager.AddToRolesAsync(userId, roleIds));
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to the specified host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public static IdentityResult AddToRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, params TKey[] roleIds)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(roleIds != null, "roleIds");

            return AsyncHelper.RunSync(() => manager.AddToRolesAsync(hostId, userId, roleIds));
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to the specified host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static IdentityResult Create<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TUser user, string password)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(user != null, "user");
            Helpers.ThrowIfNull(!password.IsNullOrWhiteSpace(), "password");

            return AsyncHelper.RunSync(() => manager.CreateAsync(user, password));
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to the specified host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IdentityResult Delete<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.DeleteAsync(userId));
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to the specified host or be a global role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static IdentityResult Delete<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TUser user)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(user != null, "user");

            return AsyncHelper.RunSync(() => manager.DeleteAsync(user));
        }

        /// <summary>
        /// Creates a ClaimsIdentity representing the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="authenticationType">the authentication type.</param>
        /// <returns></returns>
        public static ClaimsIdentity CreateIdentity<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TUser user, string authenticationType)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(user != null, "user");
            Helpers.ThrowIfNull(!authenticationType.IsNullOrWhiteSpace(), "authenticationType");

            return AsyncHelper.RunSync(() => manager.CreateIdentityAsync(user, authenticationType));
        }

        /// <summary>
        /// Get a users's claims for the specified host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<Claim> GetClaims<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetClaimsAsync(hostId, userId));
        }

        /// <summary>
        /// Get a users's claims for the current host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<Claim> GetClaims<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetClaimsAsync(userId));
        }

        /// <summary>
        /// Get a users's claims for the current host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<Claim> GetAllClaims<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetAllClaimsAsync(userId));
        }

        /// <summary>
        /// Get a users's claims for the specified host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<UserLoginInfo> GetLogins<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetLoginsAsync(hostId, userId));
        }

        /// <summary>
        /// Get a users's claims for the current host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<UserLoginInfo> GetLogins<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetLoginsAsync(userId));
        }

        /// <summary>
        /// Get a users's claims for the current host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<UserLoginInfo> GetAllLogins<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetAllLoginsAsync(userId));
        }

        /// <summary>
        /// Get a users's roles
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<string> GetRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetRolesAsync(hostId, userId));
        }

        /// <summary>
        /// Get a users's roles
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<string> GetRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetRolesAsync(userId));
        }

        /// <summary>
        /// Get a users's roles
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<TRole> GetAllRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetAllRolesAsync(userId));
        }

        /// <summary>
        /// Get a users's roles
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<TUserRole> GetAllUserRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetAllUserRolesAsync(userId));
        }

        /// <summary>
        /// Returns true if the user is in the specified role for the specified host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">manager</exception>
        public static bool IsInRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, string roleName)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleName.IsNullOrWhiteSpace(), "roleName");

            return AsyncHelper.RunSync(() => manager.IsInRoleAsync(hostId, userId, roleName));
        }

        /// <summary>
        /// Returns true if the user is in the specified role for the current host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">manager</exception>
        public static bool IsInRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, string roleName)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleName.IsNullOrWhiteSpace(), "roleName");

            return AsyncHelper.RunSync(() => manager.IsInRoleAsync(userId, roleName));
        }

        /// <summary>
        /// Returns true if the user is in the specified role for the specified host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">manager</exception>
        public static bool IsInRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, TKey roleId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleId.Equals(default(TKey)), "roleId");

            return AsyncHelper.RunSync(() => manager.IsInRoleAsync(hostId, userId, roleId));
        }

        /// <summary>
        /// Returns true if the user is in the specified role for the current host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">manager</exception>
        public static bool IsInRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, TKey roleId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleId.Equals(default(TKey)), "roleId");

            return AsyncHelper.RunSync(() => manager.IsInRoleAsync(userId, roleId));
        }

        /// <summary>
        /// Remove a user claim for the specified host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public static IdentityResult RemoveClaim<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, Claim claim)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(claim != null, "claim");

            return AsyncHelper.RunSync(() => manager.RemoveClaimAsync(hostId, userId, claim));
        }

        /// <summary>
        /// Remove a user claim for the current host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public static IdentityResult RemoveClaim<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, Claim claim)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(claim != null, "claim");

            return AsyncHelper.RunSync(() => manager.RemoveClaimAsync(userId, claim));
        }

        /// <summary>
        /// Remove a user from a group for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoleGroup<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, string groupName)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!groupName.IsNullOrWhiteSpace(), "groupName");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleGroupAsync(hostId, userId, groupName));
        }

        /// <summary>
        /// Remove a user from a group for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoleGroup<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, string groupName)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!groupName.IsNullOrWhiteSpace(), "groupName");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleGroupAsync(userId, groupName));
        }

        /// <summary>
        /// Remove a user from a group for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoleGroup<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, TKey groupId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!groupId.Equals(default(TKey)), "groupId");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleGroupAsync(hostId, userId, groupId));
        }

        /// <summary>
        /// Remove a user from a group for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoleGroup<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, TKey groupId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!groupId.Equals(default(TKey)), "groupId");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleGroupAsync(userId, groupId));
        }

        /// <summary>
        /// Remove a user from a group for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupNames">The group names.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoleGroups<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, params string[] groupNames)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(groupNames != null, "groupNames");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleGroupsAsync(hostId, userId, groupNames));
        }

        /// <summary>
        /// Remove a user from a group for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupNames">The group names.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoleGroup<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, params string[] groupNames)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(groupNames != null, "groupNames");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleGroupsAsync(userId, groupNames));
        }

        /// <summary>
        /// Remove a user from a group for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupIds">The group ids.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoleGroups<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, params TKey[] groupIds)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(groupIds != null, "groupIds");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleGroupsAsync(hostId, userId, groupIds));
        }

        /// <summary>
        /// Remove a user from a group for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupIds">The group ids.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoleGroups<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, params TKey[] groupIds)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(groupIds != null, "groupIds");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleGroupsAsync(userId, groupIds));
        }

        /// <summary>
        /// Remove a user from a role for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, string roleName)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleName.IsNullOrWhiteSpace(), "roleName");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleAsync(hostId, userId, roleName));
        }

        /// <summary>
        /// Remove a user from a role for the current host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, string roleName)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleName.IsNullOrWhiteSpace(), "roleName");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleAsync(userId, roleName));
        }

        /// <summary>
        /// Remove a user from a role for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, TKey roleId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleId.Equals(default(TKey)), "roleId");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleAsync(hostId, userId, roleId));
        }

        /// <summary>
        /// Remove a user from a role for the current host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, TKey roleId)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(!roleId.Equals(default(TKey)), "roleId");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleAsync(userId, roleId));
        }

        /// <summary>
        /// Remove a user from a role for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleNames">The role names.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, params string[] roleNames)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(roleNames != null, "roleNames");

            return AsyncHelper.RunSync(() => manager.RemoveFromRolesAsync(hostId, userId, roleNames));
        }

        /// <summary>
        /// Remove a user from a role for the current host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleNames">The role names.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, params string[] roleNames)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(roleNames != null, "roleNames");

            return AsyncHelper.RunSync(() => manager.RemoveFromRolesAsync(userId, roleNames));
        }

        /// <summary>
        /// Remove a user from a role for the specified host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, params TKey[] roleIds)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(roleIds != null, "roleIds");

            return AsyncHelper.RunSync(() => manager.RemoveFromRolesAsync(hostId, userId, roleIds));
        }

        /// <summary>
        /// Remove a user from a role for the current host.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, params TKey[] roleIds)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(roleIds != null, "roleIds");

            return AsyncHelper.RunSync(() => manager.RemoveFromRolesAsync(userId, roleIds));
        }

        /// <summary>
        /// Remove a user claim for the specified host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public static IdentityResult RemoveLogin<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, UserLoginInfo login)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(login != null, "login");

            return AsyncHelper.RunSync(() => manager.RemoveLoginAsync(hostId, userId, login));
        }

        /// <summary>
        /// Remove a user claim for the current host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public static IdentityResult RemoveLogin<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey userId, UserLoginInfo login)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(!userId.Equals(default(TKey)), "userId");
            Helpers.ThrowIfNull(login != null, "login");

            return AsyncHelper.RunSync(() => manager.RemoveLoginAsync(userId, login));
        }

        /// <summary>
        /// Remove a user claim for the specified host
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static IdentityResult Update<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TUser user)
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
            Helpers.ThrowIfNull(manager != null, "manager");
            Helpers.ThrowIfNull(user != null, "user");

            return AsyncHelper.RunSync(() => manager.UpdateAsync(user));
        }

    }
}
