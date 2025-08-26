# 🚀 MultiOutputLogger

**MultiOutputLogger** is a simple sample project for managing and storing logs in a SQL Server database using **Entity Framework Core**.  
It is built with **C# (.NET 9)** and intended for educational and practice purposes.

<p align="center">
  <img src="https://upload.wikimedia.org/wikipedia/commons/4/4f/Csharp_Logo.png" alt="C# Logo" width="120"/>
  <img src="https://upload.wikimedia.org/wikipedia/commons/8/87/Sql_data_base_with_logo.png" alt="SQL Server Logo" width="120"/>
  <img src="https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg" alt=".NET Logo" width="120"/>
</p>

---

## ✨ Features
- 📝 Store logs in a SQL Server database  
- 🛠️ Entity Framework Core for data management  
- 📦 Simple and extensible design  

---

## 📋 Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) *(optional)*

---

## 🚀 Getting Started

### 1️⃣ Clone the repository
```bash
git clone https://github.com/Motahare-KamraniFard/MultiOutputLogger.git
cd MultiOutputLogger
```

### 2️⃣ Configure the Connection String
The connection string is **not included** in the source code.  
You must configure it before running the project:

#### ✅ Option 1: Use an Environment Variable (recommended)
On Windows (PowerShell):
```powershell
setx LoggingDb_Connection "Server=.;Database=LoggingDB;Trusted_Connection=True;TrustServerCertificate=True;"
```

On Linux/Mac:
```bash
export LoggingDb_Connection="Server=localhost;Database=LoggingDB;User Id=USER;Password=PASS;TrustServerCertificate=True;"
```

The `LoggingDbContext` class automatically reads this environment variable.

#### ⚠️ Option 2: Manual replacement (for local testing)
Edit `LoggingDbContext.cs` in the `OnConfiguring` method and insert your connection string:
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=.;Database=LoggingDB;Trusted_Connection=True;TrustServerCertificate=True;");
```

> ⚠️ **Important:** Avoid hardcoding connection strings when publishing. Prefer environment variables.

---

### 3️⃣ Run the project
```bash
dotnet run
```

---

## 📂 Project Structure
- `Models/LoggingDbContext.cs` → EF Core DbContext for database connection  
- `Models/Log.cs` → Entity model for the logs table  
- `Program.cs` → Application entry point  

---

## 🤝 Contributing
Feel free to open issues or submit pull requests if you have suggestions for improvements.

---

## 📜 License
This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.
