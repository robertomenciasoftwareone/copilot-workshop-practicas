# PlayerStatsRM - API de Estadísticas de Jugadores de Fútbol

## 📋 Descripción del Proyecto

PlayerStatsRM es una API REST desarrollada en **.NET 8.0** que gestiona estadísticas de jugadores de fútbol. Permite realizar operaciones CRUD sobre jugadores, con funcionalidades de paginación y búsqueda de máximos goleadores.

## 🏗️ Arquitectura

```
┌─────────────────────────────────────────────────────────────┐
│                     API REST (.NET 8)                       │
│                    PlayerStatsRM.API                        │
└─────────────────────┬───────────────────────────────────────┘
                      │
┌─────────────────────▼───────────────────────────────────────┐
│                  PlayerController                           │
│  GET    /api/players/topscorers?page=1&size=5             │
│  POST   /api/players                                        │
│  POST   /api/players/{id}/gol                              │
└─────────────────────┬───────────────────────────────────────┘
                      │
┌─────────────────────▼───────────────────────────────────────┐
│               PlayerDbContext (EF Core)                     │
│              Entity Framework Core 8.0.0                    │
└─────────────────────┬───────────────────────────────────────┘
                      │
┌─────────────────────▼───────────────────────────────────────┐
│            SQLite Database (playerstats.db)                │
│                  Local File Database                        │
└─────────────────────────────────────────────────────────────┘
```

### Componentes

- **PlayerController**: Controlador API que maneja las operaciones HTTP
- **Player Entity**: Entidad que representa un jugador con Id, Name, Goals
- **PlayerDbContext**: Contexto de Entity Framework Core para SQLite
- **SQLite Database**: Base de datos local implementada en playerstats.db

## 📁 Estructura de Carpetas

```
RM/PlayerStatsRM/
├── bin/                              # Binarios compilados
├── obj/                              # Artefactos de compilación
├── Controllers/
│   └── PlayerController.cs           # Controlador principal de API
├── Migrations/
│   ├── InitialCreate.cs             # Primera migración
│   └── PlayerStatsRMModelSnapshot.cs # Snapshot del modelo
├── Properties/
│   └── launchSettings.json          # Configuración de inicio
├── Player.cs                         # Entidad del jugador
├── PlayerDbContext.cs                # DbContext de Entity Framework
├── Program.cs                        # Configuración de la aplicación
├── PlayerStatsRM.csproj             # Archivo de proyecto
├── PlayerStatsRM.postman_collection.json  # Colección de Postman
├── appsettings.json                 # Configuración de la app
├── appsettings.Development.json     # Config de desarrollo
└── playerstats.db                   # Base de datos SQLite

PlayerStatsRM.Tests/                 # Proyecto de pruebas unitarias
├── PlayerControllerTests.cs         # Tests del controlador
├── PlayerDbContextTests.cs          # Tests del DbContext
├── PlayerEntityTests.cs             # Tests de la entidad
└── PlayerStatsRM.Tests.csproj       # Archivo de proyecto de tests
```

## 🔧 Requisitos Previos

- **.NET 8.0 SDK** o superior
- **Visual Studio Code** (recomendado) o Visual Studio
- **PowerShell** o Command Prompt
- **Postman** (opcional, para probar endpoints)

## 📦 Instalación

### 1. Clonar o descargar el proyecto

```bash
cd C:\Users\[usuario]\copilot-workshop-practicas\RM\PlayerStatsRM
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Generar migraciones (si es necesario)

```bash
dotnet ef migrations add InitialCreate
```

### 4. Compilar el proyecto

```bash
dotnet build
```

## ▶️ Comandos para Ejecutar

### Ejecutar la aplicación en desarrollo

```bash
# Desde el directorio del proyecto
cd C:\Users\[usuario]\copilot-workshop-practicas\RM\PlayerStatsRM
dotnet run
```

**Salida esperada:**
```
Usando la configuración de inicio de ... launchSettings.json...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5111
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

### Especificar configuración de ejecución

```bash
# Ejecutar en modo HTTP (por defecto)
dotnet run --launch-profile http

# Ejecutar en modo HTTPS
dotnet run --launch-profile https
```

### Ejecutar desde cualquier ubicación

```bash
dotnet run --project "C:\Users\[usuario]\copilot-workshop-practicas\RM\PlayerStatsRM"
```

## 🧪 Testing

### Ejecutar todos los tests

```bash
cd C:\Users\[usuario]\copilot-workshop-practicas\RM\PlayerStatsRM\PlayerStatsRM.Tests
dotnet test
```

### Ejecutar tests con verbosidad detallada

```bash
dotnet test --verbosity detailed
```

### Tests Incluidos

**PlayerControllerTests.cs** (6 tests)
- ✅ GetTopScorers_ReturnsOrderedPlayersByGoals
- ✅ GetTopScorers_WithPagination_ReturnsPaginatedResults
- ✅ AddPlayer_CreatesNewPlayerSuccessfully
- ✅ IncrementGoals_IncrementsPlayerGoals
- ✅ IncrementGoals_WithInvalidId_ReturnsNotFound
- ✅ GetTopScorers_WithPage2_SkipsPreviousPlayers

