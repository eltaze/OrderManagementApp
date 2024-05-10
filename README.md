Order Managment System API
≠======================
Technology : 
      APS. NET MVC as webapi
      DataBase in memory database using EF 
      In memory cashing for holding data
      C# V8
Communication  Technologies 
      SignalR for update price with client 
      Rest sending data with api 
Backservice 
      BackGround Services using hosted service 
Configuration 
     Default http port 5267 
     Default https port 7124
Variable can be change 
      Appsetting.json 
         Name:  Time : value in seconds numbers only default is 30 seconds 
         Data type : int
         Used.:time for send massage through SignalR 
       Name: CashTime : value in minutes numbers only default is 15 
      Data type: int
      Useing : time for data cash Memeory can hold before refresh it back from database 
DataBase design 3 tables products, orders and order details in relation master child

