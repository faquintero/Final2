using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Classes
{
   public class UserAccount
   {
      [Display(Name = "User Name")]
      public string userName { get; set; }
      [Display(Name = "User Password")]
      public string userPassword { get; set; }
      [Display(Name = "Is Logged")]
      public string loggedIn { get; set; }
   }

   public sealed class LoginControl
   {
      public void Login(UserAccount userAccount)
      {
         Final.DAL.DataAccessClass dal = new DAL.DataAccessClass();

         UserAccount existingAccount = dal.getUser(userAccount.userName);

         if (existingAccount != null && existingAccount.userPassword == userAccount.userPassword)
         {
            userAccount.loggedIn = "S";
            dal.SaveUser(userAccount);
         }
         else
            throw new Exception("Invalid user or password");
      }

      public void Logout(UserAccount userAccount)
      {
         Final.DAL.DataAccessClass dal = new DAL.DataAccessClass();

         UserAccount existingAccount = dal.getUser(userAccount.userName);

         if (existingAccount != null)
         {
            existingAccount.loggedIn = "N";
            dal.SaveUser(existingAccount);
         }
      }
   }

   public class Item
   {
      [Display(Name = "Name")]
      public string itemName { get; set; }
      [Display(Name = "Description")]
      public string itemDescription { get; set; }
      [Display(Name = "Price")]
      public double itemPrice { get; set; }
   }
}