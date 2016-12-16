# Description
Get geographic (latitude, longitude) with current IP of request.

Lightweight and have good performance with cache.

# Database
This product includes GeoLite data created by MaxMind, available from 
<a href="http://www.maxmind.com" target="_blank">http://www.maxmind.com</a>.

Update new database: download new Geolite data from MaxMind and copy and override at CsvDatabase folder. (Keep the name of files as same as files in CsvDatabase folders.)

# Configuration
We can change configuration for Csv Database files or Binary database files
```json
 <add key="shsu:UseMaxMindDb" value="true"/>
```

# Example
With specified ip address:
- Format: 
```sh 
http://yourdomain.com/geo?ip={value} 
```
- Demo: <a href="http://shouldhave-showyou.azurewebsites.net/geo?ip=74.125.130.132" target="_blank">http://shouldhave-showyou.azurewebsites.net/geo?ip=74.125.130.132</a>

With current user ip address:
- Format: 
```sh
http://yourdomain.com/geo
```
- Demo: <a href="http://shouldhave-showyou.azurewebsites.net/geo" target="_blank">http://shouldhave-showyou.azurewebsites.net/geo</a>

# Return Json
```json
 {
  "ip": "74.125.130.132",
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
