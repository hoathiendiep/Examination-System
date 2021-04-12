using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPRN292.MODEL
{
    public class Exam
    {
        public string ExamCode { get; set; }
        public string ExamName { get; set; }

        public int Total{get; set;}
        public int Time { get; set; }

        public Subject Subject = new Subject();
        public List<int> lstQuesID = new List<int>();

    }
}
