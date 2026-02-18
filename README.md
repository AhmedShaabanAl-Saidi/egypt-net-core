# Egypt.NET 🇪🇬

An open-source .NET project focused on building clean, well-designed domain libraries for **Egyptian-specific data and real-world use cases**.

The project aims to provide production-aware, beginner-friendly domain models instead of ad-hoc or copy-paste implementations.

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

### Egypt.Net.Core **v1.1.0** 🆕

Core domain utilities for working with Egyptian national data.

#### Features:
- ✅ **Egyptian National ID** - parsing, validation, and data extraction
- ✅ **Birth & Age** - date extraction, age calculation, adult verification
- ✅ **Gender Detection** - with full Arabic support (ذكر/أنثى)
- ✅ **27 Governorates** - bilingual support (Arabic & English)
- ✅ **7 Geographic Regions** - Greater Cairo, Delta, Canal, Upper Egypt, Sinai & Red Sea, Western Desert, Foreign
- ✅ **6 Generations** - Silent Generation → Gen Alpha (1928-present)
- ✅ **Regional Classification** - Upper/Lower Egypt, Coastal, Born Abroad
- ✅ **Demographics** - Digital natives, working age, senior citizens
- ✅ **Multiple Formatting** - dashes, spaces, brackets, masked, detailed
- ✅ **Privacy Protection** - masked format for logging
- ✅ **Developer Experience** - IEquatable, IComparable, LINQ-friendly, string extensions
- ✅ **Zero Dependencies** - pure .NET implementation
- ✅ **200+ Unit Tests** - comprehensive coverage

📖 **Module Documentation:**  
👉 [`Egypt.Net.Core/README.md`](./Egypt.Net.Core/README.md)

📦 **NuGet Package:**
```bash
dotnet add package Egypt.Net.Core
```

---

## 🚀 Quick Example

```csharp
using Egypt.Net.Core;

var id = new EgyptianNationalId("30101010123458");

// Basic Info
Console.WriteLine(id.BirthDate);           // 2001-01-01
Console.WriteLine(id.Age);                 // 24
Console.WriteLine(id.Gender);              // Male
Console.WriteLine(id.GenderAr);            // ذكر

// Location
Console.WriteLine(id.GovernorateNameAr);   // القاهرة
Console.WriteLine(id.BirthRegionNameAr);   // القاهرة الكبرى
Console.WriteLine(id.IsFromUpperEgypt);    // false
Console.WriteLine(id.IsFromCoastalRegion); // false

// Demographics
Console.WriteLine(id.GenerationAr);        // جيل زد
Console.WriteLine(id.AgeGroupAr);          // شباب
Console.WriteLine(id.IsDigitalNative);     // true

// Formatting
Console.WriteLine(id.FormatWithDashes());  // 3-010101-01-23458
Console.WriteLine(id.FormatMasked());      // 301********58

// String Extensions
if ("30101010123458".IsValidEgyptianNationalId())
{
    var nationalId = "30101010123458".ToEgyptianNationalId();
    Console.WriteLine($"{nationalId?.GovernorateNameAr} - {nationalId?.Age} سنة");
}
```

---

## 🧠 Philosophy

- **Domain First** - Rich domain models over anemic data structures
- **Explicit Validation** - Clear error messages and validation rules
- **Fail Fast or Fail Safely** - TryCreate() for safe parsing, exceptions for invalid state
- **No Magic** - Transparent, readable code
- **Beginner-Friendly** - Clear examples and documentation
- **Production-Aware** - Battle-tested with 200+ unit tests
- **Bilingual Support** - Arabic & English throughout
- **Clean, Immutable Objects** - Thread-safe and predictable

---

## 🧪 Testing

Each module includes:
- Dedicated test project with xUnit
- Clear and readable unit tests
- Realistic test cases that reflect real-world usage
- Comprehensive edge case coverage
- **200+ tests** in Egypt.Net.Core

```bash
dotnet test
```

---

## 🤝 Contributing

Contributions are welcome, especially from beginners!

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for detailed guidelines.

### Recommended Flow:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Write or update tests
4. Ensure all tests pass (`dotnet test`)
5. Commit your changes (`git commit -m 'Add amazing feature'`)
6. Push to the branch (`git push origin feature/amazing-feature`)
7. Open a Pull Request with a clear description

---

## 🗺 Roadmap

### v1.1.0 - Geographic & Demographics ✅ (Current)
- ✅ Geographic region classification
- ✅ Generation classification (6 generations)
- ✅ Age group classification (7 age groups)
- ✅ Regional analytics support
- ✅ Digital native detection

### v1.0.1 - Hotfix ✅
- ✅ Disabled checksum validation by default

### v1.0.0 - Initial Release ✅
- ✅ Egyptian National ID validation & parsing
- ✅ Birth date & age extraction
- ✅ Gender detection
- ✅ 27 Governorates support
- ✅ Arabic language support
- ✅ Multiple formatting options

### v1.2.0 - Integration & Serialization 🔜
- 🔜 JSON serialization support (System.Text.Json)
- 🔜 ASP.NET Core model binding
- 🔜 FluentValidation integration
- 🔜 Swagger/OpenAPI support

### v1.3.0 - Performance & Extensions 🔜
- 🔜 Performance optimizations with `Span<T>`
- 🔜 Benchmark suite
- 🔜 Additional validation rules

### Future Modules 🔮
- 🔮 Egypt.Net.Phone - Egyptian phone number validation
- 🔮 Egypt.Net.Postal - Postal codes and addresses
- 🔮 Egypt.Net.Banking - Egyptian bank account validation
- 🔮 Egypt.Net.TaxId - Tax ID validation

---

## 📊 Project Statistics

| Metric | Value |
|--------|-------|
| **Modules** | 1 |
| **Version** | v1.1.0 |
| **Total Properties** | 40+ |
| **Enums** | 5 |
| **Extension Methods** | 20+ |
| **Unit Tests** | 200+ |
| **Test Coverage** | 100% |
| **Dependencies** | 0 |
| **Supported .NET** | .NET 8.0+ |

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 🌟 Show Your Support

If you find this project helpful:
- ⭐ Star the repository
- 🐛 Report bugs or request features via [Issues](https://github.com/abdulrahmanhossam/Egypt-Net-Core/issues)
- 🤝 Contribute via Pull Requests
- 📢 Share with the Egyptian developer community

---

## 📞 Contact & Community

- 💻 **GitHub**: [abdulrahmanhossam/Egypt-Net-Core](https://github.com/abdulrahmanhossam/Egypt-Net-Core)
- 📦 **NuGet**: [Egypt.Net.Core](https://www.nuget.org/packages/Egypt.Net.Core/)
- 📧 **Issues**: [GitHub Issues](https://github.com/abdulrahmanhossam/Egypt-Net-Core/issues)

---

Made with ❤️ for the Egyptian developer community 🇪🇬