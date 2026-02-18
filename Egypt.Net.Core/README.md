# Egypt.Net.Core 🇪🇬

Core domain utilities for working with Egyptian national data in .NET.

This library provides clean, immutable, and well-tested domain models for common Egyptian data concepts, starting with the **Egyptian National ID**.

---

## 🎯 Why This Library Exists

Egyptian developers often reimplement National ID validation logic in ad-hoc and error-prone ways. This library provides:
- ✅ Clean, reusable domain model
- ✅ Correct validation and domain boundaries
- ✅ Educational reference for beginners
- ✅ Production-ready code

---

## 📦 Installation

```bash
dotnet add package Egypt.Net.Core
```

**Latest Version:** v1.1.0

---

## ⚡ Quick Start

```csharp
using Egypt.Net.Core;

var id = new EgyptianNationalId("30101010123458");

Console.WriteLine(id.BirthDate);           // 2001-01-01
Console.WriteLine(id.Age);                 // 24
Console.WriteLine(id.Gender);              // Male
Console.WriteLine(id.GovernorateNameAr);   // القاهرة
Console.WriteLine(id.BirthRegionNameAr);   // القاهرة الكبرى
Console.WriteLine(id.GenerationAr);        // جيل زد
Console.WriteLine(id.IsAdult);             // true
```

---

## ✨ Features

### 🔍 Validation & Parsing
- Parse and validate Egyptian National IDs
- Safe creation with `TryCreate()` (no exceptions)
- Quick validation with `IsValid()`
- Optional checksum validation (disabled by default)

### 📊 Data Extraction
- **Birth & Age:** Date, year, month, day, current age
- **Demographics:** Gender, generation, age group
- **Geography:** Governorate (27), region (7)
- **Metadata:** Serial number, formatting

### 🌍 Geographic Classification
- **7 Major Regions:** Greater Cairo, Delta, Canal, Upper Egypt, Sinai & Red Sea, Western Desert, Foreign
- **Regional Checks:** Upper/Lower Egypt, Coastal, Born Abroad

### 👥 Demographic Classification
- **6 Generations:** Silent Generation → Gen Alpha (1928-present)
- **Digital Native Detection:** Millennials, Gen Z, Gen Alpha

### 🎨 Formatting & Privacy
- 5 formatting styles: dashes, spaces, brackets, masked, detailed
- Privacy protection with masked format (301\*\*\*\*\*\*\*\*58)

### 🔧 Developer Experience
- Full Arabic & English support
- String extension methods for fluent API
- IEquatable & IComparable support
- LINQ-friendly
- Zero dependencies
- 200+ unit tests

---

## 📚 Documentation

### Basic Usage

```csharp
// Simple creation
var id = new EgyptianNationalId("30101010123458");

// Safe creation (recommended)
if (EgyptianNationalId.TryCreate("30101010123458", out var nationalId))
{
    Console.WriteLine($"{nationalId!.GovernorateNameAr} - {nationalId.Age} سنة");
}

// String extensions
if ("30101010123458".IsValidEgyptianNationalId())
{
    var id = "30101010123458".ToEgyptianNationalId();
}
```

---

### All Available Properties

```csharp
var id = new EgyptianNationalId("30101010123458");

// 📅 Birth & Age (6 properties)
id.BirthDate              // 2001-01-01
id.BirthYear              // 2001
id.BirthMonth             // 1
id.BirthDay               // 1
id.Age                    // 24
id.IsAdult                // true (>= 18)

// 📍 Location (12 properties)
id.Governorate            // Cairo (enum)
id.GovernorateCode        // 01
id.GovernorateNameAr      // القاهرة
id.GovernorateNameEn      // Cairo
id.BirthRegion            // GreaterCairo (enum)
id.BirthRegionNameAr      // القاهرة الكبرى
id.BirthRegionNameEn      // GreaterCairo
id.IsFromUpperEgypt       // false
id.IsFromLowerEgypt       // true
id.IsFromGreaterCairo     // true
id.IsFromDelta            // false
id.IsFromCoastalRegion    // false
id.IsBornAbroad           // false

// 👥 Demographics (12 properties)
id.Gender                 // Male (enum)
id.GenderAr               // ذكر
id.Generation             // GenerationZ (enum)
id.GenerationAr           // جيل زد
id.GenerationEn           // GenerationZ
id.IsDigitalNative        // true

// 📄 Metadata (2 properties)
id.SerialNumber           // 2345
id.Value                  // "30101010123458"
```

