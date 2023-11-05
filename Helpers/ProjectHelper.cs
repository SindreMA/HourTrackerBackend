using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using HourTrackerBackend.Modals.Request;
using Microsoft.EntityFrameworkCore;

namespace HourTrackerBackend.Helpers
{
    public class ProjectHelper
    {
        private readonly TrackerContext _context;
        private readonly string _username;

        public ProjectHelper(TrackerContext context, string username = null)
        {
            _context = context;
            _username = username;
        }

        internal List<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        internal Project AddProject(ProjectMessage project)
        {
            var newProject = new Project
            {
                Name = project.Name,
                About = project.About,
                Created = System.DateTime.UtcNow,
                Common = new Common()
            };
            _context.Projects.Add(newProject);
            _context.SaveChanges();
            return newProject;
        }

        internal void RemoveProject(int id)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == id);
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        internal Project UpdateProject(ProjectMessage project, int id)
        {
            var dbProject = _context.Projects.Find(id);
            dbProject.Name = project.Name;
            dbProject.About = project.About;
            _context.Projects.Update(dbProject);
            _context.SaveChanges();
            return dbProject;   
        }

        internal void AddMechanic(int id, int mechanicId)
        {
            var project = _context.Projects.Include(p => p.Mechanics).FirstOrDefault(p => p.Id == id);
            var mechanic = project.Mechanics.FirstOrDefault(m => m.Id == mechanicId);
            if (mechanic == null)
            {
                project.Mechanics.Add(_context.Mechanics.Find(mechanicId));
                _context.Projects.Update(project);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Mechanic already exists");
            }
        }

        internal void RemoveMechanic(int id, int mechanicId)
        {
            var project = _context.Projects.Include(p => p.Mechanics).FirstOrDefault(p => p.Id == id);
            var mechanic = project.Mechanics.FirstOrDefault(m => m.Id == mechanicId);
            if (mechanic != null)
            {
                project.Mechanics.Remove(mechanic);
                _context.Projects.Update(project);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Mechanic does not exist");
            }
        }
    }
}
