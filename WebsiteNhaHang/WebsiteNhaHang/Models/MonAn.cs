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
    
    public partial class MonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonAn()
        {
            this.GiamGias = new HashSet<GiamGia>();
            this.DatBans = new HashSet<DatBan>();
            this.GoiComboes = new HashSet<GoiCombo>();
        }
    
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public Nullable<int> LoaiMon { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<double> Gia { get; set; }
        public string ChiTiet { get; set; }
        public Nullable<int> GiamGia { get; set; }
        public Nullable<int> SoLuotDat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiamGia> GiamGias { get; set; }
        public virtual LoaiMon LoaiMon1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatBan> DatBans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoiCombo> GoiComboes { get; set; }
    }
}
