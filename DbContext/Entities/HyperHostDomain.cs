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
    /// Represents a domain name or machine name that identifies a particular host.
    /// A host can be tied to multiple domains (domain.com, www.domain.com, etc.)
    /// </summary>
    public class HyperHostDomainGuid : HyperHostDomain<Guid, HyperHostGuid, HyperHostDomainGuid>
    {
        public HyperHostDomainGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// Represents a domain name or machine name that identifies a particular host.
    /// A host can be tied to multiple domains (domain.com, www.domain.com, etc.)
    /// </summary>
    public class HyperHostDomainInt : HyperHostDomain<int, HyperHostInt, HyperHostDomainInt>
    {
    }

    /// <summary>
    /// Represents a domain name or machine name that identifies a particular host.
    /// A host can be tied to multiple domains (domain.com, www.domain.com, etc.)
    /// </summary>
    public class HyperHostDomainLong : HyperHostDomain<long, HyperHostLong, HyperHostDomainLong>
    {
    }

    /// <summary>
    /// Represents a domain name or machine name that identifies a particular host.
    /// A host can be tied to multiple domains (domain.com, www.domain.com, etc.)
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public class HyperHostDomain<TKey, THost, THostDomain>
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
        /// Gets or sets the host identifier.
        /// </summary>
        /// <value>
        /// The host identifier.
        /// </value>
        [Index("IX_Domain_Host", 1, IsUnique = true)]
        [Index("IX_Host_Domain", 0, IsUnique = true)]
        public TKey HostId { get; set; }

        /// <summary>
        /// Gets or sets the domain name / machine name.
        /// </summary>
        /// <value>
        /// The name of the domain.
        /// </value>
        [Required]
        [MaxLength(255)]
        [Index("IX_Domain_Host", 0, IsUnique = true)]
        [Index("IX_Host_Domain", 1, IsUnique = true)]
        public string DomainName { get; set; }

        [ForeignKey("HostId")]
        public virtual THost Host { get; set; }
    }
}
