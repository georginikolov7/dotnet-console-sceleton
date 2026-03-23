# .NET Console Architecture Sceleton
Sample app prividing a 3-layer sceleton for .net console apps

---
### Overview:

1. Infrastructure Layer
   - Uses EF Core for access to Postgres
2. Core Layer
   - Main service layer
3. Cli Layer
   - Console app with custom commands parser and IoC container via ConfigurationBuilder
  
---

### Note:
Sceleton uses docker compose to spin up the postgre db in a container
