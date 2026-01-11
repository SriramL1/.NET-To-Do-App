# My Todo App

A modern, beautiful **full-stack Todo List application** with a **smart frontend** (HTML, CSS, JavaScript) and a **powerful .NET + C# backend**.

### Project Overview

**Frontend** (single-file SPA – no build tools):  
- Stunning light/dark mode with real glassmorphism (frosted blur)  
- Sunny productive workspace (light) & cozy night desk (dark) backgrounds  
- Fully responsive, offline-capable, fast, and minimalist UI  
- Double-click to complete tasks, Enter to add, localStorage persistence

**Backend** (built with **.NET 8** and **C#**):  
- RESTful API for todos (CRUD operations)  
- In-memory storage (or easily switch to SQLite/Entity Framework)  
- Automatic priority calculation based on due date/time  
- Precise datetime handling (date + time) for deadlines  
- Overdue detection, smart sorting, and real-time priority updates

### Features

- **Dual beautiful themes** with immersive backgrounds  
- **Automatic smart priority** (Overdue / High / Medium / Low) recalculated every time  
- **Precise due date + time** support (e.g., "Due: 12/25/2025 at 2:30 PM")  
- Tasks sorted by urgency (closest deadlines first)  
- Double-click to toggle complete, confirmation for "Clear All"  
- Full **.NET 8 + C#** backend API (REST endpoints)  
- LocalStorage persistence for frontend + optional API sync  
- Clean, minimal, and professional UI/UX

### Tech Stack

**Frontend** (single `index.html` file):
- HTML5 + CSS3 (variables, flexbox, glassmorphism, backdrop-filter)
- Vanilla JavaScript (no frameworks, localStorage, dynamic sorting)

**Backend** (ASP.NET Core Web API):
- .NET 8 (latest LTS as of 2026)
- C# 12
- Minimal APIs (clean & fast)
- Optional: In-memory store (or add EF Core + SQLite)

### How to Run (Full-Stack)

1. **Frontend only** (instant, no setup)  
   Just open `index.html` in any browser

2. **Full stack with .NET backend**  
   ```bash
   # 1. Clone repo
   git clone https://github.com/yourusername/my-todo-app.git
   cd my-todo-app/backend

   # 2. Run the API (http://localhost:5000 or https://localhost:5001)
   dotnet run

   # 3. Open frontend/index.html in browser
   #    (update fetch URLs in JS to point to your backend)
