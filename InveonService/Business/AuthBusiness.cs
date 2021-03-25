using InveonService.Authantication;
using InveonService.DbContexts;
using InveonService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InveonService.Business
{
    public class AuthBusiness
    {
        private readonly InveonContext inveonContext;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public AuthBusiness(InveonContext _inveonContext, IJwtAuthenticationManager _jwtAuthenticationManager)
        {
            inveonContext = _inveonContext;
            jwtAuthenticationManager = _jwtAuthenticationManager;
        }
        public object Login(LoginUserModel loginUser)
        {
            User user = inveonContext.Users.Where(x => x.UserName == loginUser.UserName && x.Password == loginUser.Password).FirstOrDefault();

            if (user != null)
            {
                return jwtAuthenticationManager.Authenticate(user);    
            }
            else
            {
                return null;
            }
        }
    }
}
