global using System;
global using Grpc.Core;
global using System.Threading.Tasks;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Server.Kestrel.Https;
global using System.Security.Cryptography.X509Certificates;
global using WeatherApp.GrpcApi.MtlsAuth.Services;
global using WeatherApp.GrpcApi.MtlsAuth.Middlewares;