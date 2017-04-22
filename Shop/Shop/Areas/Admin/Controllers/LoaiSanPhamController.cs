using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: Admin/LoaiSanPham
        public ActionResult Index()
        {
            var LoaiSanPham = Models.LoaiSanPham.LoaiSanPhamBus.List();
            ViewBag.dslsp = LoaiSanPham;
            return View();
        }

        // GET: Admin/LoaiSanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPham/Create
        [HttpPost]
        public ActionResult Create(shop.LOAISANPHAM lsp )
        {
            try
            {
                // TODO: Add insert logic here
                Models.LoaiSanPham.LoaiSanPhamBus.insert(lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPham/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(Models.LoaiSanPham.LoaiSanPhamBus.GetCategory(id));
        }

        // POST: Admin/LoaiSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(shop.LOAISANPHAM lsp)
        {
            try
            {
                // TODO: Add update logic here
                Models.LoaiSanPham.LoaiSanPhamBus.UpdateCategory(lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPham/Delete/5
        public ActionResult Delete(int id)
        {
            Models.LoaiSanPham.LoaiSanPhamBus.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Admin/LoaiSanPham/Delete/5
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
