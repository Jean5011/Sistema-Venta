# Sistema de ventas

## 1. Descripción general

**Sistema de ventas** es una aplicación de escritorio para Windows desarrollada en C# con Windows Forms. Permite autenticar usuarios, administrar clientes y productos, realizar facturas, generar informes y consultar facturas registradas.

El proyecto está dirigido a **.NET Framework 4.7.2** y utiliza SQL Server como sistema gestor de base de datos.

> Esta documentación refleja el comportamiento observado en el código fuente actual. No se incluye un script SQL completo en el repositorio, por lo que la estructura de base de datos se describe a partir de las consultas, procedimientos almacenados y DataSets disponibles.

## 2. Información del proyecto

| Elemento | Valor |
|---|---|
| Solución | `Sistema.sln` |
| Plataforma | Windows Forms |
| Lenguaje | C# |
| Framework | .NET Framework 4.7.2 |
| Tipo de salida principal | Aplicación Windows (`WinExe`) |
| Base de datos | Microsoft SQL Server |
| Proveedor de datos | `System.Data.SqlClient` |
| Informes | Microsoft ReportViewer |
| Arquitectura actual | Formularios, clases base, biblioteca auxiliar y acceso directo a datos |

## 3. Estructura de la solución

```text
/
├── Sistema.sln
├── DOCUMENTACION.md
├── Sistema de ventas/
│   ├── Sistema de ventas.csproj
│   ├── Program.cs
│   ├── App.config
│   ├── Login.cs
│   ├── Usuario.cs
│   ├── Administrador.cs
│   ├── ContenedorPrincipal.cs
│   ├── FormBase.cs
│   ├── Mantenimiento.cs
│   ├── Consulta.cs
│   ├── Procesos.cs
│   ├── MantenimientoCliente.cs
│   ├── MantenimientoProductos.cs
│   ├── ConsultaClientes.cs
│   ├── ConsultaProductos.cs
│   ├── Facturacion.cs
│   ├── GenerarFactura.cs
│   ├── ventas.cs
│   ├── DataSet1.xsd
│   ├── pruebademoDataSet.xsd
│   ├── InformeFactura.rdlc
│   ├── Properties/
│   ├── Resources/
│   ├── SqlServerTypes/
│   └── LibreriaDLL/
│       ├── LibreriaDLL.csproj
│       ├── Biblioteca.cs
│       └── errorTextBox.cs
└── Sistema ventas/
	└── Sistema ventas.vdproj
```

Los archivos `*.Designer.cs`, `*.resx`, `*.xsc` y `*.xss` son archivos generados o asociados al diseñador de Visual Studio. Los archivos `*.Designer.cs` no deben editarse manualmente salvo que sea imprescindible.

## 4. Inicio de la aplicación

El punto de entrada está en `Sistema de ventas/Program.cs`:

1. Se habilitan los estilos visuales de Windows Forms.
2. Se configura el modo compatible de representación de texto.
3. Se abre el formulario `Login`.

El usuario no entra directamente al menú principal: primero debe autenticarse contra la tabla `Usuarios`.

## 5. Módulos funcionales

### 5.1. Inicio de sesión

Archivo principal: `Login.cs`.

El formulario solicita una cuenta y una contraseña. Tras consultar `Usuarios`, guarda el identificador del usuario en la variable estática `Login.codigo`.

Según el campo `validar_admin`:

- Si es verdadero, abre `Administrador`.
- Si es falso, abre `Usuario`.

Los formularios de perfil cargan el nombre, la cuenta, el identificador y, opcionalmente, una imagen almacenada en la ruta indicada por el campo `Imagen`.

### 5.2. Perfil de administrador y usuario

Archivos:

- `Administrador.cs`
- `Usuario.cs`

Ambos formularios muestran información del usuario autenticado y permiten acceder a `ContenedorPrincipal`. Al cerrar estos formularios se llama a `Application.Exit()`.

El código de la aplicación no implementa una autorización detallada por cada operación. La diferenciación principal se realiza mediante el indicador `validar_admin` durante el inicio de sesión.

### 5.3. Contenedor principal

Archivo: `ContenedorPrincipal.cs`.

Es un formulario MDI que actúa como menú principal. Desde él se abren:

- Mantenimiento de clientes.
- Mantenimiento de productos.
- Consulta de clientes.
- Consulta de productos.
- Facturación.
- Consulta de ventas.

