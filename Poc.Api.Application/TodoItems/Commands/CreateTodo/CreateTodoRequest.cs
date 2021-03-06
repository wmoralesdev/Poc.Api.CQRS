using MediatR;
using Poc.Api.Application.TodoItems.Common.ViewModels;

namespace Poc.Api.Application.TodoItems.Commands.CreateTodo;

public record CreateTodoRequest(string ToDo, DateTime DueDate, bool Completed, int Priority = 1) : IRequest<TodoItemVm>;