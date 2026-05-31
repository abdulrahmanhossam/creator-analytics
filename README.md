# Creator Analytics Dashboard 📊

A robust, backend-first analytics ingestion and reporting engine designed for content creators. This system ingests video metrics, processes time-series data, and exposes RESTful endpoints for real-time dashboard visualization.

Built with a strict adherence to **Clean Architecture**, the domain logic is completely isolated, making the system highly testable and easy to navigate via standard terminal tools and lightweight editors.

## 🛠 Tech Stack

* **Framework:** .NET 10 / C# 13
* **Web:** ASP.NET Core Web API
* **Data Access:** Entity Framework Core (EF Core)
* **Database:** SQL Server
* **Architecture:** Clean Architecture (Core, Infrastructure, API layers)

## 🏗 Architecture Overview

The solution is divided into three distinct projects to enforce separation of concerns:

1. **`CreatorAnalytics.Core`**: The heart of the system. Contains POCO domain entities (Creator, Channel, Video, VideoAnalytic) and repository interfaces. **Zero external dependencies.**
2. **`CreatorAnalytics.Infrastructure`**: Contains the `ApplicationDbContext`, EF Core Fluent API configurations, and SQL Server implementations of the core interfaces.
3. **`CreatorAnalytics.API`**: The presentation layer. Contains RESTful controllers, Data Transfer Objects (DTOs), and dependency injection wiring.

## 🚀 Getting Started

The project is designed to be easily managed via the `dotnet` CLI. 

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download)
* SQL Server (or a Dockerized SQL Server instance)

### Setup & Run

1. **Clone the repository:**
```bash
   git clone [https://github.com/yourusername/creator-analytics-backend.git](https://github.com/yourusername/creator-analytics-backend.git)
   cd creator-analytics-backend
   ```

2. **Update the Database Connection:**
   Navigate to `src/CreatorAnalytics.API/appsettings.Development.json` and update your `"DefaultConnection"` string to point to your local SQL Server.

3. **Run EF Core Migrations:**
   Apply the database schema from the terminal:
```bash
   dotnet ef database update --project src/CreatorAnalytics.Infrastructure --startup-project src/CreatorAnalytics.API
   ```

4. **Build and Run the API:**
```bash
   dotnet run --project src/CreatorAnalytics.API
   ```

The API will now be listening on `http://localhost:5000` (or the port specified in your launch settings). You can test the endpoints using standard CLI tools like `curl`, or visually via Swagger UI at `/swagger`.

## 📈 Core Domain Entities

* **Creator:** The authenticated user managing the system.
* **Channel:** The specific platform channels (e.g., Main, VODs) owned by the Creator.
* **Video:** The content pieces tied to a Channel.
* **VideoAnalytic:** Time-series snapshot data (Views, Likes, Comments, Retention) tracked over time to calculate growth trajectories.

## 📜 License

Distributed under the MIT License. See `LICENSE` for more information.