using Microsoft.EntityFrameworkCore;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Domain.Context;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TodoItem>? TodoItems { get; set; }

    public DbSet<TodoItemList>? TodoItemLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>()
            .HasKey(ti => ti.Id);
    }
}