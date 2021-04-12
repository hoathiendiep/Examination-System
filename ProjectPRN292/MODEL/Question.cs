using ProjectPRN292.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPRN292
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public Chapter Chapter = new Chapter();

        public List<Answer> Answers = new List<Answer>();

        public bool isMultipleChoice
        {
            get
            {
                int count = 0;
                foreach(Answer a in Answers)
                {
                    if (a.IsCorrect) count++;
                }
                return count > 1;
            }
        }
    }
}
