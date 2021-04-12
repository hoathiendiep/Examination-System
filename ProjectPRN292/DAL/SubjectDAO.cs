using ProjectPRN292.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjectPRN292.DAL
{
    class SubjectDAO
    {
        public static DataTable GetDataTable()
        {
            string sql = "select * from Subject";
            return DAO.GetDataTable(sql);
        }
        public static bool Delete(Subject f)
        {
            string sql = "delete from Subject where Subject_ID = @ID " +
                "delete from Subject where Subject_ID = @ID";
            SqlCommand cmd = new SqlCommand(sql);
            cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID", f.Id);
            return DAO.UpdateTable(cmd);

        }
        public static bool Add(Subject f)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("INSERT INTO [dbo].[Subject]([SubjectName])" +
                " VALUES(@Name)");
            cmd.Parameters.AddWithValue("@Name", f.Name);
            return DAO.UpdateTable(cmd);
        }

        public static bool Edit(Subject f)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("update [dbo].[Subject]  SET [SubjectName] = @Name where Subject_ID = @ID");
            cmd.Parameters.AddWithValue("@ID", f.Id);
            cmd.Parameters.AddWithValue("@Name", f.Name);
            return DAO.UpdateTable(cmd);

        }
    }
}
