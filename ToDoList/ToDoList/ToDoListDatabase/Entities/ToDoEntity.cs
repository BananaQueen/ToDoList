using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDoList.Entities;

public class ToDoEntity
{
	public int Id { get; set; }
    [Required] public string Name { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
    public DateTime EventDate { get; set; }
    public DateTime ReminderDate { get; set; }
    [Required] public CategoryEntity Category { get; set; }
    public TagEntity Tag { get; set; }
}
