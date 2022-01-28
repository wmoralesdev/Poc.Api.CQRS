using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;
using Poc.Api.Domain.Context;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItemLists.Queries.GetTodoItemLists;

public class GetTodoItemListsQuery : IRequestHandler<GetTodoItemListsRequest, List<TodoItemListVm>>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public GetTodoItemListsQuery(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<List<TodoItemListVm>> Handle(GetTodoItemListsRequest request, CancellationToken cancellationToken)
    {
        var todoItemLists = await _ctx.TodoItemLists!
            .Include(til => til.Items)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<TodoItemList>, List<TodoItemListVm>>(todoItemLists);
    }
}