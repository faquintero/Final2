using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
   public class CatalogController : Controller
   {
      //// GET: Account
      //public ActionResult Index()
      //{
      //    return View();
      //}

      //// GET: Account/Details/5
      //public ActionResult Details(int id)
      //{
      //    return View();
      //}

      // GET: Account/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: Account/Create
      [HttpPost]
      public ActionResult Create(Classes.Item item)
      {
         try
         {
            // TODO: Add insert logic here
            Final.DAL.DataAccessClass dal = new DAL.DataAccessClass();
            
            dal.SaveItem(item);
            return RedirectToAction("Create");
         }
         catch(Exception ex)
         {
            return View();
         }
      }

      public ActionResult Find(string itemText = "")
      {
         try
         {
            // TODO: Add insert logic here
            Final.DAL.DataAccessClass dal = new DAL.DataAccessClass();

            var list = dal.getItems(itemText);

            return View(list);
         }
         catch (Exception ex)
         {
            return View();
         }
      }

   }
}
