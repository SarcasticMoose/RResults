# Rust-like Option & Result for C#

This repository provides **Rust-inspired optional and result types** in C#, including `Option<T>` and `Result<T, E>`.  
It allows writing **safe, functional-style code** in C# similar to Rust’s standard library.

---

## Features

### Option<T>

- Represents an optional value: **every Option is either `Some` or `None`**.
- Minimal, value-type implementation with basic creation and checks.
- Safe retrieval of the contained value via methods like `UnwrapOrPanic()`.

| Method | Description |
|--------|-------------|
| `Some(T value)` | Creates an `Option` containing a value |
| `None` | Returns an `Option` with no value |
| `IsSome()` / `IsNone()` | Checks if the option contains a value or not |
| `UnwrapOrPanic()` | Returns the contained value or throws an exception if the option is `None` |


### Important Notes on `UnwrapOrPanic()`

The `UnwrapOrPanic()` method is similar to Rust's `unwrap()`.  
It **throws an `InvalidOperationException`** if the option is `None`.

**Always check** `IsSome()` before calling `UnwrapOrPanic()`:

```csharp
var some = Option<int>.Some(42);
var none = Option<int>.None;

if (some.IsSome())
{
    int value = some.UnwrapOrPanic(); // safe, value = 42
}

// This would throw an exception:
int fail = none.UnwrapOrPanic();