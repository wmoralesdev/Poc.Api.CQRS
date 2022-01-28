using MediatR;
using Poc.Api.Application.TodoItems.Common.ViewModels;

namespace Poc.Api.Application.TodoItems.Queries.GetAllTodosQuery;

public class GetAllTodosQuery : IRequest<List<TodoItemVm>>
{
}