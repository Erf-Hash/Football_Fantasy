# FootBall_Fantasy
---

## API List 

1. **Signup**
1. **OTP**
1. **Login**
1. **Reset Password**
1. **User Info**
1. **Change User Info**
1. **Get Player**
1. **Edit Team**
1. **Get Team**

#### Sign-Up
> This API is used for Creating an acount. It should be given a name, e-mail (which must be Unique), Passowrd and an Username (Which also must be unique). 

Header :
```
Content-Type : application/json
```
Body :
```
{
"Name" : "your name",
"Email" : "your email",
"Password" : "your password" ,
"UserName" : "your userName"
}
```
Response :
```
{
"Success" : "bool {true , false} response status",
"Message" : "response message",
}
```

#### Login
> This API is used for logging in to an acount. It Puts a Cookies containing a unique JWT token in the browser.


Header :
```
Content-Type : application/json
```
Body :
```
{
"userOrEmail" : "your email or username",
"password" : "your password"
}
```
Response :
```
{
"Success" : "bool {true , false} response status",
"Message" : "response message",
}
```
Cookie :
```
Authentication : JWT Token
```

#### OTP
> One Time Password or OTP is a feature for E-mail authentication.

Header :
```
Content-Type : application/json
```
Body :
```
{
    "Email" : "your email”,
    "OTP" : "received code"
}
```
Response :
```
{
"Success" : "bool {true , false} response status",
"Message" : "response message",
}
```

#### Reset Password
> This API Identifies the User using his/her JWT Token and sends an E-mail containing a code to reset user's password.

Header :
```
Content-Type : application/json
Authentication : your Token
```

Response :
```
{
"Success" : "bool {true , false} response status",
"Message" : "response message",
}
```
#### User Info
> Returns User Information; Identification is done using the JWT Token.

Header :
```
Content-Type : application/json
Authentication : your Token
```
Fail Response:
```
{
"Success" : "bool {true , false} response status",
"Message" : "response message",
}
```
Successs Response:
```
{
"Name" : "your name",
"UserName" : "your username",
"Email" : "your email"
}
```

#### Change User Info
> Using this API, the user can change his/her information. the type of Operation is Identified using and Enum.

Header :
```
Content-Type : application/json
Authentication : your Token
```
Body :
```
{
"Info" : " Enum {Password,UserName,Name}",
"CurrentPassword" : "your current password",
"NewValue" : "value you want to assign to that Info"
}
```
Response :
```
{
"Success" : "bool {true , false} response status",
"Message" : "response message",
}
```

#### Get Players
> Returns all the players based on the metrics the were given to it.

Header :
```
Content-Type : application/json
```
Body :
```
{
"sortType" : " Enum {Default,PointSort,CostSort,NameSort,WebName} => Default won't sort players",
"sortOrder" : " Enum {Descending,Ascending}",
"position" : " Enum {Default,Goalkeepers,Defenders,Midfielders,Forwards}" => Default Position will return all positions,
"search" : "name that you want to find",
"paginationPage" : "page index",
"paginationLength" : "page length",
"teamID" : "integer => 0 will return player from all teams"
}
```
Response :
```
{
[List of player]
}
```

#### Edit Team
>This API was made for editing teams. Actions are chosen using an Enum. In order to switch their position, two players should be given to this function by PlayerID.

Header :
```
Content-Type : application/json
Authentication : your Token
```
Body :
```
{
"Action" : " Enum {Add,Remove,Substitution}",
"id_1" : "id of first player",
"id_2" : "id of second player. Just in substitution mode."
}
```
Response :
```
{
"Success" : "bool {true , false} response status",
"Message" : "response message",
}
```

#### Get Team
> Returns Player's Team. Player status should be given in an Enum with fields "Substitute", "Fixed", "Any". "Any" gives all players without respect to type. The Position Enum should be given the Position that the user wants to see; the "Default" value returns all the players no matter the position

Header :
```
Content-Type : application/json
Authentication : your Token
```
Body :
```
{
"Type" : " Enum {Any,Fixed,Substitutes}",
"Position" : " Enum {Default,Goalkeepers,Defenders,Midfielders,Forwards}"
//note : Fill Position just in Any and Fixed mode.
}
```
Response :
```
{
[List of player]
}
```
