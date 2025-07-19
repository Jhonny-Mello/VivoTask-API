# Enterprise Backend Services - API & Web

> **Note:** This repository is a portfolio piece. The code is intended for architectural and stylistic review and is not meant for production deployment in its current state.

---

## About The Project

This repository contains the backend services for a multifaceted enterprise system, featuring an **ASP.NET Core API** and an administrative **Blazor Server Web App**.

These services were developed to act as a central hub, providing data and business logic for a variety of clients, including:

* A cross-platform **.NET MAUI** mobile application.
* Several internal **Blazor** web applications.
* Various **automation scripts** and data reporting tasks.

The solution was deployed on-premises to an IIS instance on a Windows Server. To provide secure access for users outside the private network, it was connected to a **Microsoft Power Automate On-Premises Gateway**, which exposed specific API functionalities through cloud-based workflows.

The purpose of this repository is to demonstrate my coding style, architectural decision-making, and approach to solving common challenges in an enterprise environment.

---

## Architectural Notes & Rationale

The design of this project was guided by the practical constraints and requirements of its environment.

### 1. Centralized Core Logic

A key architectural choice was to consolidate all business logic, data models, and database interactions into a single shared class library.

* **Rationale**: This backend was the template for six other similar projects. A centralized core library made it efficient to maintain consistency and reuse code, significantly reducing development time when spinning up new, related applications.

### 2. Database Integration Strategy

The data access layer, including the large `DbContext`, was created by **reverse-engineering an existing and database**.

* **Rationale**: Working with established, large-scale databases is a common scenario. This pragmatic approach was taken to ensure the application correctly mapped to the existing schema and to avoid the time-intensive and error-prone process of creating hundreds of data models by hand.

### 3. Service-Oriented Structure

The solution is split into two primary projects: a RESTful API and a Blazor Server web application.

* **Rationale**: This separation of concerns was deliberate. The API served as a dedicated backend for client applications (like the MAUI app), while the Blazor project provided a distinct interface for internal administrative tasks. This keeps the roles clear and the projects easier to maintain.

---

## Technology Stack

* **Framework:** .NET 6
* **API:** ASP.NET Core Web API
* **Web UI:** Blazor Server
* **ORM:** Entity Framework Core
* **Database:** Microsoft SQL Server
* **Deployment:** IIS on Windows Server
* **Cloud Integration:** Microsoft Power Automate & On-Premises Data Gateway