using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        /// Return a user with the specified user name and password or null if there is no match.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static TUser Find<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, string userName, string password)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");
            Contract.Requires<ArgumentNullException>(!password.IsNullOrWhiteSpace(), "password");

            return AsyncHelper.RunSync(() => manager.FindAsync(hostId, userName, password));
        }

        /// <summary>
        /// Find a user by name
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public static TUser FindByName<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, string userName)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");

            return AsyncHelper.RunSync(() => manager.FindByNameAsync(hostId, userName));
        }

        /// <summary>
        /// Find a user by email
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static TUser FindByEmail<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, string email)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!email.IsNullOrWhiteSpace(), "email");

            return AsyncHelper.RunSync(() => manager.FindByEmailAsync(hostId, email));
        }

        /// <summary>
        /// Sync extension
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public static TUser Find<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, UserLoginInfo login)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(login != null, "login");

            return AsyncHelper.RunSync(() => manager.FindAsync(hostId, login));
        }

        /// <summary>
        /// Add a user claim
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public static IdentityResult AddClaim<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, Claim claim)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(claim != null, "claim");

            return AsyncHelper.RunSync(() => manager.AddClaimAsync(hostId, userId, claim));
        }

        /// <summary>
        /// Remove a user claim
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public static IdentityResult RemoveClaim<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, Claim claim)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(claim != null, "claim");

            return AsyncHelper.RunSync(() => manager.RemoveClaimAsync(hostId, userId, claim));
        }

        /// <summary>
        /// Get a users's claims
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<Claim> GetClaims<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetClaimsAsync(hostId, userId));
        }

        /// <summary>
        /// Add a user to a role
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public static IdentityResult AddToRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, string roleName)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            return AsyncHelper.RunSync(() => manager.AddToRoleAsync(hostId, userId, roleName));
        }

        /// <summary>
        /// Remove a user from a role.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public static IdentityResult RemoveFromRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, string roleName)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            return AsyncHelper.RunSync(() => manager.RemoveFromRoleAsync(hostId, userId, roleName));
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
        /// <typeparam name="TGroup">The type of the group.</typeparam>
        /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
        /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
        /// <typeparam name="TAudit">The type of the audit.</typeparam>
        /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
        /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static IList<string> GetRoles<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            return AsyncHelper.RunSync(() => manager.GetRolesAsync(hostId, userId));
        }

        /// <summary>
        /// Returns true if the user is in the specified role
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
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
        /// <param name="manager">The manager.</param>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">manager</exception>
        public static bool IsInRole<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>(this HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager, TKey hostId, TKey userId, string roleName)
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
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            return AsyncHelper.RunSync(() => manager.IsInRoleAsync(userId, roleName));
        }
    }
}
