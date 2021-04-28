using System;

namespace MMT.Domain.Abstractions
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
