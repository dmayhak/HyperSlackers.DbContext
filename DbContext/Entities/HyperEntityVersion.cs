using System;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// An entity and its property values at a point in time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class HyperEntityVersionGuid<TEntity> : HyperEntityVersion<Guid, TEntity>
        where TEntity : IAuditable<Guid>
    {

    }

    /// <summary>
    /// An entity and its property values at a point in time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class HyperEntityVersionInt<TEntity> : HyperEntityVersion<int, TEntity>
        where TEntity : IAuditable<int>
    {

    }

    /// <summary>
    /// An entity and its property values at a point in time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class HyperEntityVersionLong<TEntity> : HyperEntityVersion<long, TEntity>
        where TEntity : IAuditable<long>
    {

    }

    /// <summary>
    /// An entity and its property values at a point in time.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class HyperEntityVersion<TKey, TEntity>
        where TKey : struct, IEquatable<TKey>
        where TEntity : IAuditable<TKey>
    {
        /// <summary>
        /// Gets the edit date.
        /// </summary>
        /// <value>
        /// The edit date.
        /// </value>
        public DateTime EditDate { get; internal set; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; internal set; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public TKey UserId { get; internal set; }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public TEntity Entity { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperEntityVersion{TKey, TEntity}"/> class.
        /// </summary>
        internal HyperEntityVersion()
        {
            // prevent public instantiation
        }
    }
}