**PlayerDbContextTests.cs** (7 tests)
- ✅ DbContext_CanAddPlayer
- ✅ DbContext_CanQueryPlayers
- ✅ DbContext_SeedData_HasCorrectGoals
- ✅ DbContext_CanUpdatePlayer
- ✅ DbContext_CanDeletePlayer
- ✅ DbContext_CanFilterPlayersByGoals

**PlayerEntityTests.cs** (5 tests)
- ✅ Player_CanBeInstantiated
- ✅ Player_DefaultNameIsEmpty
- ✅ Player_GoalsCanBeIncremented
- ✅ Player_GoalsCanBeSet
- ✅ Player_CanHaveDifferentNames

## 📡 Endpoints de la API

### 1. Obtener Máximos Goleadores (Paginado)

```http
GET /api/players/topscorers?page=1&size=5
```

**Parámetros Query:**
- `page` (int, default: 1): Número de página
- `size` (int, default: 5): Cantidad de registros por página

**Respuesta (200 OK):**
```json
[
  {
    "id": 1,
    "name": "Mbappe",
    "goals": 25
  },
  {
    "id": 2,
    "name": "Vinicius",
    "goals": 22
  },
  {
    "id": 3,
    "name": "Bellingham",
    "goals": 15
  }
]
```

### 2. Crear Nuevo Jugador

```http
POST /api/players
Content-Type: application/json

{
  "name": "Cristiano Ronaldo",
  "goals": 20
}
```

**Respuesta (201 Created):**
```json
{
  "id": 4,
  "name": "Cristiano Ronaldo",
  "goals": 20
}
```

### 3. Incrementar Goles de Jugador

```http
POST /api/players/{id}/gol
```

**Ejemplo:**
```http
POST /api/players/1/gol
```

**Respuesta (204 No Content)** - Sin body

## 🔍 Swagger/OpenAPI

La documentación interactiva está disponible en:

```
http://localhost:5111/swagger/ui
```

Accede a esta URL en tu navegador para ver y probar todos los endpoints interactivamente.

## 📮 Testing con Postman

### Importar colección

1. Abre Postman
2. Click en "Import"
3. Selecciona el archivo: `PlayerStatsRM.postman_collection.json`
4. Se importarán automáticamente todos los endpoints con ejemplos

### Requests pre-configurados

- `Get Top Scorers` - Obtiene los máximos goleadores
- `Add New Player` - Crea un nuevo jugador
- `Increment Player Goals` - Incrementa goles a Mbappe (ID: 1)
- `Increment Vinicius Goals` - Incrementa goles a Vinicius (ID: 2)
- `Increment Bellingham Goals` - Incrementa goles a Bellingham (ID: 3)

## 🌱 Datos Iniciales

La base de datos se precarga con 3 jugadores:

| ID | Nombre | Goles |
|----|--------|-------|
| 1 | Mbappe | 25 |
| 2 | Vinicius | 22 |
| 3 | Bellingham | 15 |

## 📋 Configuración

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=playerstats.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Puertos

- **Desarrollo HTTP**: `http://localhost:5111`
- **Desarrollo HTTPS**: `https://localhost:7253`

## 🔌 Dependencias Principales

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
<PackageReference Include="xunit" Version="2.9.3" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.14.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="8.0.0" />
```

## 🐛 Solución de Problemas

### Error: Puerto 5111 ya en uso

```bash
# Encontrar el proceso que usa el puerto
netstat -ano | findstr :5111

# Terminar el proceso (reemplazar PID)
Stop-Process -Id [PID] -Force
```

### Error: Base de datos no encontrada

```bash
# Asegúrate de estar en el directorio correcto y ejecuta:
dotnet run
```

La base de datos se creará automáticamente en la primera ejecución.

### Error: Xunit no encontrado en tests

```bash
# Restaurar dependencias del proyecto de tests
cd PlayerStatsRM.Tests
dotnet restore
dotnet clean
dotnet build
```

## 📊 Flujo de Desarrollo

```bash
# 1. Clonar/Descargar proyecto
cd C:\Users\[usuario]\copilot-workshop-practicas\RM\PlayerStatsRM

# 2. Restaurar dependencias
dotnet restore

# 3. Compilar
dotnet build

# 4. Ejecutar tests
cd PlayerStatsRM.Tests
dotnet test
cd ..

# 5. Ejecutar aplicación
dotnet run

# 6. Acceder a la API
# HTTP: http://localhost:5111
# Swagger: http://localhost:5111/swagger/ui
```

## 📝 Notas

- La base de datos SQLite se almacena en el mismo directorio del proyecto
- Los tests utilizan una base de datos en memoria, no afectan la base de datos principal
- Swagger documenta automáticamente todos los endpoints
- Los CORS están habilitados para desarrollo

## 🚀 Deploy

Para preparar para producción:

```bash
# Build en modo Release
dotnet build -c Release

# Publicar
dotnet publish -c Release -o ./publish
```

## 📧 Contacto & Soporte

Para preguntas o problemas, revisa los logs de la aplicación en el directorio de ejecución.

---

**Versión**: 1.0.0  
**Plataforma**: .NET 8.0  
**Base de Datos**: SQLite  
**Fecha Creación**: Febrero 2026
