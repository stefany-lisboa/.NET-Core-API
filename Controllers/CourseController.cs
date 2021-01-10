using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS_API.Data;
using SS_API.Model;
using SS_API.Services;

namespace SS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IAcess _acess;

        Project project = new Project();
        public CourseController()
        {
            this._acess = new Acess(new StreamerContext());
        }

        //GET api/course/5
        [HttpGet("{id}")]
        public IEnumerable<Project> Get(int id)
        {
            try
            {
               
                return _acess.GetCourse(id);
            }
            catch (DataException ex)
            {
                 BadRequest(ex.Message);
            }
            return _acess.GetCourse(id);
        }
            
    }
}