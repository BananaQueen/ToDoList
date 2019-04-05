using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoList.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
    }
}