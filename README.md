# 🌤️ Weather App - gRPC Auth API Examples 

This repository showcases multiple gRPC-based Weather APIs, each secured with different authentication mechanisms, built using the simple Layered Architecture approach.

---

## 🛠️ Technologies Used

- **.NET 9.0** - Latest .NET framework
- **gRPC** (v2.71.0) - High-performance RPC framework
- **Grpc.AspNetCore** - ASP.NET Core integration for gRPC
- **Grpc.AspNetCore.Server.Reflection** - Reflection-based service discovery
- **Protocol Buffers** - Data serialization format
- **ASP.NET Core** - Web framework

---

## 🔐 Authentication Styles Implemented

### 1. `WeatherApp.GrpcApi.ApiKeyAuth`
Uses API Key authentication via gRPC metadata headers.
- **Authentication**: Custom middleware-based API Key validation
- **Metadata Key**: API key passed in gRPC call metadata
- **Configuration**: API keys stored in `appsettings.json`
- **Middleware**: `ApiKeyAuthMiddleware` validates API keys from metadata
- **Features**: 
  - Exception handling middleware
  - gRPC reflection service for tooling support (Postman, etc.)

### 2. `WeatherApp.GrpcApi.JwtAuth`
Secured with JSON Web Tokens (JWT).
- **Authentication**: JWT Bearer token validation via middleware
- **Token Generation**: REST endpoint `/api/auth/login` for token generation
- **Configuration**: JWT settings and user credentials in `appsettings.json`
- **Features**:
  - JWT service for token generation
  - Custom JWT validation middleware
  - REST controller for authentication
  - Exception handling middleware

### 3. `WeatherApp.GrpcApi.MtlsAuth`
Implements Mutual TLS (mTLS) for two-way certificate validation.
- **Authentication**: Client certificate validation
- **Configuration**: Server and client certificates configured in `appsettings.json`
- **Features**:
  - Kestrel HTTPS configuration with client certificate requirement
  - Custom certificate validation logic
  - Exception handling middleware
  - Two-way SSL/TLS authentication

Each project is self-contained and can be built, run, and tested independently.

---

## ▶️ Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022, VS Code, or Rider (optional)
- gRPC client tools (optional, for testing)
- For MtlsAuth: SSL certificates (server and client)

### 🔁 Clone the Repository

```bash
git clone https://github.com/vishwamkumar/weather-app.auth-grpc-apis.layered.git
cd weather-app.auth-grpc-apis.layered/src
```

### ▶️ Run Any Project

```bash
cd WeatherApp.GrpcApi.ApiKeyAuth
dotnet run
```

Replace `ApiKeyAuth` with `JwtAuth` or `MtlsAuth` to test the other options.

**Default Ports:**
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`

---

## 🧪 Testing gRPC Services

### Using gRPC Tools

gRPC services can be tested using:
- **Postman** - Supports gRPC with reflection
- **gRPCurl** - Command-line gRPC client
- **BloomRPC** - Desktop gRPC client
- **.NET gRPC Client** - Custom client application

### gRPC Reflection

All projects include gRPC reflection service, which allows tools like Postman to discover services automatically:

```csharp
builder.Services.AddGrpcReflection();
app.MapGrpcReflectionService();
```

### Test Documentation

Each project includes a `Docs/TestMe.md` file with:
- Example gRPC call configurations
- Metadata/header setup instructions
- Sample requests and responses
- Authentication requirements

---

## 📂 Project Structure

```
grpc-apis.auth-styles.examples/
├── src/
│   ├── WeatherApp.GrpcApi.ApiKeyAuth/
│   │   ├── Protos/           # Protocol buffer definitions (.proto files)
│   │   ├── Services/          # gRPC service implementations
│   │   ├── Configs/           # API Key configuration
│   │   ├── Middlewares/       # Authentication and exception middleware
│   │   ├── Docs/              # Test documentation
│   │   └── Program.cs         # Application entry point
│   │
│   ├── WeatherApp.GrpcApi.JwtAuth/
│   │   ├── Protos/            # Protocol buffer definitions
│   │   ├── Services/          # gRPC and JWT services
│   │   ├── Controllers/       # REST auth controller
│   │   ├── Configs/           # JWT and user credential settings
│   │   ├── Middlewares/       # JWT authentication middleware
│   │   ├── Attributes/        # Custom attributes (AllowAnonymous)
│   │   ├── Dtos/              # Data transfer objects
│   │   └── Program.cs
│   │
│   └── WeatherApp.GrpcApi.MtlsAuth/
│       ├── Protos/            # Protocol buffer definitions
│       ├── Services/          # gRPC service implementations
│       ├── Middlewares/       # Exception handling middleware
│       ├── App_Data/          # Certificate storage
│       ├── Docs/              # Test documentation
│       └── Program.cs         # Kestrel HTTPS configuration
```

---

## 🛡️ Auth Mechanisms Compared

| Project   | Security Mechanism | AuthN / AuthZ           | Provider | Metadata/Header Location        |
| --------- | ------------------ | ----------------------- | -------- | ------------------------------- |
| ApiKeyAuth| API Key            | Metadata-based static key| Custom   | gRPC metadata: `x-api-key`      |
| JwtAuth   | JWT                | Token-based             | Custom   | gRPC metadata: `authorization`  |
| MtlsAuth  | mTLS               | Certificate-based       | Custom   | TLS client certificate          |

---

## ⚙️ Configuration

### ApiKeyAuth
Configure API keys in `appsettings.json`:
```json
{
  "ApiKeys": [
    {
      "Key": "your-api-key-here",
      "Owner": "ClientName"
    }
  ]
}
```

### JwtAuth
Configure JWT settings in `appsettings.json`:
```json
{
  "JwtSettings": {
    "SecretKey": "your-secret-key-min-32-chars",
    "Issuer": "WeatherApp",
    "Audience": "WeatherAppUsers",
    "ExpiryInMinutes": 60
  },
  "UserCredentials": [
    {
      "Username": "user1",
      "Password": "password1"
    }
  ]
}
```

### MtlsAuth
Configure certificates in `appsettings.json`:
```json
{
  "Kestrel": {
    "Endpoints": {
      "Https": {
        "Url": "https://localhost:5001",
        "Certificate": {
          "Path": "path/to/server-certificate.pfx",
          "Password": "certificate-password"
        }
      }
    }
  }
}
```

---

## 📝 Key Features

- ✅ **gRPC Protocol Buffers** - Efficient binary serialization
- ✅ **Multiple Auth Strategies** - API Key, JWT, and mTLS examples
- ✅ **gRPC Reflection** - Service discovery for tooling
- ✅ **Exception Handling** - Centralized error handling middleware
- ✅ **Layered Architecture** - Clean separation of concerns
- ✅ **Metadata-based Auth** - gRPC metadata for authentication
- ✅ **REST Auth Endpoints** - Token generation endpoints (JwtAuth)
- ✅ **Mutual TLS** - Two-way certificate authentication (MtlsAuth)

---

## 🔗 Related Projects

- [GraphQL API Auth Examples](../graphsql-apis.auth-styles.examples) - GraphQL API authentication examples
- [REST API Auth Examples](../rest-apis.auth-styles.examples) - REST API authentication examples

---

## 👤 Author

### Vishwa Kumar
- **Email:** vishwa@vishwa.me
- **GitHub:** [Vishwam](https://github.com/vishwamkumar)
- **LinkedIn:** [Vishwa Kumar](https://www.linkedin.com/in/vishwamohan)

Vishwa is the primary developer and architect of this example app, responsible for the architecture and implementation of these features.

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
