﻿using System;
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
    public interface IAssignUserAndDate<TKey> : IAssignDate<TKey>
    {
        /// <summary>
        /// Gets or sets the id of the user who created the entity.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        TKey CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the last editor's user id.
        /// </summary>
        /// <value>
        /// The last changed by.
        /// </value>
        TKey LastChangedBy { get; set; }
    }
}
