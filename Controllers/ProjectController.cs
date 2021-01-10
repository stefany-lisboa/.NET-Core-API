using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS_API.Data;
using SS_API.Model;
using SS_API.Services;


namespace SS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IAcess _acess;
        Project project = new Project();

        public ProjectController()
        {
            this._acess = new Acess(new StreamerContext());
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            try
            {
                var projects = (from project in _acess.GetProjects()
                                select project).ToList();
                return projects;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            try
            {
                var project = _acess.GetProject(id);
                return project;
            }
            catch (DataException ex)
            {
                BadRequest(ex.Message);
            }
            return Ok();
        }

        private void View(Project project)
        {
            throw new NotImplementedException();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Project> Post(Project project)
        {
            var get = _acess.GetProject(project.Id);
            try
            {

                if (get == null)
                {
                    _acess.AddProject(project);
                    var newProjectUrl = $"api/project/{project.Id}";
                    return Created(newProjectUrl, project.Id);
                }
                else
                {
                    return Ok();
                }

            }
            catch (DataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] Project project)
        {

            try
            {

                _acess.UpdateProject(project);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool aux = false;
            try
            {
                var get = _acess.GetProject(id);
                if (get != null)
                {
                    _acess.DeleteProject(id);
                    aux = true;
                }
                else
                {
                    aux = false;
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex.Message);
            }
            return aux;
        }
    }
}
