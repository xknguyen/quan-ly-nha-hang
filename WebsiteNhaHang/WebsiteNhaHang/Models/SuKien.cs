//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SuKien
    {
        public int MaSuKien { get; set; }
        public string TenSuKien { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public Nullable<System.DateTime> NgayDang { get; set; }
        public string HinhAnh { get; set; }
        public string ChiTiet { get; set; }
        public Nullable<int> NguoiDang { get; set; }
    
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