También contiene opciones generadas por la plantilla de formulario MDI, como organizar ventanas, mostrar u ocultar barra de herramientas y cerrar ventanas hijas. Las opciones genéricas de abrir, guardar, cortar, copiar y pegar no contienen una implementación de negocio completa.

### 5.4. Mantenimiento de clientes

Archivo: `MantenimientoCliente.cs`.

Hereda de `Mantenimiento` y permite:

- Validar los campos del cliente.
- Guardar o actualizar un cliente mediante `ActualizaClientes`.
- Eliminar un cliente mediante `EliminarCliente`.
- Limpiar el formulario.
- Abrir la consulta de clientes.

Los campos utilizados son el identificador, el nombre y el apellido.

### 5.5. Mantenimiento de productos

Archivo: `MantenimientoProductos.cs`.

Permite:

- Validar los datos del producto.
- Guardar o actualizar un producto mediante `ActualizaProductos`.
- Eliminar un producto mediante `EliminarProducto`.
- Limpiar el formulario.
- Abrir la consulta de productos.

Los campos utilizados son el identificador, la descripción y el precio.

### 5.6. Consulta de clientes

Archivo: `ConsultaClientes.cs`.

Al abrirse, carga los datos de `Clientes` en un `DataGridView`. El usuario puede buscar por coincidencia parcial del nombre mediante `LIKE`. También puede seleccionar una fila para devolverla al formulario de facturación.

### 5.7. Consulta de productos

Archivo: `ConsultaProductos.cs`.

Al abrirse, carga los datos de `Articulos` en un `DataGridView`. Permite buscar por coincidencia parcial del nombre del producto y seleccionar una fila para devolver el código, descripción y precio al formulario de facturación.

### 5.8. Facturación

Archivo: `Facturacion.cs`.

El flujo general es:

1. Cargar el vendedor a partir de `Login.codigo`.
2. Seleccionar o buscar un cliente.
3. Seleccionar o introducir un producto.
4. Indicar la cantidad.
5. Añadir el producto a la cuadrícula de detalle.
6. Si el producto ya existe en la factura, acumular la cantidad.
7. Calcular el importe de cada línea y el total.
8. Eliminar líneas si es necesario.
9. Registrar la cabecera mediante `ActualizarFacturas`.
10. Registrar cada línea mediante `ActualizarDetalles`.
11. Obtener los datos para el informe mediante `DatosFactura`.
12. Mostrar `GenerarFactura` con el informe.
13. Limpiar la factura para iniciar una nueva operación.

El total se calcula en memoria multiplicando precio por cantidad. Las variables `ContadorFila` y `total` son estáticas dentro del formulario.

### 5.9. Generación de factura

Archivo: `GenerarFactura.cs`.

Utiliza un control `ReportViewer` y el informe `InformeFactura.rdlc`. El DataSet `DataSet1` contiene la tabla `DatosFactura`, que se utiliza como origen de datos del informe.

### 5.10. Consulta de ventas

Archivo: `ventas.cs`.

Carga la información de `Facturas` y permite filtrar por `NumeroFactura`.

## 6. Clases base y reutilización

### `FormBase`

Es la clase base común de los formularios de negocio. Proporciona:

- Confirmación antes de cerrar.
- Métodos virtuales para `Guardar`, `Eliminar`, `Nuevo` y `Consultar`.

### `Mantenimiento`

Hereda de `FormBase` y conecta los botones de guardar, eliminar, nuevo y consulta con los métodos virtuales correspondientes.

### `Consulta`

Hereda de `FormBase` y contiene `MostrarInFoDG`, que obtiene todos los registros de una tabla y los devuelve como `DataSet` para mostrarlos en un `DataGridView`.

### `Procesos`

Hereda de `FormBase` y sirve como clase intermedia para procesos como la facturación.

## 7. Biblioteca `LibreriaDLL`

La biblioteca contiene utilidades compartidas por la aplicación principal.

### `Biblioteca.Herramientas`

Recibe una cadena SQL, abre una conexión a SQL Server, ejecuta un `SqlDataAdapter`, llena un `DataSet` y devuelve el resultado.

### `Biblioteca.ValidarFormulario`

Recorre los controles del formulario y busca controles personalizados `errorTextBox`. Comprueba:

- Campos obligatorios mediante `Validar`.
- Campos que no deben contener letras mediante `ValidarNumeros`.

