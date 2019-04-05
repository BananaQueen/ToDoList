using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using ToDoList.Entities;

public class ToDoContext : DbContext
{ 
    public DbSet<ToDoEntity> ToDo { get; set; }
    public DbSet<CategoryEntity> Category { get; set; }
    public DbSet<ToDoForMembersEntity> ToDoForMembers { get; set; }
    public DbSet<TagEntity> Tag { get; set; }

    string _connectionString = null;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "User ID=postgres;Password=1234Qwer;Host=localhost;Port=5432;Database=ToDoList";
        optionsBuilder.UseNpgsql(connectionString);
    }

    //for migrations
    public ToDoContext()
    {

    }

    //do wstrzykiwania 
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {
        _connectionString = options.GetExtension<NpgsqlOptionsExtension>()?.ConnectionString;
        if (string.IsNullOrEmpty(_connectionString))
            throw new ArgumentNullException(nameof(options));
    }

    static public void Main(String[] args)
    {

    }
}
