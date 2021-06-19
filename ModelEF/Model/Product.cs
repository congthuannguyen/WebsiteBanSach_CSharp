
//@Admin: Nguyen Cong Thuan

namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Image = "~/Contents/Images/Add.png";
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Tên Sách Không Được Bỏ Trống")]
        [StringLength(100)]
        [DisplayName("Tên Sách")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Đơn Không Được Bỏ Trống")]
        [DisplayName("Đơn Giá")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:#,##0} VNĐ", ApplyFormatInEditMode = true)]
        public decimal UnitCost { get; set; }

        [Required(ErrorMessage = "Số Lượng Không Được Bỏ Trống")]
        [DisplayName("Số Lượng")]
        public int Quantity { get; set; }

        [StringLength(300)]
        [DisplayName("Hình Ảnh")]
        public string Image { get; set; }

        [StringLength(200)]
        [DisplayName("Mô Tả")]
        public string Description { get; set; }

        [StringLength(100)]
        [DisplayName("Trạng Thái")]
        public string Status { get; set; }

        [DisplayName("ID Loại Sách")]
        public int? IDCategoryNo { get; set; }

        public virtual Category Category { get; set; }
    }
}
