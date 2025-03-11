# TimeInAngle API

This is an ASP.NET Core Web API project that calculates the angle between the hour and minute hands of a clock.

---

## Features
- **Calculate Clock Angle**: Given a time (e.g., `3:30`), the API calculates the sum of the hour and minute hand angles.
- **Global Exception Handling**: Middleware to handle exceptions globally.
- **Custom Configuration**: Configuration settings in `appsettings.json`.
- **Modular Structure**: Organized into controllers, services, middleware, and validators.

---

## Folder Structure
TimeInAngle/
├── Controllers/
│ └── ClockController.cs # API controller for clock angle calculations
├── Middleware/
│ └── ExceptionMiddleware.cs # Global exception handling middleware
├── Services/
│ └── ClockAngleService.cs # Service for calculating clock angles
├── Validators/
│ └── ClockAngleValidator.cs # Utility for validating time inputs
├── Properties/
│ └── launchSettings.json # Configuration for running the application
├── appsettings.json # Application settings (e.g., logging, connection strings)
├── Program.cs # Entry point and application configuration
├── TimeInAngle.csproj # Project file with dependencies and build settings
├── .gitignore # Specifies files to ignore in Git
└── README.md # Project documentation (this file)



---

## Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Git](https://git-scm.com/)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/TimeInAngle.git

