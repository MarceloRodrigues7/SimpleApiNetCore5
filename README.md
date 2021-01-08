# ApiNetCore5
api project .net core 5 + Mysql + JWT

Database public in remotesql.com

Routers

Geration Token
[Post]
../api/Home/login
Body: username and password
Return parameter: token bearer HmacSha256 and expired: 2 hours.

Without Authentication
[GET]
../api/Home/login

[GET]
../api/datetime

With Authentication
[GET]
../api/Home/Login

[GET]
../api/Users

[Post]
../api/Users/NewUser
Body: name,password and statusAccount

[Delete]
../api/Users/DelUser/{id}
Parameter in Url: id={id}
