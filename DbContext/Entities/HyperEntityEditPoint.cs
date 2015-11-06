using System;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Represents a point in time that an entity was edited, when, and by whom.
    /// </summary>
    public class HyperEntityEditPointGuid : HyperEntityEditPoint<Guid>
    {

    }

    /// <summary>
    /// Represents a point in time that an entity was edited, when, and by whom.
    /// </summary>
    public class HyperEntityEditPointInt : HyperEntityEditPoint<int>
    {

    }

    /// <summary>
    /// Represents a point in time that an entity was edited, when, and by whom.
    /// </summary>
    public class HyperEntityEditPointLong : HyperEntityEditPoint<long>
    {

    }

    /// <summary>
    /// Represents a point in time that an entity was edited, when, and by whom.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public class HyperEntityEditPoint<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public TKey EntityId { get; internal set; }

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
        /// Initializes a new instance of the <see cref="HyperEntityEditPoint{TKey}"/> class.
        /// </summary>
        internal HyperEntityEditPoint()
        {
            // prevent public instantiation
        }
    }
}