---

### Geographic Regions

Egypt is divided into **7 geographic regions**:

```csharp
id.BirthRegion            // Region enum
id.BirthRegionNameAr      // القاهرة الكبرى
id.BirthRegionNameEn      // GreaterCairo

// Regional checks
id.IsFromUpperEgypt       // الصعيد
id.IsFromLowerEgypt       // الوجه البحري
id.IsFromGreaterCairo     // القاهرة الكبرى
id.IsFromDelta            // الدلتا
id.IsFromCoastalRegion    // ساحلي (بحر متوسط/أحمر)
id.IsBornAbroad           // خارج الجمهورية
```

**The 7 Regions:**
1. **Greater Cairo** (القاهرة الكبرى): Cairo, Giza, Qalyubia
2. **Delta** (الدلتا): Alexandria, Dakahlia, Sharqia, Gharbia, Kafr El-Sheikh, Monufia, Beheira, Damietta
3. **Canal** (قناة السويس): Port Said, Suez, Ismailia
4. **Upper Egypt** (الصعيد): Beni Suef, Fayoum, Minya, Asyut, Sohag, Qena, Aswan, Luxor
5. **Sinai & Red Sea** (سيناء والبحر الأحمر): Red Sea, North Sinai, South Sinai
6. **Western Desert** (الصحراء الغربية): Matrouh, New Valley
7. **Foreign** (خارج الجمهورية): Born outside Egypt

---

### Generation Classification

Automatically determines the generation based on birth year:

```csharp
id.Generation             // Enum: SilentGeneration → GenerationAlpha
id.GenerationAr           // الجيل الصامت → جيل ألفا
id.GenerationEn           // SilentGeneration → GenerationAlpha
id.IsDigitalNative        // Millennials, Gen Z, Gen Alpha = true
```

**The 6 Generations:**
- **Silent Generation** (1928-1945) - الجيل الصامت
- **Baby Boomers** (1946-1964) - جيل الطفرة
- **Generation X** (1965-1980) - الجيل إكس
- **Millennials** (1981-1996) - جيل الألفية
- **Generation Z** (1997-2012) - جيل زد
- **Generation Alpha** (2013+) - جيل ألفا

---

### Formatting Options

```csharp
var id = new EgyptianNationalId("30101010123458");

id.FormatWithDashes()     // 3-010101-01-23458
id.FormatWithSpaces()     // 3 010101 01 23458
id.FormatWithBrackets()   // [3][010101][01][23458]
id.FormatMasked()         // 301********58 (privacy!)
id.FormatDetailed()       // Multi-line format with all details
```

---

### Checksum Validation

⚠️ **Disabled by default** - The official algorithm is not publicly documented.

```csharp
// Default - no checksum validation
var id = new EgyptianNationalId("30101010123458");  // ✅

// Enable checksum (if you have the verified algorithm)
var id = new EgyptianNationalId("30101010123458", validateChecksum: true);

// Check only
bool hasValidChecksum = EgyptianNationalId.ValidateChecksum("30101010123458");
```

**What IS validated by default:**
✅ Format (14 digits)  
✅ Birth date validity  
✅ Governorate code (01-88)  
✅ Century digit (2 or 3)  
✅ All structural rules

---

### String Extensions

```csharp
string input = "30101010123458";

// Validation
input.IsValidEgyptianNationalId()     // true/false
input.HasValidNationalIdFormat()      // format only
input.HasValidNationalIdChecksum()    // checksum only

// Parsing
var id = input.ToEgyptianNationalId();
if (input.TryParseAsNationalId(out var nationalId))
{
    // Use nationalId
}
```

---

### Collections & LINQ

