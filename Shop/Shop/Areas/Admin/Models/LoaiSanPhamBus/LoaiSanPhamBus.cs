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
        public static void insert(LOAISANPHAM lsp)
        {
            lsp.Insert();
        }

        public static void Delete(int id)
        {
            try
            {
                using (var db = new shopDB())
                {
                    db.Execute("delete from LOAISANPHAM where MaLoaiSanPham = @0", id);
                }
            }
            catch
            {
            }
        }
        public static void UpdateCategory(LOAISANPHAM lsp)
        {
            using (var db = new shopDB())
            {
                db.Update<LOAISANPHAM>("SET TenLoaiSanPham=@0 WHERE MaLoaiSanPham=@1", lsp.TenLoaiSanPham, lsp.MaLoaiSanPham);
            }
        }
        public static LOAISANPHAM GetCategory(int id)
        {
            using (var db = new shopDB())
            {
                return db.SingleOrDefault<LOAISANPHAM>("select * from LOAISANPHAM where MaLoaiSanPham = @0", id);
            }
        }
    }
}