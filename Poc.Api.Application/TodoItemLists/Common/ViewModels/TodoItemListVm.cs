using Poc.Api.Application.TodoItems.Common.ViewModels;

namespace Poc.Api.Application.TodoItemLists.Common.ViewModels;

public class TodoItemListVm
{
    public IList<TodoItemVm> Items { get; set; }
}