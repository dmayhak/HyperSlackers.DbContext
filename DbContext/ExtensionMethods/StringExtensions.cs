using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns true if the string is either null, or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [Pure]
        public static bool IsNullOrEmpty(this String value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Returns true if the string is null, empty, or contains only whitespace.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [Pure]
        public static bool IsNullOrWhiteSpace(this String value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
