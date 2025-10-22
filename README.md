# 🧩 NTierArch Task

This project is part of an **ITI session task** demonstrating how to implement an **N-Tier Architecture** using **ASP.NET Core MVC**.

## 📘 Overview
The system manages **Departments** and **Employees**:

- Each **Department** can have many **Employees**.
- Each **Employee** belongs to only one **Department**.

## 🏗️ Architecture Layers
- **PL (Presentation Layer):** ASP.NET Core MVC project for UI.  
- **BLL (Business Logic Layer):** Contains the business rules and logic.  
- **DAL (Data Access Layer):** Handles database access using Entity Framework Core.

## ⚙️ Features
- Add, edit, delete, and view departments and employees.  
- Implemented relation between Department and Employee.  
- Applied **Localization** (Arabic & English) with RTL layout for Arabic.  

## 🛠️ Technologies Used
```text
- ASP.NET Core MVC
- Entity Framework Core (Code First)
- SQL Server
- C#
