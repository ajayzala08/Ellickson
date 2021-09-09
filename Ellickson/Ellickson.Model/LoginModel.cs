using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ellickson.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter your Email Id")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please Enter your Password")]
        public string password { get; set; }
    }
}
