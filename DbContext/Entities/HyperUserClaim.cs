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
    /// Entity type that represents one specific user claim in a multi-tenant <c>DbContext</c>.
    /// </summary>
    public class HyperUserClaimGuid : HyperUserClaim<Guid>
    {
    }

    /// <summary>
    /// Entity type that represents one specific user claim in a multi-tenant <c>DbContext</c>.
    /// </summary>
    public class HyperUserClaimInt : HyperUserClaim<int>
    {
    }

    /// <summary>
    /// Entity type that represents one specific user claim in a multi-tenant <c>DbContext</c>.
    /// </summary>
    public class HyperUserClaimLong : HyperUserClaim<long>
    {
    }

    /// <summary>
    /// Entity type that represents one specific user claim in a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TKey">The key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
    public class HyperUserClaim<TKey> : IdentityUserClaim<TKey>, IHyperUserClaim<TKey>
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
        /// Gets or sets a value indicating whether this instance is global.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is global; otherwise, <c>false</c>.
        /// </value>
        public bool IsGlobal { get; set; }
    }
}
