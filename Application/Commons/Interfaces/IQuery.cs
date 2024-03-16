using Domain.Commons.Abstractions;
using MediatR;

namespace Application.Commons.Interfaces;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
