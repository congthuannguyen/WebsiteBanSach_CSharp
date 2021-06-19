
//@ Nguyen Cong Thuan

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    public class LoginModels
    {
        [Required]
        public string UserName { get; set; }

        public string PassWord { get; set; }

    }
}