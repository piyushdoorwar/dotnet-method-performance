
Here’s a brief README.md for your project:

---

# Measuring Method Performance in C# Web API

This project demonstrates how to measure the performance of API endpoints in a .NET 8 Web API using two different approaches:
1. **Manual measurement** using `Stopwatch`.
2. **Automated method measurement** using the **MethodTimer.Fody** library.

## Project Overview

### Endpoints:
- `GET /WeatherForecast/simple`: 
  Measures the performance manually using `Stopwatch` and logs the elapsed time to the console.
  
- `GET /WeatherForecast/fody`: 
  Uses the **MethodTimer.Fody** library to automatically log the performance time to the debug window.

Both endpoints simulate a long-running operation and return a weather forecast for the next 5 days.

### Key Concepts:
- **Stopwatch**: Manually starts and stops to measure elapsed time.
- **MethodTimer.Fody**: Automatically tracks and logs the execution time of any decorated method (marked with `[Time]` attribute).

## Running the Project

### Prerequisites:
- .NET 8 SDK
- Visual Studio or any preferred C# IDE

### Steps:
1. Clone or download the project.
2. Restore the NuGet packages: 
   ```bash
   dotnet restore
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

### Swagger UI:
Once the project is running, Swagger will be available at: 
```
http://localhost:<port>/swagger
```
This UI allows you to test the API endpoints easily.

### Measuring Performance:

1. **For `/WeatherForecast/simple`**:
   - Call the endpoint via Swagger or directly using a tool like Postman.
   - Observe the performance logs in the **console window**. The elapsed time in milliseconds will be printed using `Stopwatch`.

2. **For `/WeatherForecast/fody`**:
   - Call the endpoint via Swagger or Postman.
   - Check the **debug window** (Output window in Visual Studio) for the performance logs, which are automatically logged by the MethodTimer.Fody library.

---
