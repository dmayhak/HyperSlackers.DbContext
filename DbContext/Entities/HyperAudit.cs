using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// An audit entry tracks a group of changes that were committed to the database in one
    /// transaction. Each change has an <see cref="AuditItem" /> in the <c>AuditItems</c>
    /// </summary>
    public class HyperAuditGuid : HyperAudit<Guid, HyperAuditGuid, HyperAuditItemGuid, HyperAuditPropertyGuid>
    {
        public HyperAuditGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// An audit entry tracks a group of changes that were committed to the database in one
    /// transaction. Each change has an <see cref="AuditItem" /> in the <c>AuditItems</c>
    /// </summary>
    public class HyperAuditInt : HyperAudit<int, HyperAuditInt, HyperAuditItemInt, HyperAuditPropertyInt>
    {

    }

    /// <summary>
    /// An audit entry tracks a group of changes that were committed to the database in one
    /// transaction. Each change has an <see cref="AuditItem" /> in the <c>AuditItems</c>
    /// </summary>
    public class HyperAuditLong : HyperAudit<long, HyperAuditLong, HyperAuditItemLong, HyperAuditPropertyLong>
    {

    }

    /// <summary>
    /// An audit entry tracks a group of changes that were committed to the database in one
    /// transaction. Each change has an <see cref="AuditItem" /> in the <c>AuditItems</c>
    /// List.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public class HyperAudit<TKey, TAudit, TAuditItem, TAuditProperty>
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
        [Index("IX_Date_Id", 1)]
        public TKey Id { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Index("IX_ClusteredKey", IsClustered = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClusteredKey { get; protected set; }

        /// <summary>
        /// Gets or sets the host identifier. Only used for multi-host systems.
        /// </summary>
        /// <value>
        /// The host identifier.
        /// </value>
        [Index("IX_Host_Date", 0)]
        public TKey HostId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [Index("IX_User_Date", 0)]
        public TKey UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the host.
        /// Computer name for a windows application, host name for web application
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        [MaxLength(255)]
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the name of the user. From windows identity or web identity.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [MaxLength(255)]
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the date/time the audit record was created.
        /// </summary>
        /// <value>
        /// The audit date.
        /// </value>
        [Required]
        [Index("IX_Date", 0)]
        [Index("IX_Host_Date", 1)]
        [Index("IX_User_Date", 1)]
        public DateTime AuditDate { get; set; }

        [CascadeDelete]
        internal ICollection<TAuditItem> AuditItems { get; set; }

        public HyperAudit()
        {
            this.AuditItems = new List<TAuditItem>();
        }
    }
}
