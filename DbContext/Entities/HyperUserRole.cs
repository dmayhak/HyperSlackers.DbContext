using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Entity type that represents a user belonging to a role in a multi-tenant <c>DbContext</c>.
    /// </summary>
    public class HyperUserRoleGuid : HyperUserRole<Guid>
    {
    }

    /// <summary>
    /// Entity type that represents a user belonging to a role in a multi-tenant <c>DbContext</c>.
    /// </summary>
    public class HyperUserRoleInt : HyperUserRole<int>
    {
    }

    /// <summary>
    /// Entity type that represents a user belonging to a role in a multi-tenant <c>DbContext</c>.
    /// </summary>
    public class HyperUserRoleLong : HyperUserRole<long>
    {
    }

    /// <summary>
    /// Entity type that represents a user belonging to a role in a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TKey">The key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
    public class HyperUserRole<TKey> : IdentityUserRole<TKey>, IHyperUserRole<TKey>
        where TKey : struct, IEquatable<TKey>
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
        /// Gets or sets the id of the group responsible for this role being assigned.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public TKey? GroupId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the role is assigned at the global level.
        /// Global roles, if not Global Only, are assigned to a user for a particular host and are
        /// not flagged as global here.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is global; otherwise, <c>false</c>.
        /// </value>
        public bool IsGlobal { get; set; }
    }
}
