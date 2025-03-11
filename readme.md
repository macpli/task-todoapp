# My Solution to the assignment
I have created the TODO List application with all the required CRUD functionalities and written tests for them.

## Frontend
I've used the provided template and created a simple client UI with tailwindcss and some lucid icons. 

You can:
- view tasks
- create tasks
- rename tasks ( by clicking on the text )
- delete tasks
- change state from completed to not completed

## Backend
I have chosen to go with the simple route of using in-memory storage.
Folders: Controllers, Models, Repositories have been created for better project organisation.
All required CRUD operations have been implemented and tested using xUnit.

# TodoList Assignment  

Build a **TODO list application** with a **React frontend** and a **C# backend API**.  

Write an **integration test** using xUnit on the backend to verify that all **CRUD (Create, Read, Update, Delete)** operations work correctly.  

## Instructions  

1. **Clone this repository**, make the necessary updates, and push your changes to your **GitHub account**.  
2. Implement both the **frontend** and **backend** as described below.  

## Frontend  

- Start from provided **empty React app**, created using [React’s official guide](https://react.dev/learn/creating-a-react-app).  
- Design and implement a **TODO list UI** that allows users to:  
  - **Add** new items  
  - **Rename** existing items  
  - **Remove** items  
- The frontend **must communicate with the backend API** for all CRUD operations.  

## Backend  

- Start from provided **empty C# Web API project** along with an **empty xUnit test project**.  
- Use any **persistence method** of your choice:  
  - **Relational DB**, **document DB**, **filesystem**, or **in-memory storage**.  
- Implement **CRUD endpoints** for managing TODO items.  
- Write **integration tests** in xUnit that call the real API endpoints to validate that all CRUD operations work correctly.  

