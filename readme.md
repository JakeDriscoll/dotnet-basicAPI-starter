This is an augmented version of https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio-code

There are a few scripts added to facilitate building from scratch

## Birth Certificate

```
mkdir basicAPI
cd basicAPI
dotnet new webapi -f net7.0
dotnet add package Microsoft.EntityFrameworkCore.InMemory
# Optional might not be needed
# dotnet dev-certs https --trust
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
# OPTIONAL since you might not have it
# dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
mkdir Models
.\buildModels.ps1 #This creates the basic models
# Add the text it tells you to add after the line builder.Services.AddControllers();
dotnet build
# probably have to add some usings to the Program.cs
Remove-Item .\WeatherForecast.cs
Remove-Item .\Controllers\WeatherForecastController.cs
dotnet run
# Go to your running app and add swaggger to the end ie: http://localhost:5110/swagger
```
echo "# dotnet-basicAPI-starter" >> README.md
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/JakeDriscoll/dotnet-basicAPI-starter.git
git push -u origin main