Devuelve:

- `0`: sin error.
- `1`: existe un campo obligatorio vacío.
- `2`: existe texto en un campo que debe ser numérico.

### `errorTextBox`

Es un control que hereda de `TextBox` y añade las propiedades booleanas `Validar` y `ValidarNumeros`.

## 8. Base de datos

### 8.1. Conexiones configuradas

Las conexiones están definidas en `Sistema de ventas/App.config` y en `Properties/Settings.settings`:

- `sistemaConnectionString`: base de datos `sistema`.
- `pruebademoConnectionString`: base de datos `pruebademo`.

Ambas utilizan autenticación integrada de Windows y el servidor configurado es `DENJI5011\SQLEXPRESS`.

Para ejecutar la aplicación en otro equipo es necesario cambiar el servidor, la instancia y, si procede, el nombre de la base de datos.

### 8.2. Tablas observadas

A partir del código se utilizan las siguientes tablas o vistas:

| Tabla | Uso observado |
|---|---|
| `Usuarios` | Inicio de sesión, permisos básicos y datos del vendedor/usuario |
| `Clientes` | Consulta y selección de clientes |
| `Articulos` | Consulta y selección de productos |
| `Facturas` | Consulta de facturas registradas |

El DataSet `pruebademoDataSet.xsd` también contiene un esquema de ejemplo para una tabla `clientes` con columnas `ID`, `Cliente`, `Telefono` y `Correo`. Este esquema usa la conexión `pruebademoConnectionString` y puede corresponder a una versión anterior o alternativa del modelo.

### 8.3. Procedimientos almacenados utilizados

La aplicación invoca los siguientes procedimientos almacenados en la base de datos `sistema`:

- `ActualizaClientes`
- `EliminarCliente`
- `ActualizaProductos`
- `EliminarProducto`
- `ActualizarFacturas`
- `ActualizarDetalles`
- `DatosFactura`

Los parámetros exactos y la lógica transaccional de estos procedimientos no están incluidos en el repositorio; deben comprobarse en SQL Server.

### 8.4. Datos del informe

`DataSet1.xsd` define la tabla `DatosFactura` con campos como:

- `NumeroFactura`
- `FachaFactura` — nombre existente en el esquema; probablemente debería ser `FechaFactura`.
- `CodigoCliente`
- `PrecioVenta`
- `CantidadVenta`
- `nombre_cliente`
- `apellido_cliente`
- `nombre_producto`
- `Total`
- `total2`

## 9. Dependencias

Las dependencias NuGet configuradas en `packages.config` son:

- `Microsoft.Report.Viewer` versión `11.0.0.0`.
- `Microsoft.ReportingServices.ReportViewerControl.Winforms` versión `140.1000.523`.
- `Microsoft.SqlServer.Types` versión `14.0.314.76`.

También se utilizan referencias de .NET Framework como `System.Data`, `System.Windows.Forms`, `System.Drawing`, `System.Xml` y `System.Net.Http`.

## 10. Instalación y ejecución

### Requisitos

1. Windows.
2. Visual Studio con desarrollo de escritorio .NET instalado.
3. .NET Framework 4.7.2 Developer Pack o Targeting Pack.
4. SQL Server/SQL Server Express.
5. Base de datos `sistema` creada y con sus tablas y procedimientos almacenados.
6. Paquetes NuGet restaurados.
7. ReportViewer y SQL Server Types disponibles.

### Pasos

1. Abrir `Sistema.sln` en Visual Studio.
2. Comprobar que las dependencias NuGet se hayan restaurado.
3. Revisar las cadenas de conexión en `App.config`.
4. Confirmar que SQL Server esté iniciado y sea accesible.
5. Verificar que exista la base de datos `sistema`.
6. Verificar los procedimientos almacenados requeridos.
7. Configurar como proyecto de inicio `Sistema de ventas`.
8. Compilar en `Debug`.
9. Ejecutar y probar el inicio de sesión.

## 11. Estado actual y problemas conocidos

La compilación actual de la solución presenta el error `CS2001`: el proyecto `LibreriaDLL` incluye `Program.cs` en `LibreriaDLL.csproj`, pero ese archivo no se encuentra físicamente en la ruta esperada.

También se han observado estas incidencias técnicas:

