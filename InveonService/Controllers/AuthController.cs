using InveonService.Authantication;
using InveonService.Business;
using InveonService.DbContexts;
using InveonService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InveonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly InveonContext inveonContext;
        private HttpContext hcontext;

        private readonly string key = "b14ca5898a4e4133bbce2ea2315a1916";
        public AuthController(IJwtAuthenticationManager jwtAuthenticationManager, IHttpContextAccessor haccess, InveonContext _inveonContext)
        {
            
            hcontext = haccess.HttpContext;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            inveonContext = _inveonContext;

        }
        [HttpPost("Login")]
        public IActionResult Login(LoginUserModel loginModel)
        {
            var response = (new AuthBusiness(inveonContext, jwtAuthenticationManager)).Login(loginModel);
            return new JsonResult(response);
        }
    }
}
