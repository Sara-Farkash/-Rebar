# -Rebar
ASP.NET Core 6 | MongoDB Database
Simulation - ASP.NET Core Web Application This is a C# project developed in ASP.NET Core Web Application using the:
Models, Services, Controllers and Swagger for API documentation.
The project simulates Shake shop -Rebar.
with 3 tables:
- **Menu**
  This class contains the menu of the shakes that are in the store
- **Account**
When the customer has looked at the shake menu and wants to decide to buy a shake, he goes to the Account,
There he will have to enter details of the customer as well as the choice of the shake and the price he chose for the size of the shake.
(The price in our store for each size has a fixed price)
And the customer will have to say what price he chose and we will bring him the requested size.
Soldiers and teachers or students,
we have a a lot of coupons for you at the cash register,
please let us know if you have a coupon and if so, the coupon code and we will arrange an equal discount for you!!!
- **DatabaseOfBranch**
This is the class reserved for the manager,
Only he can enter it by entering a password in the console
There he can close the daily account
and also see a daily report.

# Prerequisites 
- Visual Studio 2022
- .NET Core
- Mongo DB

# To Begin :
1. please download the project to your local machine.
2. open the project in Visual Studio.
3. open your Mongo DB  and when you connect to Mongo DB you need to see the "conntion string"
4. copy the connection strint
5. paste the "conntion string" in : appsettings.json there is setting there... (see:ConnectionString)
6. Creating tables in Mongo:
I am very sorry, you will have to create tables in Mongo DB yourself.
with overlapping fields for classes in the Models folder

Now you can add values in the Swagger 
and they will be updated in the database. 
Note that you must enter logical and correct data because otherwise the data will not enter the database.

Successfully !
Hope you enjoy the project 🖤!
