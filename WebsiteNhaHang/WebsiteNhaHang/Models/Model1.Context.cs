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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NhaHangEntities : DbContext
    {
        public NhaHangEntities()
            : base("name=NhaHangEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<DanhSachDatCombo> DanhSachDatCombo { get; set; }
        public virtual DbSet<DanhSachMonDatBan> DanhSachMonDatBan { get; set; }
        public virtual DbSet<DatBan> DatBan { get; set; }
        public virtual DbSet<GoiCombo> GoiCombo { get; set; }
        public virtual DbSet<KieuDatBan> KieuDatBan { get; set; }
        public virtual DbSet<KhongGianNhaHang> KhongGianNhaHang { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<LoaiKhongGianNhaHang> LoaiKhongGianNhaHang { get; set; }
        public virtual DbSet<LoaiMon> LoaiMon { get; set; }
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoan { get; set; }
        public virtual DbSet<MonAn> MonAn { get; set; }
        public virtual DbSet<SuKien> SuKien { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TuyenDung> TuyenDung { get; set; }
        public virtual DbSet<ThongTinNhaHang> ThongTinNhaHang { get; set; }
    }
}
