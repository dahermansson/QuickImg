using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickImg.Models;

namespace QuickImg.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, int maxShow = 2)
        {
            if (file != null && file.ContentLength > 0)
            {
                bool ok = true;
                if (Path.GetExtension(file.FileName).ToLower() != ".jpg")
                {
                    ok = false;
                    ViewBag.format = "Only jpg...";
                }
                if (file.ContentLength > 2000*1024)
                {
                    ok = false;
                    ViewBag.size = "2MB max";
                }
                if(maxShow > 10)
                {
                    ok = false;
                    ViewBag.error = "I don't think so";
                }

                if (ok)
                {
                    byte[] imgBytes = new byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var img = ImgStore.AddImg(imgBytes, maxShow);
                    ViewBag.result = img.Id;
                }
            }

            return View();
        }

       
    }
}