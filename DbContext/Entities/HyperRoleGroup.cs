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
    public class HyperRoleGroupGuid : HyperRoleGroup<Guid, HyperRoleGroupRoleGuid, HyperRoleGroupUserGuid>
    {
        public HyperRoleGroupGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// Represents a set of Roles and the users assigned to them.
    /// </summary>
    public class HyperRoleGroupInt : HyperRoleGroup<int, HyperRoleGroupRoleInt, HyperRoleGroupUserInt>
    {

    }

    /// <summary>
    /// Represents a set of Roles and the users assigned to them.
    /// </summary>
    public class HyperRoleGroupLong : HyperRoleGroup<long, HyperRoleGroupRoleLong, HyperRoleGroupUserLong>
    {

    }

    /// <summary>
    /// Represents a set of Roles and the users assigned to them.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TRoleGroupRole">The type of the group role.</typeparam>
    /// <typeparam name="TRoleGroupUser">The type of the group user.</typeparam>
    public class HyperRoleGroup<TKey, TRoleGroupRole, TRoleGroupUser> : IAuditable<TKey>
        where TKey : struct, IEquatable<TKey>
        where TRoleGroupRole : HyperRoleGroupRole<TKey>
        where TRoleGroupUser : HyperRoleGroupUser<TKey>
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
        public virtual ICollection<TRoleGroupRole> Roles { get; set; }

        [CascadeDelete]
        public virtual ICollection<TRoleGroupUser> Users { get; set; }

        public HyperRoleGroup()
        {
            this.Roles = new List<TRoleGroupRole>();
            this.Users = new List<TRoleGroupUser>();
        }

        public HyperRoleGroup(string name)
            : this()
        {
            this.Name = name;
        }

        public HyperRoleGroup(string name, string description)
            : this(name)
        {
            this.Description = description;
        }
    }
}
