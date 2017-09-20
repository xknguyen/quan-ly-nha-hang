var giohang = {
    init: function () {
        giohang.regEvents();
    },
    regEvents: function () { 
        $('.txtCapNhap').off('click').on('click', function () {
            var soLuong = $('.txtSoLuong').val();
            var maSP=$('.txtSoLuong').data('id');
            var loaiDat=$('.txtSoLuong').data('loai');
            $.ajax({
                
                type: 'POST',
                dataType: 'json',
                //data: { gioHang: JSON.stringify(duLieu) },
                data:{
                    iSoLuong:soLuong ,
                    iMaSP:maSP ,
                    iLoaiDat: loaiDat,
                },
                url: '/DatBan/CapNhapSoLuong',
                success: function (res) {
                    if (res.status == true) {
                        //alert("Sửa thành công!")
                        window.location.href = $(location).attr('href');
                    }                    
                },
                //error: function() {
                //    alert("Loi");
                //}
            })
        });
        $('#btnXoa').off('click').on('click', function () {
            $.ajax({
                url: '/DatBan/XoaTatCa',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        //alert("Xóa thành công!")
                        
                        window.location.href = $(location).attr('href');
                    }
                }
            })
        });
        $('.txtXoa').off('click').on('click', function () {
            var maSP = $('.txtXoa').data('id');
            var loai = $('.txtXoa').data('loai')
            $.ajax({

                type: 'POST',
                dataType: 'json',
                //data: { gioHang: JSON.stringify(duLieu) },
                data: {
                    iMaSP: maSP,
                    iLoaiDat:loai,
                },
                url: '/DatBan/XoaGioHang',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = $(location).attr('href');
                    }
                },
                //error: function() {
                //    alert("Loi");
                //}
            })
        });
    }
}
giohang.init();