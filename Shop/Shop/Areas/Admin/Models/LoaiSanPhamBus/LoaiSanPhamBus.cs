using shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Areas.Admin.Models.LoaiSanPham
{
    public class LoaiSanPhamBus
    {
        public static IEnumerable<LOAISANPHAM> List()
        {
            var db = new shopDB();
            return db.Query<LOAISANPHAM>("select * from loaisanpham");
        }
    }
}