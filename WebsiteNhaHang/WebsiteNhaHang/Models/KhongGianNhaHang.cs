﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations;

    public partial class KhongGianNhaHang
    {
        public int MaKhongGian { get; set; }
        [Display(Name = "Tên khu vực")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string TenKhongGian { get; set; }
        [Display(Name = "Hình Ảnh")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string HinhAnh { get; set; }
        [Display(Name = "Giới thiệu")]
        public string GioiThieu { get; set; }
        [Display(Name = "Loại không gian")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public Nullable<int> LoaiKhongGian { get; set; }
        [Display(Name = "Người đăng")]
        public Nullable<int> NguoiDang { get; set; }
        [Display(Name = "Ngày đăng")]        
        public Nullable<System.DateTime> NgayDang { get; set; }
    
        public virtual LoaiKhongGianNhaHang LoaiKhongGianNhaHang { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
