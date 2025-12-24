COMMANDS
dotnet watch --project src/GurventVantilator.AdminUI 
dotnet watch --project src/GurventVantilator.WebUI 
dotnet ef database drop --project src/GurventVantilator.WebUI
dotnet ef migrations add InitialCreate --project src/GurventVantilator.Infrastructure --startup-project src/GurventVantilator.WebUI
dotnet ef database update --project src/GurventVantilator.Infrastructure --startup-project src/GurventVantilator.WebUI
dotnet ef migrations remove --project src/GurventVantilator.Infrastructure --startup-project src/GurventVantilator.WebUI
dotnet add package ClosedXML --project src/GurventVantilator.Infrastructure

LOCAL CONNECTION STRINGS
"ConnectionStrings": {
  "DefaultConnection": "Server=127.0.0.1,1433;Database=GurventVantilatorDb;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True;"
},

REMOTE CONNECTION STRINGS
"ConnectionStrings": {
    "DefaultConnection": "Server=104.247.162.242\\MSSQLSERVER2019;Database=firatram_musteri_kayit_sistemi_db;user=firatram_musteri_kayit_sistemi_db_admin;password=C^Qz8Dfmfnz*cr49;MultipleActiveResultSets=true;TrustServerCertificate=true"
},