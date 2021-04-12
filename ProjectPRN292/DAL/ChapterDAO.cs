using ProjectPRN292.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjectPRN292.DAL
{
    class ChapterDAO
    {
        public static DataTable GetDataBySubjectID(int id)
        {
            string sql = "select Chapter_ID,ChapterName from Chapter where Subject_ID = @subject_id";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@subject_id", id);
            return DAO.GetDataTable(command);
        }

        public static bool AddDataBySubjectID(int subid,string chap)
        {
            string sql = "INSERT INTO [dbo].[Chapter] ([Subject_ID] ,[ChapterName])  VALUES (@subid ,@chap)";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@subid", subid);
            command.Parameters.AddWithValue("@chap", chap);
            return DAO.UpdateTable(command);
        }

        public static bool Delete(Chapter f)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("delete from Chapter " +
                           "where Chapter_ID = @ID");
            cmd.Parameters.AddWithValue("@ID", f.Id);
            return DAO.UpdateTable(cmd);

        }
        public static bool Edit(Chapter f)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("update [dbo].[Chapter]  SET [ChapterName] = @Name " +
                   "where Chapter_ID = @ID");
            cmd.Parameters.AddWithValue("@ID", f.Id);
            cmd.Parameters.AddWithValue("@Name", f.Name);
            return DAO.UpdateTable(cmd);

        }

        public static bool DeleteAllChapter(String f)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("delete from Chapter " +
                           "where Subject_ID = @ID");
            cmd.Parameters.AddWithValue("@ID", f);
            return DAO.UpdateTable(cmd);

        }
    }
}
