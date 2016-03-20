using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickImg.Models;

namespace QuickImg.Controllers
{
  public class ImgController : Controller
  {
    // GET: Img
    public ActionResult Index(string id)
    {
      Guid imageId;
      if (Guid.TryParse(id, out imageId) && ImgStore.ImgExists(imageId))
      {
        ViewBag.img = imageId.ToString();
      }
      else
        return View("Nothing");

      return View();
    }

    public ActionResult Show(Guid id)
    {
      var imageData = ImgStore.GetImg(id);
      ImgStore.Show(id);
      return File(imageData.ImgBytes, "image/jpg");
    }
  }
}