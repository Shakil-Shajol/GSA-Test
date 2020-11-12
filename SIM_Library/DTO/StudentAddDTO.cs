using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIM_Library.DTO
{
    public class StudentAddDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public IFormFile Picture { get; set; }
    }
}
