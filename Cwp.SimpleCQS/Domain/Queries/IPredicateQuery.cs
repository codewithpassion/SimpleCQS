namespace CwP.SimpleCQS.Domain.Queries
{
    using System;

    public interface IPredicateQuery<T>
    {
        Predicate<T> Predicate { get; }
    }
}