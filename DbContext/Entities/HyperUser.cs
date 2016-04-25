using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// EntityFramework <c>IdentityUser</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    public class HyperUserGuid : HyperUser<Guid, HyperUserLoginGuid, HyperUserRoleGuid, HyperUserClaimGuid, HyperRoleGroupUserGuid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserGuid"/> class.
        /// </summary>
        public HyperUserGuid()
            : base()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserGuid"/> class.
        /// </summary>
        /// <param name="userName">The userName.</param>
        public HyperUserGuid(string userName)
            : base(userName)
        {
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");

            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// EntityFramework <c>IdentityUser</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    public class HyperUserInt : HyperUser<int, HyperUserLoginInt, HyperUserRoleInt, HyperUserClaimInt, HyperRoleGroupUserInt>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserInt"/> class.
        /// </summary>
        public HyperUserInt()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserInt"/> class.
        /// </summary>
        /// <param name="userName">The userName.</param>
        public HyperUserInt(string userName)
            : base(userName)
        {
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");
        }
    }

    /// <summary>
    /// EntityFramework <c>IdentityUser</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    public class HyperUserLong : HyperUser<long, HyperUserLoginLong, HyperUserRoleLong, HyperUserClaimLong, HyperRoleGroupUserLong>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserLong"/> class.
        /// </summary>
        public HyperUserLong()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperUserLong"/> class.
        /// </summary>
        /// <param name="userName">The userName.</param>
        public HyperUserLong(string userName)
            : base(userName)
        {
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");
        }
    }

    /// <summary>
    /// EntityFramework <c>IdentityUser</c> implementation for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TKey">The key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
    /// <typeparam name="TLogin">The type of the login.</typeparam>
    /// <typeparam name="TRole">The type of the role.</typeparam>
    /// <typeparam name="TClaim">The type of the claim.</typeparam>
    public class HyperUser<TKey, TLogin, TRole, TClaim, TRoleGroupUser> : IdentityUser<TKey, TLogin, TRole, TClaim>, IHyperUser<TKey>
        where TKey : struct, IEquatable<TKey>
        where TLogin : HyperUserLogin<TKey>, IHyperUserLogin<TKey>, new()
        where TRole : HyperUserRole<TKey>, IHyperUserRole<TKey>, new()
        where TClaim : HyperUserClaim<TKey>, IHyperUserClaim<TKey>, new()
        where TRoleGroupUser : HyperRoleGroupUser<TKey>, new()
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Index("IX_ClusteredKey", IsClustered = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClusteredKey { get; protected set; }

        /// <summary>
        /// Gets or sets the host identifier.
        /// </summary>
        /// <value>
        /// The host identifier.
        /// </value>
        public TKey HostId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is global.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is global; otherwise, <c>false</c>.
        /// </value>
        public bool IsGlobal { get; set; }

        /// <summary>
        /// Gets or sets the roleGroups the user belongs to.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        public virtual ICollection<TRoleGroupUser> RoleGroups { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityUserMultiHost{TKey}"/> class.
        /// </summary>
        public HyperUser()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityUserMultiHost{TKey}"/> class.
        /// </summary>
        /// <param name="userName">The userName.</param>
        public HyperUser(string userName)
        {
            Contract.Requires<ArgumentNullException>(!userName.IsNullOrWhiteSpace(), "userName");

            base.UserName = userName;
        }
    }
}
