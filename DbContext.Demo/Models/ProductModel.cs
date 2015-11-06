using HyperSlackers.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.DbContext.Demo.Models
{
    // DRM Added
    public class ProductModel : IAuditable<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid HostId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
