using MediatR;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;

namespace Poc.Api.Application.TodoItemLists.Queries.GetTodoItemList;

public record GetTodoItemListRequest(int Id) : IRequest<TodoItemListVm>;