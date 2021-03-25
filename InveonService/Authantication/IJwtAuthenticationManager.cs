using InveonService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InveonService.Authantication
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(User users);
    }
}
