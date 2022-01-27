using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.Api.Application.TodoItems.Commands.CreateTodoCommand;
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
    public async Task<ActionResult<List<TodoItemVm>>> GetAllTodos()
    {
        var query = new GetAllTodosQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost("new")]
    public async Task<ActionResult<TodoItemVm>> CreateTodoItem(CreateTodoRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(request);
    }
}