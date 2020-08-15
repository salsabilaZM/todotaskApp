using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoTaskApps.Entities;

namespace ToDoTaskApps.Services
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodos(Guid todoId);
        Todo GetTodo(Guid todoId);
        IEnumerable<Todo> GetTodos(IEnumerable<Guid> todoIds);
        void AddTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteBand(Todo todo);

        bool TodoExists(Guid todoId);
        bool save();
    }
}
