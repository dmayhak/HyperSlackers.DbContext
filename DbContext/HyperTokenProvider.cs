using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.AspNet.Identity.EntityFramework
{
    public static class HyperTokenProvider<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroup, TRoleGroupRole, TRoleGroupUser>
        where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TRoleGroupUser>, IHyperUser<TKey>, new()
        where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TUserLogin : HyperUserLogin<TKey>, IHyperUserLogin<TKey>, new()
        where TUserRole : HyperUserRole<TKey>, IHyperUserRole<TKey>, new()
        where TUserClaim : HyperUserClaim<TKey>, IHyperUserClaim<TKey>, new()
        where TRoleGroup : HyperRoleGroup<TKey, TRoleGroupRole, TRoleGroupUser>, new()
        where TRoleGroupRole : HyperRoleGroupRole<TKey>, new()
        where TRoleGroupUser : HyperRoleGroupUser<TKey>, new()
    {
        private static DataProtectorTokenProvider<TUser, TKey> tokenProvider;

        public static DataProtectorTokenProvider<TUser, TKey> Provider
        {
            get
            {
                if (tokenProvider == null)
                {
                    var dataProtectionProvider = new DpapiDataProtectionProvider();
                    tokenProvider = new DataProtectorTokenProvider<TUser, TKey>(dataProtectionProvider.Create());
                }

                return tokenProvider;
            }
        }
    }
}