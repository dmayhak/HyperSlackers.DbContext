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
    /// Linker that ties a user to a group
    /// </summary>
    public class HyperGroupUserGuid : HyperGroupUser<Guid>
    {
        public HyperGroupUserGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// Linker that ties a user to a group
    /// </summary>
    public class HyperGroupUserInt : HyperGroupUser<int>
    {

    }

    /// <summary>
    /// Linker that ties a user to a group
    /// </summary>
    public class HyperGroupUserLong : HyperGroupUser<long>
    {

    }

    /// <summary>
    /// Linker that ties a user to a group
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public class HyperGroupUser<TKey> : IAuditable<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Index("IX_ClusteredKey", IsClustered = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClusteredKey { get; protected set; }

        [Required]
        [Index("IX_User_Group_Host_Global", 2)]
        [Index("IX_Group_User_Host_Global", 2)]
        public TKey HostId { get; set; }

        [Required]
        [Index("IX_User_Group_Host_Global", 1)]
        [Index("IX_Group_User_Host_Global", 0)]
        public TKey GroupId { get; set; }

        [Required]
        [Index("IX_User_Group_Host_Global", 0)]
        [Index("IX_Group_User_Host_Global", 1)]
        public TKey UserId { get; set; }

        [Index("IX_User_Group_Host_Global", 3)]
        [Index("IX_Group_User_Host_Global", 3)]
        public bool IsGlobal { get; set; }
    }
}
