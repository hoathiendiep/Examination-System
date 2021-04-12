using ProjectPRN292.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectPRN292.dao
{
    class QuestionDAO:DAO
    {
        public static DataTable GetDataByExamCode(string id)
        {
            string sql = "select Question.Question_ID as ID,Question.Chapter_ID as 'Chapter ID',Question.Content as Question,Answer.Content as Answer,Answer_ID " +
                "from [ProjectPRN292].[dbo].Question,[ProjectPRN292].[dbo].Answer ,ExamQuestion " +
                "where Question.Question_ID = Answer.Question_ID " +
                "and Answer.isCorrect = 1 and ExamQuestion.Exam_Code = @id and ExamQuestion.Question_ID=Question.Question_ID";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@id", id);
            return DAO.GetDataTable(command);
        }

        public static DataTable GetDataByChapterID(int id)
        {
            string sql = "select Question.Question_ID as ID,Question.Content as Question,Answer.Content as Answer,Answer_ID " +
                "from [ProjectPRN292].[dbo].Question,[ProjectPRN292].[dbo].Answer " +
                "where Question.Question_ID = Answer.Question_ID " +
                "and Answer.isCorrect = 1 and Chapter_ID = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@id", id);
            return DAO.GetDataTable(command);
        }

        public static bool DeletebyID(int id)
        {
            string sql = "DELETE FROM [dbo].[ExamQuestion] WHERE Question_ID = @id " +
                "DELETE FROM [dbo].[ExamResult] WHERE Question_ID = @id " + 
                "DELETE FROM [dbo].[Answer] WHERE Question_ID = @id " +
                "DELETE FROM [dbo].[Question] WHERE Question_ID = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@id", id);
            return DAO.UpdateTable(command);
        }
        public static void insertQuestion(Question q)
        {
            string sql = "INSERT INTO [Question] ([Chapter_ID],[Content]) output INSERTED.Question_ID " +
                "VALUES (@id,@content)";
            SqlCommand command = new SqlCommand(sql,conn);
            command.Parameters.Add(new SqlParameter("@id", q.Chapter.Id));
            command.Parameters.Add(new SqlParameter("@content", q.Content));
            conn.Open();
            q.Id = (int)command.ExecuteScalar();
            foreach (Answer a in q.Answers)
            {

                string sql_insert_answer = "INSERT INTO [dbo].[Answer] ([Question_ID] ,[Content] ,[isCorrect]) VALUES (@id,@content,@isCorrected)";
                SqlCommand command_insert_answer =
                    new SqlCommand(sql_insert_answer,conn);
                command_insert_answer.Parameters.Add(new SqlParameter("@id", q.Id));
                command_insert_answer.Parameters.Add(new SqlParameter("@content", a.Content));
                command_insert_answer.Parameters.Add(new SqlParameter("@isCorrected", a.IsCorrect));
                command_insert_answer.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void updateQuestion(Question q)
        {
            string sql = "UPDATE [dbo].[Question] SET [Content] = @content WHERE [Question_ID] = @qid";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(new SqlParameter("@content", q.Content));
            command.Parameters.Add(new SqlParameter("@qid", q.Id));

            conn.Open();
            command.ExecuteNonQuery();
            foreach (Answer a in q.Answers)
            {
                SqlCommand command_insert_answer = null;
                string sql_insert_answer;
                if (a.Id == 0)
                {

                    sql_insert_answer = "INSERT INTO [dbo].[Answer] ([Question_ID] ,[Content] ,[isCorrect]) VALUES (@id,@content,@isCorrected)";

                    command_insert_answer =
                       new SqlCommand(sql_insert_answer, conn);
                    command_insert_answer.Parameters.Add(new SqlParameter("@id", q.Id));
                    command_insert_answer.Parameters.Add(new SqlParameter("@content", a.Content));
                    command_insert_answer.Parameters.Add(new SqlParameter("@isCorrected", a.IsCorrect));
                    command_insert_answer.ExecuteNonQuery();
                }
                else
                {
                    sql_insert_answer = "UPDATE [dbo].[Answer]  SET " +
                        " [Content] = @content" +
                        " ,[isCorrect] = @isCorrected" +
                        " WHERE [Answer_ID] = @aid";
                    command_insert_answer =
                       new SqlCommand(sql_insert_answer, conn);
                    command_insert_answer.Parameters.Add(new SqlParameter("@aid", a.Id));
                    command_insert_answer.Parameters.Add(new SqlParameter("@content", a.Content));
                    command_insert_answer.Parameters.Add(new SqlParameter("@isCorrected", a.IsCorrect));
                    command_insert_answer.ExecuteNonQuery();
                }
            }
            conn.Close();
        }

        public static List<Question> getQuestionsByExamCode(string code)
        {
            List<Question> lsQuestions = new List<Question>();
            string sql = "SELECT q.[Question_ID] as id  , q.[Content] , a.Answer_ID as 'aid', a.Question_ID, a.Content as 'acontent', a.isCorrect " +
                "FROM ExamQuestion, [dbo].[Question] q INNER JOIN Answer a on q.Question_ID = a.Question_ID " +
                "where ExamQuestion.[Question_ID]= q.[Question_ID] and Exam_Code = @code order by Question_ID asc";
            try
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@code", code);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Question prv = new Question { Id = -1 };
                while (reader.Read())
                {
                    int qid = Convert.ToInt32(reader["id"]);
                    if (prv.Id != qid)
                    {
                        prv = new Question();
                        lsQuestions.Add(prv);
                    }
                    prv.Id = qid;
                    prv.Content = reader["Content"].ToString();

                    Answer ans = new Answer();
                    ans.Id = Convert.ToInt32(reader["aid"]);
                    ans.Content = reader["acontent"].ToString();
                    ans.IsCorrect = Convert.ToBoolean(reader["isCorrect"].ToString());

                    prv.Answers.Add(ans);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return lsQuestions;
        }

        public List<Question> getQuestions()
        {
            List<Question> lsQuestions = new List<Question>();
            string sql = " SELECT q.[Question_ID]  , q.[Content] , a.Answer_ID as 'aid', a.Question_ID, a.Content as 'acontent', a.isCorrect "
            + "FROM[dbo].[Question] q INNER JOIN Answer a on q.Question_ID = a.Question_ID";
            try
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Question prv = new Question { Id = -1 };
                while (reader.Read())
                {
                    int qid = Convert.ToInt32(reader["id"]);
                    if (prv.Id != qid)
                    {
                        prv = new Question();
                        lsQuestions.Add(prv);
                    }
                    prv.Id = qid;
                    prv.Content = reader["Content"].ToString();

                    Answer ans = new Answer();
                    ans.Id = Convert.ToInt32(reader["aid"]);
                    ans.Content = reader["acontent"].ToString();
                    ans.IsCorrect = Convert.ToBoolean(reader["isCorrect"].ToString());

                    prv.Answers.Add(ans);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return lsQuestions;
        }


        public static List<int> getQuesByChap(int chap)
        {
            string sql = "SELECT [Question_ID] FROM[dbo].[Question] where [Chapter_ID] = @chap";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@chap", chap);
            return DAO.getListData(cmd);
        }
    }
}
