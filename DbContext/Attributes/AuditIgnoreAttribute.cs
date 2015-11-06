using System;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Tells the auditing engine to NOT audit this property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class AuditIgnoreAttribute : Attribute
    {
    }
}
