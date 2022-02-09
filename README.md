![example workflow](https://github.com/viiparente/DevGames/actions/workflows/build.yml/badge.svg)

# DevGames - Jornada .NET Direto ao Ponto
Foi desenvolvida uma API REST completa em .NET de gerenciamento de boards, posts e comentários de uma plataforma como o Reddit.

##

### Tecnologias e práticas utilizadas
* ASP.NET Core com .NET 6
* Entity Framework Core
* SQL Server
* Swagger
* AutoMapper
* Injeção de Dependência
* Programação Orientada a Objetos
* Padrão Repository
* Logs com Serilog
* Publicação na nuvem com Azure App Service

##

### Funcionalidades
* Cadastro, Listagem, Detalhes, Atualização de Board
* Cadastro, Listagem e Detalhes de um Post
* Cadastro de Comentários

##

### Run

```console
dotnet restore

dotnet build --no-restore

dotnet run --project ./DevGames.API/DevGames.API.csproj

dotnet ef migrations add InitialMigration -o Persistence/Migrations

dotnet ef database update
```


##

Ministrado pelo instrutor [Luis Felipe](https://www.linkedin.com/in/luisdeol/)
