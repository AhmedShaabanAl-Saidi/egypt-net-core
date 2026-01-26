# Egypt.Net.Core 🇪🇬

Core domain utilities for working with Egyptian national data in .NET.

This library provides clean, immutable, and well-tested domain models
for common Egyptian data concepts, starting with the **Egyptian National ID**.

---

## Why this library exists

Most .NET examples focus on global or Western data models.
Egyptian developers often reimplement the same logic
(such as parsing the national ID) in ad-hoc and error-prone ways.

This library exists to:
- Provide a clean and reusable core domain model
- Encourage correct validation and domain boundaries
- Serve as an educational reference for beginners
- Grow gradually through real Egyptian use cases

---

## Features

- Parse and validate Egyptian National ID
- Extract birth date
- Determine gender
- Resolve governorate
- Calculate age and adulthood
- Clean and immutable domain model
- Domain-specific exception hierarchy
- Safe creation via `TryCreate`
- Quick validation via `IsValid`
- No external dependencies
- Fully unit tested

---

## Installation

Available on NuGet:

```bash
dotnet add package Egypt.Net.Core
```

## Usage

```csharp
using Egypt.Net.Core;

var nationalId = new EgyptianNationalId("30101010123456");

Console.WriteLine(nationalId.BirthDate);    // 2001-01-01
Console.WriteLine(nationalId.Gender);       // Male
Console.WriteLine(nationalId.Governorate);  // Cairo
Console.WriteLine(nationalId.IsAdult);      // true
```

## Safe Creation (Recommended)
```csharp
using Egypt.Net.Core;

if (EgyptianNationalId.TryCreate("30101010123456", out var nationalId))
{
    Console.WriteLine(nationalId!.Gender);
}
else
{
    Console.WriteLine("Invalid National ID");
}
```

## Quick Validation
```csharp
bool isValid = EgyptianNationalId.IsValid("30101010123456");
```

## Versioning

This library follows semantic versioning:

- `0.x.x` → Public API may change
- `1.0.0` → Stable API


## Project Status

This project is under active development.
New features will be added gradually with a strong focus on correctness and clarity.


## License

This project is licensed under the MIT License.

