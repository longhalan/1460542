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
        public ActionResult Index()
        {
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
        [HttpPost]
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
            return View();
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
