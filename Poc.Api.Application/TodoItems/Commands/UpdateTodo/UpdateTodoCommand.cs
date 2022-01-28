using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Application.TodoItems.Common.ViewModels;
using Poc.Api.Domain.Context;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItems.Commands.UpdateTodo;

public class UpdateTodoCommand : IRequestHandler<UpdateTodoRequest, TodoItemVm>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public UpdateTodoCommand(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<TodoItemVm> Handle(UpdateTodoRequest request, CancellationToken cancellationToken)
    {
        var todoItem = await _ctx.TodoItems!
            .Where(ti => ti.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (todoItem is null)
            return null!;

        todoItem.Completed = request.Completed ?? todoItem.Completed;
        todoItem.ToDo = request.ToDo ?? todoItem.ToDo;
        todoItem.DueDate = request.DueDate ?? todoItem.DueDate;
        todoItem.Priority = request.Priority ?? todoItem.Priority;
        todoItem.UpdatedAt = DateTime.Now;

        await _ctx.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TodoItem, TodoItemVm>(todoItem);
    }
}