using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectPRN292.DAL
{
    class AdminDAO
    {
        public static bool checkLogin(string name, string pass)
        {
            //MessageBox.Show(DAO.GetDataTable("SELECT [Admin_ID] ,[LoginName] ,[Password] FROM[dbo].[Admin] where LoginName ='" + name + "' and Password='" + pass + "'").Rows.Count+"");
            if (DAO.GetDataTable("SELECT [Admin_ID] ,[LoginName] ,[Password] FROM[dbo].[Admin] where LoginName ='" + name + "' and Password='" + pass + "'").Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static bool EditPassword(string user, string passchanged)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("update Admin set Password = @Password where LoginName = @LoginName");
            cmd.Parameters.AddWithValue("@LoginName", user);
            cmd.Parameters.AddWithValue("@Password", passchanged);
            return DAO.UpdateTable(cmd);
        }
        public static bool checkpassword(string name, string pass)
        {
            MessageBox.Show("" + name + "' and Password='" + pass );
            if (DAO.GetDataTable("SELECT [Admin_ID] ,[LoginName] ,[Password] FROM[dbo].[Admin] where LoginName ='" + name + "' and Password='" + pass + "'").Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
