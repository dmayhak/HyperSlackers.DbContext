using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Defines an entity object that can have data changes automatically audited/logged in the database.
    /// Logs data changes as well as who made the change and when.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IAuditableDate<TKey> : IAuditable<TKey>, IAssignDate<TKey>
    {
    }
}
