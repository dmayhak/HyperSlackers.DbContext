using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Multi-tenant <c>Role</c> having both key and host key as <c>TKey</c> types
    /// </summary>
    public class HyperRoleGuid : HyperRole<Guid, HyperUserRoleGuid>
    {
        public HyperRoleGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// Multi-tenant <c>Role</c> having both key and host key as <c>TKey</c> types
    /// </summary>
    public class HyperRoleInt : HyperRole<int, HyperUserRoleInt>
    {
    }

    /// <summary>
    /// Multi-tenant <c>Role</c> having both key and host key as <c>TKey</c> types
    /// </summary>
    public class HyperRoleLong : HyperRole<long, HyperUserRoleLong>
    {
    }

    /// <summary>
    /// Represents a <c>Role</c> entity for a multi-tenant DbContext.
    /// </summary>
    /// <typeparam name="TKey">The key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    public class HyperRole<TKey, TUserRole> : IdentityRole<TKey, TUserRole>, IHyperRole<TKey>
        where TKey : struct, IEquatable<TKey>
        where TUserRole : IdentityUserRole<TKey>, IHyperUserRole<TKey>, new()
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
        /// Gets or sets a value indicating whether this role can be assigned on a host-by-host basis.
        /// Only applicable to global roles;
        /// if true, then this role is ALWAYS global and can only be assigned to the system host (but applies globally)
        /// if false, this global role can be assigned to individual hosts through UserRole entity
        /// </summary>
        /// <value>
        ///   <c>true</c> if [assign by host]; otherwise, <c>false</c>.
        /// </value>
        public bool IsGlobalOnly { get; set; }


        /// <summary>
        /// Sequence field used to order display lists, etc.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public int Sequence { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRole{TKey}"/> class.
        /// </summary>
        public HyperRole()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRole{TKey}"/> class.
        /// </summary>
        /// <param name="name">The role name.</param>
        public HyperRole(string name)
        {
            Helpers.ThrowIfNull(!name.IsNullOrWhiteSpace(), "name");

            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperRole{TKey}"/> class.
        /// </summary>
        /// <param name="name">The role name.</param>
        /// <param name="hostId">The host id.</param>
        public HyperRole(string name, TKey hostId)
        {
            Helpers.ThrowIfNull(!name.IsNullOrWhiteSpace(), "name");
            Helpers.ThrowIfNull(!hostId.Equals(default(TKey)), "hostId");

            this.Name = name;
            this.HostId = hostId;
        }
    }
}
