# ABC-Money-Transfer
This project is created to transfer the remittance amount from other country to the nepal according to the exchange rate printed by NRB

# .NET Core 8 Application Setup

This guide will help you set up a .NET Core 8 application with authentication, Entity Framework, and SQL Server support.

## Prerequisites

1. Install [VS Code](https://code.visualstudio.com/).
2. Install [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet).

## Step 1: Install Necessary Packages

You can install the following packages using the NuGet Package Manager or terminal.

### Install Packages via Terminal

```bash
dotnet add package IdentityModel
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Newtonsoft.Json --version 13.0.3
dotnet add package Swashbuckle.AspNetCore
```

## Step 2: Setup Connection String

Add the following connection string to the `appsettings.json` file:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=YourDbName;Trusted_Connection=True;"
}
```

Replace `YourDbName` with your actual database name.

## Step 3: Clean the Solution

Clean your solution to remove old artifacts:

```bash
dotnet clean
```

## Step 4: Create and Apply Migrations

Run the following commands to create and apply the migration:

```bash
add-migration New
update-database
```

## Step 5: Rebuild and Start the Application

Rebuild your application:

```bash
dotnet build
```

Then, start the application:

```bash
dotnet run
```

Your application will now be running on the IIS server.

## Conclusion

You have successfully set up your .NET Core 8 application with authentication and Entity Framework using SQL Server.

##//ToDos
frontend assembly using reactjs or blazor
