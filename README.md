# Description
Get geographic (latitude, longitude) with current IP of request.

Lightweight and have good performance with cache.

# Database
This product includes GeoLite data created by MaxMind, available from 
<a href="http://www.maxmind.com">http://www.maxmind.com</a>.

# Example
- With specified ip address:
http://yourdomain.com/geo?ip={value}

- With current user ip address
http://yourdomain.com/geo

# Return Json
```json
 {
  "id": "15865",
  "locId": "15865",
  "country": "SG",
  "region": "00",
  "city": "Singapore",
  "postalCode": "",
  "latitude": 1.2931,
  "longitude": 103.8558,
  "metroCode": "",
  "areaCode": ""
}
```
