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
- Demo: <a href="http://shouldhave-showyou.azurewebsites.net//geo?ip=139.130.4.5" target="_blank">http://shouldhave-showyou.azurewebsites.net//geo?ip=139.130.4.5</a>

With current user ip address:
- Format: 
```sh
http://yourdomain.com/geo
```
- Demo: <a href="http://shouldhave-showyou.azurewebsites.net//geo" target="_blank">http://shouldhave-showyou.azurewebsites.net//geo</a>

# Return Json
```json
 {
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
