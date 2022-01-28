using MediatR;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;

namespace Poc.Api.Application.TodoItemLists.Queries.GetTodoItemLists;

public class GetTodoItemListsRequest : IRequest<List<TodoItemListVm>>
{
    
}