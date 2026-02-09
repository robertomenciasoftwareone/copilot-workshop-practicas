# Guía Rápida de Comandos - PlayerStatsRM

## 🚀 Inicio Rápido

```bash
# 1. Navegar al proyecto
cd C:\Users\[usuario]\copilot-workshop-practicas\RM\PlayerStatsRM

# 2. Restore & Build
dotnet restore && dotnet build

# 3. Ejecutar
dotnet run

# 4. Acceder a la API
# HTTP:   http://localhost:5111
# Swagger: http://localhost:5111/swagger/ui
```

---

## 📦 Comandos de Compilación

| Comando | Descripción |
|---------|-----------|
| `dotnet restore` | Restaura todas las dependencias NuGet |
| `dotnet build` | Compila el proyecto (Debug) |
| `dotnet build -c Release` | Compila en modo Production |
| `dotnet clean` | Limpia artefactos de compilación |
| `dotnet publish -c Release -o ./publish` | Publica para producción |

---

## ▶️ Comandos de Ejecución

| Comando | Descripción |
|---------|-----------|
| `dotnet run` | Ejecuta la aplicación en desarrollo |
| `dotnet run --launch-profile http` | Ejecuta solo con HTTP (sin HTTPS) |
| `dotnet run --launch-profile https` | Ejecuta solo con HTTPS |
| `dotnet watch run` | Ejecuta con auto-reload en cambios (requiere `dotnet-watch`) |

---

## 🧪 Comandos de Testing

```bash
# Navegar al proyecto de tests
cd PlayerStatsRM.Tests

# Ejecutar todos los tests
dotnet test

# Ejecutar tests con verbosidad
dotnet test --verbosity detailed

# Ejecutar tests de una clase específica
dotnet test --filter ClassName=PlayerControllerTests

# Ejecutar tests de un método específico
dotnet test --filter Name=GetTopScorers_ReturnsOrderedPlayersByGoals

# Volver al directorio principal
cd ..
```

---

## 🗄️ Comandos de Base de Datos (Entity Framework)

| Comando | Descripción |
|---------|-----------|
| `dotnet ef migrations list` | Lista todas las migraciones |
| `dotnet ef migrations add [Nombre]` | Crea nueva migración |
| `dotnet ef database update` | Aplica migraciones a la BD |
| `dotnet ef database drop` | Elimina la base de datos |

---

## 📡 Pruebas de Endpoints (cURL)

```bash
# 1. Obtener máximos goleadores
curl -X GET "http://localhost:5111/api/players/topscorers?page=1&size=5"

# 2. Crear nuevo jugador
curl -X POST "http://localhost:5111/api/players" ^
  -H "Content-Type: application/json" ^
  -d "{\"name\":\"Lewandowski\",\"goals\":20}"

# 3. Incrementar goles (ID: 1)
curl -X POST "http://localhost:5111/api/players/1/gol"
```

---

## 🔥 Troubleshooting Rápido

```bash
# Puerto ocupado
Stop-Process -Name "PlayerStatsRM" -Force

# Limpiar todo y recompilar
dotnet clean && dotnet restore && dotnet build

# Resetear base de datos
Remove-Item playerstats.db -ErrorAction SilentlyContinue
dotnet run

# Problemas con tests
cd PlayerStatsRM.Tests
dotnet clean
dotnet restore
dotnet test
cd ..
```

---

## 📍 URLs Principales

| Recurso | URL |
|---------|-----|
| API Base | http://localhost:5111 |
| Swagger UI | http://localhost:5111/swagger/ui |
| Top Scorers | http://localhost:5111/api/players/topscorers |
| Health Check | http://localhost:5111 (GET) |

---

## 🔑 Variables de Entorno

```bash
# Establecer configuración de desarrollo
$env:ASPNETCORE_ENVIRONMENT = "Development"

# Establecer nivel de logging
$env:Logging__LogLevel__Default = "Information"
```

---

## 📝 Estructura de Peticiones HTTP

### GET - Máximos Goleadores
```
GET /api/players/topscorers?page=1&size=5
Respuesta: 200 OK (JSON Array)
```

### POST - Crear Jugador
```
POST /api/players
Content-Type: application/json
Body: { "name": "NombreJugador", "goals": 0 }
Respuesta: 201 Created
```

### POST - Incrementar Goles
```
POST /api/players/{id}/gol
Respuesta: 204 No Content
```

---

## 🎯 Workflow Completo

```bash
# [1] Setup Inicial
cd C:\Users\[usuario]\copilot-workshop-practicas\RM\PlayerStatsRM
dotnet restore

# [2] Compilar
dotnet build

# [3] Ejecutar tests
cd PlayerStatsRM.Tests
dotnet test
cd ..

# [4] Ejecutar aplicación
dotnet run

# [5] Probar endpoints en otra terminal PowerShell
curl http://localhost:5111/api/players/topscorers

# [6] Acceder a Swagger
# Abre navegador: http://localhost:5111/swagger/ui
```

---

## 🛑 Parar la Aplicación

```bash
# En PowerShell (mientras está ejecutando)
Ctrl + C

# O desde otra terminal
Stop-Process -Name "dotnet" -Force

# O específicamente el puerto
netstat -ano | findstr :5111
Stop-Process -Id [PID] -Force
```

---

**Última actualización**: Febrero 2026
