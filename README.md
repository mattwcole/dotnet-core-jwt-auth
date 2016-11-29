# Dotnet Core JWT Auth Demo with OpenIddict

Create the user DB and run:

```sh
dotnet restore
dotnet ef database update
dotnet watch run
```

Post the following `x-www-form-urlencoded` body at `/connect/token`:

```
grant_type=token
username=admin
password=helloP4ss!
resource=http://localhost:5000
```

Get an example resource at `/resource` by adding the Authorization header:

```
Authorization: Bearer <access_token>
```
