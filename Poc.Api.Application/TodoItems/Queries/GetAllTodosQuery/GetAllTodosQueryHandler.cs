using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Application.TodoItems.Common.ViewModels;
using Poc.Api.Domain.Context;

namespace Poc.Api.Application.TodoItems.Queries.GetAllTodosQuery;

public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, List<TodoItemVm>>
{
    private readonly TodoDbContext _ctx;
    private readonly IMapper _mapper;

    public GetAllTodosQueryHandler(TodoDbContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<List<TodoItemVm>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        var items = await _mapper.ProjectTo<TodoItemVm>(
            _ctx.TodoItems!.OrderBy(t => t.Id)
        ).ToListAsync(cancellationToken);

        return items;
    }
}