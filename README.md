# Rust-like Option & Result for C#

This repository provides **Rust-inspired optional and result types** for C#, including `Option<T>` and `Result<T, E>`.

It enables writing **safe, explicit, and functional-style code** in .NET — eliminating `null` reference exceptions and reducing reliance on exceptions for standard control flow.

---

## 🚀 Key Features

* **Zero Nulls**: Explicitly model the presence or absence of a value.
* **Explicit Error Handling**: Errors are part of the method signature, making them impossible to ignore.
* **Functional API**: Support for safe pattern matching and fluent chaining.
* **Rust-Inspired**: Familiar naming conventions for developers coming from Rust or other functional languages.

---

## 📦 1. Option<T>

`Option<T>` represents an optional value: **every `Option` is either `Some` or `None`.** It is used to explicitly model the absence of a value without using `null`.

### State Inspection
* **`IsSome`**: `true` if the option contains a value.
* **`IsNone`**: `true` if the option is empty.

### Creation
```csharp
// Creating a value
var valueOption = Option<int>.Some(42);

// Creating an empty state
var emptyOption = Option<int>.None;
```

### Usage
```csharp
var valueOption = Option<int>.Some(42);
var isSome = valueOption.IsSome; //check if is some
var isNone = valueOption.IsNone; // check if is none
var value = valueOption.UnwrapOrThrow(); // unwrap when some / panic when none
```

> [!WARNING]  
> Using `UnwrapOrThrow()` without checking if option is some will throw exception