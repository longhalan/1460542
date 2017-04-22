using System;
using shop;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
namespace Shop.Models.SanPhamBus
{
    public class SanPhamBus
    {
        public static IEnumerable<SANPHAM> List()
        {
            var db = new shopDB();
            return db.Query<SANPHAM>("select * from sanpham");
        }
        public static SANPHAM GetProduct(int id)
        {
            var db = new shopDB();
            return db.SingleOrDefault<SANPHAM>("select * from sanpham where MaSanPham = @0", id);
        }

        public static Page<SANPHAM> SanPham(int pagenume, int itemperpage, int id)
        {
            var db = new shopDB();
            return db.Page<SANPHAM>(pagenume,itemperpage,"select * from sanpham where LoaiSP = @0", id);
        }
    }
  
   
}