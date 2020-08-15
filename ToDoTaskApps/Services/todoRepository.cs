using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTaskApps.DBContext;
using ToDoTaskApps.Entities;

namespace ToDoTaskApps.Services
{
    public class todoRepository : ITodoRepository
    {
        private readonly TodoContext _todoContext;
        public todoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext ?? throw new ArgumentNullException(nameof(todoContext));
        }

        public void AddTodo(Todo todo)
        {
            if (todo == null)
                throw new ArgumentNullException(nameof(todo));
            _todoContext.Todos.Add(todo);
        }

        public void DeleteBand(Todo todo)
        {
            if (todo == null)
                throw new ArgumentNullException(nameof(todo));
            _todoContext.Todos.Remove(todo);
        }

        public IEnumerable<Todo> GetTodos(Guid todoIds)
        {
           if(todoIds == Guid.Empty)
                throw new ArgumentNullException(nameof(todoIds));
            return _todoContext.Todos.Where(a => a.Id == todoIds)
                                    .OrderBy(a => a.Expiry).ToList();
        }

        public Todo GetTodo(Guid todoId)
        {
            if (todoId == Guid.Empty)
                throw new ArgumentNullException(nameof(todoId));
            return _todoContext.Todos.Where(a => a.Id == todoId).FirstOrDefault();
        }

      

        public bool save()
        {
            return (_todoContext.SaveChanges() >= 0);
        }

        public bool TodoExists(Guid todoId)
        {
           if(todoId == Guid.Empty)
                throw new ArgumentNullException(nameof(todoId));
            return _todoContext.Todos.Any(a => a.Id == todoId);
        }

        public void UpdateTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Todo> ITodoRepository.GetTodos()
        {
            return _todoContext.Todos.ToList();
        }

        public IEnumerable<Todo> GetTodos(IEnumerable<Guid> todoIds)
        {
           if(todoIds == null)
            {
                throw new ArgumentNullException(nameof(todoIds));
            }
            return _todoContext.Todos.Where(a => todoIds.Contains(a.Id))
                                     .OrderBy(a => a.Expiry).ToList();

        }
    }
}
