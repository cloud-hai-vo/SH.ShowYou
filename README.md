# Description
Get geographic (latitude, longitude) with current IP of request.

Lightweight and have good performance with cache.

# Database
This product includes GeoLite data created by MaxMind, available from 
<a href="http://www.maxmind.com">http://www.maxmind.com</a>.

# Example
With specified ip address:
- Format: http://yourdomain.com/geo?ip={value}
- Demo: http://shouldhave.azurewebsites.net/geo?ip=139.130.4.5

With current user ip address:
- Format: http://yourdomain.com/geo
- Demo: http://shouldhave.azurewebsites.net/geo

# Return Json
```json
 {
  "id": "string",
  "locId": "string",
  "country": "string",
  "region": "string",
  "city": "string",
  "postalCode": "string",
  "latitude": double,
  "longitude": double,
  "metroCode": "string",
  "areaCode": "string"
}
```
