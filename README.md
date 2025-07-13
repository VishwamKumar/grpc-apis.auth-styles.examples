# 🌤️ Weather App - gRPC Auth API Examples (Layered Architecture)

This repository showcases multiple gRPC-based Weather APIs, each secured with different authentication mechanisms, built using the **Layered Architecture** approach.

---

# Author

## Vishwa Kumar
- **Email:** vishwa@vishwa.me
- **GitHub:** [Vishwam](https://github.com/vishwamkumar)
- **LinkedIn:** [Vishwa Kumar](https://www.linkedin.com/in/vishwamohan)

Vishwa is the primary developer and architect of this example app, responsible for the architecture and implementation of these features.

---

## 🔐 Authentication Styles Implemented

- `WeatherApp.GrpcApi.ApiKeyAuth` - Uses API Key authentication via metadata headers.
- `WeatherApp.GrpcApi.JwtAuth` - Secured with JSON Web Tokens (JWT).
- `WeatherApp.GrpcApi.MtlsAuth` - Implements Mutual TLS (mTLS) for two-way certificate validation.

Each project is self-contained and can be built, run, and tested independently.

---

## ▶️ Getting Started

### 🔁 Clone the Repository

    ```bash
    git clone https://github.com/vishwamkumar/weather-app.auth-grpc-apis.layered.git
    cd weather-app.auth-grpc-apis.layered
    ```
---

## ▶️ Run Any Project

    ```bash
      cd WeatherApp.GrpcApi.JwtAuth
      dotnet run
    ```
    Replace JwtAuth with ApiKeyAuth or MtlsAuth to test the other options.
---

## Structure

    weather-app.auth-grpc-apis.layered/
    ├── WeatherApp.GrpcApi.ApiKeyAuth/
    ├── WeatherApp.GrpcApi.JwtAuth/
    └── WeatherApp.GrpcApi.MtlsAuth/


## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.