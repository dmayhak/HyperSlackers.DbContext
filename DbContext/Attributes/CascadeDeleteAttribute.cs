using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// code from: https://gist.github.com/tystol/20b07bd4e0043d43faff
namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CascadeDeleteAttribute : Attribute
    {
    }
}
