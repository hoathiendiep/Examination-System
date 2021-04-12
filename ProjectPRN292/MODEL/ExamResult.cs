using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPRN292.MODEL
{
    public class ExamResult
    {
        public string ExamCode { get; set; }
        public string StudentID { get; set; }

        public DateTime testDate { get; set; }

        public int Score { get; set; }

        public int QuestionNo { get; set; }
        public int QuestionID { get; set; }
        public int AnswernID { get; set; }


    }
}
