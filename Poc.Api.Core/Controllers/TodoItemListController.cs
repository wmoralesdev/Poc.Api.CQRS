using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.Api.Application.TodoItemLists.Commands.AddTodoItem;
using Poc.Api.Application.TodoItemLists.Commands.CreateTodoItemList;
using Poc.Api.Application.TodoItemLists.Commands.DeleteTodoItemFromList;
using Poc.Api.Application.TodoItemLists.Commands.DeleteTodoItemList;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;
using Poc.Api.Application.TodoItemLists.Queries.GetTodoItemList;
using Poc.Api.Application.TodoItemLists.Queries.GetTodoItemLists;

namespace Poc.Api.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemListController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoItemListController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoItemListVm>>> GetTodoItemLists()
    {
        var query = new GetTodoItemListsRequest();
        var result = await _mediator.Send(query);

        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<List<TodoItemListVm>>> GetTodoItemList(int id)
    {
        var query = new GetTodoItemListRequest(id);
        var result = await _mediator.Send(query);

        return result is null ? NotFound() : Ok(result);
    }
    
    [HttpPost("new")]
    public async Task<ActionResult<TodoItemListVm>> CreateTodoItemList(CreateTodoItemListRequest command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("addItem")]
    public async Task<ActionResult<TodoItemListVm>> AddTodoItem(AddTodoItemCommand command)
    {
        var result = await _mediator.Send(command);

        return result is null ? NotFound() : Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<TodoItemListVm>> DeleteTodoItemList(int id)
    {
        var result = await _mediator.Send(new DeleteTodoItemListRequest(id));

        return result is null ? NotFound() : Ok(result);
    }
    
    [HttpDelete("item")]
    public async Task<ActionResult<TodoItemListVm>> DeleteTodoItemFromList(DeleteTodoItemListFromRequest command)
    {
        var result = await _mediator.Send(command);

        return result is null ? NotFound() : Ok(result);
    }
}