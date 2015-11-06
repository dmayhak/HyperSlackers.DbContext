using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// An Audit item is a single change (property modification, object insert, or object delete, relationship change) that occurred in the database.
    /// </summary>
    public class HyperAuditItemGuid : HyperAuditItem<Guid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
    {
        public HyperAuditItemGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// An Audit item is a single change (property modification, object insert, or object delete, relationship change) that occurred in the database.
    /// </summary>
    public class HyperAuditItemInt : HyperAuditItem<int, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
    {

    }

    /// <summary>
    /// An Audit item is a single change (property modification, object insert, or object delete, relationship change) that occurred in the database.
    /// </summary>
    public class HyperAuditItemLong : HyperAuditItem<long, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
    {

    }

    /// <summary>
    /// An Audit item is a single change (property modification, object insert, or object delete, relationship change) that occurred in the database.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="T:ClassroomForOne.Entities.IEntity" />
    public class HyperAuditItem<TKey, TAudit, TAuditItem, TAuditProperty>
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
        /// Gets or sets the audit identifier.
        /// </summary>
        /// <value>
        /// The audit identifier.
        /// </value>
        [Required]
        [Index("IX_Audit")]
        public TKey AuditId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the first entity involved.
        /// </summary>
        /// <value>
        /// The entity1 identifier.
        /// </value>
        [Required]
        [Index("IX_Entity1")]
        public TKey Entity1Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the first entity involved (if applicable).
        /// </summary>
        /// <value>
        /// The entity2 identifier.
        /// </value>
        [Required]
        [Index("IX_Entity2")]
        public TKey Entity2Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the audit property that was changed.
        /// </summary>
        /// <value>
        /// The audit property identifier.
        /// </value>
        [Required]
        [Index("IX_Property")]
        public TKey AuditPropertyId { get; set; }

        /// <summary>
        /// Gets or sets the type of operation.
        /// </summary>
        /// <value>
        /// The type of the operation.
        /// </value>
        /// <remarks>
        /// <list type="table">
        ///   <listheader>Operation Types</listheader>
        ///   <item>C - Create</item>
        ///   <item>U - Update</item>
        ///   <item>D - Delete</item>
        ///   <item>+ - Add Relation</item>
        ///   <item>- - Remove Relation</item>
        /// </list>
        /// </remarks>
        [Required]
        [MaxLength(1)]
        public string OperationType { get; set; }

        /// <summary>
        /// Gets or sets the old value.
        /// </summary>
        /// <value>
        /// The old value.
        /// </value>
        public string OldValue { get; set; }

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        /// <value>
        /// The new value.
        /// </value>
        public string NewValue { get; set; }

        [ForeignKey("AuditId")]
        internal TAudit Audit { get; set; }

        [ForeignKey("AuditPropertyId")]
        internal TAuditProperty AuditProperty { get; set; }

        [NotMapped]
        internal IAuditable<TKey> Entity1 { get; set; }

        [NotMapped]
        internal IAuditable<TKey> Entity2 { get; set; }
    }
}
