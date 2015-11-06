using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Defines an entity object that can have data changes automatically audited/logged in the database.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IAuditable<TKey> : IEntity<TKey>
    {
    }
}
