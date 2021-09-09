using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ellickson.Model
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }
        public int? DepartmentID { get; set; }

        [Required(ErrorMessage = "Please Enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter your Designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Please Enter your Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter your State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter your City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter your PinCode")]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Please Enter your ContactNo")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please Enter your Alternate_ContactNo")]
        public string Alternate_ContactNo { get; set; }

        [Required(ErrorMessage = "Please Enter your EmailID")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Please Enter your Password")]
        public string Password { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool isActive { get; set; }

        public bool isDelete { get; set; }
    }
}
