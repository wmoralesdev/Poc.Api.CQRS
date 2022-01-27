using AutoMapper;
using Poc.Api.Application.TodoItems.Common.ViewModels;
using Poc.Api.Domain.Entities.Todo;

namespace Poc.Api.Application.TodoItems.Mappers;

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        CreateMap<TodoItem, TodoItemVm>();
        CreateMap<TodoItemVm, TodoItem>();
    }
}