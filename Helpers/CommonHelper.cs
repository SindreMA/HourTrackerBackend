using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using HourTrackerBackend.Modals.Request;
using Microsoft.EntityFrameworkCore;

namespace HourTrackerBackend.Helpers
{
    public class CommonHelper
    {
        private readonly TrackerContext _context;
        private readonly string? _username;
        public CommonHelper(TrackerContext context, IHttpContextAccessor ctx)
        {
            _context = context;
            _username = ctx.HttpContext?.User?.Identity?.Name;
        }

        public Comment AddComment(int commonId, CommentMessage comment)
        {
            var user = _context.Users.Find(_username);
            if (user == null) throw new System.Exception("Unauthorized");
            var common = _context.Commons.Include(x=> x.Comments).Single(x => x.Id == commonId);
            
            var newComment = new Comment
            {
                Text = comment.Text,
                Created = DateTime.UtcNow,
                User = user
            };

            common.Comments.Add(newComment);
            _context.SaveChanges();
            return newComment;
        }

        public void RemoveComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null) throw new System.Exception("NotFound");
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