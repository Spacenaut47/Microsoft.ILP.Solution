# Microsoft ILP Solution

## 🔧 Tech Stack

- .NET 9 (C#)
- Microservice Architecture
- REST APIs
- Razor Pages (MVC)
- AutoMapper
- JSON-based storage (no DB)

---

## 🧩 Projects Overview

### ✅ Microsoft.ILP.UserService
- Handles user registration, login
- Issues JWT tokens
- Saves users to `users.json`

### ✅ Microsoft.ILP.ProductService
- Full CRUD for products
- Persists data to `products.json`
- DTOs, services, and repository pattern

### ✅ Microsoft.ILP.Web
- ASP.NET MVC frontend
- Login/Register pages
- Product Create/Edit/Delete/List
- Communicates with APIs using `HttpClient`

---

## ▶️ Running the Project in VS Code

1. Open `Microsoft.ILP.Solution` folder in VS Code
2. Use the `.vscode/launch.json` to run all services
3. Access:
   - WebApp: `https://localhost:7181`| Or Check the port numbers in the files
   - ProductService: `https://localhost:7171/swagger` | Or Check the port numbers in the files
   - UserService: `https://localhost:7166/swagger` | Or Check the port numbers in the files

---

## ✅ Completed Features

- ✅ JWT-based login/register
- ✅ Product management (CRUD)
- ✅ Razor pages connected to microservices
- ✅ Swagger for API testing

---

## 🔜 Future (Optional)
- Add OrderService
- Add product filtering/pagination
- Admin dashboard view

## ✅ Tree - 
├───.vscode
├───Microsoft.ILP.ProductService
│   ├───bin
│   │   └───Debug
│   │       └───net9.0
│   │           └───Data
│   ├───Controllers
│   ├───Data
│   ├───DTOs
│   ├───Mapping
│   ├───Models
│   ├───obj
│   │   └───Debug
│   │       └───net9.0
│   │           ├───ref
│   │           ├───refint
│   │           └───staticwebassets
│   ├───Properties
│   ├───Repositories
│   └───Services
├───Microsoft.ILP.UserService
│   ├───bin
│   │   └───Debug
│   │       └───net9.0
│   │           └───Data
│   ├───Controllers
│   ├───Data
│   ├───DTOs
│   ├───Mapping
│   ├───Models
│   ├───obj
│   │   └───Debug
│   │       └───net9.0
│   │           ├───ref
│   │           ├───refint
│   │           └───staticwebassets
│   ├───Properties
│   ├───Repositories
│   └───Services
└───Microsoft.ILP.Web
    ├───bin
    │   └───Debug
    │       └───net9.0
    ├───Controllers
    ├───DTOs
    ├───Models
    ├───obj
    │   └───Debug
    │       └───net9.0
    │           ├───compressed
    │           ├───ref
    │           ├───refint
    │           ├───scopedcss
    │           │   ├───bundle
    │           │   ├───projectbundle
    │           │   └───Views
    │           │       └───Shared
    │           └───staticwebassets
    ├───Properties
    ├───Services
    ├───Settings
    ├───Views
    │   ├───Account
    │   ├───Home
    │   ├───Product
    │   └───Shared
    └───wwwroot
        ├───css
        ├───js
        └───lib
            ├───bootstrap
            │   └───dist
            │       ├───css
            │       └───js
            ├───jquery
            │   └───dist
            ├───jquery-validation
            │   └───dist
            └───jquery-validation-unobtrusive
                └───dist
