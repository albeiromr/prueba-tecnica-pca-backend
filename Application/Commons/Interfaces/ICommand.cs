using Domain.Commons.Abstractions;
using MediatR;

namespace Application.Commons.Interfaces;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}