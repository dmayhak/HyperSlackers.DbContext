using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Minimal interface for a user login for a multi-tenant <c>DbContext</c>.
    /// </summary>
    /// <typeparam name="TKey">The database key type. (Typically <c>string</c>, <c>Guid</c>, <c>int</c>, or <c>long</c>.)</typeparam>
    public interface IHyperUserLogin<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        TKey HostId { get; set; }
        bool IsGlobal { get; set; }
    }
}
