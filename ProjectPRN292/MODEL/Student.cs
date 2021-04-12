using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPRN292.MODEL
{
    public class Student
    {
        public string Student_ID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
