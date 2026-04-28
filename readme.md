# GESTIONES

Sistema de gestión de zonas deportivas y préstamos desarrollado en ASP.NET Core MVC con MySQL.

---

## Tecnologías

- **Backend:** ASP.NET Core MVC (.NET 8)
- **ORM:** Entity Framework Core + Pomelo (MySQL)
- **Base de datos:** MySQL
- **Frontend:** Razor Views + Bootstrap 5 + Bootstrap Icons

---

## Estructura del proyecto

```
GESTIONES/
├── Controllers/
│   ├── HomeController.cs
│   ├── deportesController.cs
│   ├── LoanController.cs
│   └── UserController.cs
├── Data/
│   └── DataContext.cs
├── Models/
│   ├── deporte.cs
│   ├── Loan.cs
│   ├── User.cs
│   └── ErrorViewModel.cs
├── Views/
│   ├── Shared/
│   │   └── _Layout.cshtml
│   ├── deportes/
│   │   ├── deportes.cshtml
│   │   ├── Show.cshtml
│   │   ├── Edit.cshtml
│   │   └── Create.cshtml
│   ├── arrenting/
│   │   ├── Loan.cshtml
│   │   ├── Show.cshtml
│   │   └── Create.cshtml
│   └── User/
│       ├── user.cshtml
│       ├── Show.cshtml
│       ├── Edit.cshtml
│       └── Create.cshtml
└── wwwroot/
```

---

## Modelos

### `deporte`
| Campo | Tipo | Descripción |
|---|---|---|
| Id | int | Clave primaria |
| tipo_espacio | string | Tipo de zona deportiva |
| Stock | int | Unidades disponibles |
| Description | string | Descripción |
| Author | string | Responsable |
| genero | string | Categoría |
| Quantity | int | Cantidad total |

### `User`
| Campo | Tipo | Descripción |
|---|---|---|
| Id | int | Clave primaria |
| Username | string | Nombre |
| lastname | string | Apellido |
| Email | string | Correo electrónico |
| number | int | Teléfono |
| dateRegistered | DateTime | Fecha de registro |

### `Loan`
| Campo | Tipo | Descripción |
|---|---|---|
| Id | int | Clave primaria |
| UserId | int | FK → Users |
| deporteid | int | FK → Deportes |
| StartDate | DateTime | Fecha de inicio |
| EndDate | DateTime? | Fecha de devolución |
| estado | string | Activo / Devuelto |

---

## Base de datos

Crear las tablas en este orden:

```sql
CREATE TABLE deportes (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    tipo_espacio VARCHAR(255) NOT NULL,
    Stock INT NOT NULL,
    Description VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    genero VARCHAR(255) NOT NULL,
    Quantity INT NOT NULL
);

CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(255) NOT NULL,
    lastname VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    number INT NOT NULL,
    dateRegistered DATETIME NOT NULL
);

CREATE TABLE Loans (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId INT NOT NULL,
    deporteid INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NULL,
    estado VARCHAR(50) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (deporteid) REFERENCES Deportes(Id)
);
```

---

## Rutas principales

| Ruta | Controlador | Descripción |
|---|---|---|
| `/deportes` | deportesController | Lista de zonas |
| `/deportes/CreaResult` | deportesController | Crear zona |
| `/deportes/Edit/{id}` | deportesController | Editar zona |
| `/deportes/Show/{id}` | deportesController | Detalle zona |
| `/Loan` | LoanController | Lista de préstamos |
| `/Loan/Create` | LoanController | Crear préstamo |
| `/Loan/Show/{id}` | LoanController | Detalle préstamo |
| `/Loan/Return/{id}` | LoanController | Devolver préstamo |
| `/User` | UserController | Lista de usuarios |
| `/User/Create` | UserController | Crear usuario |
| `/User/Edit/{id}` | UserController | Editar usuario |
| `/User/Show/{id}` | UserController | Detalle usuario |

---

## Configuración

1. Clonar el repositorio
2. Configurar la cadena de conexión en `appsettings.json`:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=prueba-wen;User=root;Password=tu_password;"
}
```

3. Crear las tablas en MySQL con los scripts de arriba
4. Ejecutar el proyecto:

```bash
dotnet run
```

---

## Lógica de stock

- Al registrar un préstamo, el `Stock` de la zona se **decrementa en 1**
- Al devolver un préstamo, el `Stock` se **incrementa en 1**
- Las zonas sin stock aparecen deshabilitadas en el formulario de préstamo

## github
*
git remote add origin https://github.com/TzerK-LAST/pruebaDeC.git