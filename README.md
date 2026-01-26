# Egypt.NET 🇪🇬

An open-source .NET project focused on building clean, well-designed
domain libraries for **Egyptian-specific data and real-world use cases**.

The project aims to provide production-aware, beginner-friendly
domain models instead of ad-hoc or copy-paste implementations.

---

## 🎯 Project Goals

Egypt.NET exists to:

- Provide **Egypt-focused .NET libraries**
- Encourage **clean domain modeling**
- Help **beginners learn real open-source practices**
- Avoid fragile, duplicated implementations
- Grow gradually through real, well-defined use cases

---

## 📦 Current Modules

### Egypt.Net.Core

Core domain utilities for working with Egyptian national data.

Current features include:
- Egyptian National ID parsing and validation
- Birth date extraction
- Gender detection
- Governorate resolution
- Age and adulthood calculation
- Safe creation without exceptions
- Domain-specific exception hierarchy
- Fully unit tested
- No external dependencies

📖 Module documentation:
👉 [`Egypt.Net.Core/README.md`](./Egypt.Net.Core/README.md)

📦 NuGet:
```bash
dotnet add package Egypt.Net.Core
```
---

## 🧠 Philosophy

- Domain first
- Explicit validation
- Fail fast or fail safely
- No magic
- Beginner-friendly but production-aware

---

## 🧪 Testing

Each module includes:
- Dedicated test project
- Clear and readable unit tests
- Realistic test cases that reflect real usage

---

## 🤝 Contributing

Contributions are welcome, especially from beginners.

Recommended flow:
- Fork the repository
- Create a feature branch
- Write or update tests
- Submit a pull request with a clear description

---

## 🗺 Roadmap (High-Level)

- Improve National ID validation rules
- Add more safe factory APIs
- Introduce more Egyptian domain models
- Improve documentation and examples

---

## 📄 License

This project is licensed under the MIT License.