- El proyecto principal referencia `LibreriaDLL` mediante `LibreriaDLL\bin\Debug\LibreriaDLL.dll` en lugar de una referencia de proyecto.
- El proyecto `LibreriaDLL` tiene `OutputType` `WinExe`, aunque funciona como biblioteca auxiliar.
- El proyecto `LibreriaDLL` tiene `RootNamespace` y `AssemblyName` con valores heredados o poco descriptivos (`Login.cs`).
- La cadena de conexión está fijada a un nombre de equipo concreto.
- Las consultas SQL se construyen concatenando valores introducidos por el usuario.
- Las contraseñas se comparan directamente en la consulta de inicio de sesión.
- Algunas excepciones se capturan y se descartan sin registrar información (`catch` vacío).
- El registro de cabecera y detalles de una factura se realiza en varias llamadas sin una transacción visible en la aplicación.
- El campo `FachaFactura` presenta una posible errata de nomenclatura.
- Existen dos modelos de conexión (`sistema` y `pruebademo`), lo que puede provocar confusión entre el modelo actual y el modelo de pruebas.
- Hay funcionalidades de la plantilla MDI —abrir, guardar, cortar, copiar y pegar— que están vacías o incompletas.

## 12. Recomendaciones de mantenimiento

Prioridad alta:

1. Corregir la referencia a `LibreriaDLL\Program.cs` y conseguir una compilación limpia.
2. Sustituir la referencia binaria por una referencia de proyecto.
3. Cambiar las consultas concatenadas por comandos parametrizados.
4. Proteger las contraseñas mediante hash y verificación segura.
5. Mover la configuración de conexión fuera del código fuente y documentar la configuración por entorno.

Prioridad media:

1. Usar `using` para garantizar el cierre de conexiones y recursos.
2. Añadir validación de filas vacías antes de acceder a `Rows[0]`.
3. Registrar excepciones con información técnica, sin mostrar detalles sensibles al usuario.
4. Utilizar `decimal` para precios y totales monetarios en lugar de `double`.
5. Ejecutar el registro de una factura y sus detalles dentro de una transacción.
6. Separar la lógica de acceso a datos de los formularios.

Prioridad baja:

1. Renombrar clases, métodos y campos con nombres consistentes.
2. Eliminar referencias y eventos sin uso.
3. Revisar la nomenclatura de campos como `FachaFactura`.
4. Añadir pruebas automatizadas para autenticación, mantenimiento y facturación.
5. Actualizar gradualmente la aplicación a una arquitectura mantenible antes de considerar una migración tecnológica.

## 13. Pruebas funcionales recomendadas

- Inicio de sesión con usuario válido.
- Inicio de sesión con contraseña incorrecta.
- Inicio de sesión cuando no existe ningún registro.
- Carga del perfil de administrador.
- Carga del perfil de usuario normal.
- Alta, actualización y eliminación de clientes.
- Alta, actualización y eliminación de productos.
- Búsqueda de clientes y productos.
- Selección de cliente y producto desde los diálogos de consulta.
- Acumulación de cantidades cuando se añade dos veces el mismo producto.
- Eliminación de una línea de factura.
- Cálculo del total.
- Generación e impresión/visualización del informe.
- Consulta de una factura por número.
- Comportamiento cuando SQL Server no está disponible.
- Comportamiento cuando la base de datos devuelve cero filas.

## 14. Resumen del flujo completo

```text
Inicio
  ↓
Login
  ↓
Validación contra Usuarios
  ↓
Administrador o Usuario
  ↓
ContenedorPrincipal
  ├── Clientes
  │   ├── MantenimientoCliente
  │   └── ConsultaClientes
  ├── Productos
  │   ├── MantenimientoProductos
  │   └── ConsultaProductos
  ├── Facturación
  │   ├── Selección de cliente
  │   ├── Selección de productos
  │   ├── Cálculo del total
  │   ├── ActualizarFacturas
  │   ├── ActualizarDetalles
  │   └── DatosFactura → InformeFactura.rdlc
  └── Ventas
	  └── Consulta de Facturas
```

## 15. Conclusión

El proyecto implementa un sistema básico de ventas funcional basado en Windows Forms, SQL Server, procedimientos almacenados y ReportViewer. La estructura contiene los módulos principales de un punto de venta, pero antes de utilizarlo en producción se debe corregir el error de compilación, revisar la configuración de base de datos y reforzar la seguridad y el acceso a datos.
