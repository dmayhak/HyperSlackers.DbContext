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
    /// Represents a set of Roles and the users assigned to them.
    /// </summary>
    public class HyperGroupGuid : HyperGroup<Guid, HyperGroupRoleGuid, HyperGroupUserGuid>
    {
        public HyperGroupGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// Represents a set of Roles and the users assigned to them.
    /// </summary>
    public class HyperGroupInt : HyperGroup<int, HyperGroupRoleInt, HyperGroupUserInt>
    {

    }

    /// <summary>
    /// Represents a set of Roles and the users assigned to them.
    /// </summary>
    public class HyperGroupLong : HyperGroup<long, HyperGroupRoleLong, HyperGroupUserLong>
    {

    }

    /// <summary>
    /// Represents a set of Roles and the users assigned to them.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TGroupRole">The type of the group role.</typeparam>
    /// <typeparam name="TGroupUser">The type of the group user.</typeparam>
    public class HyperGroup<TKey, TGroupRole, TGroupUser> : IAuditable<TKey>
        where TKey : struct, IEquatable<TKey>
        where TGroupRole : HyperGroupRole<TKey>
        where TGroupUser : HyperGroupUser<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Index("IX_ClusteredKey", IsClustered = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClusteredKey { get; protected set; }

        [Index("IX_Host_Name", 0, IsUnique = true)]
        public TKey HostId { get; set; }

        [Required]
        [MaxLength(255)]
        [Index("IX_Host_Name", 1, IsUnique = true)]
        [Index("IX_Global_Name", 1)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Index("IX_Global_Name", 0)]
        public bool IsGlobal { get; set; }

        public bool IsGlobalOnly { get; set; }

        [CascadeDelete]
        public virtual ICollection<TGroupRole> Roles { get; set; }

        [CascadeDelete]
        public virtual ICollection<TGroupUser> Users { get; set; }

        public HyperGroup()
        {
            this.Roles = new List<TGroupRole>();
            this.Users = new List<TGroupUser>();
        }

        public HyperGroup(string name)
            : this()
        {
            this.Name = name;
        }

        public HyperGroup(string name, string description)
            : this(name)
        {
            this.Description = description;
        }
    }
}
