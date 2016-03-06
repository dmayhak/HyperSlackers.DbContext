using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Validates a role prior to saving it.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperRoleValidatorGuid<TUser> : HyperRoleValidator<TUser, HyperRoleGuid, Guid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperHostGuid, HyperHostDomainGuid, HyperGroupGuid, HyperGroupRoleGuid, HyperGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleValidatorGuid{TUser}"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public HyperRoleValidatorGuid(HyperRoleManagerGuid<TUser> manager)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
        }
    }

    /// <summary>
    /// Validates a role prior to saving it.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperRoleValidatorInt<TUser> : HyperRoleValidator<TUser, HyperRoleInt, int, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperHostInt, HyperHostDomainInt, HyperGroupInt, HyperGroupRoleInt, HyperGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleValidatorInt{TUser}"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public HyperRoleValidatorInt(HyperRoleManagerInt<TUser> manager)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
        }
    }

    /// <summary>
    /// Validates a role prior to saving it.
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperRoleValidatorLong<TUser> : HyperRoleValidator<TUser, HyperRoleLong, long, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperHostLong, HyperHostDomainLong, HyperGroupLong, HyperGroupRoleLong, HyperGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRoleValidatorLong{TUser}"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public HyperRoleValidatorLong(HyperRoleManagerLong<TUser> manager)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
        }
    }

    /// <summary>
    /// Validates a role prior to saving it.
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
    public class HyperRoleValidator<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> : RoleValidator<TRole, TKey>, IDisposable
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
        protected readonly HyperRoleManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> Manager;
        private bool disposed = false;

        public HyperRoleValidator(HyperRoleManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null, "manager");

            Manager = manager;
        }

        /// <summary>
        /// Validates a role before saving.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public override async Task<IdentityResult> ValidateAsync(TRole role)
        {
            Contract.Requires<ArgumentNullException>(role != null, "role");

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(role.Name))
            {
                errors.Add(String.Format("Role name cannot be empty."));
            }

            if (role.IsGlobal)
            {
                // check if the role already exists
                // either as a system role or on any host
                var roleId = role.Id;
                var roleName = role.Name;
                List<TRole> existingRoles = Manager.Roles.Where(r => r.Name == roleName).ToList();

                if (existingRoles.Any(r => !r.Id.Equals(roleId)))
                {
                    errors.Add(String.Format("Role '{0}' already exists.", role.Name));
                }
            }
            else
            {
                // role cannot exist in host
                var roleId = role.Id;
                var roleName = role.Name;
                var hostId = role.HostId;
                List<TRole> existingHostRoles = Manager.Roles.Where(r => r.Name == roleName && r.HostId.Equals(hostId)).ToList();

                if (existingHostRoles.Any(r => !r.Id.Equals(roleId)))
                {
                    errors.Add(String.Format("Role '{0}' already exists for host.", roleName));
                }

                // role cannot exist as global
                List<TRole> existingGlobalRoles = Manager.Roles.Where(r => r.Name == roleName && r.IsGlobal == true).ToList();

                if (existingGlobalRoles.Any(r => !r.Id.Equals(roleId)))
                {
                    errors.Add(String.Format("Role '{0}' already exists as global role.", roleName));
                }
            }

            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // dispose of resources

                    this.disposed = true;
                }
            }
        }
    }
}
