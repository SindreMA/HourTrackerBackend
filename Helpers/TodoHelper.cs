using HourTrackerBackend.Modals;
using HourTrackerBackend.Modals.Database;
using HourTrackerBackend.Modals.Request;
using Microsoft.EntityFrameworkCore;

namespace HourTrackerBackend.Helpers
{
    public class TodoHelper
    {
        private readonly TrackerContext _context;
        private readonly string? _username;

        public TodoHelper(TrackerContext context, IHttpContextAccessor ctx)
        {
            _context = context;
            _username = ctx.HttpContext?.User?.Identity?.Name;
        }

        internal Todo AddTodoItem(TodoMessage todo, int id)
        {
            var project = _context.Projects.Include(p => p.Todos).FirstOrDefault(p => p.Id == id);

            if (project == null) throw new Exception("NotFound");
            
            var newTodo = new Todo
            {
                Title = todo.Title,
                Status = todo.Status,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };
            project.Todos.Add(newTodo);
            _context.SaveChanges();
            return newTodo;
        }

        internal Todo UpdateTodoItem(TodoMessage todo, int id)
        {
            var dbTodo = _context.Todos.Find(id);

            if (dbTodo == null) throw new Exception("NotFound");

            dbTodo.Title = todo.Title;
            dbTodo.Status = todo.Status;
            dbTodo.Updated = DateTime.UtcNow;
            _context.Todos.Update(dbTodo);
            _context.SaveChanges();
            return dbTodo;
        }

        internal void RemoveTodoItem(int id)
        {
            var todo = _context.Todos.Find(id);

            if (todo == null) throw new Exception("NotFound");

            _context.Todos.Remove(todo);
            _context.SaveChanges();
        }

        internal List<Todo> GetTodos()
        {
            return _context.Todos.ToList();
        }

        internal void RemoveTodos(List<Todo> todos)
        {
            _context.Todos.RemoveRange(todos);            
        }
    }
}