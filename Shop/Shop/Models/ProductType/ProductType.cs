using shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
namespace Shop.Models.ProductType
{
    public class ProductType
    {

        public static IEnumerable<LOAISANPHAM> danhsach()
        {
            var db = new shopDB();
            return db.Query<LOAISANPHAM>("select * from loaisanpham");
        }

      
    }
    
}