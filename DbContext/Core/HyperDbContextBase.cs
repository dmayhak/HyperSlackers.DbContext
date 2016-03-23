using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Reflection;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    /// <summary>
    /// Base class for our DBContext implementation.
    /// </summary>
    /// <typeparam name="THost">The type of the host.</typeparam>
    /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <typeparam name="TRole">The type of the role.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    public class HyperDbContextBase<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> : IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>
        where THost : HyperHost<TKey, THost, THostDomain>, new()
        where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
        where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
        where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TUserLogin : HyperUserLogin<TKey>, IHyperUserLogin<TKey>, new()
        where TUserRole : HyperUserRole<TKey>, IHyperUserRole<TKey>, new()
        where TUserClaim : HyperUserClaim<TKey>, IHyperUserClaim<TKey>, new()
        where TGroup : HyperGroup<TKey, TGroupRole, TGroupUser>, new()
        where TGroupRole : HyperGroupRole<TKey>, new()
        where TGroupUser : HyperGroupUser<TKey>, new()
        where TAudit : HyperAudit<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditItem : HyperAuditItem<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditProperty : HyperAuditProperty<TKey, TAudit, TAuditItem, TAuditProperty>, new()
    {
        private THost systemHost = null;
        private THost currentHost = null;
        private TUser currentUser = null;

        /// <summary>
        /// Gets or sets a value indicating whether multi-host functionality is enabled or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if multi-host is enabled; otherwise, <c>false</c>.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool MultiHostEnabled { get; set; }

        private const string defaultName = "<system>";

        /// <summary>
        /// Gets the system host.
        /// </summary>
        /// <value>
        /// The system host.
        /// </value>
        public THost SystemHost
        {
            get
            {
                if (systemHost == null)
                {
                    systemHost = this.Set<THost>().Where(h => h.IsSystemHost == true).SingleOrDefault();
                }

                return systemHost;
            }
        }

        /// <summary>
        /// Gets the current host.
        /// </summary>
        /// <value>
        /// The current host.
        /// </value>
        public THost CurrentHost
        {
            get
            {
                if (currentHost == null)
                {
                    try
                    {
                        System.Web.HttpContext context = System.Web.HttpContext.Current;
                        if (context != null)
                        {
                            // web application
                            var hostName = context.Request.Url.Host;
                            currentHost = this.Set<THostDomain>().SingleOrDefault(d => d.DomainName.ToUpper() == hostName.ToUpper()).Host;
                        }
                    }
                    catch (Exception ex)
                    {
                        //TODO: hopefully we only hit this when creating the migration and db does not exist
                        System.Diagnostics.Debug.WriteLine("CurrentHost.Get Failed: " + ex.Message);
                    }
                }

                return currentHost;
            }
        }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public TUser CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    try
                    {
                        System.Web.HttpContext context = System.Web.HttpContext.Current;
                        if (context != null)
                        {
                            var contextUser = context.User;
                            if (contextUser != null)
                            {
                                var userId = contextUser.Identity.GetUserId();
                                currentUser = this.Set<TUser>().SingleOrDefault(u => u.Id.ToString().ToUpper() == userId.ToUpper());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //TODO: hopefully we only hit this when creating the migration and db does not exist
                        System.Diagnostics.Debug.WriteLine("CurrentUser.Get Failed: " + ex.Message);
                    }
                }

                return currentUser;
            }
        }

        /// <summary>
        /// Gets the name of the system host.
        /// </summary>
        /// <value>
        /// The name of the system host.
        /// </value>
        public string SystemHostName
        {
            get
            {
                if (SystemHost != null)
                {
                    return systemHost.Name;
                }

                return defaultName;
            }
        }
        /// <summary>
        /// Gets the system host id.
        /// </summary>
        /// <value>
        /// The system host id.
        /// </value>
        public TKey SystemHostId
        {
            get
            {
                if (SystemHost != null)
                {
                    return systemHost.Id;
                }

                return default(TKey);
            }
        }

        /// <summary>
        /// Gets the name of the current host.
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        public string CurrentHostName
        {
            get
            {
                if (CurrentHost != null)
                {
                    return currentHost.Name;
                }

                return defaultName;
            }
        }

        /// <summary>
        /// Gets the current host's identifier.
        /// </summary>
        /// <value>
        /// The host identifier.
        /// </value>
        public TKey CurrentHostId
        {
            get
            {
                if (CurrentHost != null)
                {
                    return currentHost.Id;
                }

                return default(TKey);
            }
        }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string CurrentUserName
        {
            get
            {
                if (CurrentUser != null)
                {
                    return currentUser.UserName;
                }

                return defaultName;
            }
        }

        /// <summary>
        /// Gets the current user's identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public TKey CurrentUserId
        {
            get
            {
                if (CurrentUser != null)
                {
                    return currentUser.Id;
                }

                return default(TKey);
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingDbContext{TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TAudit, TAuditItem}" /> class.
        /// </summary>
        protected HyperDbContextBase()
            : this("DefaultConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditingDbContext{TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TAudit, TAuditItem}"/> class.
        /// </summary>
        /// <param name="nameOrConnectionString">The name or connection string.</param>
        protected HyperDbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Contract.Requires<ArgumentNullException>(!nameOrConnectionString.IsNullOrWhiteSpace(), "nameOrConnectionString");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // cascade deletes are no good -- well, sometimes they are no good; M-M cascade deletes might be OK most times though
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Add<CascadeDeleteAttributeConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
