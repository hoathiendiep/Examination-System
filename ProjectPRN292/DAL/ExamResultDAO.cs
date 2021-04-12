using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectPRN292.DAL
{
    class ExamResultDAO:DAO
    {
        public static bool updateScoreandDate(float score, DateTime testDate,string code,int sid)
        {
            string sql = "UPDATE [dbo].[ExamResult] " +
                "SET [Score] = @score" +
                " WHERE Exam_Code = @code and Student_ID = @sid and [testDate] like @date";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@code", code);
            command.Parameters.AddWithValue("@date", testDate);
            command.Parameters.AddWithValue("@score", score);
            command.Parameters.AddWithValue("@sid", sid);
            return DAO.UpdateTable(command);

        }

        public static bool deleteScoreandDate(string code, int sid, DateTime testDate)
        {
            string sql = "delete from [dbo].[ExamResult] " +
                " WHERE Exam_Code = @code and Student_ID = @sid and [testDate] like @date";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@code", code);
            command.Parameters.AddWithValue("@date", testDate);
            command.Parameters.AddWithValue("@sid", sid);
            return DAO.UpdateTable(command);

        }
        public static DataTable getDetails(int eid, int sid)
        {
            string sql = "select Question_No as 'Number',Question.Content as 'Question',Answer.Content as 'Answer',Answer.isCorrect as 'Is Correct'" +
                " from ExamResult,Question,Answer " +
                "where Question.Question_ID = ExamResult.Question_ID and " +
                "Answer.Answer_ID = ExamResult.Answer_ID and Exam_Code = @eid " +
                "and Student_ID= @sid";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@eid", eid);
            command.Parameters.AddWithValue("@sid", sid);
            return DAO.GetDataTable(command);
        }
        public static void insertResult(Dictionary<int, List<int>> stdResult,string sid, string code, float pnt, DateTime finish)
        {
            string sql = "INSERT INTO [dbo].[ExamResult] ([Student_ID] ,[Exam_Code] ,[testDate] ,[Score],[Question_No],[Question_ID],[Answer_ID]" +
                ") VALUES (@sid,@code,@finish ,@pnt,@qno,@qid,@aid)";
            SqlCommand command;
            int i = 1;
            foreach (KeyValuePair<int, List<int>> entry in stdResult)
            {
                command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@sid", sid);
                command.Parameters.AddWithValue("@code", code);
                command.Parameters.AddWithValue("@finish", finish);
                command.Parameters.AddWithValue("@pnt", pnt);
                command.Parameters.AddWithValue("@qno", i++);
                command.Parameters.AddWithValue("@qid", entry.Key.ToString());
                if (entry.Value.Count == 0)
                {
                    command.Parameters.AddWithValue("@aid", DBNull.Value);
                    DAO.UpdateTable(command);
                }
                else
                {
                    foreach (int j in entry.Value)
                    {
                        SqlParameter aid = new SqlParameter("@aid", j.ToString());
                        command.Parameters.Add(aid);
                        DAO.UpdateTable(command);
                        command.Parameters.Remove(aid);
                    }
                }
            }
            
        }

    }
}
