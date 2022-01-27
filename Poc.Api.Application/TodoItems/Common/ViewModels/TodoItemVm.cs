namespace Poc.Api.Application.TodoItems.Common.ViewModels;

public class TodoItemVm
{
    public int Id { get; set; }
    
    public string? ToDo { get; set; }
    
    public DateTime DueDate { get; set; }

    public int Priority { get; set; }

    public bool Completed { get; set; }
}