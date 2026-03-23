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
There is also a docker compose config for the app itself, so it can be built into a container

### App Startup:
   1. Ensure you have .env file with all necessary configs
   2. In the root directory run:
      ```
      docker compose up -d db
      ```
      This commands spins up the db container
   3. Run
       ```
      docker compose run --rm app
      ```
       This spins up the app container in an interactive shell so the app can directly be used
       --rm unsures the container is deleted after running the app

