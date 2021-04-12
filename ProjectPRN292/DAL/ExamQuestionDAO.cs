using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjectPRN292.DAL
{
    class ExamQuestionDAO:DAO
    {

        public static DataTable displayRandomQuestion(List<int> quesID)
        {
            string sql = "select Question.Chapter_ID,Question.Question_ID as ID,Question.Content as Question,Answer.Content as Answer,Answer_ID " +
                "from [ProjectPRN292].[dbo].Question,[ProjectPRN292].[dbo].Answer " +
                "where Answer.isCorrect = 1 and  Question.Question_ID = Answer.Question_ID  " +
                "and (Question.Question_ID =" + quesID[0];

            if (quesID.Count > 1)
            {
                for (int i = 1; i < quesID.Count; i++)
                {
                    sql += " or Question.Question_ID =" + quesID[i];
                }
            }
            sql += " )";

            return DAO.GetDataTable(sql);
        }
        public static DataTable chapterList(string ecode)
        {
            string sql = "select distinct Chapter.Chapter_ID,Chapter.ChapterName from" +
                "	Question,ExamQuestion,Chapter where" +
                " Question.Question_ID = ExamQuestion.Question_ID and Chapter.Chapter_ID = Question.Chapter_ID and Exam_Code = @ecode";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@ecode", ecode);
            return DAO.GetDataTable(command);
        }

        public static List<int> quesList(string ecode)
        {
            string sql = "select Question_ID from ExamQuestion where Exam_Code = @ecode";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@ecode", ecode);
            return DAO.getListData(command);
        }
    }
}
