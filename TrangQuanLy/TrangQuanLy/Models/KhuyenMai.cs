//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrangQuanLy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhuyenMai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuyenMai()
        {
            this.MonAns = new HashSet<MonAn>();
        }
    
        public int MaKhuyenMai { get; set; }
        public string TenKhuyenMai { get; set; }
        public string ChiTietKhuyenMai { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<int> NguoiDang { get; set; }
        public Nullable<System.DateTime> NgayDang { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public Nullable<double> TiLeGiamGia { get; set; }
    
        public virtual TaiKhoan TaiKhoan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonAn> MonAns { get; set; }
    }
}
