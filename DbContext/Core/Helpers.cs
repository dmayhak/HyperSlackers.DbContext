using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    internal static class Helpers
    {
        public static void ThrowIfNull(bool condition, string paramName)
        {
            if (!condition)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
