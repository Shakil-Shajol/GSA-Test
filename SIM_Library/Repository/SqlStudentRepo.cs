using Microsoft.EntityFrameworkCore;
using SIM_Library.Context;
using SIM_Library.DTO;
using SIM_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SIM_Library.Repository
{
    public class SqlStudentRepo : IStudentRepo
    {
        private readonly StudentContext _context;

        public SqlStudentRepo(StudentContext context)
        {
            _context = context;
        }
        public void DeleteStudent(int id)
        {
            _context.Students.FromSql<Student>("spDeleteStudent {0}", id);
            _context.SaveChanges();
        }

        public IEnumerable<Gender> GetGenders()
        {
            throw new NotImplementedException();
        }

        public StudentOutDTO GetStudentById(int id)
        {
            Student student= _context.Students.FromSql("spGetStudentById {0}", id).FirstOrDefault();
            StudentOutDTO studentOut = new StudentOutDTO
            {
                StudentName = student.StudentName,
                Gender = student.Gender.GenderName,
                DateOfBirth = student.DateOfBirth,
                PicturePath = student.PicturePath
            };
            return studentOut;
        }

        public IEnumerable<StudentOutDTO> GetStudents()
        {
            var studentList = _context.Students.FromSql("spGetStudents").ToList();

            List<StudentOutDTO> studentOutList = new List<StudentOutDTO>();
            //foreach (var item in studentList)
            //{
            //    StudentOutDTO dto = new StudentOutDTO
            //    {
            //        StudentId = item.StudentId,
            //        StudentName = item.StudentName,
            //        Gender = item.Gender.GenderName,
            //        DateOfBirth = item.DateOfBirth,
            //        PicturePath = item.PicturePath
            //    };
            //    studentOutList.Add(dto);
        //}
            return studentOutList;
        }

        public void InsertStudent(Student student)
        {
            _context.Students.FromSql("spInsertStudent '{0}','{1}',{2},'{3}'", 
                                            student.StudentName, 
                                            student.DateOfBirth, 
                                            student.GenderId, 
                                            student.PicturePath);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.FromSql("spUpdateStudent {0},'{1}','{2}',{3},'{4}'",
                                            student.StudentId,
                                            student.StudentName,
                                            student.DateOfBirth,
                                            student.GenderId,
                                            student.PicturePath);
            _context.SaveChanges();
        }
    }
}
