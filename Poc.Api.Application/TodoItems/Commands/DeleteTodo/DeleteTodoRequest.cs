using MediatR;
using Poc.Api.Application.TodoItems.Common.ViewModels;

namespace Poc.Api.Application.TodoItems.Commands.DeleteTodo;

public record DeleteTodoRequest(int Id) : IRequest<TodoItemVm>;