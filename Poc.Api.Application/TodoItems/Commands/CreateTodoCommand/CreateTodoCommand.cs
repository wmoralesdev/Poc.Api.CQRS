using AutoMapper;
using MediatR;
using Poc.Api.Application.TodoItems.Common.ViewModels;
using Poc.Api.Domain.Context;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItems.Commands.CreateTodoCommand;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoRequest, TodoItemVm>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public CreateTodoCommandHandler(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<TodoItemVm> Handle(CreateTodoRequest request, CancellationToken cancellationToken)
    {
        var item = _ctx.Add(new TodoItem
        {
            Completed = request.Completed,
            ToDo = request.ToDo,
            DueDate = request.DueDate,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Priority = request.Priority
        }).Entity;

        await _ctx.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TodoItem, TodoItemVm>(item);
    }
}