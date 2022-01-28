using MediatR;
using Poc.Api.Application.TodoItems.Common.ViewModels;

namespace Poc.Api.Application.TodoItemLists.Commands.DeleteTodoItemFromList;

public record DeleteTodoItemListFromRequest(int ListId, int ItemId) : IRequest<TodoItemVm>;