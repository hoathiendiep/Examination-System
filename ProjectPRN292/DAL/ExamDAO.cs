using ProjectPRN292.GUI.Admin;
using ProjectPRN292.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectPRN292.DAL
{
    class ExamDAO:DAO
    {

        public static DataTable GetDataTable()
        {
            string sql = "select * from Exam";
            return DAO.GetDataTable(sql);
        }

        public static DataTable GetDataTableForScore()
        {
            string sql= "SELECT Exam_Code,[ExamName],SubjectName  FROM[ProjectPRN292].[dbo].[Exam],Subject where Subject.Subject_ID = Exam.Subject_ID";
            return DAO.GetDataTable(sql);
        }

        public static DataTable selectByExamCode(string code)
        {
            string sql = "SELECT distinct Student.[Student_ID] ,[FirstName] ,[LastName],[testDate] ,[Score] " +
                "FROM [ProjectPRN292].[dbo].[ExamResult],Student where" +
                " Student.[Student_ID] = [ExamResult].[Student_ID]" +
                " and Exam_Code = @code";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@code", code);
            return DAO.GetDataTable(command);
        }


        public static List<int> listOfChapId(ExamManageGUI parent)
        {
            string sql = "select Chapter_ID,ChapterName from Chapter where Subject_ID = @subject_id";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@subject_id", Convert.ToInt32(parent.LbChapter.SelectedValue.ToString()));
            return DAO.getListData(command);
        }

        public static Dictionary<int, List<int>> GetChapterAndQuestion(string code, ExamManageGUI parent)
        {
            Dictionary<int, List<int>> selectedID = new Dictionary<int, List<int>>();
            List<int> listId = listOfChapId(parent);
            try
            {
                string sql = "select Question.Chapter_ID,[ProjectPRN292].[dbo].Question.Question_ID " +
                    " from[ProjectPRN292].[dbo].Question, [ProjectPRN292].[dbo].ExamQuestion," +
                    " [ProjectPRN292].[dbo].Exam ,[ProjectPRN292].[dbo].Chapter " +
                    "where [ProjectPRN292].[dbo].Exam.Exam_Code = [ProjectPRN292].[dbo].ExamQuestion.Exam_Code" +
                    " and [ProjectPRN292].[dbo].Question.Chapter_ID = [ProjectPRN292].[dbo].Chapter.Chapter_ID " +
                    "and [ProjectPRN292].[dbo].[ExamQuestion].[Question_ID] = [ProjectPRN292].[dbo].[Question].[Question_ID] " +
                    "and [ProjectPRN292].[dbo].ExamQuestion.Exam_Code = @code";
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@code", code);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int chapid = Convert.ToInt32(reader["Chapter_ID"]);
                    int chapid1 = listId.IndexOf(chapid);
                    int quesid = Convert.ToInt32(reader["Question_ID"]);
                    if (!selectedID.ContainsKey(chapid1))
                    {
                        selectedID[chapid1] = new List<int>();
                    }
                    selectedID[chapid1].Add(quesid);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
            return selectedID;
        }

        public static bool deleteExam(Exam e,bool edit)
        {
            try {
                string sql;
                SqlCommand command;
                conn.Open();

                    sql = "delete from [dbo].[ExamQuestion]  where Exam_Code = @code";
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@code", e.ExamCode));

                    command.ExecuteNonQuery();
                
                if (!edit)
                {
                    sql = "delete from [dbo].[ExamResult]  where Exam_Code = @code";
                }
                else
                {
                    sql = "ALTER TABLE [ProjectPRN292].[dbo].[ExamResult] NOCHECK CONSTRAINT all " +
                        "update  [ProjectPRN292].[dbo].[ExamResult] set [Exam_Code] = '' where [Exam_Code]=@code";
                }
                command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@code", e.ExamCode));
                command.ExecuteNonQuery();

                sql = "delete from Exam where Exam_Code = @code";
                command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@code", e.ExamCode));
                command.ExecuteNonQuery();
                conn.Close();
        }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return false;
            }
            return true;
        }

        public static bool insertExam(Exam e,bool edit)
        {
            try
            {
                string sql = "INSERT INTO [dbo].[Exam]  ([Exam_Code] ,[Subject_ID] ,[ExamName],[TotalQuestion],[Time])" +
    " VALUES (@code,@subid,@name,@total,@time)";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@code", e.ExamCode));
                command.Parameters.Add(new SqlParameter("@subid", e.Subject.Id));
                command.Parameters.Add(new SqlParameter("@name", e.ExamName));
                command.Parameters.Add(new SqlParameter("@total", e.Total));
                command.Parameters.Add(new SqlParameter("@time", e.Time));
                conn.Open();
                command.ExecuteNonQuery();
                foreach (int i in e.lstQuesID)
                {
                    sql = "INSERT INTO [dbo].[ExamQuestion]  ([Exam_Code] ,[Question_ID]) VALUES (@code,@qid)";
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@code", e.ExamCode));
                    command.Parameters.Add(new SqlParameter("@qid", i));
                    command.ExecuteNonQuery();
                }
                if (edit)
                {
                    sql = "Update  [ProjectPRN292].[dbo].[ExamResult] set [Exam_Code] = @code where [Exam_Code] ='' " +
                        "ALTER TABLE [ProjectPRN292].[dbo].[ExamResult] WITH CHECK CHECK CONSTRAINT ALL";
                    command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@code", e.ExamCode));
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public static bool checkExistExamCode(string code)
        {
            string sql = "select * from Exam where Exam_Code = @code";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@code", code);
            return DAO.GetDataTable(command).Rows.Count != 0;
        }
    }
}
