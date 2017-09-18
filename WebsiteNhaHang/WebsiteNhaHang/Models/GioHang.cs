using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteNhaHang.Models
{
    public class GioHang
    {
        NhaHangEntities db = new NhaHangEntities();
        public int iMaSP { get; set; }
        public int iLoaiDat { get; set; }
        public string sTenSp { get; set; }
        public string sHinhAnh { get; set; }

        [Range(1, 15)]
        public int iSoLuong { get; set; }
        public double dDonGia { get; set; }
        public double dThanhTien { get { return iSoLuong * dDonGia; } }
        //TaoGioHang
        public GioHang(int MaSP,int LoaiDat)
        {
            iMaSP = MaSP;
            iLoaiDat = LoaiDat;
            if (LoaiDat == 1)
            {
                MonAn monAn = db.MonAns.Single(n => n.MaMon == iMaSP);
                sTenSp = monAn.TenMon;
                sHinhAnh = monAn.HinhAnh;
                dDonGia =double.Parse(monAn.Gia.ToString());
                iSoLuong = 1;
            }
            else
            {
                GoiCombo goiCombo = db.GoiComboes.Single(n => n.MaCombo == iMaSP);
                sTenSp = goiCombo.TenComBo;
                sHinhAnh = goiCombo.HinhAnh;
                dDonGia = double.Parse(goiCombo.Gia.ToString());
                iSoLuong = 1;
            }

        }
    }
}