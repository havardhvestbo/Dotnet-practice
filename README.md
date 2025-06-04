# .NET Practice Project - Mood Encouragement App 🌟

A full-stack web application built to practice and develop .NET skills, featuring a mood-based encouragement system with ASP.NET Core backend and React frontend.

## 🎯 Project Purpose

This project is designed for **learning and practicing .NET development skills**, including:
- ASP.NET Core Minimal APIs
- RESTful API design
- CORS configuration
- HTTP client-server communication
- Full-stack application architecture
- React frontend integration

## 🏗️ Project Structure

```
Dotnet-practice/
├── MyBackendApp/                    # .NET 6 Web API
│   ├── Program.cs                   # Main API configuration and endpoints
│   ├── MyBackendApp.csproj         # Project file
│   └── Properties/
└── mood-encouragement-frontend/     # React Frontend
    ├── src/
    │   ├── App.js                   # Main React component
    │   ├── App.css                  # Styling
    │   └── index.js
    ├── package.json
    └── public/
```

## 🚀 Features

### Backend (.NET API)
- **Minimal API** using ASP.NET Core 6
- **RESTful endpoints** for mood data
- **CORS configuration** for frontend integration
- **In-memory data storage** (Dictionary-based)
- **Swagger/OpenAPI** documentation

### Frontend (React)
- **Modern React** with hooks (useState, useEffect)
- **Responsive design** with CSS Grid and Flexbox
- **API integration** using fetch()
- **Error handling** and loading states
- **Interactive UI** with mood selection buttons

## 📋 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/moods` | Get all available moods |
| GET | `/encouragement/{mood}` | Get random encouragement for specific mood |
| POST | `/mood` | Submit mood and get encouragement |
| GET | `/daily-encouragement` | Get random daily inspiration |
| GET | `/swagger` | API documentation |

## 🛠️ Technologies Used

### Backend
- **.NET 6** - Latest LTS version
- **ASP.NET Core** - Web framework
- **Minimal APIs** - Lightweight API approach
- **Swagger/OpenAPI** - API documentation

### Frontend
- **React 18** - UI library
- **Modern JavaScript (ES6+)** - Async/await, destructuring
- **CSS3** - Grid, Flexbox, animations
- **Fetch API** - HTTP requests

## 🚦 Getting Started

### Prerequisites
- .NET 6 SDK
- Node.js (16+)
- npm or yarn

### Running the Backend
```bash
cd MyBackendApp
dotnet run
```
Backend will run on: `http://localhost:5085`

### Running the Frontend
```bash
cd mood-encouragement-frontend
npm install
npm start
```
Frontend will run on: `http://localhost:3000`

## 🎭 Available Moods

The app supports 6 different moods with personalized encouragement:
- **Happy** 😊 - Positive, uplifting messages
- **Sad** 😢 - Comforting, supportive messages
- **Stressed** 😰 - Calming, reassuring messages
- **Excited** 🤩 - Energizing, motivational messages
- **Tired** 😴 - Restful, self-care messages
- **Anxious** 😟 - Grounding, peaceful messages

## 📚 Learning Objectives

This project helps practice:

### .NET Core Concepts
- [x] Minimal API setup and configuration
- [x] Dependency injection and services
- [x] HTTP request/response handling
- [x] CORS policy configuration
- [x] Environment-based configuration
- [x] API documentation with Swagger

### Web Development Skills
- [x] RESTful API design principles
- [x] HTTP status codes and error handling
- [x] JSON serialization/deserialization
- [x] Cross-origin resource sharing (CORS)
- [x] Frontend-backend integration

### React Integration
- [x] API consumption from React
- [x] State management with hooks
- [x] Error handling in frontend
- [x] Loading states and UX

## 🔧 Configuration

### CORS Settings
The backend is configured to allow requests from:
- `http://localhost:3000` (React default)
- `http://localhost:3001` (React fallback)
- `http://127.0.0.1:3000`

### API Base URL
Frontend is configured to call: `http://localhost:5085`

## 🎨 Styling

The frontend features:
- **Glass-morphism design** with gradient backgrounds
- **Responsive grid layout** for mood buttons
- **CSS animations** and hover effects
- **Mobile-first responsive design**
- **Modern color palette** with emojis

## 🚀 Future Enhancements

Potential additions for continued learning:
- [ ] Database integration (Entity Framework Core)
- [ ] User authentication and authorization
- [ ] Logging with Serilog
- [ ] Unit testing (xUnit)
- [ ] Docker containerization
- [ ] Azure deployment
- [ ] API versioning
- [ ] Caching (Redis)

## 📖 Learning Resources

This project demonstrates concepts from:
- Microsoft .NET Documentation
- ASP.NET Core fundamentals
- React official documentation
- RESTful API best practices

---

**Built for learning .NET development skills** 🎓