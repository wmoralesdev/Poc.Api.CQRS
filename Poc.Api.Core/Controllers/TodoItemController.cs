using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.Api.Application.TodoItems.Commands.CreateTodo;
using Poc.Api.Application.TodoItems.Commands.DeleteTodo;
using Poc.Api.Application.TodoItems.Commands.UpdateTodo;
using Poc.Api.Application.TodoItems.Common.ViewModels;
using Poc.Api.Application.TodoItems.Queries.GetAllTodosQuery;

namespace Poc.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;


    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoItemVm>>> GetTodoItems()
    {
        var query = new GetAllTodosQuery();
        var result = await _mediator.Send(query);

        return result;
    }

    [HttpPost("new")]
    public async Task<ActionResult<TodoItemVm>> CreateTodoItem(CreateTodoRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(request);
    }

    [HttpPatch("update")]
    public async Task<ActionResult<TodoItemVm>> UpdateTodoItem(UpdateTodoRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(request);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<TodoItemVm>> DeleteTodoItem(int id)
    {
        var result = await _mediator.Send(new DeleteTodoRequest(id));
        return Ok(result);
    }
}