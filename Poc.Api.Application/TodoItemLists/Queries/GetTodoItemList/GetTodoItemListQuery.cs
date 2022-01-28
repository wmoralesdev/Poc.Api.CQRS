using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;
using Poc.Api.Domain.Context;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItemLists.Queries.GetTodoItemList;

public class GetTodoItemListQuery : IRequestHandler<GetTodoItemListRequest, TodoItemListVm>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public GetTodoItemListQuery(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<TodoItemListVm> Handle(GetTodoItemListRequest request, CancellationToken cancellationToken)
    {
        var todoItemList = await _ctx.TodoItemLists!
            .Where(til => til.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        return todoItemList is null ? null! : _mapper.Map<TodoItemList, TodoItemListVm>(todoItemList);
    }
}