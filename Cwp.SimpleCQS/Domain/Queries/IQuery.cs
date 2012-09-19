namespace CwP.SimpleCQS.Domain.Queries
{
    using System;

    public interface IQuery<in TResult>
    {
        Action<TResult> Callback { get; }
    }
}