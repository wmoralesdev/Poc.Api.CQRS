using MediatR;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;

namespace Poc.Api.Application.TodoItemLists.Commands.CreateTodoItemList;

public record CreateTodoItemListRequest(IList<int> TodoItems) : IRequest<TodoItemListVm>;