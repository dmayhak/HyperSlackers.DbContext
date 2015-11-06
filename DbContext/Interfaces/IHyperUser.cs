using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Minimal interface for a user in a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TKey">The key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
    /// <typeparam name="TKey">The host id key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
    public interface IHyperUser<TKey> : IUser<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the host identifier.
        /// </summary>
        /// <value>
        /// The host identifier.
        /// </value>
        TKey HostId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is global.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is global; otherwise, <c>false</c>.
        /// </value>
        bool IsGlobal { get; set; }
    }
}
