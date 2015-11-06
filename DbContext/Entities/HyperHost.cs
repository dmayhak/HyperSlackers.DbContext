using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Represents a single host on a multi-host system.
    /// </summary>
    public class HyperHostGuid : HyperHost<Guid, HyperHostGuid, HyperHostDomainGuid>
    {
        public HyperHostGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// Represents a single host on a multi-host system.
    /// </summary>
    public class HyperHostInt : HyperHost<int, HyperHostInt, HyperHostDomainInt>
    {
    }

    /// <summary>
    /// Represents a single host on a multi-host system.
    /// </summary>
    public class HyperHostLong : HyperHost<long, HyperHostLong, HyperHostDomainLong>
    {
    }

    /// <summary>
    /// Represents a single host on a multi-host system.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key used in the system.</typeparam>
    public class HyperHost<TKey, THost, THostDomain>
        where TKey : struct, IEquatable<TKey>
        where THost : HyperHost<TKey, THost, THostDomain>
        where THostDomain : HyperHostDomain<TKey, THost, THostDomain>
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [MaxLength(255)]
        [Index("IX_Name", IsUnique = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is the system (default) host.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is the system host; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystemHost { get; set; }

        /// <summary>
        /// Gets or sets the domains/machine names that identify this host.
        /// </summary>
        /// <value>
        /// The domains.
        /// </value>
        [CascadeDelete]
        public virtual ICollection<THostDomain> Domains { get; set; }

        public HyperHost()
        {
            this.Domains = new List<THostDomain>();
        }
    }
}
