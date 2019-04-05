using System;
using System.Collections.Generic;
using ToDoList.Entities;

public class ToDoForMembersEntity
{
    public int Id { get; set; }
    public ToDoEntity ToDo { get; set; }
    public string Email { get; set; }
    public TagEntity Tag { get; set; }
}
