using shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Areas.Admin.Models.SanPhamBus
{
    public class SanPhamBus
    {
        public static IEnumerable<SANPHAM> List()
        {
            var db = new shopDB();
            return db.Query<SANPHAM>("select * from sanpham");
        }

        public static void insert(SANPHAM sp)
        {
            sp.Insert();
        }

        public static void Delete(int id)
        {
            try
            {
                using (var db = new shopDB())
                {
                    db.Execute("delete from SANPHAM where MaSanPham = @0", id);
                }
            }
            catch
            {
            }
        }

        public static SANPHAM GetProduct(int id)
        {
            using (var db = new shopDB())
            {
                return db.SingleOrDefault<SANPHAM>("select * from SANPHAM where MaSanPham = @0", id);
            }
        }
        public static void UpdateProduct(SANPHAM Sp, int valueImg)
        {
            if (valueImg == 0)
            {
                using (var db = new shopDB())
                {
                    db.Update<SANPHAM>("SET TenSanPham=@0, Gia=@1, GiamGia=@2,MoTa=@3, LoaiSp=@4 WHERE MaSanPham=@5", Sp.TenSanPham, Sp.Gia, Sp.GiamGia, Sp.MoTa, Sp.LoaiSp, Sp.MaSanPham);
                }
            }
            else
            {
                using (var db = new shopDB())
                {
                    db.Update<SANPHAM>("SET TenSanPham=@0, Gia=@1, GiamGia=@2, HinhAnh=@3, MoTa=@4, LoaiSp=@5 WHERE MaSanPham=@6", Sp.TenSanPham, Sp.Gia, Sp.GiamGia, Sp.HinhAnh, Sp.MoTa, Sp.LoaiSp, Sp.MaSanPham);
                }
            }

        }
    }
}