using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;

namespace Final.DAL
{
   public class DataAccessClass
   {
      public void SaveUser(Classes.UserAccount useraccount)
      {
         Classes.UserAccount userExists = getUser(useraccount.userName);

         string connstr = ConfigurationManager.ConnectionStrings["database"].ToString();
         using (SqlConnection oConn = new SqlConnection(connstr))
         {
            oConn.Open();
            string cmdText = "";
            if (userExists == null)
            {
               cmdText = "insert into userAccount (userName, userPassword, loggedIn) values(@name, @pass, @logged)";
            }
            else
            {
               cmdText = "update userAccount set userPassword = @pass, loggedin = @logged where userName  = @name";
            }

            using (SqlCommand cmd = new SqlCommand(cmdText, oConn))
            {
               cmd.Parameters.Add(new SqlParameter() { ParameterName = "@name", DbType = System.Data.DbType.String, Value = useraccount.userName });
               cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pass", DbType = System.Data.DbType.String, Value = useraccount.userPassword });
               cmd.Parameters.Add(new SqlParameter() { ParameterName = "@logged", DbType = System.Data.DbType.String, Value = useraccount.loggedIn });

               cmd.ExecuteNonQuery();
            }
         }
      }

      public Classes.UserAccount getUser(string userName)
      {
         string connstr = ConfigurationManager.ConnectionStrings["database"].ToString();
         using (SqlConnection oConn = new SqlConnection(connstr))
         {
            oConn.Open();
            using (SqlCommand cmd = new SqlCommand("select userPassword from userAccount where userName = @name", oConn))
            {
               cmd.Parameters.Add(new SqlParameter() { ParameterName = "@name", DbType = System.Data.DbType.String, Value = userName });

               using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
               {
                  if (reader.Read())
                  {
                     return new Classes.UserAccount() { userName = userName, userPassword = reader.GetString(0) };
                  }
                  else
                     return null;
               }
            }
         }
      }

      public void SaveItem(Classes.Item item)
      {
         Classes.Item itemExists = getItem(item.itemName);

         string connstr = ConfigurationManager.ConnectionStrings["database"].ToString();
         using (SqlConnection oConn = new SqlConnection(connstr))
         {
            oConn.Open();
            string cmdText = "";
            if (itemExists == null)
            {
               cmdText = "insert into item (itemName, itemDescription, itemPrice) values(@name, @descr, @price)";
            }
            else
            {
               cmdText = "update item set itemDescription = @descr, itemPrice = @price where itemName  = @name";
            }

            using (SqlCommand cmd = new SqlCommand(cmdText, oConn))
            {
               cmd.Parameters.Add(new SqlParameter() { ParameterName = "@name", DbType = System.Data.DbType.String, Value = item.itemName });
               cmd.Parameters.Add(new SqlParameter() { ParameterName = "@descr", DbType = System.Data.DbType.String, Value = item.itemDescription });
               cmd.Parameters.Add(new SqlParameter() { ParameterName = "@price", DbType = System.Data.DbType.String, Value = item.itemPrice });

               cmd.ExecuteNonQuery();
            }
         }
      }

      public Classes.Item getItem(string itemName)
      {
         string connstr = ConfigurationManager.ConnectionStrings["database"].ToString();
         using (SqlConnection oConn = new SqlConnection(connstr))
         {
            oConn.Open();
            using (SqlCommand cmd = new SqlCommand("select * from item where itemName = @name", oConn))
            {
               cmd.Parameters.Add(new SqlParameter() { ParameterName = "@name", DbType = System.Data.DbType.String, Value = itemName });

               using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
               {
                  if (reader.Read())
                  {
                     return new Classes.Item() { itemName = itemName, itemDescription = reader.GetString(1), itemPrice = reader.GetDouble(2) };
                  }
                  else
                     return null;
               }
            }
         }
      }

      public List<Classes.Item> getItems(string itemText = "")
      {
         List<Classes.Item> list = new List<Classes.Item>();

         string connstr = ConfigurationManager.ConnectionStrings["database"].ToString();
         using (SqlConnection oConn = new SqlConnection(connstr))
         {
            itemText = "%" + itemText + "%";
            oConn.Open();
            using (SqlCommand cmd = new SqlCommand("select * from item where itemName like @text or itemDescription like @text", oConn))
            {
               cmd.Parameters.Add(new SqlParameter() { ParameterName = "@text", DbType = System.Data.DbType.String, Value = itemText });

               using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult))
               {
                  while(reader.Read())
                  {
                     list.Add ( new Classes.Item() { itemName = reader.GetString(0), itemDescription = reader.GetString(1), itemPrice = reader.GetDouble(2) });
                  }
               }
            }
         }

         return list;
      }
   }
}