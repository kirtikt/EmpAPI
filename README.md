Technology Stack:
Language: C#

Framework: ASP.NET Core (.NET 8)

Architecture: MVC-style with a focus on API development

Database: Entity Framework Core (code-first approach)


📂 Key Components:
1. Models
Employee.cs: Represents an employee entity with properties like Id, Name, Salary, and a reference to Department.

Department.cs: Simple model holding department data (Deptid, Deptname).

2. Repository Layer
Appdbcontext.cs: Inherits from DbContext, sets up DbSet<Employee> and DbSet<Department> for database interactions.

3. Services Layer
IEmployeeService.cs: Interface defining operations like GetAll(), AddEmployee(), DeleteEmployee(), etc.

SqlEmployeeService.cs: Concrete implementation using Appdbcontext to perform database operations.

4. Controllers
EmployeeController.cs: Defines HTTP endpoints (GET, POST, DELETE) for interacting with employee data. Delegates logic to the service layer.

5. Program.cs
Configures services and sets up middleware for the application, including:

Adding DbContext with SQL Server

Registering services

Enabling Swagger for API documentation
