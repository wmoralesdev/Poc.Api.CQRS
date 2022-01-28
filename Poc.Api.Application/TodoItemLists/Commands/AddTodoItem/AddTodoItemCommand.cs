using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;
using Poc.Api.Domain.Context;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItemLists.Commands.AddTodoItem;

public class AddTodoItemCommand : IRequestHandler<AddTodoItemRequest, TodoItemListVm>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public AddTodoItemCommand(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<TodoItemListVm> Handle(AddTodoItemRequest request, CancellationToken cancellationToken)
    {
        var todoItemList = await _ctx.TodoItemLists!
            .Where(til => til.Id == request.ListId)
            .FirstOrDefaultAsync(cancellationToken);

        if (todoItemList is null)
            return null!;
        
        var todoItem = await _ctx.TodoItems!
            .Where(ti => ti.Id == request.ItemId)
            .FirstOrDefaultAsync(cancellationToken);
        
        todoItemList!.Items.Add(todoItem!);

        await _ctx.SaveChangesAsync(cancellationToken);
        return _mapper.Map<TodoItemList, TodoItemListVm>(todoItemList);
    }
}