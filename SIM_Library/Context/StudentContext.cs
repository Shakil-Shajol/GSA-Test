using Microsoft.EntityFrameworkCore;
using SIM_Library.DTO;
using SIM_Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIM_Library.Context
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbQuery<StudentOutDTO> StudentView { get; set; }


    }
}
