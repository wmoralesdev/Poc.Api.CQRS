using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;
using Poc.Api.Domain.Context;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItemLists.Commands.DeleteTodoItemList;

public class DeleteTodoItemListCommand : IRequestHandler<DeleteTodoItemListRequest, TodoItemListVm>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public DeleteTodoItemListCommand(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<TodoItemListVm> Handle(DeleteTodoItemListRequest request, CancellationToken cancellationToken)
    {
        var todoItemList = await _ctx.TodoItemLists!
            .Where(til => til.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (todoItemList == null)
            return null!;
        
        _ctx.Remove(todoItemList);
        await _ctx.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TodoItemList, TodoItemListVm>(todoItemList);
    }
}