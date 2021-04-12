using ProjectPRN292.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjectPRN292.DAL
{
    class StudentDAO
    {
        public static DataTable GetDataTable()
        {
            string sql = "select * from Student";
            return DAO.GetDataTable(sql);
        }

        public static bool checkLogin(string name, string pass,string code)
        {
            if (DAO.GetDataTable("SELECT [Student_ID] ,[Password] FROM [dbo].[Student] where Student_ID ='" + name + "' and [Password] ='" + pass + "' ").Rows.Count == 0)
            {
                return false;
            }
            if(DAO.GetDataTable("SELECT Exam_Code from Exam where Exam_Code ='" + code + "'").Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static DataTable GetPassword(string StudentID)
        {
            string sql = "select password from Student where Student_ID = '" + StudentID + "'";
            return DAO.GetDataTable(sql);
        }
        public static bool Add(Student f)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("INSERT INTO [dbo].[Student]([Password],[FirstName],[LastName],[DOB],[Gender],[Email],[PhoneNumber])" +
                " VALUES(@Password, @FirstName, @LastName, @DOB, @Gender, @Email, @PhoneNumber)");
            cmd.Parameters.AddWithValue("@Password", f.Password);
            cmd.Parameters.AddWithValue("@FirstName", f.FirstName);
            cmd.Parameters.AddWithValue("@LastName", f.LastName);
            cmd.Parameters.AddWithValue("@DOB", f.DOB);
            cmd.Parameters.AddWithValue("@Gender", f.Gender);
            cmd.Parameters.AddWithValue("@Email", f.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", f.PhoneNumber);
            return DAO.UpdateTable(cmd);
        }

        public static bool Edit(Student f)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("update Student " +
                   "set Password = @Password, " +
                   "FirstName = @FirstName, LastName = @LastName, " +
                   "DOB = @DOB, Gender = @Gender, " +
                   "Email = @Email, PhoneNumber = @PhoneNumber " +
                   "where Student_ID = @Student_ID");
            cmd.Parameters.AddWithValue("@Student_ID", f.Student_ID);
            cmd.Parameters.AddWithValue("@Password", f.Password);
            cmd.Parameters.AddWithValue("@FirstName", f.FirstName);
            cmd.Parameters.AddWithValue("@LastName", f.LastName);
            cmd.Parameters.AddWithValue("@DOB", f.DOB);
            cmd.Parameters.AddWithValue("@Gender", f.Gender);
            cmd.Parameters.AddWithValue("@Email", f.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", f.PhoneNumber);
            return DAO.UpdateTable(cmd);

        }
        public static bool EditPassword(string user, string pass)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("update Student " +
                   "set Password = @Password " +
                   "where Student_ID = @Student_ID");
            cmd.Parameters.AddWithValue("@Student_ID", user);
            cmd.Parameters.AddWithValue("@Password", pass);
            return DAO.UpdateTable(cmd);
        }

        public static bool Delete(Student f)
        {
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("delete from Student " +
                           "where Student_ID = @Student_ID");
            cmd.Parameters.AddWithValue("@Student_ID", f.Student_ID);
            return DAO.UpdateTable(cmd);

        }

        public static DataTable Search(String f)
        {
            String cmd = "select * from Student where FirstName like '%" + f + "%' or LastName like '%" + f + "%'";
            return DAO.GetDataTable(cmd);
        }

    }
}
