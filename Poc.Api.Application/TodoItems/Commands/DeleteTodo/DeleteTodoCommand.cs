using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Application.TodoItems.Common.ViewModels;
using Poc.Api.Domain.Context;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItems.Commands.DeleteTodo;

public class DeleteTodoCommand : IRequestHandler<DeleteTodoRequest, TodoItemVm>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public DeleteTodoCommand(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<TodoItemVm> Handle(DeleteTodoRequest request, CancellationToken cancellationToken)
    {
        var todoItem = await _ctx.TodoItems!
            .Where(ti => ti.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (todoItem is null)
            return null!;

        _ctx.Remove(todoItem);
        await _ctx.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TodoItem, TodoItemVm>(todoItem);
    }
}