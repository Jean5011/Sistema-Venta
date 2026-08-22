# 📦 Sistema de Ventas y Facturación (.NET Framework / Windows Forms)

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Windows Forms](https://img.shields.io/badge/GUI-Windows%20Forms-0078D7?style=for-the-badge&logo=windows&logoColor=white)](#)
[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC292B?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![ReportViewer](https://img.shields.io/badge/Reports-Microsoft%20ReportViewer%20(RDLC)-F25022?style=for-the-badge)](#)

Aplicación de escritorio para la administración comercial, gestión de clientes y productos, emisión de facturas con cálculo en tiempo real y generación de informes imprimibles mediante **Microsoft ReportViewer (RDLC)**, desarrollada en **C# (.NET Framework 4.7.2)** con interfaz **MDI (Multiple Document Interface)** y persistencia en **Microsoft SQL Server**.

---

## 🚀 Módulos y Funcionalidades

* 🔐 **Control de Acceso y Perfiles de Usuario:**
  * Autenticación contra base de datos con diferenciación de privilegios (`Administrador` / `Usuario`).
  * Carga dinámica de perfiles con nombre, identificador y fotografía de usuario.
* 👥 **Mantenimiento y Consulta de Clientes:**
  * Alta, baja, modificación y consulta reactiva con filtrado en tiempo real mediante `LIKE`.
  * Integración con diálogos de búsqueda para selección directa durante la facturación.
* 📦 **Mantenimiento y Consulta de Productos (Artículos):**
  * Gestión de catálogo (código, descripción y precio unitario).
  * Búsqueda dinámica y selección asistida para composición de ventas.
* 🧾 **Módulo de Facturación:**
  * Carga contextual del vendedor autenticado y asociación del cliente seleccionado.
  * Adición de artículos con acumulación automática de cantidades y cálculo reactivo de subtotales y totales.
  * Persistencia de cabecera (`Facturas`) y líneas de detalle (`DetalleFactura`) mediante procedimientos almacenados.
* 📊 **Reportes e Impresión (RDLC):**
  * Generación visual e impresión de comprobantes de venta a través de **Microsoft ReportViewer** alimentado por esquemas `DataSet` fuertemente tipados.
* 🔍 **Historial y Consulta de Ventas:**
  * Visualización y filtrado rápido de comprobantes emitidos por número de factura.

---

## 🏗️ Flujo de Navegación y Procesos

```
[ Inicio de la Aplicación ]
            │
            ▼
     [ Form: Login ] ──► Validación de Credenciales
            │
   ┌────────┴────────┐
   ▼                 ▼
[ Administrador ] [ Usuario ]
   └────────┬────────┘
            ▼
 ┌─────────────────────────────────────────────────────────────┐
 │           CONTENEDOR PRINCIPAL (Interfaz MDI)               │
 ├────────────────┬─────────────────┬──────────────────────────┤
 │ Clientes       │ Productos       │ Facturación & Ventas     │
 │ • Mantenimiento│ • Mantenimiento │ • Facturación en vivo    │
 │ • Consulta     │ • Consulta      │ • ReportViewer (RDLC)    │
 │                │                 │ • Consulta de Ventas     │
 └────────────────┴─────────────────┴──────────────────────────┘
```

---

## 🛠️ Stack Tecnológico y Dependencias

| Componente | Tecnología | Detalle |
|---|---|---|
| **Plataforma & Lenguaje** | C# / .NET Framework 4.7.2 | Base de ejecución en entorno Windows Forms |
| **Arquitectura de UI** | MDI (Multiple Document Interface) | Ventanas hijas organizadas dentro de un contenedor maestro |
| **Acceso a Datos** | ADO.NET (`System.Data.SqlClient`) | Conexión directa y ejecución de `Stored Procedures` |
| **Motor de Base de Datos** | Microsoft SQL Server | Persistencia relacional (`Usuarios`, `Clientes`, `Articulos`, `Facturas`) |
| **Motor de Informes** | Microsoft ReportViewer (RDLC) | Generación y previsualización de facturas |
| **Validaciones** | `LibreriaDLL` (Custom Component) | Control personalizado `errorTextBox` para reglas de UI |

---

## 📁 Estructura de la Solución

```text
├── Sistema.sln                         # Solución principal de Visual Studio
├── DOCUMENTACION.md                    # Documentación técnica exhaustiva
│
├── Sistema de ventas/                  # Proyecto Principal (Windows Forms)
│   ├── Program.cs                      # Punto de entrada de la aplicación
│   ├── App.config                      # Cadenas de conexión a SQL Server
│   │
│   ├── Login.cs                        # Formulario de autenticación
│   ├── Administrador.cs / Usuario.cs   # Pantallas de perfil por rol
│   ├── ContenedorPrincipal.cs          # Formulario contenedor MDI principal
│   │
│   ├── FormBase.cs                     # Clase base para formularios de negocio
│   ├── Mantenimiento.cs                # Clase base para operaciones CRUD
│   ├── Consulta.cs                     # Clase base para vistas con DataGridView
│   ├── Procesos.cs                     # Clase base para operaciones transaccionales
│   │
│   ├── MantenimientoCliente.cs         # CRUD de clientes
│   ├── MantenimientoProductos.cs       # CRUD de productos
│   ├── ConsultaClientes.cs             # Búsqueda y selección de clientes
│   ├── ConsultaProductos.cs            # Búsqueda y selección de productos
│   ├── Facturacion.cs                  # Emisión y procesamiento de ventas
│   ├── GenerarFactura.cs               # Visor de reporte RDLC
│   ├── ventas.cs                       # Consulta histórica de facturas
│   │
│   ├── DataSet1.xsd                    # Esquema tipado para reporte de factura
│   ├── InformeFactura.rdlc             # Plantilla de diseño del reporte
│   └── LibreriaDLL/                    # Biblioteca de clases auxiliar
│       ├── Biblioteca.cs               # Helpers de conexión y validación
│       └── errorTextBox.cs             # Control extendido con validación integrada
│
└── Sistema ventas/                     # Proyecto de despliegue / instalador
```

---

## ⚙️ Configuración y Puesta en Marcha

### 1. Prerrequisitos
* Windows 10/11.
* [Visual Studio](https://visualstudio.microsoft.com/) con la carga de trabajo de desarrollo de escritorio de .NET.
* .NET Framework 4.7.2 Developer Pack.
* Microsoft SQL Server / SQL Server Express.

### 2. Configuración de Base de Datos
Actualizar la cadena de conexión en `Sistema de ventas/App.config` con los datos de tu servidor local:

```xml
<connectionStrings>
  <add name="sistemaConnectionString"
       connectionString="Data Source=TU_SERVIDOR\SQLEXPRESS;Initial Catalog=sistema;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 3. Compilación y Ejecución
1. Abrir `Sistema.sln` en Visual Studio.
2. Restaurar paquetes NuGet (ReportViewer y tipos SQL).
3. Establecer `Sistema de ventas` como proyecto de inicio.
4. Compilar en configuración `Debug` o `Release` y presionar `F5`.

---

## 👨‍💻 Autor

**Jean Pierre Esquen** — *Desarrollador Backend & Software Engineer*
