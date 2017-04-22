using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult List()
        {
            var List = Models.SanPhamBus.SanPhamBus.List();
            ViewBag.list = List;
            return View();
        }

        // GET: Admin/SanPham/Details/5
     
        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            var LoaiSanPham = Models.LoaiSanPham.LoaiSanPhamBus.List();
            ViewBag.dslsp = LoaiSanPham;
            return View();
        }

        // POST: Admin/SanPham/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(shop.SANPHAM sp)
        {
         
            string pathValue = Server.MapPath("~/");

            var hpt = HttpContext.Request.Files[0];
            if (HttpContext.Request.Files.Count > 0)
            {
                if (hpt.ContentLength > 0)
                {
                    string temp = hpt.FileName;
                    string RDString = Guid.NewGuid().ToString();
                    string fullNameImage = "img/" + RDString + temp;
                    hpt.SaveAs(pathValue + fullNameImage);
                    sp.HinhAnh = fullNameImage;
                }
            }

            Models.SanPhamBus.SanPhamBus.insert(sp);
            return RedirectToAction("Create");

        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int id)
        {
            var LoaiSanPham = Models.LoaiSanPham.LoaiSanPhamBus.List();
            ViewBag.dslsp = LoaiSanPham;
            return View(Models.SanPhamBus.SanPhamBus.GetProduct(id));
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(shop.SANPHAM sp1)
        {
            string pathValue = Server.MapPath("~/");

            var hpt = HttpContext.Request.Files[0];
            if (hpt.FileName == null)
            {
                Models.SanPhamBus.SanPhamBus.UpdateProduct(sp1, 0);
            }
            else
            {
                if (HttpContext.Request.Files.Count > 0)
                {
                    if (hpt.ContentLength > 0)
                    {
                        string temp = hpt.FileName;
                        string RDString = Guid.NewGuid().ToString();
                        string fullNameImage = "img/" + RDString + temp;
                        hpt.SaveAs(pathValue + fullNameImage);
                        sp1.HinhAnh = fullNameImage;
                    }
                }
                Models.SanPhamBus.SanPhamBus.UpdateProduct(sp1, 1);
            }
            return RedirectToAction("List");
        }

      
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Models.SanPhamBus.SanPhamBus.Delete(id);

                return RedirectToAction("List");
            }
            catch
            {
                return List();
            }
        }
    }
}
