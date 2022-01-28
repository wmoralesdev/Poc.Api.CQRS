using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;
using Poc.Api.Domain.Context;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItemLists.Commands.CreateTodoItemList;

public class CreateTodoItemListCommand : IRequestHandler<CreateTodoItemListRequest, TodoItemListVm>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public CreateTodoItemListCommand(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<TodoItemListVm> Handle(CreateTodoItemListRequest request, CancellationToken cancellationToken)
    {
        var todoItems = await _ctx.TodoItems!
            .Where(x => request.TodoItems.Any(i => i == x.Id))
            .ToListAsync(cancellationToken);

        var todoItemList = new TodoItemList
        {
            Items = todoItems
        };

        _ctx.Add(todoItemList);
        await _ctx.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TodoItemList, TodoItemListVm>(todoItemList);
    }
}