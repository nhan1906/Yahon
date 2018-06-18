using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yahon.Models;

namespace Yahon.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _BannerPost()
        {
            List<Post> listProduct = null;
            // Lay danh sach san pham
            using (var db = new DatabaseContext())
            {
                listProduct = db.Posts.Where(n => n.PostType == 1).Take(3).ToList();
            }
            return PartialView(listProduct);
        }
    }
}