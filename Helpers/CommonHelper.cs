using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using HourTrackerBackend.Modals.Request;
using Microsoft.EntityFrameworkCore;

namespace HourTrackerBackend.Helpers
{
    public class CommonHelper
    {
        private readonly TrackerContext _context;
        private readonly string _username;
        public CommonHelper(TrackerContext context, string username = null)
        {
            _context = context;
            _username = username;
        }

        public Comment AddComment(int commonId, CommentMessage comment)
        {
            var user = _context.Users.Find(_username);
            var common = _context.Commons.Include(x=> x.Comments).Single(x => x.Id == commonId);
            
            var newComment = new Comment
            {
                Text = comment.Text,
                Created = System.DateTime.UtcNow,
                User = user
            };

            common.Comments.Add(newComment);
            _context.SaveChanges();
            return newComment;
        }

        public void RemoveComment(int id)
        {
            var comment = _context.Comments.Find(id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        internal List<Comment> GetComments(int id)
        {
            var common = _context.Commons.Include(x=> x.Comments).Single(x => x.Id == id);
            return common.Comments;
        }
    }    
}