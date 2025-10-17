# Rick and Morty Backend - BFF (Backend For Frontend)

![Autor](https://img.shields.io/badge/Autor-Iv%C3%A1n%20Mancilla-lightgrey)  
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)  
![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=csharp&logoColor=white)  
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?logo=dotnet&logoColor=white)  
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?logo=swagger&logoColor=black)  
![Licencia](https://img.shields.io/badge/Licencia-Unlicense-blue)

Backend BFF (Backend For Frontend) desarrollado en .NET 8 que consume la API pública de Rick and Morty y expone endpoints REST para el frontend Angular.

---

## 📋 Descripción

API REST desarrollada en ASP.NET Core 8 que actúa como capa intermedia (BFF) entre el frontend Angular y la API pública de Rick and Morty. Implementa patrones de diseño, documentación con Swagger/OpenAPI y manejo de errores.

## 🚀 Tecnologías

- **.NET**: 8.0
- **C#**: 12.0
- **ASP.NET Core Web API**: 8.0
- **HttpClient**: Para consumo de API externa
- **Swagger/OpenAPI**: Documentación automática de API
- **CORS**: Configurado para desarrollo local

## 📦 Prerrequisitos

- **.NET SDK**: 8.0 o superior
- **Visual Studio 2022** o **Visual Studio Code**
- **Postman** (opcional, para probar endpoints)

---

### Verifica la versión de .NET:

dotnet --version

text

Si no tienes .NET 8 instalado, descárgalo desde:
- [https://dotnet.microsoft.com/download/dotnet/8.0](https://dotnet.microsoft.com/download/dotnet/8.0)

### Clonar el Repositorio

git clone https://github.com/IvanAlejandroMancilla/BackendCarsales.git
cd BackendCarsales

text

### Restaurar dependencias:

dotnet restore

text

## ▶️ Ejecución

### Modo desarrollo

dotnet run

text

> **Nota:** La API estará disponible en: [**http://localhost:5000**](http://localhost:5000) o [**https://localhost:5001**](https://localhost:5001)

### Ver documentación Swagger

Una vez ejecutado el proyecto, accede a:
- [**http://localhost:5000/swagger**](http://localhost:5000/swagger)

### Build de producción

dotnet build --configuration Release

text

---

## 📂 Estructura del Proyecto

BackendCarsales/
├── Controllers/
│ ├── EpisodeController.cs # Endpoints de episodios
│ ├── CharacterController.cs # Endpoints de personajes
│ └── LocationController.cs # Endpoints de locaciones
├── Services/
│ └── RickAndMortyService.cs # Lógica de consumo de API
├── Models/
│ ├── Episode.cs # Modelo de episodio
│ ├── Character.cs # Modelo de personaje
│ └── Location.cs # Modelo de locación
├── Program.cs # Configuración de la aplicación
├── appsettings.json # Configuración general
└── appsettings.Development.json # Configuración de desarrollo

text

## ✨ Características

✅ **Arquitectura BFF**: Backend dedicado para el frontend Angular  
✅ **Consumo de API externa**: HttpClient con manejo de errores  
✅ **Documentación Swagger**: OpenAPI 3.0 generada automáticamente  
✅ **CORS configurado**: Permite requests desde el frontend  
✅ **Inyección de dependencias**: Patrón DI de ASP.NET Core  
✅ **Manejo de errores**: Try-catch y respuestas HTTP apropiadas  
✅ **DTOs**: Separación de modelos de dominio y respuesta  

## 🌐 Endpoints Disponibles

### Episodios

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/Episode` | Obtiene todos los episodios |
| GET | `/api/Episode/{id}` | Obtiene un episodio por ID |

### Personajes

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/Character` | Obtiene todos los personajes |
| GET | `/api/Character/{id}` | Obtiene un personaje por ID |

### Locaciones

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/Location` | Obtiene todas las locaciones |
| GET | `/api/Location/{id}` | Obtiene una locación por ID |

## 🛠️ Scripts Disponibles

dotnet run # Ejecuta la aplicación
dotnet build # Compila el proyecto
dotnet test # Ejecuta pruebas unitarias
dotnet publish -c Release # Genera build de producción

text

---

## 🔗 API Externa Consumida

Este backend consume la API pública de Rick and Morty:
- **Base URL**: https://rickandmortyapi.com/api
- **Documentación**: https://rickandmortyapi.com/documentation

## ⚙️ Configuración

### appsettings.json

{
"RickAndMortyApi": {
"BaseUrl": "https://rickandmortyapi.com/api"
},
"Cors": {
"AllowedOrigins": ["http://localhost:4200"]
}
}

text

### CORS

El backend está configurado para aceptar requests desde:
- `http://localhost:4200` (Angular frontend)

Para modificar, edita el archivo `Program.cs`.

---

## 🎨 Arquitectura

Frontend (Angular) → Backend BFF (.NET 8) → Rick and Morty API
↓ ↓ ↓
Consume /api/Episode Procesa/Transforma API Externa

text

## 👤 Autor

**Iván Alejandro Mancilla**  
GitHub: [@IvanAlejandroMancilla](https://github.com/IvanAlejandroMancilla)

## 📄 Licencia

Este proyecto es parte de una prueba técnica para Carsales.

---

⭐ Si este proyecto te resultó útil, no dudes en dar una estrella al repositorio.
