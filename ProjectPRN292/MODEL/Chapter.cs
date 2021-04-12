using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPRN292.MODEL
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Subject Subject { get; set; }
    }
}
