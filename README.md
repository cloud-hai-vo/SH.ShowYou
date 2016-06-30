# Description
Get geographic (latitude, longitude) with current IP of request.

Lightweight and have good performance with cache.

# Database
This product includes GeoLite data created by MaxMind, available from 
<a href="http://www.maxmind.com" target="_blank">http://www.maxmind.com</a>.

# Example
With specified ip address:
- Format: 
```sh 
http://yourdomain.com/geo?ip={value} 
```
- Demo: <a href="http://shouldhave.azurewebsites.net/geo?ip=74.125.130.132" target="_blank">http://shouldhave.azurewebsites.net/geo?ip=74.125.130.132</a>

With current user ip address:
- Format: 
```sh
http://yourdomain.com/geo
```
- Demo: <a href="http://shouldhave.azurewebsites.net/geo" target="_blank">http://shouldhave.azurewebsites.net/geo</a>

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
