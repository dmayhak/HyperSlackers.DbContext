using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// EntityFramework <c>UserStore</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperUserStoreGuid<TUser> : HyperUserStore<TUser, HyperRoleGuid, Guid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperHostGuid, HyperHostDomainGuid, HyperGroupGuid, HyperGroupRoleGuid, HyperGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserStore{TUser, TKey}" /> class.
        /// </summary>
        /// <param name="context">The <c>DbContext</c>.</param>
        public HyperUserStoreGuid(HyperDbContextGuid<TUser> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");

            //
        }
    }

    /// <summary>
    /// EntityFramework <c>UserStore</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperUserStoreInt<TUser> : HyperUserStore<TUser, HyperRoleInt, int, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperHostInt, HyperHostDomainInt, HyperGroupInt, HyperGroupRoleInt, HyperGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserStore{TUser, TKey}" /> class.
        /// </summary>
        /// <param name="context">The <c>DbContext</c>.</param>
        public HyperUserStoreInt(HyperDbContextInt<TUser> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");

            //
        }
    }

    /// <summary>
    /// EntityFramework <c>UserStore</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperUserStoreLong<TUser> : HyperUserStore<TUser, HyperRoleLong, long, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperHostLong, HyperHostDomainLong, HyperGroupLong, HyperGroupRoleLong, HyperGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserStore{TUser, TKey}" /> class.
        /// </summary>
        /// <param name="context">The <c>DbContext</c>.</param>
        public HyperUserStoreLong(HyperDbContextLong<TUser> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");

            //
        }
    }

    /// <summary>
    /// EntityFramework <c>UserStore</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TUser">A user type derived from <c>IdentityUserMultiHost{TKey}</c>.</typeparam>
    /// <typeparam name="TRole">The type of the role.</typeparam>
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
    public class HyperUserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> : UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>
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
        private readonly IDbSet<TUserLogin> logins;
        private readonly IDbSet<TRole> roles;
        private readonly IDbSet<TGroup> groups;
        private readonly IDbSet<TGroupUser> groupUsers;
        private readonly IDbSet<TGroupRole> groupRoles;
        private readonly IDbSet<TUserClaim> userClaims;
        private readonly IDbSet<TUserLogin> userLogins;
        private readonly IDbSet<TUserRole> userRoles;
        private readonly IDbSet<TUser> users;
        private readonly IDbSet<THost> hosts;
        protected internal readonly HyperDbContext<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> HyperContext;
        private bool disposed = false;

        public bool MultiHostEnabled { get { return HyperContext.MultiHostEnabled; } }
        public TKey SystemHostId { get { return HyperContext.SystemHostId; } }
        public TKey HostId { get { return HyperContext.HostId; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStoreMultiHost{TUser, TKey}"/> class.
        /// </summary>
        /// <param name="context">The <c>DbContext</c>.</param>
        /// <param name="hostId">The default host id.</param>
        public HyperUserStore(HyperDbContext<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> context)
            : base(context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");

            this.HyperContext = context;

            this.roles = Context.Set<TRole>();
            this.groups = Context.Set<TGroup>();
            this.groupUsers = Context.Set<TGroupUser>();
            this.groupRoles = Context.Set<TGroupRole>();
            this.users = Context.Set<TUser>();
            this.logins = Context.Set<TUserLogin>();
            this.userClaims = Context.Set<TUserClaim>();
            this.userRoles = Context.Set<TUserRole>();
            this.userLogins = Context.Set<TUserLogin>();
            this.hosts = Context.Set<THost>();
        }

        // Only call save changes if AutoSaveChanges is true
        private async Task SaveChanges()
        {
            if (AutoSaveChanges)
            {
                await Context.SaveChangesAsync().WithCurrentCulture();
            }
        }

        /// <summary>
        /// Add a claim to a user for the current host.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public override async Task AddClaimAsync(TUser user, Claim claim)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(claim != null, "claim");

            ThrowIfDisposed();

            await AddClaimAsync(this.HostId, user, claim);
        }

        /// <summary>
        /// Add a claim to a user for the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public virtual async Task AddClaimAsync(TKey hostId, TUser user, Claim claim)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(claim != null, "claim");

            ThrowIfDisposed();

            var userClaim = new TUserClaim
            {
                HostId = hostId,
                UserId = user.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
                IsGlobal = user.IsGlobal
            };

            await Task.Run(() => userClaims.Add(userClaim));
        }

        /// <summary>
        /// Add a login to the user for the current host. If user is global, login is as well.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public override async Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            await AddLoginAsync(this.HostId, user, login);
        }

        /// <summary>
        /// Add a login to the user for the specified host. If user is global, login is as well.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public virtual async Task AddLoginAsync(TKey hostId, TUser user, UserLoginInfo login)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            var userLogin = new TUserLogin
            {
                HostId = hostId,
                UserId = user.Id,
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey,
                IsGlobal = user.IsGlobal
            };

            await Task.Run(() => userLogins.Add(userLogin));
        }

        /// <summary>
        /// Add a user to a group for the current host. Group must belong to current host or be a global group.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public virtual async Task AddToGroupAsync(TUser user, string groupName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            await AddToGroupAsync(this.HostId, user, groupName, global);
        }

        /// <summary>
        /// Add a user to a group for the specified host. Group must belong to specified host or be a global group.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="groupName">Name of the role.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public virtual async Task AddToGroupAsync(TKey hostId, TUser user, string groupName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            var group = await groups
                .SingleOrDefaultAsync(g => g.Name.ToUpper() == groupName.ToUpper() && (g.HostId.Equals(hostId) || g.IsGlobal == true))
                .WithCurrentCulture();

            if (group == null)
            {
                throw new Exception(string.Format("Group '{0}' not found for hostId '{1}' or in global groups.", groupName, hostId));
            }

            await AddToGroupAsync(hostId, user, group, global);
        }

        /// <summary>
        /// Add a user to a group for the current host. Group must belong to current host or be a global group.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public virtual async Task AddToGroupAsync(TUser user, TKey groupId, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)), "groupId");

            ThrowIfDisposed();

            await AddToGroupAsync(this.HostId, user, groupId, global);
        }

        /// <summary>
        /// Add a user to a group for the specified host. Group must belong to specified host or be a global group.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public virtual async Task AddToGroupAsync(TKey hostId, TUser user, TKey groupId, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!groupId.Equals(default(TKey)), "groupId");

            ThrowIfDisposed();

            var group = await groups
                .SingleOrDefaultAsync(g => g.Id.Equals(groupId) && (g.HostId.Equals(hostId) || g.IsGlobal == true))
                .WithCurrentCulture();

            if (group == null)
            {
                throw new Exception(string.Format("GroupId '{0}' not found for hostId '{1}' or in global groups.", groupId, hostId));
            }

            await AddToGroupAsync(hostId, user, group, global);
        }

        /// <summary>
        /// Add a user to a group for the current host. Group must belong to current host or be a global group.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="group">The group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public virtual async Task AddToGroupAsync(TUser user, TGroup group, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisposed();

            await AddToGroupAsync(this.HostId, user, group, global);
        }

        /// <summary>
        /// Add a user to a group for the specified host. Group must belong to specified host or be a global group.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="group">The group.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public virtual async Task AddToGroupAsync(TKey hostId, TUser user, TGroup group, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisposed();

            var userId = user.Id;
            var groupId = group.Id;

            // check existing
            if (groupUsers.Any(gu => gu.UserId.Equals(userId) && gu.GroupId.Equals(groupId) && (gu.HostId.Equals(hostId) || gu.IsGlobal)))
            {
                throw new Exception(string.Format("User '{0}' already assigned to Group '{1}'.", userId, groupId));
            }

            var userGroup = new TGroupUser
            {
                // assign to system host if global flag set and group is global -OR- it's a global only group
                HostId = ((global && group.IsGlobal) || (group.IsGlobal && group.IsGlobalOnly)) ? this.SystemHostId : hostId,   // assign to system host if global only group
                UserId = userId,
                GroupId = groupId,
                // assign to system host if global flag set and group is global -OR- it's a global only group
                IsGlobal = ((global && group.IsGlobal) || (group.IsGlobal && group.IsGlobalOnly))
            };

            groupUsers.Add(userGroup);

            // add user roles...
            var newGroupRoles = groupRoles.Where(gr => gr.GroupId.Equals(groupId));
            foreach (var item in newGroupRoles)
            {
                var role = roles.Find(item.RoleId);
                if (role != null)
                {
                    var userRole = new TUserRole
                    {
                        // assign to system host if global flag set and role is global -OR- it's a global only role
                        HostId = ((global && role.IsGlobal) || (role.IsGlobal && role.IsGlobalOnly)) ? this.SystemHostId : hostId,   // assign to system host if global only role
                        UserId = user.Id,
                        RoleId = role.Id,
                        GroupId = groupId, // this role was added as part of a group
                        // assign to system host if global flag set and role is global -OR- it's a global only role
                        IsGlobal = ((global && role.IsGlobal) || (role.IsGlobal && role.IsGlobalOnly))
                    };

                    userRoles.Add(userRole);
                }
            }

            await SaveChanges();
        }

        /// <summary>
        /// Add a user to a role for the current host. Role must belong to current host or be a global role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public override async Task AddToRoleAsync(TUser user, string roleName)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            await AddToRoleAsync(user.HostId, user, roleName);
        }

        /// <summary>
        /// Add a user to a role for the current host. Role must belong to current host or be a global role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public virtual async Task AddToRoleAsync(TUser user, string roleName, bool global)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            await AddToRoleAsync(user.HostId, user, roleName, global);
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to specified host or be a global role.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public virtual async Task AddToRoleAsync(TKey hostId, TUser user, string roleName, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            var role = await roles
                .SingleOrDefaultAsync(r => r.Name.ToUpper() == roleName.ToUpper() && (r.HostId.Equals(hostId) || r.IsGlobal == true))
                .WithCurrentCulture();

            if (role == null)
            {
                throw new Exception(string.Format("Role '{0}' not found for hostId '{1}' or in global roles.", roleName, hostId));
            }

            await AddToRoleAsync(hostId, user, role, global);
        }

        /// <summary>
        /// Add a user to a role for the current host. Role must belong to current host or be a global role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        public virtual async Task AddToRoleAsync(TUser user, TKey roleId, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!roleId.Equals(default(TKey)), "roleId");

            ThrowIfDisposed();

            await AddToRoleAsync(user.HostId, user, roleId, global);
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to specified host or be a global role.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public virtual async Task AddToRoleAsync(TKey hostId, TUser user, TKey roleId, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!roleId.Equals(default(TKey)), "roleId");

            ThrowIfDisposed();

            var role = await roles
                .SingleOrDefaultAsync(r => r.Id.Equals(roleId) && (r.HostId.Equals(hostId) || r.IsGlobal == true))
                .WithCurrentCulture();

            if (role == null)
            {
                throw new Exception(string.Format("RoleId '{0}' not found for hostId '{1}' or in global roles.", roleId, hostId));
            }

            await AddToRoleAsync(hostId, user, role, global);
        }

        /// <summary>
        /// Add a user to a role for the specified host. Role must belong to specified host or be a global role.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="role">The role.</param>
        /// <param name="global">if set to <c>true</c> [global].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public virtual async Task AddToRoleAsync(TKey hostId, TUser user, TRole role, bool global = false)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            ThrowIfDisposed();

            var roleId = role.Id;
            var userId = user.Id;

            if (userRoles.Any(ur => ur.RoleId.Equals(roleId) && ur.UserId.Equals(userId) && (ur.HostId.Equals(hostId) || ur.IsGlobal)))
            {
                throw new Exception(string.Format("User '{0}' already assigned Role '{1}'.", userId, roleId));
            }

            var userRole = new TUserRole
            {
                // assign to system host if global flag set and role is global -OR- it's a global only role
                HostId = ((global && role.IsGlobal) || (role.IsGlobal && role.IsGlobalOnly)) ? this.SystemHostId : hostId,
                UserId = userId,
                RoleId = roleId,
                GroupId = null, // this role was not added as part of a group, so will not be affected by group operations
                // set global flag if global flag set and role is global -OR- it's a global only role
                IsGlobal = ((global && role.IsGlobal) || (role.IsGlobal && role.IsGlobalOnly))
            };

            userRoles.Add(userRole);

            await SaveChanges();
        }

        /// <summary>
        /// Creates a new user for the host specified in <c>user.HostId</c>. If no host id specified, the default host id is used.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Global users must belong to system host.</exception>
        public override async Task CreateAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            if (user.HostId.Equals(default(TKey)))
            {
                user.HostId = this.HostId;
            }

            if (user.IsGlobal && !user.HostId.Equals(this.SystemHostId))
            {
                throw new ArgumentException("Global users must belong to system host.");
            }

            await base.CreateAsync(user); // base makes use of AutoSave flag
        }

        // <summary>
        ///     Delete a user. Also deletes all user groups, roles, claims, and logins for all domains!!!
        /// </summary>
        /// <param name="user"></param>
        public override Task DeleteAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            var userId = user.Id;

            var groups = groupUsers.Where(gu => gu.UserId.Equals(userId));
            foreach (var item in groups)
            {
                groupUsers.Remove(item);
            }

            var roles = userRoles.Where(ur => ur.UserId.Equals(userId));
            foreach (var item in roles)
            {
                userRoles.Remove(item);
            }

            var claims = userClaims.Where(uc => uc.UserId.Equals(userId));
            foreach (var item in claims)
            {
                userClaims.Remove(item);
            }

            var logins = userLogins.Where(ul => ul.UserId.Equals(userId));
            foreach (var item in logins)
            {
                userLogins.Remove(item);
            }

            return base.DeleteAsync(user);
        }

        /// <summary>
        /// Finds a user belonging to the default host or that is a global user.
        /// </summary>
        /// <param name="login">The user's login info.</param>
        /// <returns></returns>
        public override async Task<TUser> FindAsync(UserLoginInfo login)
        {
            Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            return await FindAsync(this.HostId, login);
        }

        /// <summary>
        /// Finds a user belonging to the specified host or that is a global user.
        /// </summary>
        /// <param name="hostId">The host id.</param>
        /// <param name="login">The user's login info.</param>
        /// <returns></returns>
        public virtual async Task<TUser> FindAsync(TKey hostId, UserLoginInfo login)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            var provider = login.LoginProvider;
            var key = login.ProviderKey;
            var userLogin = await userLogins.FirstOrDefaultAsync(ul => (ul.HostId.Equals(hostId) || ul.IsGlobal) && ul.LoginProvider == provider && ul.ProviderKey == key).WithCurrentCulture();

            if (userLogin != null)
            {
                var userId = userLogin.UserId;
                return await GetUserAggregateAsync(u => u.Id.Equals(userId)).WithCurrentCulture();
            }

            return null;
        }

        /// <summary>
        /// Finds all users (for any host) matching the login info.
        /// </summary>
        /// <param name="login">The user's login info.</param>
        /// <returns></returns>
        public virtual async Task<IList<TUser>> FindAllAsync(UserLoginInfo login)
        {
            Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            var provider = login.LoginProvider;
            var key = login.ProviderKey;
            var logins = userLogins.Where(ul => ul.LoginProvider == provider && ul.ProviderKey == key);

            List<TUser> users = new List<TUser>();

            if (logins != null)
            {
                foreach (var item in logins)
                {
                    var userId = item.UserId;
                    users.Add(await GetUserAggregateAsync(u => u.Id.Equals(userId)).WithCurrentCulture());
                }
            }

            return users;
        }

        /// <summary>
        /// Finds a user for the current host (or global) with the given email address.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <returns></returns>
        public override async Task<TUser> FindByEmailAsync(string email)
        {
            Contract.Requires<ArgumentNullException>(!email.IsNullOrWhiteSpace(), "email");

            ThrowIfDisposed();

            return await FindByEmailAsync(this.HostId, email);
        }

        /// <summary>
        /// Finds a user for the given host with the given email address.
        /// </summary>
        /// <param name="hostId">The host id.</param>
        /// <param name="email">The user's email address.</param>
        /// <returns></returns>
        public virtual async Task<TUser> FindByEmailAsync(TKey hostId, string email)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!email.IsNullOrWhiteSpace(), "email");

            ThrowIfDisposed();

            return await GetUserAggregateAsync(u => (u.HostId.Equals(hostId) || u.IsGlobal) && u.Email.ToUpper() == email.ToUpper());
        }

        /// <summary>
        /// Finds all users (for any host) with the given email address.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <returns></returns>
        public virtual async Task<IList<TUser>> FindAllByEmailAsync(string email)
        {
            Contract.Requires<ArgumentNullException>(!email.IsNullOrWhiteSpace(), "email");

            ThrowIfDisposed();

            var userIds = this.users.Where(u => u.Email.ToUpper() == email.ToUpper()).Select(u => u.Id);

            List<TUser> users = new List<TUser>();

            foreach (var item in logins)
            {
                var userId = item.UserId;
                users.Add(await GetUserAggregateAsync(u => u.Id.Equals(userId)).WithCurrentCulture());
            }

            return users;
        }

        /// <summary>
        ///     Find a user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public override async Task<TUser> FindByIdAsync(TKey userId)
        {
            Contract.Requires<ArgumentNullException>(!userId.Equals(default(TKey)), "userId");

            return await GetUserAggregateAsync(u => u.Id.Equals(userId));
        }

        /// <summary>
        /// Finds a user for the current host (or global) with the specified userName.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <returns></returns>
        public override async Task<TUser> FindByNameAsync(string userName)
        {
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");

            ThrowIfDisposed();

            return await FindByNameAsync(this.HostId, userName);
        }

        /// <summary>
        /// Finds a user for the given host with the specified userName.
        /// </summary>
        /// <param name="hostId">The host id.</param>
        /// <param name="userName">The userName.</param>
        /// <returns></returns>
        public virtual async Task<TUser> FindByNameAsync(TKey hostId, string userName)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");

            ThrowIfDisposed();

            return await GetUserAggregateAsync(u => (u.HostId.Equals(hostId) || u.IsGlobal) && u.UserName.ToUpper() == userName.ToUpper());
        }

        /// <summary>
        /// Finds all users (for any host) with the specified userName.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <returns></returns>
        public virtual async Task<IList<TUser>> FindAllByNameAsync(string userName)
        {
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");

            ThrowIfDisposed();

            var userIds = this.users.Where(u => u.UserName.ToUpper() == userName.ToUpper()).Select(u => u.Id);

            List<TUser> users = new List<TUser>();

            foreach (var item in logins)
            {
                var userId = item.UserId;
                users.Add(await GetUserAggregateAsync(u => u.Id.Equals(userId)).WithCurrentCulture());
            }

            return users;
        }

        /// <summary>
        /// Get a users's claims for current host or global.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public override async Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            return await GetClaimsAsync(this.HostId, user);
        }

        /// <summary>
        /// Get a users's claims for specified host or global.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public virtual async Task<IList<Claim>> GetClaimsAsync(TKey hostId, TUser user)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            await EnsureClaimsLoaded(user).WithCurrentCulture();

            return user.Claims
                .Where(uc => uc.UserId.Equals(user.Id)
                    && (uc.HostId.Equals(hostId) || uc.IsGlobal))
                .Select(uc => new Claim(uc.ClaimType, uc.ClaimValue))
                .ToList();
        }

        /// <summary>
        /// Get a users's claims for specified host or global.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public virtual async Task<IList<Claim>> GetAllClaimsAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            await EnsureClaimsLoaded(user).WithCurrentCulture();

            return user.Claims
                .Where(uc => uc.UserId.Equals(user.Id))
                .Select(uc => new Claim(uc.ClaimType, uc.ClaimValue))
                .ToList();
        }

        /// <summary>
        ///     Get the logins for a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public override async Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            return await GetLoginsAsync(this.HostId, user);
        }

        /// <summary>
        ///     Get the logins for a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual async Task<IList<UserLoginInfo>> GetLoginsAsync(TKey hostId, TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            await EnsureLoginsLoaded(user).WithCurrentCulture();

            return user.Logins
                .Where(ul => (ul.HostId.Equals(hostId) || ul.IsGlobal))
                .Select(ul => new UserLoginInfo(ul.LoginProvider, ul.ProviderKey))
                .ToList();
        }

        /// <summary>
        /// Get the logins for a user
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public virtual async Task<IList<UserLoginInfo>> GetAllLoginsAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            await EnsureLoginsLoaded(user).WithCurrentCulture();

            return user.Logins
                .Select(ul => new UserLoginInfo(ul.LoginProvider, ul.ProviderKey))
                .ToList();
        }

        /// <summary>
        /// Get all roles (for all hosts) that user is a member of.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public virtual async Task<IList<TRole>> GetAllRolesAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            await EnsureRolesLoaded(user);

            var roleIds = user.Roles
                .Select(r => r.RoleId)
                .Distinct()
                .ToArray();

            return await Context.Set<TRole>()
                .Where(r => roleIds.Contains(r.Id))
                .ToListAsync();
        }

        /// <summary>
        /// Get all UserRoles (for all hosts) for the given user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public virtual async Task<IList<TUserRole>> GetAllUserRolesAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            await EnsureRolesLoaded(user);

            var userId = user.Id;

            return await Context.Set<TUserRole>()
                .Where(ur => ur.UserId.Equals(userId))
                .ToListAsync();
        }

        /// <summary>
        /// Get the names of the roles a user is a member of for the current host; includes global roles.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public override async Task<IList<string>> GetRolesAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            return await GetRolesAsync(this.HostId, user);
        }

        /// <summary>
        /// Get the names of the roles a user is a member of for the specified host; includes global roles.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public virtual async Task<IList<string>> GetRolesAsync(TKey hostId, TUser user)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");

            ThrowIfDisposed();

            await EnsureRolesLoaded(user);

            var roleIds = user.Roles
                .Where(r => r.HostId.Equals(hostId) || r.IsGlobal == true)
                .Select(r => r.RoleId)
                .Distinct()
                .ToArray();

            return await Context.Set<TRole>()
                .Where(r => roleIds.Contains(r.Id))
                .Select(r => r.Name)
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        ///     Returns true if the user is in the named role for the current host (or global)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override async Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            return await IsInRoleAsync(this.HostId, user, roleName);
        }

        /// <summary>
        /// Returns true if the user is in the named role for the current host (or global)
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public virtual async Task<bool> IsInRoleAsync(TKey hostId, TUser user, string roleName)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            var userId = user.Id;
            var roleIds = roles.Where(r => r.Name.ToUpper() == roleName.ToUpper() && (r.HostId.Equals(hostId) || r.IsGlobal)).Select(r => r.Id).Distinct();

            return await userRoles.AnyAsync(ur => ur.UserId.Equals(userId) && roleIds.Contains(ur.RoleId) && (ur.HostId.Equals(hostId) || ur.IsGlobal)).WithCurrentCulture();
        }

        /// <summary>
        /// Returns true if the user is in the named role for the specified host (or global)
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public virtual async Task<bool> IsInRoleAsync(TKey hostId, TUser user, TRole role)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            var userId = user.Id;
            var roleId = role.Id;

            return await userRoles.AnyAsync(ur => ur.UserId.Equals(userId) && ur.RoleId.Equals(roleId) && (ur.HostId.Equals(hostId) || ur.IsGlobal)).WithCurrentCulture();
        }

        /// <summary>
        /// Returns true if the user is in the named role for the current host (or global)
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public virtual async Task<bool> IsInRoleAsync(TUser user, TRole role)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            return await IsInRoleAsync(this.HostId, user, role);
        }

        /// <summary>
        /// Remove a user claim from the current host.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public override async Task RemoveClaimAsync(TUser user, Claim claim)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(claim != null, "claim");

            ThrowIfDisposed();

            await RemoveClaimAsync(this.HostId, user, claim);
        }

        /// <summary>
        /// Remove a user claim from the specified host.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public virtual async Task RemoveClaimAsync(TKey hostId, TUser user, Claim claim)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(claim != null, "claim");

            ThrowIfDisposed();

            IEnumerable<TUserClaim> claims;
            var claimValue = claim.Value;
            var claimType = claim.Type;

            if (AreClaimsLoaded(user))
            {
                claims = user.Claims.Where(uc => uc.HostId.Equals(hostId) && uc.ClaimValue == claimValue && uc.ClaimType == claimType).ToList();
            }
            else
            {
                var userId = user.Id;
                claims = await userClaims.Where(uc => uc.HostId.Equals(hostId) && uc.ClaimValue == claimValue && uc.ClaimType == claimType && uc.UserId.Equals(userId)).ToListAsync().WithCurrentCulture();
            }

            foreach (var c in claims)
            {
                await Task.Run(() => userClaims.Remove(c));
            }
        }

        /// <summary>
        /// Remove a user from a group (current host or global).
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">The group.</param>
        /// <returns></returns>
        public virtual async Task RemoveFromGroupAsync(TUser user, string groupName)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            await RemoveFromGroupAsync(this.HostId, user, groupName);
        }

        /// <summary>
        /// Remove a user from a group (current host or global).
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public virtual async Task RemoveFromGroupAsync(TUser user, TGroup group)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisposed();

            await RemoveFromGroupAsync(this.HostId, user, group);
        }

        /// <summary>
        /// Remove a user from a group (specified host or global).
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public virtual async Task RemoveFromGroupAsync(TKey hostId, TUser user, string groupName)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!groupName.IsNullOrWhiteSpace(), "groupName");

            ThrowIfDisposed();

            var group = await groups.SingleOrDefaultAsync(r => r.Name.ToUpper() == groupName.ToUpper() && (r.HostId.Equals(hostId) || r.IsGlobal)).WithCurrentCulture();

            await RemoveFromGroupAsync(hostId, user, group);
        }

        /// <summary>
        /// Remove a user from a group (specified host or global).
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public virtual async Task RemoveFromGroupAsync(TKey hostId, TUser user, TGroup group)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(group != null, "group");

            ThrowIfDisposed();

            if (group != null)
            {
                var groupId = group.Id;
                var userId = user.Id;

                // we do not mess with roles that were given tot he user via a group--i.e. test that groupId is null
                var groups = await groupUsers.Where(gu => gu.GroupId.Equals(groupId) && gu.UserId.Equals(userId) && (gu.HostId.Equals(hostId) || gu.IsGlobal)).ToArrayAsync();
                foreach (var item in groups)
                {
                    groupUsers.Remove(item);
                }
            }
        }

        /// <summary>
        /// Remove a user from a role (current host or global).
        /// Does not remove roles assigned through groups.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public override async Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            await RemoveFromRoleAsync(this.HostId, user, roleName);
        }

        /// <summary>
        /// Remove a user from a role (current host or global).
        /// Does not remove roles assigned through groups.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public virtual async Task RemoveFromRoleAsync(TUser user, TRole role)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            ThrowIfDisposed();

            await RemoveFromRoleAsync(this.HostId, user, role);
        }

        /// <summary>
        /// Remove a user from a role (specified host or global).
        /// Does not remove roles assigned through groups.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public virtual async Task RemoveFromRoleAsync(TKey hostId, TUser user, string roleName)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(!roleName.IsNullOrWhiteSpace(), "roleName");

            ThrowIfDisposed();

            var role = await roles.SingleOrDefaultAsync(r => r.Name.ToUpper() == roleName.ToUpper() && (r.HostId.Equals(hostId) || r.IsGlobal)).WithCurrentCulture();

            await RemoveFromRoleAsync(hostId, user, role);
        }

        /// <summary>
        /// Remove a user from a role (specified host or global).
        /// Does not remove roles assigned through groups.
        /// </summary>
        /// <param name="hostId">The host identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public virtual async Task RemoveFromRoleAsync(TKey hostId, TUser user, TRole role)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(role != null, "role");

            ThrowIfDisposed();

            if (role != null)
            {
                var roleId = role.Id;
                var userId = user.Id;

                // we do not mess with roles that were given tot he user via a group--i.e. test that groupId is null
                var roles = await userRoles.Where(ur => ur.RoleId.Equals(roleId) && ur.UserId.Equals(userId) && ur.GroupId.Equals(null) && (ur.HostId.Equals(hostId) || ur.IsGlobal)).ToArrayAsync();
                foreach (var item in roles)
                {
                    userRoles.Remove(item);
                }
            }
        }

        /// <summary>
        ///     Remove a login from a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public override async Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(login != null, "login");

            await RemoveLoginAsync(this.HostId, user, login);
        }

        /// <summary>
        ///     Remove a login from a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public virtual async Task RemoveLoginAsync(TKey hostId, TUser user, UserLoginInfo login)
        {
            Contract.Requires<ArgumentNullException>(!MultiHostEnabled || !hostId.Equals(default(TKey)), "hostId");
            Contract.Requires<ArgumentNullException>(user != null, "user");
            Contract.Requires<ArgumentNullException>(login != null, "login");

            ThrowIfDisposed();

            TUserLogin userLogin;
            var provider = login.LoginProvider;
            var key = login.ProviderKey;

            if (AreLoginsLoaded(user))
            {
                userLogin = user.Logins.SingleOrDefault(ul => (ul.HostId.Equals(hostId) || ul.IsGlobal) && ul.LoginProvider == provider && ul.ProviderKey == key);
            }
            else
            {
                var userId = user.Id;
                userLogin = await userLogins.SingleOrDefaultAsync(ul => ul.LoginProvider == provider && ul.ProviderKey == key && ul.UserId.Equals(userId)).WithCurrentCulture();
            }

            if (userLogin != null)
            {
                userLogins.Remove(userLogin);
            }
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Users cannot be assigned a new hostId.
        /// or
        /// Global users must belong to system host.</exception>
        public override async Task UpdateAsync(TUser user)
        {
            Contract.Requires<ArgumentNullException>(user != null, "user");

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

            await base.UpdateAsync(user);
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

        /// <summary>
        /// Used to attach child entities to the User aggregate, i.e. Roles, Logins, and Claims
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        protected override async Task<TUser> GetUserAggregateAsync(Expression<Func<TUser, bool>> filter)
        {
            {
                TUser user = await users.FirstOrDefaultAsync(filter).WithCurrentCulture();

                return await GetUserAggregateAsync(user);
            }
        }

        /// <summary>
        /// Used to attach child entities to the User aggregate, i.e. Roles, Logins, and Claims
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        protected virtual async Task<TUser> GetUserAggregateAsync(TUser user)
        {
            if (user != null)
            {
                await EnsureClaimsLoaded(user).WithCurrentCulture();
                await EnsureLoginsLoaded(user).WithCurrentCulture();
                await EnsureRolesLoaded(user).WithCurrentCulture();
                await EnsureGroupsLoaded(user).WithCurrentCulture();
            }

            return user;
        }

        private bool AreClaimsLoaded(TUser user)
        {
            return Context.Entry(user).Collection(u => u.Claims).IsLoaded;
        }

        private bool AreGroupsLoaded(TUser user)
        {
            return Context.Entry(user).Collection(u => u.Groups).IsLoaded;
        }

        private bool AreLoginsLoaded(TUser user)
        {
            return Context.Entry(user).Collection(u => u.Logins).IsLoaded;
        }

        private bool AreRolesLoaded(TUser user)
        {
            return Context.Entry(user).Collection(u => u.Roles).IsLoaded;
        }

        private async Task EnsureClaimsLoaded(TUser user)
        {
            if (!AreClaimsLoaded(user))
            {
                var userId = user.Id;
                await userClaims.Where(uc => uc.UserId.Equals(userId)).LoadAsync().WithCurrentCulture();
                Context.Entry(user).Collection(u => u.Claims).IsLoaded = true;
            }
        }

        private async Task EnsureLoginsLoaded(TUser user)
        {
            if (!AreLoginsLoaded(user))
            {
                var userId = user.Id;
                await userLogins.Where(uc => uc.UserId.Equals(userId)).LoadAsync().WithCurrentCulture();
                Context.Entry(user).Collection(u => u.Logins).IsLoaded = true;
            }
        }

        private async Task EnsureRolesLoaded(TUser user)
        {
            if (!AreRolesLoaded(user))
            {
                var userId = user.Id;
                await userRoles.Where(uc => uc.UserId.Equals(userId)).LoadAsync().WithCurrentCulture();
                Context.Entry(user).Collection(u => u.Roles).IsLoaded = true;
            }
        }

        private async Task EnsureGroupsLoaded(TUser user)
        {
            if (!AreGroupsLoaded(user))
            {
                var userId = user.Id;
                await groupUsers.Where(gu => gu.UserId.Equals(userId)).LoadAsync().WithCurrentCulture();
                Context.Entry(user).Collection(u => u.Groups).IsLoaded = true;
            }
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