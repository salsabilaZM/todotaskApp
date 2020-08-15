using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoTaskApps.Entities
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; } //id Of todo
        
        public DateTime Expiry { get; set; } //datetime expiry

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }//title of the todo
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }//Descripton of the todo
        public int Complete { get; set; }//percentage todo
    }
}
