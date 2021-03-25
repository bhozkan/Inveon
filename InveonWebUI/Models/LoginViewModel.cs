using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InveonWebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Token { get; set; }
    }
}
