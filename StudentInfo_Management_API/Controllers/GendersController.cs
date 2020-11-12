using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIM_Library.Models;
using SIM_Library.Repository;

namespace StudentInfo_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IStudentRepo repo;

        public GendersController(IStudentRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Gender>> Get()
        {
            return repo.GetGenders().ToList();
        }
    }
}
