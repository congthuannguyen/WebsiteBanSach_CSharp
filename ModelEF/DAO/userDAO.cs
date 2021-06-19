
//@ Nguyen Cong Thuan

using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class userDAO
    {
        private NguyenCongThuanContext db;

        public userDAO()
        {
            db = new NguyenCongThuanContext();
        }

        // kiểm tra userName và password
        public int Login(String UserName, String UserPassword)
        {
            if(UserName.Equals("") || UserPassword.Equals(""))
            {
                return -2;
            }
            else
            {
                var result = db.UserAccounts.SingleOrDefault(x => x.UserName == UserName);
                if (result == null) //Nếu không tồn tại username thì return 0
                {
                    return 0;
                }
                else
                {
                    if (result.Password == UserPassword)
                    {
                        return 1; //Trả về 1 nếu tên đăng nhập và mật khẩu đều đúng
                    }
                    else
                    {
                        return -1; //Trả về -1 nếu đúng tên đăng nhập nhưng sai mật khẩu
                    }
                }
            }
        }

        public UserAccount getUserByID(string user)
        {
            return db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user));
        }
        // lấy dữ liệu tạo trang
        public IEnumerable<UserAccount> ListAllPaging(int page, int pageSize)
        {
            return db.UserAccounts.OrderBy(x=>x.ID).ToPagedList(page, pageSize);
        }
    }
}
