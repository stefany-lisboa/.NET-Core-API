using SS_API.Data;
using SS_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace SS_API.Services
{
    public class Acess : IAcess
    {
        private Project project = new Project();
        private StreamerContext context;

        public Acess(StreamerContext streamer)
        {
            this.context = streamer;
        }


        public void AddProject(Project item)
        {

            context.Project.Add(item);
            Save();

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(int id)
        {

            Project project = context.Project.Find(id);
            context.Project.Remove(project);
            Save();
        }

        public Project GetProject(int id)
        {
            return context.Project.Where(i => i.Id == id).Include("Course").FirstOrDefault();

        }

        public IEnumerable<Project> GetProjects()
        {

            return context.Project.Include("Course");

        }

        public void UpdateProject(Project item)
        {

            context.Project.Update(item);
            Save();
        }

        public IEnumerable<Project> GetCourse(int id)
        {

            return (from p in context.Project where p.CourseId == id select p).Include("Course").ToList();

        }


        public void Save()
        {

            context.SaveChanges();

        }
    }
}
