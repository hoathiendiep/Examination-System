using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPRN292
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public Question Q { get; set; }
    }
}
