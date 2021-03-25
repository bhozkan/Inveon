using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InveonService.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
