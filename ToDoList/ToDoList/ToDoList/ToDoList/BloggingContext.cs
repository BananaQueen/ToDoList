using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDoList.Entities;

public class BloggingContext : DbContext
{ 
    public DbSet<ToDoEntity> ToDo { get; set; }
    public DbSet<CategoryEntity> Category { get; set; }
    public DbSet<ToDo_For_MembersEntity> ToDo_For_Members { get; set; }
    public DbSet<TagEntity> Tag { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "User ID=postgres;Password=1234Qwer;Host=localhost;Port=5432;Database=ToDoList";
        optionsBuilder.UseNpgsql(connectionString);
    }
}
