using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webCommon.Common
{
    [Serializable]
    public class UserLogin
    {
        // lấy dữ liệu trung gian từ database
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}