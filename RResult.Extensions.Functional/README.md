# RResult Option Extensions

This library provides extension methods for working with `Option<T>` from the [`RResults`](https://www.nuget.org/packages/RResults/) package, allowing for more expressive and convenient handling of optional values.

## Installation

Install the package via NuGet (if published) or include the extension class in your project:

```bash
dotnet add package RResults.Options.Extensions
```

Include the extensions namespace in your code:

```csharp
using RResult.Options.Extensions;
```

## Extension Methods

### `IsSomeAnd`

```csharp
public static bool IsSomeAnd<T>(this Option<T> opt, Func<T, bool> predicate)
```

* **Description:** Returns `true` if the `Option` contains a value (`Some`) **and** the value satisfies the given predicate.
* **Parameters:**

    * `opt`: The `Option<T>` to evaluate.
    * `predicate`: A function that takes the contained value and returns a boolean.
* **Example:**

```csharp
Option<int> opt = Option.Some(5);
bool result = opt.IsSomeAnd(x => x > 3); // true
```

---

### `IsNoneOr`

```csharp
public static bool IsNoneOr<T>(this Option<T> opt, Func<T, bool> predicate)
```

* **Description:** Returns `true` if the `Option` is `None` **or** the contained value satisfies the predicate.
* **Parameters:**

    * `opt`: The `Option<T>` to evaluate.
    * `predicate`: A function that takes the contained value and returns a boolean.
* **Example:**

```csharp
Option<int> opt = Option.None<int>();
bool result = opt.IsNoneOr(x => x > 3); // true (because it's None)
```

---

### `IsSomeOr`

```csharp
public static bool IsSomeOr<T>(this Option<T> opt, Func<T, bool> predicate)
```

* **Description:** Returns `true` if the `Option` is `Some` **or** the contained value satisfies the predicate.

* **Parameters:**

    * `opt`: The `Option<T>` to evaluate.
    * `predicate`: A function that takes the contained value and returns a boolean.
* **Example:**

```csharp
Option<int> opt = Option<int>.Some(-10);
Console.WriteLine(opt.IsSomeOr(x => x > 20)); //true
```

---

## Option Unwrap Extensions

### `UnwrapOr`

```csharp
public static T UnwrapOr<T>(this Option<T> opt, T value)
```

- **Description:** Returns the inner value if the option is `Some`; otherwise returns the provided fallback value.
- **Example:**

```csharp
Option<int> opt = Option.None<int>();
int result = opt.UnwrapOr(10); // 10
```

---

### `UnwrapOrElse`

```csharp
public static T UnwrapOrElse<T>(this Option<T> opt, Func<T> fallback)
```

- **Description:** Returns the inner value if the option is `Some`; otherwise executes the provided function and returns its result.
- **Example:**

```csharp
Option<string> opt = Option.None<string>();
string result = opt.UnwrapOrElse(() => "computed"); // "computed"
```

---

### `UnwrapOrDefault`

```csharp
public static T UnwrapOrDefault<T>(this Option<T> opt)
    where T : struct
```

- **Description:**  
  Returns the contained value when the option is `Some`.  
  If the option is `None`, it returns `default(T)`.  
  Since this overload is restricted to value types (`struct`), `default(T)` is guaranteed to be non-null.

- **Example:**

```csharp
Option<int> some = Option.Some(42);
Option<int> none = Option.None<int>();

int a = some.UnwrapOrDefault(); // 42
int b = none.UnwrapOrDefault(); // 0  (default(int))
```
---

## Additional Option Extensions

### `AsSlice`

```csharp
public static ReadOnlySpan<T> AsSlice<T>(this Option<T> opt)
```

- **Description:** Returns a `ReadOnlySpan<T>` containing the inner value if the option is `Some`; otherwise returns an empty span.
- **Example:**

```csharp
Option<int> opt = Option.Some(42);
ReadOnlySpan<int> span = opt.AsSlice(); // span[0] == 42
```

---

### `Expect`

```csharp
public static T Expect<T>(this Option<T> opt, string message)
```

- **Description:** Returns the inner value if the option is `Some`; otherwise throws `InvalidOperationException` with the provided message.
- **Example:**

```csharp
Option<string> opt = Option.Some("hello");
string value = opt.Expect("should never fail");
```
