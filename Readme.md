# Small .NET 8 RestAPI Project

### The Db :
I used Docker with MSSQL Server 2022, as I am developing on Linux, and it is a pretty straightforward way to:

```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=P@ssw0rd" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

And the connection string is therefore different from the regular SSMS on Windows system. If you want to run it on your own PC to test it, you can adapt the string to your database, I am sure that it can easily be done with your favorite LLM chatbot or harness.

If you want to connect to the db with dbever or similar tool, the username is `sa` as the `MSSQL_SA_PASSWORD` variable is defining it.

---

### The endpints :

REST Architecture: I implemented full lifecycle CRUD endpoints (GET, POST, PUT, DELETE) with HTTP status codes (200 OK, 404 Not Found).

I used DTOs and Models for entities with Entity Framework

Swagger is also included by default so it can be used.

