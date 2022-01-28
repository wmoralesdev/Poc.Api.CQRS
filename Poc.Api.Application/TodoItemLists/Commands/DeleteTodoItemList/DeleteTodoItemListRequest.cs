using MediatR;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;

namespace Poc.Api.Application.TodoItemLists.Commands.DeleteTodoItemList;

public record DeleteTodoItemListRequest(int Id) : IRequest<TodoItemListVm>;
