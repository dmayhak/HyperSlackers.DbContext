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
        private string systemHostName;
        private TKey systemHostId;
        private string hostName;
        private TKey hostId;
        private string userName;
        private TKey userId;
        private bool initialized = false;

        /// <summary>
        /// Gets or sets a value indicating whether multi-host functionality is enabled or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if multi-host is enabled; otherwise, <c>false</c>.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool MultiHostEnabled { get; set; }

        public const string SystemUserName = "<system>";

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
                Initialize();

                return systemHostName;
            }
            private set
            {
                Initialize();

                systemHostName = value;
            }
        }
        /// <summary>
        /// Gets the system host identifier.
        /// </summary>
        /// <value>
        /// The system host identifier.
        /// </value>
        public TKey SystemHostId
        {
            get
            {
                Initialize();

                return systemHostId;
            }
            private set
            {
                Initialize();

                systemHostId = value;
            }
        }
        /// <summary>
        /// Gets the name of the current host.
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        public string HostName
        {
            get
            {
                Initialize();

                return hostName;
            }
            private set
            {
                Initialize();

                hostName = value;
            }
        }
        /// <summary>
        /// Gets the current host's identifier.
        /// </summary>
        /// <value>
        /// The host identifier.
        /// </value>
        public TKey HostId
        {
            get
            {
                Initialize();

                return hostId;
            }
            private set
            {
                Initialize();

                hostId = value;
            }
        }
        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get
            {
                Initialize();

                return userName;
            }
            private set
            {
                Initialize();

                userName = value;
            }
        }
        /// <summary>
        /// Gets the current user's identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public TKey UserId
        {
            get
            {
                Initialize();

                return userId;
            }
            private set
            {
                Initialize();

                userId = value;
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

            this.systemHostName = string.Empty;
            this.systemHostId = default(TKey);
            this.hostName = string.Empty;
            this.hostId = default(TKey);
            this.userName = string.Empty;
            this.userId = default(TKey);
        }

        /// <summary>
        /// Initializes the system, host, and user names and ids.
        /// </summary>
        /// <param name="forceInit">if set to <c>true</c> forces a re-initialization of the variables.</param>
        protected void Initialize(bool forceInit = false)
        {
            if (initialized && !forceInit)
            {
                return;
            }

            initialized = true; // up top to avoid recursion on first call

            this.SystemHostName = GetSystemHostName();
            this.SystemHostId = GetSystemHostId();
            this.HostName = GetHostName();
            this.HostId = GetHostId(this.HostName);
            this.UserName = GetUserName();
            this.UserId = GetUserId(this.UserName);
        }

        /// <summary>
        /// Gets the name of the system host.
        /// </summary>
        /// <returns>The name of the system host, or "<system>" if no system host found.</system></returns>
        private string GetSystemHostName()
        {
            var host = this.Set<THost>().SingleOrDefault(h => h.IsSystemHost);
            if (host != null)
            {
                return host.Name;
            }

            return "<system>";
        }

        /// <summary>
        /// Gets the host id for the system host.
        /// </summary>
        /// <returns>The id of the system host, or <code>default(TKey)</code> if no system host found.</returns>
        private TKey GetSystemHostId()
        {
            var host = this.Set<THost>().SingleOrDefault(h => h.IsSystemHost);
            if (host != null)
            {
                return host.Id;
            }

            return default(TKey);
        }

        /// <summary>
        /// Gets the name of the current host.
        /// </summary>
        /// <returns></returns>
        private string GetHostName()
        {
            try
            {
                System.Web.HttpContext context = System.Web.HttpContext.Current;
                if (context != null)
                {
                    // web application
                    return context.Request.Url.Host;
                }
                else
                {
                    // windows application
                    var host = System.Environment.MachineName;

                    return host;
                }
            }
            catch (Exception ex)
            {
                //TODO: hopefully we only hit this when creating the migration and db does not exist
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return SystemHostName;
        }

        /// <summary>
        /// Gets the host id for the specified host name.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        private TKey GetHostId(string hostName)
        {
            if (!MultiHostEnabled || hostName == SystemHostName)
            {
                return SystemHostId;
            }

            if (!hostName.IsNullOrWhiteSpace())
            {
                var host = this.Set<THost>().SingleOrDefault(h => h.Name.ToUpper() == hostName.ToUpper());
                if (host != null)
                {
                    return host.Id;
                }
            }

            return SystemHostId;
        }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns></returns>
        private string GetUserName()
        {
            try
            {
                System.Web.HttpContext context = System.Web.HttpContext.Current;
                if (context != null)
                {
                    // web application
                    return context.User.Identity.Name;
                }
                else
                {
                    // windows application
                    var user = System.Security.Principal.WindowsIdentity.GetCurrent();

                    return user.Name;
                }
            }
            catch (Exception ex)
            {
                //TODO: hopefully we only hit this when creating the migration and db does not exist
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return SystemUserName;
        }

        /// <summary>
        /// Gets the user id for the specified user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns></returns>
        private TKey GetUserId(string userName)
        {
            if (!userName.IsNullOrWhiteSpace() && userName != SystemUserName)
            {
                var user = this.Set<TUser>().SingleOrDefault(u => u.UserName.ToUpper() == userName.ToUpper());
                if (user != null)
                {
                    return user.Id;
                }
            }

            return default(TKey);
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
