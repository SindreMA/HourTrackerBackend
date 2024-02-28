using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using HourTrackerBackend.Modals.Request;
using Microsoft.EntityFrameworkCore;

namespace HourTrackerBackend.Helpers
{
    public class LinkHelper
    {
        private TrackerContext _context;
                
        public LinkHelper(TrackerContext context)
        {
            _context = context;
        }

        public void RemoveLink(int linkId)
        {
            var link = _context.ProjectMecanicLinks.Where(l => l.Id == linkId).Include(l => l.WeekData).FirstOrDefault();
            if (link == null)
            {
                throw new Exception("Link not found");
            }
            _context.WeekData.RemoveRange(link.WeekData);

            _context.ProjectMecanicLinks.Remove(link);
            _context.SaveChanges();
        }

        public void AddLink(int projectId, int mechanicId)
        {
            var project = _context.Projects.Include(p => p.Links).FirstOrDefault(p => p.Id == projectId);
            var link = project.Links.FirstOrDefault(l => l.MechanicId == mechanicId);
            if (link == null)
            {
                project.Links.Add(new ProjectMecanicLink
                {
                    ProjectId = projectId,
                    MechanicId = mechanicId,
                    Created = DateTime.UtcNow
                });
                _context.SaveChanges();
            }
        }

        public List<ProjectMecanicLink> GetLinks(int projectId)
        {
            return _context.ProjectMecanicLinks.Where(l => l.ProjectId == projectId).ToList();
        }

        public void AddWeekData(int linkId, WeekDataMessage msg)
        {
            var link = _context.ProjectMecanicLinks.Include(l => l.WeekData).FirstOrDefault(l => l.Id == linkId);
            if (link == null)
            {
                throw new Exception("Link not found");
            }
            var weekData = link.WeekData.FirstOrDefault(w => w.WeekNumber == msg.WeekNumber && w.Year == msg.Year);
            if (weekData != null)
            {
                throw new Exception("Week data already exists");
            }

            weekData = new WeekData
            {
                WeekNumber = msg.WeekNumber,
                Year = msg.Year,
                SecondsWorked = msg.SecondsWorked,
                Created = DateTime.UtcNow
            };

            link.WeekData.Add(weekData);
            _context.SaveChanges();
        }

        public void EditWeekData(int linkId, WeekDataMessage msg)
        {
            var link = _context.ProjectMecanicLinks.Include(l => l.WeekData).FirstOrDefault(l => l.Id == linkId);
            if (link == null)
            {
                throw new Exception("Link not found");
            }
            var weekData = link.WeekData.FirstOrDefault(w => w.WeekNumber == msg.WeekNumber && w.Year == msg.Year);
            if (weekData == null)
            {
                throw new Exception("Week data not found");
            }

            weekData.SecondsWorked = msg.SecondsWorked;
            _context.SaveChanges();
        }

        internal void RemoveLinks(List<ProjectMecanicLink> links)
        {
            _context.ProjectMecanicLinks.RemoveRange(links);            
        }
    }
}
