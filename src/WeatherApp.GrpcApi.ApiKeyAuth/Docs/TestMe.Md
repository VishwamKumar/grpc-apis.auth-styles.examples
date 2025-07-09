# WeatherApp ApiKey Auth TestMe

## How To Test
1. Use PostMan
2. Create a gRPC request, name it e.g. GetWeatherForecast
   a. In URL put : localhost:7026 [ensure it is secure, means TLS is enabled, lock is showing up]
   b. In Select a method, select : Weatherforecaster/GetWeatherForecast
   c. In message section: Add the following 
    {
      "days": 3
    }

3. In Authorization tab, choose API Key, And choose the following 
   a. Key: X-API-Key
   b. Value: ApiKey1
    
4. Invoke the call, you should receive a reponse in JSON format
 



    