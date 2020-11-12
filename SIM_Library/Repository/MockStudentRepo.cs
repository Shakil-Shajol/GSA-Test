using Microsoft.EntityFrameworkCore;
using SIM_Library.Context;
using SIM_Library.DTO;
using SIM_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIM_Library.Repository
{
    public class MockStudentRepo : IStudentRepo
    {
        private readonly StudentContext _context;

        public MockStudentRepo(StudentContext context)
        {
            this._context = context;
        }
        public void DeleteStudent(int id)
        {
            Student student = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public IEnumerable<Gender> GetGenders()
        {
            return _context.Genders.ToList();
        }

        public StudentOutDTO GetStudentById(int id)
        {
                var student = _context.Students.AsNoTracking().Include("Gender").Where(x => x.StudentId == id).FirstOrDefault();
                StudentOutDTO outDTO = new StudentOutDTO
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    DateOfBirth = student.DateOfBirth,
                    Gender = student.Gender.GenderName,
                    GenderId=student.GenderId,
                    PicturePath = student.PicturePath
                };
                return outDTO;
        }

        public IEnumerable<StudentOutDTO> GetStudents()
        {
            var students = _context.Students.Include("Gender").ToList();
            List<StudentOutDTO> studentOuts = new List<StudentOutDTO>();
            foreach (var student in students)
            {
                StudentOutDTO outDTO = new StudentOutDTO
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    DateOfBirth = student.DateOfBirth,
                    Gender = student.Gender.GenderName,
                    GenderId = student.GenderId,
                    PicturePath = student.PicturePath
                };
                studentOuts.Add(outDTO);
            }
            return studentOuts;
        }

        public void InsertStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            
        }
    }
}
