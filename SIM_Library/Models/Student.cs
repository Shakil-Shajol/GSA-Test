using System;
using System.Collections.Generic;
using System.Text;

namespace SIM_Library.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public string PicturePath { get; set; }
    }
}
