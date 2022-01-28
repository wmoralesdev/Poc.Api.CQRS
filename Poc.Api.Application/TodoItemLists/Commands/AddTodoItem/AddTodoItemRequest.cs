using MediatR;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;

namespace Poc.Api.Application.TodoItemLists.Commands.AddTodoItem;

public record AddTodoItemRequest(int ListId, int ItemId) : IRequest<TodoItemListVm>;