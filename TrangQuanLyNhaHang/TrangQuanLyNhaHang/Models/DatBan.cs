//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrangQuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DatBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatBan()
        {
            this.DanhSachDatComboes = new HashSet<DanhSachDatCombo>();
            this.DanhSachMonDatBans = new HashSet<DanhSachMonDatBan>();
        }
    
        public int MaDatBan { get; set; }
        public Nullable<System.DateTime> NgayDatBan { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public Nullable<System.DateTime> NgayThucHien { get; set; }
        public Nullable<int> KieuDatBan { get; set; }
        public Nullable<int> SoNguoi { get; set; }
        public Nullable<double> TongTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachDatCombo> DanhSachDatComboes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachMonDatBan> DanhSachMonDatBans { get; set; }
        public virtual KieuDatBan KieuDatBan1 { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
