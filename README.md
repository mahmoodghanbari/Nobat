# Nobat — Simple and Reliable Queue Management System

⚠️ **Warning**

This software is a work in progress.

Nobat is a modern, containerized queue management system designed for small businesses. It provides a scalable backend API, an interactive frontend, and caching support with Redis. The platform is structured to be easily extended and maintained.

---

## 🏗️ Architecture Overview

The Nobat platform consists of the following modules:

- **Backend (ASP.NET Core)**: Core API and business logic, structured with Clean Architecture, implementing the CQRS pattern, and using SignalR for real-time communication.
- **Frontend (TBD)**: Interactive web client (can be Vue.js, React, or other frameworks).  
- **Database (PostgreSQL)**: Stores all persistent data for the system.  
- **Redis**: Caching layer for fast data access.  
- **Docker Compose**: Orchestrates all services for easy setup and development.

---

## 📋 Prerequisites

Before running Nobat, ensure you have one of the following installed:

- **Docker** (v20+ recommended)  
- **Docker Compose** (v2+ recommended)  

Optional:

- Git (for cloning the repository)  

---

