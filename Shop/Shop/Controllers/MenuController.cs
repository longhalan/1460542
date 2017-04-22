using Shop.Models.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class MenuController : Controller
    {
        // GET: menu
        public ActionResult Index()
        {
            return View(ProductType.danhsach());
        }
    }
}
