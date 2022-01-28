using AutoMapper;
using Poc.Api.Application.TodoItemLists.Common.ViewModels;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItemLists.Mappers;

public class TodoItemListProfile : Profile
{
    public TodoItemListProfile()
    {
        CreateMap<TodoItemList, TodoItemListVm>();
        CreateMap<TodoItemListVm, TodoItemList>();
    }
}