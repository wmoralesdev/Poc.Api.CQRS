namespace Poc.Api.Domain.Entities.Todo;

public class TodoItemList
{
    public int Id { get; set; }

    public IList<TodoItem> Items { get; set; }
}