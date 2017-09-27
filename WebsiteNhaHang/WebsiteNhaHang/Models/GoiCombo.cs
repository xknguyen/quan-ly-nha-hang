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

    public partial class GoiCombo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoiCombo()
        {
            this.DanhSachDatCombo = new HashSet<DanhSachDatCombo>();
            this.MonAn = new HashSet<MonAn>();
        }
    
        public int MaCombo { get; set; }
        [Display(Name = "Tên Combo")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string TenComBo { get; set; }
        [Display(Name = "Hình Ảnh")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string HinhAnh { get; set; }
        [Display(Name = "Giá")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public Nullable<double> Gia { get; set; }
        [Display(Name = "Giới thiệu")]
        public string GioiThieu { get; set; }
        [Display(Name = "Số lần đặt")]
        public Nullable<int> SoLanDat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachDatCombo> DanhSachDatCombo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonAn> MonAn { get; set; }
    }
}
