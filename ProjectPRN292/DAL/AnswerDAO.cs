using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectPRN292.DAL
{
    class AnswerDAO:DAO
    {
        public static bool deleteAns(int id)
        {
            string sql = "delete from Answer where Answer_ID = @id";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", id);
            return DAO.UpdateTable(command);
        }
        public static List<Answer> getAnswers(int id)
        {
            List<Answer> lsAnswers = new List<Answer>();
            string sql = " SELECT q.[Question_ID]  , q.[Content] , a.Answer_ID as 'aid', a.Question_ID, a.Content as 'acontent', a.isCorrect "
            + "FROM[dbo].[Question] q INNER JOIN Answer a on q.Question_ID = a.Question_ID  where q.Question_ID = @id";

            try
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Answer ans = new Answer();
                    ans.Q = new Question();
                    ans.Q.Id = Convert.ToInt32(reader["Question_ID"]);
                    ans.Q.Content = reader["Content"].ToString();
                    ans.Id = Convert.ToInt32(reader["aid"]);
                    ans.Content = reader["acontent"].ToString();
                    ans.IsCorrect = Convert.ToBoolean(reader["isCorrect"].ToString());

                    lsAnswers.Add(ans);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return lsAnswers;
        }
    }
}
