# EF 
==> **Execute from cmder**

## create migration
```bash
dotnet ef migrations add "MIGRATION_NAME" --context=WebServ.Data.ApplicationDbContext --output-dir Data\Persistence\Migrations
```
## update the database
```bash
dotnet ef database update
```