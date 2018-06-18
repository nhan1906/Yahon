using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yahon.Models;

namespace Yahon.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _Brands()
        {
            List<Brand> listBrand = null;
            using (var db = new DatabaseContext())
            {
                listBrand = db.Brands.ToList();
            }
            return PartialView(listBrand);
        }
    }
}