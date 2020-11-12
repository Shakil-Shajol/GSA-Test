using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SIM_Library.DTO;
using SIM_Library.Models;
using SIM_Library.Repository;


namespace StudentInfo_Management_API.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _repo;
        private readonly IHostingEnvironment _host;

        public StudentsController(IStudentRepo repo,IHostingEnvironment host)
        {
            _repo = repo;
            _host = host;
        }
        // GET: api/Students
        [HttpGet]
        public ActionResult<IEnumerable<StudentOutDTO>> Get()
        {
            return _repo.GetStudents().ToList();
        }

        // GET api/Students/5
        [HttpGet("{id}")]
        public ActionResult<StudentOutDTO> Get(int id)
        {
            return _repo.GetStudentById(id);
        }

        // POST api/Students
        [HttpPost]
        public ActionResult Post([FromForm] StudentAddDTO value)
        {
            string imagePath = FileUpload.Upload(value.Picture, "Images", _host.WebRootPath);
            Student student = new Student
            {
                StudentName = value.StudentName,
                DateOfBirth = value.DateOfBirth,
                GenderId = value.GenderId,
                PicturePath = imagePath
            };
            _repo.InsertStudent(student);
            
            return Ok(student);
        }

        // PUT api/Students
        [HttpPut]
        public ActionResult Put([FromForm] StudentAddDTO value)
        {
            var preStudent = Get(value.StudentId);
            if (preStudent !=null)
            {
                string imagePath = preStudent.Value.PicturePath;
                if (value.Picture != null)
                {
                    imagePath = FileUpload.UpdateFile(value.Picture,imagePath, "Images", _host.WebRootPath);
                }
                Student student = new Student
                {
                    StudentId = value.StudentId,
                    StudentName = value.StudentName,
                    DateOfBirth = value.DateOfBirth,
                    GenderId = value.GenderId,
                    PicturePath = imagePath
                };
                _repo.UpdateStudent(student);

                return Ok(student);
            }
            return NotFound();
        }

        // DELETE api/Students/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            _repo.DeleteStudent(id);
            FileUpload.Remove(student.PicturePath, _host.WebRootPath);
            return Ok(student);
        }
    }
}
