# Egypt.NET Core

Core domain utilities for working with Egyptian national data in .NET.

This project aims to provide clean, well-designed, and beginner-friendly
domain models for common Egyptian data concepts, starting with the Egyptian
National ID.

---

## Why this project exists

Most examples and libraries in the .NET ecosystem focus on global or Western
data models. Egyptian developers often reimplement the same logic (such as
parsing the national ID) in ad-hoc, error-prone ways.

This project exists to:
- Provide a clean and reusable core library
- Encourage correct domain modeling
- Serve as an educational reference for beginners
- Grow gradually through real use cases

---

## Features

- Parse and validate Egyptian National ID
- Extract birth date
- Determine gender
- Clean and immutable domain model
- No external dependencies

---

## Non-Goals

This project does **not** aim to:
- Be a full identity system
- Handle UI, databases, or APIs
- Replace official government validation
- Solve all Egyptian data problems at once

---

## Installation

> Package not published yet.

Once published, it will be available via NuGet:

```bash
dotnet add package Egypt.Net.Core
