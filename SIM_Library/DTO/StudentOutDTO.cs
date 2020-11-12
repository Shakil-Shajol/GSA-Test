using System;
using System.Collections.Generic;
using System.Text;

namespace SIM_Library.DTO
{
    public class StudentOutDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public string PicturePath { get; set; }
    }
}
