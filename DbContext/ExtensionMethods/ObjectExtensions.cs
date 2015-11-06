using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// taken from: https://raw.githubusercontent.com/Burtsev-Alexey/net-object-deep-copy/master/ObjectExtensions.cs
    /// </summary>
    internal static class ObjectExtensions
    {
        private readonly static object lockObject = new object();

        /// <summary>
        /// Creates a copy of the specified object by copying valueType property values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original">The original.</param>
        /// <returns></returns>
        public static T Copy<T>(this T original)
        {
            try
            {
                Monitor.Enter(lockObject);

                T copy = Activator.CreateInstance<T>();

                PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

                foreach (PropertyInfo prop in properties)
                {
                    if (prop.PropertyType.IsValueType || prop.PropertyType == typeof(String))
                    {
                        if (prop.GetValue(copy, null) != prop.GetValue(original, null))
                        {
                            prop.SetValue(copy, prop.GetValue(original, null), null);
                        }
                    }
                }

                return copy;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
    }
}