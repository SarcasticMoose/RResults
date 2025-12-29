namespace RResult.Extensions.Functional.Option.RefFunc;

public delegate TResult ImmutableRefFunc<T, out TResult>(in T arg);
public delegate TResult ImmutableRefFunc<out TResult>();
