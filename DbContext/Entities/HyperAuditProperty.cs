using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Audit property references an entity and property that is tracked by the auditing system.
    /// </summary>
    public class HyperAuditPropertyGuid : HyperAuditProperty<Guid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
    {
        public HyperAuditPropertyGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// Audit property references an entity and property that is tracked by the auditing system.
    /// </summary>
    public class HyperAuditPropertyInt : HyperAuditProperty<int, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
    {

    }

    /// <summary>
    /// Audit property references an entity and property that is tracked by the auditing system.
    /// </summary>
    public class HyperAuditPropertyLong : HyperAuditProperty<long, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
    {

    }

    /// <summary>
    /// Audit property references an entity and property that is tracked by the auditing system.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="T:ClassroomForOne.Entities.IEntity" />
    public class HyperAuditProperty<TKey, TAudit, TAuditItem, TAuditProperty>
        where TKey : struct, IEquatable<TKey>
        where TAudit : HyperAudit<TKey, TAudit, TAuditItem, TAuditProperty>
        where TAuditItem : HyperAuditItem<TKey, TAudit, TAuditItem, TAuditProperty>
        where TAuditProperty : HyperAuditProperty<TKey, TAudit, TAuditItem, TAuditProperty>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public TKey Id { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Index("IX_ClusteredKey", IsClustered = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClusteredKey { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        [Required]
        [MaxLength(255)]
        [Index("IX_Entity_Property", 0)]
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        [MaxLength(255)]
        [Index("IX_Entity_Property", 1)]
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the type of the property.
        /// </summary>
        /// <value>
        /// The type of the property.
        /// </value>
        public string PropertyType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is a relation.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is relation; otherwise, <c>false</c>.
        /// </value>
        public bool IsRelation { get; set; }
    }
}
