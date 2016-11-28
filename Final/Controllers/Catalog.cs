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

      // GET: Account/Login
      public ActionResult Login()
      {
         return View();
      }

      // POST: Account/Login
      [HttpPost]
      public ActionResult Login(Classes.UserAccount userAccount)
      {
         try
         {
            // TODO: Add insert logic here
            Classes.LoginControl loginControl = new Classes.LoginControl();
            loginControl.Login(userAccount);
            return RedirectToAction("Login");
         }
         catch (Exception ex)
         {
            return View();
         }
      }

      // GET: Account/Login
      public ActionResult Logout()
      {
         return View();
      }

      // POST: Account/Login
      [HttpPost]
      public ActionResult Logout(Classes.UserAccount userAccount)
      {
         try
         {
            // TODO: Add insert logic here
            Classes.LoginControl loginControl = new Classes.LoginControl();
            loginControl.Logout(userAccount);
            return RedirectToAction("Logout");
         }
         catch (Exception ex)
         {
            return View();
         }
      }

      //// GET: Account/Edit/5
      //public ActionResult Edit(int id)
      //{
      //   return View();
      //}

      //// POST: Account/Edit/5
      //[HttpPost]
      //public ActionResult Edit(int id, FormCollection collection)
      //{
      //   try
      //   {
      //      // TODO: Add update logic here

      //      return RedirectToAction("Index");
      //   }
      //   catch
      //   {
      //      return View();
      //   }
      //}

      //// GET: Account/Delete/5
      //public ActionResult Delete(int id)
      //{
      //   return View();
      //}

      //// POST: Account/Delete/5
      //[HttpPost]
      //public ActionResult Delete(int id, FormCollection collection)
      //{
      //   try
      //   {
      //      // TODO: Add delete logic here

      //      return RedirectToAction("Index");
      //   }
      //   catch
      //   {
      //      return View();
      //   }
      //}
   }
}
