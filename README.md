# CosmoRequests
Library created in order to make requests and http responses easier using the native C # class WebRequest

## Provided methods

1. GET
2. POST
3. PUT
3. PATCH
3. DELETE

### PS: 
All of them expect at least one parameter, an url. If you want, you can also pass an object data which it will be converted to JSON and included at the request, and create a RequestOption object which contains definitions to timeout, contentType, headers e etc.

### How to use

```C#
CosmoRequest cosmoRequest = new CosmoRequest();

string url = "https://rickandmortyapi.com/api/character/1";

CosmoResponse response = cosmoRequest.GET(url)
Console.WriteLine(response);
`````

> 
 id": 1,
  "name": "Rick Sanchez",<br>
  "status": "Alive",<br>
  "species": "Human",<br>
  "type": "",<br>
  "gender": "Male",<br>
  "origin": {
    "name": "Earth (C-137)",
    "url": "https://rickandmortyapi.com/api/location/1"
  },<br>
  "location": {
    "name": "Earth (Replacement Dimension)",
    "url": "https://rickandmortyapi.com/api/location/20"
  },<br>
  "image": "https://rickandmortyapi.com/api/character/avatar/1.jpeg",<br>
  "episode": [
    "https://rickandmortyapi.com/api/episode/1",
    "https://rickandmortyapi.com/api/episode/2",
    "https://rickandmortyapi.com/api/episode/3",
    "https://rickandmortyapi.com/api/episode/4",
    "https://rickandmortyapi.com/api/episode/5",
    "https://rickandmortyapi.com/api/episode/6",
    "https://rickandmortyapi.com/api/episode/7",
    "https://rickandmortyapi.com/api/episode/8",
    "https://rickandmortyapi.com/api/episode/9",
    <br>
...
 
  ],
  "url": "https://rickandmortyapi.com/api/character/1",<br>
  "created": "2017-11-04T18:48:46.250Z"
 >
 <br>

### PS:   You can also see full response's request using;

`````
CosmoResponse response = cosmoRequest.GET(url)
Console.WriteLine(response.GetResponse);
`````

> 
Body: {"id":1,"name":"Rick Sanchez","status":"Alive","species":"Human","type":"","gender":"Male","origin":{"name":"Earth (C-137)","url":"https://rickandmortyapi.com/api/location/1"},"location":{"name":"Earth (Replacement Dimension)","url":"https://rickandmortyapi.com/api/location/20"},"image":"https://rickandmortyapi.com/api/character/avatar/1.jpeg","episode":["https://rickandmortyapi.com/api/episode/1","https://rickandmortyapi.com/api/episode/2","https://rickandmortyapi.com/api/episode/3","https://rickandmortyapi.com/api/episode/4","https://rickandmortyapi.com/api/episode/5","https://rickandmortyapi.com/api/episode/6","https://rickandmortyapi.com/api/episode/7","https://rickandmortyapi.com/api/episode/8","https://rickandmortyapi.com/api/episode/9","https://rickandmortyapi.com/api/episode/10","https://rickandmortyapi.com/api/episode/11","https://rickandmortyapi.com/api/episode/12","https://rickandmortyapi.com/api/episode/13","https://rickandmortyapi.com/api/episode/14","https://rickandmortyapi.com/api/episode/15","https://rickandmortyapi.com/api/episode/16","https://rickandmortyapi.com/api/episode/17","https://rickandmortyapi.com/api/episode/18","https://rickandmortyapi.com/api/episode/19","https://rickandmortyapi.com/api/episode/20","https://rickandmortyapi.com/api/episode/21","https://rickandmortyapi.com/api/episode/22","https://rickandmortyapi.com/api/episode/23","https://rickandmortyapi.com/api/episode/24","https://rickandmortyapi.com/api/episode/25","https://rickandmortyapi.com/api/episode/26","https://rickandmortyapi.com/api/episode/27","https://rickandmortyapi.com/api/episode/28","https://rickandmortyapi.com/api/episode/29","https://rickandmortyapi.com/api/episode/30","https://rickandmortyapi.com/api/episode/31","https://rickandmortyapi.com/api/episode/32","https://rickandmortyapi.com/api/episode/33","https://rickandmortyapi.com/api/episode/34","https://rickandmortyapi.com/api/episode/35","https://rickandmortyapi.com/api/episode/36","https://rickandmortyapi.com/api/episode/37","https://rickandmortyapi.com/api/episode/38","https://rickandmortyapi.com/api/episode/39","https://rickandmortyapi.com/api/episode/40","https://rickandmortyapi.com/api/episode/41"],"url":"https://rickandmortyapi.com/api/character/1","created":"2017-11-04T18:48:46.250Z"},<br>
ContentEncoding: ,<br>
ContentType: application/json; charset=utf-8,<br>
ContentLength: 2283,<br>
Cookies: System.Net.CookieCollection,<br>
Headers: access-control-allow-origin: *
Content-Length: 2283
Cache-Control: max-age=259200,public
Content-Type: application/json; charset=utf-8
date: Wed, 14 Jul 2021 16:56:31 GMT
etag: W/"8eb-Tb5YlC+lq/WbjSuXI6O6LTPN2Yw"
expires: Sat, 17 Jul 2021 16:56:31 GMT
server: Netlify
age: 127180
x-nf-request-id: 01FAPREV4JG8B9SF9HFNMH31W0
x-powered-by: Express

,<br>
IsSuccessful: True,<br>
ErrorMessage: ,<br>
LastModified: 7/16/2021 1:16:10 AM,<br>
Method: GET,<br>
ProtocolVersion: 1.1,<br>
ResponseUri: https://rickandmortyapi.com/api/character/1,<br>
StatusCode: 200,<br>
StatusDescription: OK,<br>
Server: Netlify,<br>
SupportsHeaders: True,<br>
>