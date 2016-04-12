using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Exposes user related API for a multi-tenant <c>DbContext</c> which will automatically save changes to the <c>UserStore</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperUserManagerGuid<TUser> : HyperUserManager<TUser, HyperRoleGuid, Guid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperHostGuid, HyperHostDomainGuid, HyperRoleGroupGuid, HyperRoleGroupRoleGuid, HyperRoleGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserManagerGuid" /> class.
        /// </summary>
        /// <param name="store">The <c>UserStore</c>.</param>
        public HyperUserManagerGuid(HyperUserStoreGuid<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");

            this.UserValidator = new HyperUserValidatorGuid<TUser>(this);
        }
    }

    /// <summary>
    /// Exposes user related API for a multi-tenant <c>DbContext</c> which will automatically save changes to the <c>UserStore</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperUserManagerInt<TUser> : HyperUserManager<TUser, HyperRoleInt, int, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperHostInt, HyperHostDomainInt, HyperRoleGroupInt, HyperRoleGroupRoleInt, HyperRoleGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserManagerInt" /> class.
        /// </summary>
        /// <param name="store">The <c>UserStore</c>.</param>
        public HyperUserManagerInt(HyperUserStoreInt<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");

            this.UserValidator = new HyperUserValidatorInt<TUser>(this);
        }
    }

    /// <summary>
    /// Exposes user related API for a multi-tenant <c>DbContext</c> which will automatically save changes to the <c>UserStore</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperUserManagerLong<TUser> : HyperUserManager<TUser, HyperRoleLong, long, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperHostLong, HyperHostDomainLong, HyperRoleGroupLong, HyperRoleGroupRoleLong, HyperRoleGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserManagerLong" /> class.
        /// </summary>
        /// <param name="store">The <c>UserStore</c>.</param>
        public HyperUserManagerLong(HyperUserStoreLong<TUser> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");

            this.UserValidator = new HyperUserValidatorLong<TUser>(this);
        }
    }

    /// <summary>
    /// Exposes user related API for a multi-tenant <c>DbContext</c> which will automatically save changes to the <c>UserStore</c>.
    /// </summary>
    /// <typeparam name="TUser">A user type derived from <c>IdentityUserMultiHost{TKey, TKey}</c>.</typeparam>
    /// <typeparam name="TRole">The type of the role.</typeparam>
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
    public class HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> : UserManager<TUser, TKey>
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
        protected internal readonly HyperUserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> HyperUserStore;
        private bool disposed = false;

        public bool MultiHostEnabled { get { return HyperUserStore.MultiHostEnabled; } }
        public TKey SystemHostId { get { return HyperUserStore.SystemHostId; } }
        public TKey HostId { get { return HyperUserStore.CurrentHostId; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserManager{TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty}"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public HyperUserManager(HyperUserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TRoleGroup, TRoleGroupRole, TRoleGroupUser, TAudit, TAuditItem, TAuditProperty> store)
            : base(store)
        {
            Contract.Requires<ArgumentNullException>(store != null, "store");

            this.HyperUserStore = store;

            // allow duplicate emails and funky chars
            this.UserValidator = new UserValidator<TUser, TKey>(this) { AllowOnlyAlphanumericUserNames = false, RequireUniqueEmail = false };
        }

        /// <summary>
        ///     Returns an IQueryable of users (for the current and system host) if the store is an IQueryableUserStore
        /// </summary>
        public override IQueryable<TUser> Users
        {
            get
            {
                var users = base.Users;
                var hostId = this.HostId;

                return users.Where(u => u.HostId.Equals(hostId) || u.IsGlobal);
            }
        }

        /// <summary>
        ///     Returns an IQueryable of users (for all hosts) if the store is an IQueryableUserStore
        /// </summary>
        public virtual IQueryable<TUser> AllUsers
        {
            get
            {
                return base.Users;
            }
        }

        /// <summary>
        /// Add a user claim for the current host.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> AddClaimAsync(TKey userId, System.Security.Claims.Claim claim)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(claim != null, "claim");

            ThrowIfDisposed();

            return await AddClaimAsync(this.HostId, userId, claim);
        }

        /// <summary>
        /// Add a user claim for the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddClaimAsync(TKey hostId, TKey userId, Claim claim)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(claim != null, "claim");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.AddClaimAsync(hostId, user, claim).WithCurrentCulture();

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Associate a login with a user for the current host.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> AddLoginAsync(TKey userId, UserLoginInfo login)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            var existingUser = await FindAsync(this.HostId, login).WithCurrentCulture();
            if (existingUser != null)
            {
                return IdentityResult.Failed("External login already exists");
            }

            await HyperUserStore.AddLoginAsync(this.HostId, user, login);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Associate a login with a user for the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddLoginAsync(TKey hostId, TKey userId, UserLoginInfo login)
        {
            //x Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            var existingUser = await FindAsync(hostId, login).WithCurrentCulture();
            if (existingUser != null)
            {
                return IdentityResult.Failed("External login already exists");
            }

            await HyperUserStore.AddLoginAsync(hostId, user, login);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Add a user to a group for the current host. Group must belong to current host or be a global group.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRoleGroupAsync(TKey userId, string groupName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            return await AddToRoleGroupAsync(this.HostId, userId, groupName, global);
        }

        /// <summary>
        /// Add a user to a group for the specified host. Group must belong to specified host or be a global group.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddToRoleGroupAsync(TKey hostId, TKey userId, string groupName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.AddToRoleGroupAsync(hostId, user, groupName, global);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Method to add user to multiple groups for the current host. Group names must belong to
        /// the current host or be global.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupNames">The groups.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRoleGroupsAsync(TKey userId, params string[] groupNames)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groupNames != null, "groupNames");

            ThrowIfDisposed();

            return await AddToRoleGroupsAsync(this.HostId, userId, groupNames);
        }

        /// <summary>
        /// Method to add user to multiple groups.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupNames">The groups.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddToRoleGroupsAsync(TKey hostId, TKey userId, params string[] groupNames)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groupNames != null, "groupNames");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            foreach (var groupName in groupNames)
            {
                await HyperUserStore.AddToRoleGroupAsync(hostId, user, groupName);
            }

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Add a user to a group for the current host. Group must belong to current host or be a global group.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRoleGroupAsync(TKey userId, TKey groupId, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)), "groupId");

            ThrowIfDisposed();

            return await AddToRoleGroupAsync(this.HostId, userId, groupId, global);
        }

        /// <summary>
        /// Add a user to a group for the specified host. Group must belong to specified host or be a global group.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddToRoleGroupAsync(TKey hostId, TKey userId, TKey groupId, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)), "groupId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.AddToRoleGroupAsync(hostId, user, groupId, global);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Method to add user to multiple groups for the current host. Groups must belong to
        /// the current host or be global.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupIds">The group ids.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRoleGroupsAsync(TKey userId, params TKey[] groupIds)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groupIds != null, "groupIds");

            ThrowIfDisposed();

            return await AddToRoleGroupsAsync(this.HostId, userId, groupIds);
        }

        /// <summary>
        /// Method to add user to multiple groups.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupIds">The group ids.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddToRoleGroupsAsync(TKey hostId, TKey userId, params TKey[] groupIds)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groupIds != null, "groupIds");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            foreach (var groupId in groupIds)
            {
                await HyperUserStore.AddToRoleGroupAsync(hostId, user, groupId);
            }

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Add a user to a group for the current host. Group must belong to current host or be a global group.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRoleGroupAsync(TKey userId, TRoleGroup group)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisposed();

            return await AddToRoleGroupAsync(this.HostId, userId, group);
        }

        /// <summary>
        /// Add a user to a group for the specified host. Group must belong to specified host or be a global group.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddToRoleGroupAsync(TKey hostId, TKey userId, TRoleGroup group)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.AddToRoleGroupAsync(hostId, user, group);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Method to add user to multiple groups for the current host. Group names must belong to
        /// the current host or be global.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groups">The groups.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRoleGroupsAsync(TKey userId, params TRoleGroup[] groups)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groups != null, "groups");

            ThrowIfDisposed();

            return await AddToRoleGroupsAsync(this.HostId, userId, groups);
        }

        /// <summary>
        /// Method to add user to multiple groups.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groups">The groups.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddToRoleGroupsAsync(TKey hostId, TKey userId, params TRoleGroup[] groups)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groups != null, "groups");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            foreach (var group in groups)
            {
                await HyperUserStore.AddToRoleGroupAsync(hostId, user, group);
            }

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Add a user to a role for the current host. Role must belong to current host or be a global role.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> AddToRoleAsync(TKey userId, string roleName)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await AddToRoleAsync(this.HostId, userId, roleName);
        }

        /// <summary>
        /// Add a user to a role for the current host. Role must belong to current host or be a global role.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRoleAsync(TKey userId, string roleName, bool global)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await AddToRoleAsync(this.HostId, userId, roleName, global);
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to specified host or be a global role.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddToRoleAsync(TKey hostId, TKey userId, string roleName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.AddToRoleAsync(hostId, user, roleName, global);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Add a user to a role for the current host. Role must belong to current host or be a global role.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRoleAsync(TKey userId, TKey roleId, bool global = false)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(!roleId.Equals(default(TKey)), "roleId");

            ThrowIfDisposed();

            return await AddToRoleAsync(this.HostId, userId, roleId, global);
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to specified host or be a global role.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddToRoleAsync(TKey hostId, TKey userId, TKey roleId, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleId.Equals(default(TKey)), "roleId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.AddToRoleAsync(hostId, user, roleId, global);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Method to add user to multiple roles for the current host. Role names must belong to
        /// the current host or be a global role.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleNames">The roles.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> AddToRolesAsync(TKey userId, params string[] roleNames)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(roleNames != null, "roleNames");

            ThrowIfDisposed();

            return await AddToRolesAsync(this.HostId, userId, roleNames);
        }

        /// <summary>
        /// Method to add user to multiple roles.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleNames">The roles.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRolesAsync(TKey hostId, TKey userId, params string[] roleNames)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(roleNames != null, "roleNames");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            foreach (var roleName in roleNames)
            {
                await HyperUserStore.AddToRoleAsync(hostId, user, roleName);
            }

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Method to add user to multiple roles for the current host. Roles must belong to
        /// the current host or be a global role.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> AddToRolesAsync(TKey userId, params TKey[] roleIds)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(roleNames != null, "roleNames");

            ThrowIfDisposed();

            return await AddToRolesAsync(this.HostId, userId, roleIds);
        }

        /// <summary>
        /// Method to add user to multiple roles.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> AddToRolesAsync(TKey hostId, TKey userId, params TKey[] roleIds)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(roleIds != null, "roleIds");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            foreach (var roleId in roleIds)
            {
                await HyperUserStore.AddToRoleAsync(hostId, user, roleId);
            }

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Create a user with no password for the host specified in user.HostId, or current host if not specified.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> CreateAsync(TUser user)
        {
            //x Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            if (user.HostId.Equals(default(TKey)))
            {
                user.HostId = this.HostId;
            }

            if (user.IsGlobal && !user.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global users must belong to system host.");
            }

            var result = await UserValidator.ValidateAsync(user).WithCurrentCulture();
            if (!result.Succeeded)
            {
                return result;
            }

            await HyperUserStore.CreateAsync(user);

            return IdentityResult.Success;
        }

        /// <summary>
        /// Create a user with the given password for the host specified in user.HostId, or current host if not specified.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> CreateAsync(TUser user, string password)
        {
            //x Contract.Requires<ArgumentNullException>(user != null, "user");
            //x Contract.Requires<ArgumentNullException>(!password.IsNullOrWhiteSpace(), "password");

            ThrowIfDisposed();

            if (user.HostId.Equals(default(TKey)))
            {
                user.HostId = this.HostId;
            }

            if (user.IsGlobal && !user.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global users must belong to system host.");
            }

            var result = await UpdatePassword(HyperUserStore, user, password).WithCurrentCulture();
            if (!result.Succeeded)
            {
                return result;
            }

            return await CreateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> DeleteAsync(TKey userId)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            return await DeleteAsync(user);
        }

        /// <summary>
        ///     Delete a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public override async Task<IdentityResult> DeleteAsync(TUser user)
        {
            //x Contract.Requires<ArgumentNullException>(user != null, "user");

            await HyperUserStore.DeleteAsync(user).WithCurrentCulture();

            return IdentityResult.Success;
        }

        /// <summary>
        /// Returns the user associated with this login. Only users for the current host or global users are returned.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public override async Task<TUser> FindAsync(UserLoginInfo login)
        {
            //x Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            return await FindAsync(this.HostId, login);
        }

        /// <summary>
        /// Returns the user associated with this login. Only users for the specified host or global users are returned.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public virtual async Task<TUser> FindAsync(TKey hostId, UserLoginInfo login)
        {
            Contract.Requires<ArgumentNullException>(!hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            return await HyperUserStore.FindAsync(hostId, login);
        }

        /// <summary>
        /// Returns the user associated with this login. Only users for the current host or global users are returned.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public virtual async Task<IList<TUser>> FindAllAsync(UserLoginInfo login)
        {
            //x Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            return await HyperUserStore.FindAllAsync(login);
        }

        /// <summary>
        /// Find a user by their email. Only users for the current host or global users are returned.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public override async Task<TUser> FindByEmailAsync(string email)
        {
            //x Contract.Requires<ArgumentNullException>(!email.IsNullOrWhiteSpace(), "email");

            ThrowIfDisposed();

            return await FindByEmailAsync(this.HostId, email);
        }

        /// <summary>
        /// Find a user by their email. Only users for the specified host or global users are returned.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public virtual async Task<TUser> FindByEmailAsync(TKey hostId, string email)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!email.IsNullOrWhiteSpace(), "email");

            ThrowIfDisposed();

            return await HyperUserStore.FindByEmailAsync(hostId, email);
        }

        /// <summary>
        /// Find all users (for all hosts) with the given email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public virtual async Task<IList<TUser>> FindAllByEmailAsync(string email)
        {
            Contract.Requires<ArgumentNullException>(!email.IsNullOrWhiteSpace(), "email");

            ThrowIfDisposed();

            return await HyperUserStore.FindAllByEmailAsync(email);
        }

        /// <summary>
        ///     Find a user by id for any host
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public override async Task<TUser> FindByIdAsync(TKey userId)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            return await HyperUserStore.FindByIdAsync(userId); // does the find across all hosts
        }

        /// <summary>
        /// Find a user by user name. Only users for the current host or global users are returned.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public override async Task<TUser> FindByNameAsync(string userName)
        {
            //x Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");

            ThrowIfDisposed();

            return await FindByNameAsync(this.HostId, userName);
        }

        /// <summary>
        /// Find a user by user name. Only users for the specified host or global users are returned.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public virtual async Task<TUser> FindByNameAsync(TKey hostId, string userName)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");

            ThrowIfDisposed();

            return await HyperUserStore.FindByNameAsync(hostId, userName);
        }

        /// <summary>
        /// Find all users (for all hosts) with the given userName.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public virtual async Task<IList<TUser>> FindAllByNameAsync(string userName)
        {
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");

            ThrowIfDisposed();

            return await HyperUserStore.FindAllByNameAsync(userName);
        }

        /// <summary>
        /// Returns the user associated with this login for the current host or is a global user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public override async Task<TUser> FindAsync(string userName, string password)
        {
            //x Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");
            //x Contract.Requires<ArgumentNullException>(!password.IsNullOrWhiteSpace(), "password");

            ThrowIfDisposed();

            return await FindAsync(this.HostId, userName, password);
        }

        /// <summary>
        /// Returns the user associated with this login for the specified host or system host if specified.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public virtual async Task<TUser> FindAsync(TKey hostId, string userName, string password)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");
            Contract.Requires<ArgumentNullException>(!password.IsNullOrWhiteSpace(), "password");

            ThrowIfDisposed();

            var user = await FindByNameAsync(hostId, userName).WithCurrentCulture();

            if (user == null)
            {
                return null;
            }

            return await CheckPasswordAsync(user, password).WithCurrentCulture() ? user : null;
        }

        /// <summary>
        /// Creates a ClaimsIdentity representing the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="authenticationType">the authentication type.</param>
        /// <returns></returns>
        public override async Task<ClaimsIdentity> CreateIdentityAsync(TUser user, string authenticationType)
        {
            //x Contract.Requires<ArgumentNullException>(user != null, "user");
            //x Contract.Requires<ArgumentNullException>(!authenticationType.IsNullOrWhiteSpace(), "authenticationType");

            ThrowIfDisposed();

            //TODO: any custom logic here?

            return await base.CreateIdentityAsync(user, authenticationType);
        }

        /// <summary>
        /// Get a users's claims for current or global host.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public override async Task<IList<Claim>> GetClaimsAsync(TKey userId)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            ThrowIfDisposed();

            return await GetClaimsAsync(this.HostId, userId);
        }

        /// <summary>
        /// Get a users's claims for specified host or global.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IList<Claim>> GetClaimsAsync(TKey hostId, TKey userId)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            return await HyperUserStore.GetClaimsAsync(hostId, user);
        }

        /// <summary>
        /// Get a users's claims for all hosts.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public virtual async Task<IList<Claim>> GetAllClaimsAsync(TKey userId)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            return await HyperUserStore.GetAllClaimsAsync(user);
        }

        /// <summary>
        ///     Gets the logins for a user for the current host.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public override async Task<IList<UserLoginInfo>> GetLoginsAsync(TKey userId)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            return await GetLoginsAsync(this.HostId, userId);
        }

        /// <summary>
        /// Gets the logins for a user for the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public virtual async Task<IList<UserLoginInfo>> GetLoginsAsync(TKey hostId, TKey userId)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            return await HyperUserStore.GetLoginsAsync(hostId, user);
        }

        /// <summary>
        /// Gets all logins for a user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IList<UserLoginInfo>> GetAllLoginsAsync(TKey userId)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            return await HyperUserStore.GetAllLoginsAsync(user);
        }

        /// <summary>
        /// Returns the current host and global roles for the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public override async Task<IList<string>> GetRolesAsync(TKey userId)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            ThrowIfDisposed();

            return await GetRolesAsync(this.HostId, userId);
        }

        /// <summary>
        /// Returns the host and global roles for the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public virtual async Task<IList<string>> GetRolesAsync(TKey hostId, TKey userId)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            return await HyperUserStore.GetRolesAsync(hostId, user);
        }

        /// <summary>
        /// Returns all the roles for the user for all hosts.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public virtual async Task<IList<TRole>> GetAllRolesAsync(TKey userId)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            return await HyperUserStore.GetAllRolesAsync(user);
        }

        /// <summary>
        /// Returns all the UserRoles for the user for all hosts.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public virtual async Task<IList<TUserRole>> GetAllUserRolesAsync(TKey userId)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            return await HyperUserStore.GetAllUserRolesAsync(user);
        }

        /// <summary>
        /// Determines whether the specified user is in the specified role. Checks global roles and current host roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public override async Task<bool> IsInRoleAsync(TKey userId, string roleName)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await IsInRoleAsync(this.HostId, userId, roleName);
        }

        /// <summary>
        /// Determines whether the specified user is in the specified role. Checks global roles and specified host roles.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>
        ///   <c>true</c> if user is in the role, <c>false</c> otherwise
        /// </returns>
        public virtual async Task<bool> IsInRoleAsync(TKey hostId, TKey userId, string roleName)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            return await HyperUserStore.IsInRoleAsync(hostId, user, roleName);
        }

        /// <summary>
        /// Determines whether the specified user is in the specified role. Checks global roles and current host roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public virtual async Task<bool> IsInRoleAsync(TKey userId, TKey roleId)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleId.Equals(default(TKey)), "roleId");

            ThrowIfDisposed();

            return await IsInRoleAsync(this.HostId, userId, roleId);
        }

        /// <summary>
        /// Determines whether the specified user is in the specified role. Checks global roles and specified host roles.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns>
        ///   <c>true</c> if user is in the role, <c>false</c> otherwise
        /// </returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<bool> IsInRoleAsync(TKey hostId, TKey userId, TKey roleId)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleId.Equals(default(TKey)), "roleId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            var role = await HyperUserStore.HyperContext.Roles.FirstOrDefaultAsync(r => r.Id.Equals(roleId));
            if (role == null)
            {
                throw new InvalidOperationException(String.Format("RoleId {0} not found.", roleId));
            }

            return await HyperUserStore.IsInRoleAsync(hostId, user, role);
        }

        /// <summary>
        /// Remove a user claim from the current host.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> RemoveClaimAsync(TKey userId, Claim claim)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(claim != null, "claim");

            ThrowIfDisposed();

            return await RemoveClaimAsync(this.HostId, userId, claim);
        }

        /// <summary>
        /// Remove a user claim from the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveClaimAsync(TKey hostId, TKey userId, Claim claim)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(claim != null, "claim");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.RemoveClaimAsync(hostId, user, claim);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Remove a user from a group (current host or global).
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">The group name.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveFromRoleGroupAsync(TKey userId, string groupName)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            return await RemoveFromRoleGroupAsync(this.HostId, userId, groupName);
        }

        /// <summary>
        /// Remove a user from a group (specified host or global).
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveFromRoleGroupAsync(TKey hostId, TKey userId, string groupName)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.RemoveFromRoleGroupAsync(hostId, user, groupName);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Remove user from multiple groups (current host or global).
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupNames">The group names.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveFromRoleGroupsAsync(TKey userId, params string[] groupNames)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groupNames != null, "groupNames");

            ThrowIfDisposed();

            return await RemoveFromRoleGroupsAsync(this.HostId, userId, groupNames);
        }

        /// <summary>
        /// Remove user from multiple groups (specified host or global).
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupNames">The group names.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> RemoveFromRoleGroupsAsync(TKey hostId, TKey userId, params string[] groupNames)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groupNames != null, "groupNames");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            foreach (var groupName in groupNames)
            {
                await HyperUserStore.RemoveFromRoleAsync(hostId, user, groupName);
            }

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Remove a user from a group (current host or global).
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveFromRoleGroupAsync(TKey userId, TKey groupId)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)), "groupId");

            ThrowIfDisposed();

            return await RemoveFromRoleGroupAsync(this.HostId, userId, groupId);
        }

        /// <summary>
        /// Remove a user from a group (specified host or global).
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> RemoveFromRoleGroupAsync(TKey hostId, TKey userId, TKey groupId)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)), "groupId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            var group = await HyperUserStore.HyperContext.RoleGroups.FirstOrDefaultAsync(g => g.Id.Equals(groupId));
            if (group == null)
            {
                throw new InvalidOperationException(String.Format("GroupId {0} not found.", groupId));
            }

            await HyperUserStore.RemoveFromRoleGroupAsync(hostId, user, group);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Remove user from multiple groups (current host or global).
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupIds">The group ids.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveFromRoleGroupsAsync(TKey userId, params TKey[] groupIds)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groupIds != null, "groupIds");

            ThrowIfDisposed();

            return await RemoveFromRoleGroupsAsync(this.HostId, userId, groupIds);
        }

        /// <summary>
        /// Remove user from multiple groups (specified host or global).
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupIds">The group ids.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> RemoveFromRoleGroupsAsync(TKey hostId, TKey userId, params TKey[] groupIds)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(groupIds != null, "groupIds");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            foreach (var groupId in groupIds)
            {
                var group = await HyperUserStore.HyperContext.RoleGroups.FirstOrDefaultAsync(g => g.Id.Equals(groupId));
                if (group != null)
                {
                    await HyperUserStore.RemoveFromRoleGroupAsync(hostId, user, group);
                }
            }

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Remove a user from a role (current host or global).
        /// Does not remove roles assigned through group membership.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> RemoveFromRoleAsync(TKey userId, string roleName)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            return await RemoveFromRoleAsync(this.HostId, userId, roleName);
        }

        /// <summary>
        /// Remove a user from a role (specified host or global).
        /// Does not remove roles assigned through group membership.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveFromRoleAsync(TKey hostId, TKey userId, string roleName)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.RemoveFromRoleAsync(hostId, user, roleName);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Remove user from multiple roles (current host or global).
        /// Does not remove roles assigned through group membership.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleNames">The role names.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> RemoveFromRolesAsync(TKey userId, params string[] roleNames)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(roles != null, "roles");

            ThrowIfDisposed();

            return await RemoveFromRolesAsync(this.HostId, userId, roleNames);
        }

        /// <summary>
        /// Remove user from multiple roles (specified host or global).
        /// Does not remove roles assigned through group membership.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleNames">The role names.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> RemoveFromRolesAsync(TKey hostId, TKey userId, params string[] roleNames)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(roleNames != null, "roleNames");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            foreach (var role in roleNames)
            {
                await HyperUserStore.RemoveFromRoleAsync(hostId, user, role);
            }

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Remove a user from a role (current host or global).
        /// Does not remove roles assigned through group membership.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveFromRoleAsync(TKey userId, TKey roleId)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleId.Equals(default(TKey)), "roleId");

            ThrowIfDisposed();

            return await RemoveFromRoleAsync(this.HostId, userId, roleId);
        }

        /// <summary>
        /// Remove a user from a role (specified host or global).
        /// Does not remove roles assigned through group membership.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveFromRoleAsync(TKey hostId, TKey userId, TKey roleId)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(!roleId.Equals(default(TKey)), "roleId");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            var role = await HyperUserStore.HyperContext.Roles.FirstOrDefaultAsync(r => r.Id.Equals(roleId));
            if (role == null)
            {
                throw new InvalidOperationException(String.Format("RoleId {0} not found.", roleId));
            }

            await HyperUserStore.RemoveFromRoleAsync(hostId, user, role);

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Remove user from multiple roles (current host or global).
        /// Does not remove roles assigned through group membership.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveFromRolesAsync(TKey userId, params TKey[] roleIds)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(roles != null, "roles");

            ThrowIfDisposed();

            return await RemoveFromRolesAsync(this.HostId, userId, roleIds);
        }

        /// <summary>
        /// Remove user from multiple roles (specified host or global).
        /// Does not remove roles assigned through group membership.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleIds">The role ids.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public virtual async Task<IdentityResult> RemoveFromRolesAsync(TKey hostId, TKey userId, params TKey[] roleIds)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(roleIds != null, "roleIds");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            foreach (var roleId in roleIds)
            {
                var role = await HyperUserStore.HyperContext.Roles.FirstOrDefaultAsync(r => r.Id.Equals(roleId));
                if (role != null)
                {
                    //throw new InvalidOperationException(String.Format("RoleId {0} not found.", roleId));
                    await HyperUserStore.RemoveFromRoleAsync(hostId, user, role);
                }
            }

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        ///     Remove a user login
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public override async Task<IdentityResult> RemoveLoginAsync(TKey userId, UserLoginInfo login)
        {
            //x Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            //x Contract.Requires<ArgumentNullException>(login != null, "login");

            return await RemoveLoginAsync(this.HostId, userId, login);
        }

        /// <summary>
        /// Remove a user login
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> RemoveLoginAsync(TKey hostId, TKey userId, UserLoginInfo login)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");
            Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            var user = await FindByIdAsync(userId).WithCurrentCulture();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("UserId {0} not found.", userId));
            }

            await HyperUserStore.RemoveLoginAsync(hostId, user, login).WithCurrentCulture();
            await UpdateSecurityStampInternal(user).WithCurrentCulture();

            return await UpdateAsync(user).WithCurrentCulture();
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// Users cannot be assigned a new hostId.
        /// or
        /// Global users must belong to system host.
        /// </exception>
        public override async Task<IdentityResult> UpdateAsync(TUser user)
        {
            //x Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            var existing = await FindByIdAsync(user.Id);

            if (existing != null && !user.HostId.Equals(existing.HostId))
            {
                throw new ArgumentException("Users cannot be assigned a new hostId.");
            }

            if (user.IsGlobal && !user.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global users must belong to system host.");
            }

            var result = await UserValidator.ValidateAsync(user).WithCurrentCulture();
            if (!result.Succeeded)
            {
                return result;
            }

            await HyperUserStore.UpdateAsync(user).WithCurrentCulture();

            return IdentityResult.Success;
        }

        // Update the security stamp if the store supports it
        internal async Task UpdateSecurityStampInternal(TUser user)
        {
            if (SupportsUserSecurityStamp)
            {
                await HyperUserStore.SetSecurityStampAsync(user, NewSecurityStamp()).WithCurrentCulture();
            }
        }

        private static string NewSecurityStamp()
        {
            return Guid.NewGuid().ToString();
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

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}