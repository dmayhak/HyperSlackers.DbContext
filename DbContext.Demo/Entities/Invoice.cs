using HyperSlackers.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.DbContext.Demo.Entities
{
    // DRM Added
    public class Invoice : IAuditable<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HostId { get; set; }
        public Guid UserId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double Shipping { get; set; }
        public double Total { get; set; }
        [CascadeDelete]
        public virtual ICollection<InvoiceItem> Items { get; set; }
    }
}
