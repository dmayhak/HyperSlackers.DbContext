using HyperSlackers.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.DbContext.Demo.Entities
{
    // DRM Added
    public class InvoiceItem : IAuditable<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HostId { get; set; }
        public Guid InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
}

