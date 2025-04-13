# CRM Solution

A modern Customer Relationship Management (CRM) system built with .NET 8, following Clean Architecture and Domain-Driven Design principles.

## 🏗️ Architecture

This solution follows Clean Architecture principles with a domain-centric approach:

```plaintext
src/
├── Core/
│   ├── CRM.Domain/        # Business entities and logic
│   ├── CRM.Application/   # Use cases and interfaces
│   └── CRM.SharedKernel/  # Shared components and base classes
├── Infrastructure/        # External concerns and implementations
└── Presentation/         # User interface and API layer
```

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- Your preferred IDE (Visual Studio 2022, VS Code, or JetBrains Rider)
- Postgres

### Installation

1. Clone the repository
```bash
git clone https://github.com/your-username/crm-solution.git
```

2. Navigate to the solution directory
```bash
cd crm-solution
```

3. Restore dependencies
```bash
dotnet restore
```

4. Build the solution
```bash
dotnet build
```

5. Run the tests
```bash
dotnet test
```

## 🧪 Testing

The solution includes both unit tests and integration tests:

```plaintext
tests/
├── CRM.UnitTests/        # Unit tests for core business logic
└── CRM.IntegrationTest/  # Integration tests for infrastructure
```

To run specific test categories:
```bash
dotnet test --filter "Category=Unit"
dotnet test --filter "Category=Integration"
```

## 🏛️ Project Structure

### Core Layer

- **CRM.Domain**: Contains business entities, value objects, and domain logic
- **CRM.Application**: Houses use cases, interfaces, and application services
- **CRM.SharedKernel**: Provides common base classes and shared components

### Infrastructure Layer

- Database access
- External service integrations
- Implementation of interfaces defined in the Application layer

### Presentation Layer

- API Controllers
- Middleware
- Request/Response models

## 🛠️ Technologies & Tools

- **.NET 8.0**: Core framework
- **xUnit**: Testing framework
- **Entity Framework Core**: Data access
- **Clean Architecture**: Architectural pattern
- **Domain-Driven Design**: Design approach

## 🔄 Development Workflow

1. Create a new feature branch from `main`
2. Implement changes following the existing architecture
3. Write/update tests
4. Create a pull request
5. Await code review and CI checks
6. Merge after approval

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 Coding Standards

- Follow C# coding conventions
- Use meaningful names for classes, methods, and variables
- Write unit tests for new features
- Keep methods small and focused
- Document public APIs

## 🏃‍♂️ Running the Application

### Development Environment
```bash
dotnet run --project src/Presentation/CRM.API
```

### Docker Support
```bash
docker-compose up -d
```

## 🔒 Security

- Follow security best practices
- Keep dependencies updated
- Use secure communication protocols
- Implement proper authentication and authorization

## 📄 License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## 📞 Support

For support, please:
1. Check existing issues
2. Create a new issue with detailed information
3. Contact me

---
