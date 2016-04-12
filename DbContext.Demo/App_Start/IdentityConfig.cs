using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using HyperSlackers.DbContext.Demo.Models;
using HyperSlackers.AspNet.Identity.EntityFramework;
using System.Diagnostics.Contracts;

namespace HyperSlackers.DbContext.Demo
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    // DRM Changed
    //x public class ApplicationUserManager : UserManager<ApplicationUser>
    public class ApplicationUserManager : HyperUserManagerGuid<ApplicationUser>
    {
        //x public ApplicationUserManager(IUserStore<ApplicationUser> store)
        public ApplicationUserManager(HyperUserStoreGuid<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            Contract.Requires<ArgumentNullException>(options != null, "options");
            Contract.Requires<ArgumentNullException>(context != null, "context");

            // DRM Changed
            //x var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            var manager = new ApplicationUserManager(new HyperUserStoreGuid<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            // DRM Changed
            //x manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            manager.UserValidator = new HyperUserValidatorGuid<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                // DRM Changed
                //x RequireUniqueEmail = true
                RequireUniqueEmail = false // Multi-host requires non-unique emails
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            // DRM Changed
            //x manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser, Guid>
            {
                MessageFormat = "Your security code is {0}"
            });
            // DRM Changed
            //x manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser, Guid>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    // DRM Changed
                    //x new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
                    new DataProtectorTokenProvider<ApplicationUser, Guid>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    // DRM Changed
    //x public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    public class ApplicationSignInManager : SignInManager<ApplicationUser, Guid>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            Contract.Requires<ArgumentNullException>(context != null, "context");

            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }
    }

    // DRM Added
    public class ApplicationRoleManager : HyperRoleManagerGuid<ApplicationUser>
    {
        public ApplicationRoleManager(HyperRoleStoreGuid<ApplicationUser> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new HyperRoleStoreGuid<ApplicationUser>(context.Get<ApplicationDbContext>()));
        }
    }

    // DRM Added
    public class ApplicationRoleGroupManager : HyperRoleGroupManagerGuid<ApplicationUser>
    {
        public ApplicationRoleGroupManager(HyperRoleGroupStoreGuid<ApplicationUser> groupStore)
            : base(groupStore)
        {
        }

        public static ApplicationRoleGroupManager Create(IdentityFactoryOptions<ApplicationRoleGroupManager> options, IOwinContext context)
        {
            return new ApplicationRoleGroupManager(new HyperRoleGroupStoreGuid<ApplicationUser>(context.Get<ApplicationDbContext>()));
        }
    }

    // DRM Added
    public class ApplicationHostManager : HyperHostManagerGuid<ApplicationUser>
    {
        public ApplicationHostManager(HyperHostStoreGuid<ApplicationUser> hostStore)
            : base(hostStore)
        {
        }

        public static ApplicationHostManager Create(IdentityFactoryOptions<ApplicationHostManager> options, IOwinContext context)
        {
            return new ApplicationHostManager(new HyperHostStoreGuid<ApplicationUser>(context.Get<ApplicationDbContext>()));
        }
    }
}
