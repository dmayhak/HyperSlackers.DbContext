﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Validates users before they are saved
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperUserValidatorGuid<TUser> : HyperUserValidator<TUser, HyperRoleGuid, Guid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperHostGuid, HyperHostDomainGuid, HyperGroupGuid, HyperGroupRoleGuid, HyperGroupUserGuid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
        where TUser : HyperUserGuid, new()
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="manager"></param>
        public HyperUserValidatorGuid(HyperUserManagerGuid<TUser> manager)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
        }
    }

    /// <summary>
    /// Validates users before they are saved
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperUserValidatorInt<TUser> : HyperUserValidator<TUser, HyperRoleInt, int, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperHostInt, HyperHostDomainInt, HyperGroupInt, HyperGroupRoleInt, HyperGroupUserInt, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
        where TUser : HyperUserInt, new()
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="manager"></param>
        public HyperUserValidatorInt(HyperUserManagerInt<TUser> manager)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
        }
    }

    /// <summary>
    /// Validates users before they are saved
    /// </summary>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    public class HyperUserValidatorLong<TUser> : HyperUserValidator<TUser, HyperRoleLong, long, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperHostLong, HyperHostDomainLong, HyperGroupLong, HyperGroupRoleLong, HyperGroupUserLong, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
        where TUser : HyperUserLong, new()
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="manager"></param>
        public HyperUserValidatorLong(HyperUserManagerLong<TUser> manager)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null, "manager");
        }
    }

    /// <summary>
    /// Validates users before they are saved
    /// MODIFIED FROM: https://aspnetidentity.codeplex.com/SourceControl/latest#src/Microsoft.AspNet.Identity.Core/UserValidator.cs
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
    public class HyperUserValidator<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> : UserValidator<TUser, TKey>
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
        /// <summary>
        /// Gets or sets the minimum length of the user name.
        /// Default: 6
        /// </summary>
        /// <value>
        /// The minimum length of the user name.
        /// </value>
        public int MinimumUserNameLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of the user name.
        /// Default: 50
        /// </summary>
        /// <value>
        /// The maximum length of the user name.
        /// </value>
        public int MaximumUserNameLength { get; set; }

        /// <summary>
        /// Gets or sets the regular expression to validate user names.
        /// If set, the AllowOnlyAlphanumericUserNames flag will be ignored and the
        /// specified regular expression will be used.
        /// Default: (null)
        /// Default for AllowOnlyAlphanumericUserNames: "^[A-Za-z0-9@_\.]+$"
        /// </summary>
        /// <value>
        /// The validation regular expression.
        /// </value>
        public string ValidatorRegex { get; set; }

        protected readonly HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> Manager;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="manager"></param>
        public HyperUserValidator(HyperUserManager<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, THost, THostDomain, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> manager)
            : base(manager)
        {
            Contract.Requires<ArgumentNullException>(manager != null, "manager");

            MinimumUserNameLength = 6;
            MaximumUserNameLength = 50;
            RequireUniqueEmail = true;
            Manager = manager;
        }

        /// <summary>
        ///     Validates a user before saving
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override async Task<IdentityResult> ValidateAsync(TUser item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var errors = new List<string>();

            await ValidateUserName(item, errors).WithCurrentCulture();

            await ValidateEmailAsync(item, errors).WithCurrentCulture();

            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }

            return IdentityResult.Success;
        }

        private async Task ValidateUserName(TUser user, List<string> errors)
        {
            if (user.UserName.IsNullOrWhiteSpace() || user.UserName.Trim().Length < MinimumUserNameLength)
            {
                errors.Add("User name is too short.");
                return;
            }

            if (user.UserName.Trim().Length > MaximumUserNameLength)
            {
                errors.Add("User name is too long.");
                return;
            }

            // if custom regex, use that, else check regular regex if flag set
            if (!ValidatorRegex.IsNullOrWhiteSpace())
            {
                if (!Regex.IsMatch(user.UserName, ValidatorRegex))
                {
                    // If we don't match the custom regex
                    errors.Add("User name is invalid");
                    return;
                }
            }
            else if (AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, @"^[A-Za-z0-9@_\.]+$"))
            {
                // If any characters are not letters or digits, its an illegal user name
                errors.Add("User name is invalid");
                return;
            }

            if (user.IsGlobal)
            {
                // global user cannot exist in any hosts
                var userId = user.Id;
                var userName = user.UserName;
                List<TUser> existingUsers = Manager.Users.Where(u => u.UserName == userName).ToList();

                if (existingUsers.Any(u => !u.Id.Equals(userId)))
                {
                    errors.Add(String.Format("User '{0}' already exists in system.", user.UserName));
                    return;
                }
            }
            else
            {
                // user name must be unique to the host and cannot be a global one
                var existing = await Manager.FindByNameAsync(Manager.HostId, user.UserName).WithCurrentCulture();
                if (existing != null && !user.Id.Equals(existing.Id))
                {
                    errors.Add(String.Format("User name {0} already exists.", user.UserName));
                    return;
                }
            }
        }

        // make sure email is not empty, is valid, and is unique
        private async Task ValidateEmailAsync(TUser user, List<string> errors)
        {
            var email = await Manager.HyperUserStore.GetEmailAsync(user).WithCurrentCulture();
            if (email.IsNullOrWhiteSpace())
            {
                errors.Add(String.Format("Email address is required."));
                return;
            }

            try
            {
                var m = new MailAddress(email);
            }
            catch (FormatException)
            {
                errors.Add("Email address is invalid.");
                return;
            }

            if (RequireUniqueEmail)
            {
                // check for duplicates for this host or system host
                var owner = await Manager.FindByEmailAsync(Manager.HostId, email).WithCurrentCulture();
                if (owner != null && !user.Id.Equals(owner.Id))
                {
                    errors.Add(String.Format("Email address {0} already exists.", email));
                }
            }
        }
    }
}