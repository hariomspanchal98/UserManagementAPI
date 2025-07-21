# User Management API

This is a simple RESTful API for managing users, built with **ASP.NET Core**. The project was developed using **GitHub Copilot** to assist with writing, debugging, and enhancing the code. It demonstrates CRUD operations, middleware integration, validation, and Swagger documentation.

## ✅ Features

- Create, Read, Update, and Delete (CRUD) operations for users
- Input validation for user data
- Custom middleware for logging request processing time
- Swagger/OpenAPI support for API documentation
- Structured using best practices with modular components

## 📁 File Structure

- `Program.cs`: Entry point and configuration
- `Startup.cs`: Service registration and middleware configuration
- `Models/User.cs`: User model with validation
- `Controllers/UsersController.cs`: API controller with CRUD endpoints
- `Middleware/RequestLoggingMiddleware.cs`: Custom middleware for logging
- `README.md`: Project documentation

## 🔧 Setup Instructions

1. Clone the repository:

```bash
git clone https://github.com/your-username/UserManagementAPI.git
cd UserManagementAPI
