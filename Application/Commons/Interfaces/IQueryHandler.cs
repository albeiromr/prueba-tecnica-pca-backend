using Domain.Commons.Abstractions;
using MediatR;

namespace Application.Commons.Interfaces;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> 
    where TQuery : IQuery<TResponse>
{
}
