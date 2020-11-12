using SIM_Library.DTO;
using SIM_Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIM_Library.Repository
{
    public interface IStudentRepo
    {
        StudentOutDTO GetStudentById(int id);
        IEnumerable<StudentOutDTO> GetStudents();
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        IEnumerable<Gender> GetGenders();
    }
}
