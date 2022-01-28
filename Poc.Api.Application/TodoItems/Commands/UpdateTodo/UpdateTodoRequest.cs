using MediatR;
using Poc.Api.Application.TodoItems.Common.ViewModels;

namespace Poc.Api.Application.TodoItems.Commands.UpdateTodo;

public class UpdateTodoRequest : TodoItemVm, IRequest<TodoItemVm>
{
    
}