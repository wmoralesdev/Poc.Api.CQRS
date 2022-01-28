using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Application.TodoItems.Common.ViewModels;
using Poc.Api.Domain.Context;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItemLists.Commands.DeleteTodoItemFromList;

public class DeleteTodoItemFromListCommand : IRequestHandler<DeleteTodoItemListFromRequest, TodoItemVm>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public DeleteTodoItemFromListCommand(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<TodoItemVm> Handle(DeleteTodoItemListFromRequest request, CancellationToken cancellationToken)
    {
        var todoItemList = await _ctx.TodoItemLists!
            .Where(til => til.Id == request.ListId)
            .Include(til => til.Items)
            .FirstOrDefaultAsync(cancellationToken);

        if (todoItemList is null)
            return null!;

        var todoItem = await _ctx.TodoItems!
            .Where(x => x.Id == request.ItemId)
            .FirstOrDefaultAsync(cancellationToken);

        todoItemList!.Items.Remove(todoItem!);

        await _ctx.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TodoItem, TodoItemVm>(todoItem!);
    }
}