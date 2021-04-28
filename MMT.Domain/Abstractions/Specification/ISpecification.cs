using System;
using System.Linq.Expressions;

namespace MMT.Domain.Abstractions.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> SpecExpression { get; }
        bool IsSatisfiedBy(T obj);
    }
}
