using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
   public class AccountController : Controller
   {
      // GET: Account/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: Account/Create
      [HttpPost]
      public ActionResult Create(Classes.UserAccount userAccount)
      {
         try
         {
            // TODO: Add insert logic here
            Final.DAL.DataAccessClass dal = new DAL.DataAccessClass();
            var user = dal.getUser(userAccount.userName);
            if (user != null)
            {
               ViewBag.ErrorMsg = "User already exists";
               return View();
            }
            userAccount.loggedIn = "N";
            dal.SaveUser(userAccount);
            ViewBag.ErrorMsg = "User created";
            return View();
         }
         catch (Exception ex)
         {
            return View();
         }
      }

      // GET: Account/Update
      public ActionResult Update()
      {
         Classes.UserAccount user = (Classes.UserAccount)Session["user"];
         return View(user);
      }

      // POST: Account/Update
      [HttpPost]
      public ActionResult Update(Classes.UserAccount userAccount)
      {
         try
         {
            // TODO: Add insert logic here
            Final.DAL.DataAccessClass dal = new DAL.DataAccessClass();
            var user = dal.getUser(userAccount.userName);
            if (user == null)
            {
               ViewBag.ErrorMsg = "User does not exists";
               return View();
            }
            userAccount.loggedIn = "N";
            dal.SaveUser(userAccount);
            ViewBag.ErrorMsg = "User updated";
            return View();
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
            Session.Remove("user");
            // TODO: Add insert logic here
            Classes.LoginControl loginControl = new Classes.LoginControl();
            loginControl.Login(userAccount);
            Session["user"] = userAccount;
            return RedirectToAction("Index", "Home");
         }
         catch (Exception ex)
         {
            ViewBag.ErrorMsg = ex.Message;
            return View();
         }
      }

      // GET: Account/Login
      public ActionResult Logout()
      {
         Classes.UserAccount user = (Classes.UserAccount)Session["user"];
         return View(user);
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
            Session.Remove("user");
            return RedirectToAction("Index", "home");
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
