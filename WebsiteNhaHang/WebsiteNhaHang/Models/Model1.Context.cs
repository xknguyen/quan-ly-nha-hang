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
    
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<DanhSachDatCombo> DanhSachDatComboes { get; set; }
        public virtual DbSet<DanhSachMonDatBan> DanhSachMonDatBans { get; set; }
        public virtual DbSet<DatBan> DatBans { get; set; }
        public virtual DbSet<GoiCombo> GoiComboes { get; set; }
        public virtual DbSet<KhongGianNhaHang> KhongGianNhaHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<KieuDatBan> KieuDatBans { get; set; }
        public virtual DbSet<LoaiKhongGianNhaHang> LoaiKhongGianNhaHangs { get; set; }
        public virtual DbSet<LoaiMon> LoaiMons { get; set; }
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<SuKien> SuKiens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongTinNhaHang> ThongTinNhaHangs { get; set; }
        public virtual DbSet<TuyenDung> TuyenDungs { get; set; }
    }
}