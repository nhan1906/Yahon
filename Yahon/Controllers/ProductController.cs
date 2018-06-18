using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yahon.Models;


namespace Yahon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

         [HttpGet]
        public PartialViewResult _Products(int brandId)
        {
            List<Product> listProduct = null;
            // Lay danh sach san pham
            using(var db = new DatabaseContext())
            {
                listProduct = db.Products.Where(n => n.BrandId == brandId).Take(8).ToList();
            }
            return PartialView(listProduct);
        }
    }
}