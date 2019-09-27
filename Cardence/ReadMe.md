This was created using the standard Microsoft .Net React SPA template using the Latest .Net Core 3.0

I tried to show injection and unit testing and the business logic such as the card decision was developed using TDD.

Work to improve on would be to add in a service layer between the controller and the data context. This
would allow for some intergration tests say swapping out one database for an in memory database etc

To get this project running 
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update


gerg