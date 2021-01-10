using SS_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SS_API.Services
{
    public interface IAcess : IDisposable
    {
        IEnumerable<Project> GetProjects();
        Project GetProject(int id);
        void AddProject(Project item);
        void DeleteProject(int id);
        void UpdateProject(Project item);

        IEnumerable<Project> GetCourse(int id);
        void Save();

    }
}
