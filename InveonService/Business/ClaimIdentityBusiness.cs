using InveonService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InveonService.Business
{
    public class ClaimIdentityBusiness
    {
        public static User GetUser(ClaimsPrincipal user)
        {
            var userData = (from c in user.Claims
                            select new
                            {
                                c.Type,
                                c.Value
                            }).ToList();
            User users = new User
            {
                UserName = userData.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value,
                UserType = userData.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value,
                Id = Convert.ToInt32(userData.Where(x => x.Type == ClaimTypes.UserData).FirstOrDefault().Value)
               
            };
            return users;
        }
    }
}
