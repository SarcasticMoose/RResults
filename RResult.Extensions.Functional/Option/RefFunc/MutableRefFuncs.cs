namespace RResult.Extensions.Functional.Option.RefFunc;

public delegate TResult MutableRefFunc<T, out TResult>(ref T value);
public delegate TResult MutableRefFunc<out TResult>();
