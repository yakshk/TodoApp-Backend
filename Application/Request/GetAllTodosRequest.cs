using Application.DTOs;
using MediatR;

namespace Application.Request;

public class GetAllTodosRequest : IRequest<List<TodoDto>>;