```csharp
var id1 = new EgyptianNationalId("30101010123458");
var id2 = new EgyptianNationalId("30101010123458");
var id3 = new EgyptianNationalId("29001010123452");

// Equality
id1 == id2                // true
id1.Equals(id2)           // true

// Comparison (by birth date)
id3 < id1                 // true (1990 < 2001)

// Collections
var unique = new HashSet<EgyptianNationalId> { id1, id2, id3 };
// Count = 2 (id1 and id2 are equal)

// LINQ Examples
var adults = ids.Where(id => id.IsAdult);
var fromCairo = ids.Where(id => id.Governorate == Governorate.Cairo);
var millennials = ids.Where(id => id.Generation == Generation.Millennials);
var workingAge = ids.Where(id => id.IsWorkingAge);
var fromUpperEgypt = ids.Where(id => id.IsFromUpperEgypt);
```

---

### Exception Handling

```csharp
try
{
    var id = new EgyptianNationalId("invalid");
}
catch (InvalidNationalIdFormatException)
{
    // Format error: not 14 digits, contains letters, etc.
}
catch (InvalidBirthDateException)
{
    // Invalid date: Feb 30, etc.
}
catch (InvalidGovernorateCodeException)
{
    // Unknown governorate code
}
catch (InvalidChecksumException)
{
    // Checksum validation failed (if enabled)
}
catch (EgyptianNationalIdException)
{
    // Base exception - catches all
}
```

---

## 🎯 Use Cases

### Age Verification System
```csharp
var id = userInput.ToEgyptianNationalId();
if (id == null)
    return "Invalid National ID";

if (!id.IsAdult)
    return $"Must be 18+. Your age: {id.Age}";

return "Access granted";
```

### Regional Demographics Dashboard
```csharp
var users = GetUsers();

// By Region
var byRegion = users
    .GroupBy(u => u.NationalId.BirthRegion)
    .Select(g => new { 
        Region = g.Key.GetArabicName(), 
        Count = g.Count() 
    });

// By Generation
var byGeneration = users
    .GroupBy(u => u.NationalId.Generation)
    .Select(g => new { 
        Generation = g.Key.GetArabicName(), 
        Count = g.Count() 
    });

// Digital Natives
var digitalNatives = users.Count(u => u.NationalId.IsDigitalNative);
```

### Targeted Marketing by Demographics
```csharp
// Target Gen Z from coastal cities
var targetAudience = customers
    .Where(c => c.NationalId.Generation == Generation.GenerationZ)
    .Where(c => c.NationalId.IsFromCoastalRegion);

// Target working-age adults from Upper Egypt
var ruralWorkforce = employees
    .Where(e => e.NationalId.IsWorkingAge)
    .Where(e => e.NationalId.IsFromUpperEgypt);
```

### Privacy-Protected Logging
```csharp
// ❌ Bad - privacy violation
logger.Log($"User {id.Value} logged in");

// ✅ Good - masked format
logger.Log($"User {id.FormatMasked()} logged in");
// Output: User 301********58 logged in
```

---

## 📊 Testing

- **200+ Unit Tests** with comprehensive coverage
- All edge cases tested (leap years, boundaries, generations, etc.)
- 100% pass rate
- Production-ready quality

```bash
dotnet test
```

---

## 🗺️ Version History

### v1.1.0 - Geographic & Demographics Enhancement ✅
- ✅ Geographic region classification (7 regions)
- ✅ Generation classification (6 generations)
- ✅ Age group classification (7 age groups)
- ✅ Regional checks (Upper/Lower Egypt, Coastal)
- ✅ Digital native detection
- ✅ 100+ new tests

### v1.0.1 - Hotfix ✅
- ✅ Disabled checksum validation by default

### v1.0.0 - Initial Release ✅
- ✅ National ID validation & parsing
- ✅ Birth date & age extraction
- ✅ Gender detection
- ✅ 27 Governorates support
- ✅ Arabic language support
- ✅ Multiple formatting options
- ✅ Equality & comparison

---

## 🔜 Future Enhancements

- JSON serialization support
- ASP.NET Core model binding
- FluentValidation integration
- Performance optimizations with Span<T>

---

## 🤝 Contributing

Contributions are welcome! See [CONTRIBUTING.md](../CONTRIBUTING.md) for guidelines.

---

## 📄 License

MIT License - Made with ❤️ for Egyptian developers

---

## 🔗 Links

- 📦 [NuGet Package](https://www.nuget.org/packages/Egypt.Net.Core/)
- 💻 [GitHub Repository](https://github.com/abdulrahmanhossam/Egypt-Net-Core)