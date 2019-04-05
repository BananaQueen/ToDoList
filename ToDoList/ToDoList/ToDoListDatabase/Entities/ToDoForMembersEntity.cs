using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDoList.Entities;

public class ToDoForMembersEntity
{
    public int Id { get; set; }
    [Required] public ToDoEntity ToDo { get; set; }
    [Required] public string Email { get; set; }
    public TagEntity Tag { get; set; }
}
