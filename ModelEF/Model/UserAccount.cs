
//@Admin: Nguyen Cong Thuan

namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Mật Khẩu")]
        public string Password { get; set; }

        [StringLength(100)]
        [DisplayName("Trạng Thái")]
        public string Status { get; set; }
    }
}
