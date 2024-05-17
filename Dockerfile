# Usar uma imagem de SDK do .NET 8 para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar a solução e os arquivos de projeto específicos
COPY crm/crm.sln ./
COPY crm/src/modules/project/crm.Project/Api/crm.Project.Api.csproj ./crm/src/modules/project/crm.Project/Api/
COPY crm/src/modules/project/crm.Project.Domain/crm.Project.Domain.csproj ./crm/src/modules/project/crm.Project.Domain/
COPY crm/src/modules/project/crm.Project.Infra/crm.Project.Infra.csproj ./crm/src/modules/project/crm.Project.Infra/

# Restaurar as dependências do projeto
RUN dotnet restore

# Copiar o restante dos arquivos do projeto
COPY crm/src/modules/project/ProjetoAPI/ ./crm/src/modules/project/ProjetoAPI/
COPY crm/src/modules/project/OutrasLibs/ ./crm/src/modules/project/OutrasLibs/

# Compilar e publicar o projeto da API
RUN dotnet publish crm/src/modules/project/ProjetoAPI -c Release -o out

# Gerar a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ProjetoAPI.dll"]
