<h1 align="center">Proyecto Programación II — Chatbot</h1>

<p align="center">
  Proyecto del curso <b>Programación II</b>, Universidad Católica del Uruguay.<br>
  Integrantes: <b>Horacio Díaz</b>, <b>Andrés Charpentié</b> y <b>Andrés Rodriguéz</b>.
</p>

## 🗂️ Organización del equipo

La planificación y división de tareas se realiza en **Trello**

🔗 [Tablero Trello](https://trello.com/invite/b/68ee454952ea5cb366736671/ATTI47495b8d46b377d3fb5435bbe7c2c4ea144F20E7/proyecto-p2)

## 🧩 Diagrama de Clases (Mermaid)

El diseño de clases fue hecho con **Mermaid** para tener una idea de qué clases serían necesarias para llevar a cabo este proyecto previamente a hacerlo.

🔗 [Abrir en Mermaid](https://www.mermaidchart.com/app/projects/d3c42d9d-aa06-4e81-b08e-e9ba599f56fb/diagrams/e8dd9a10-86d6-4e84-8737-7c0717ca9ea4/version/v0.1/edit)

```mermaid
---
config:
  theme: mc
  look: neo
---
classDiagram
direction TB
    class Cliente {
	    +string Id
	    +string Nombre
	    +string Apellido
	    +string Telefono
	    +string Correo
	    +string Genero
	    +List~string~ Etiquetas
	    +string FechaDeNacimiento
	    +Cliente(id: string, nombre: string, apellido: string, telefono: string, correo: string)
	    +CambiarNombre(nuevoNombre: string) void
	    +CambiarApellido(nuevoApellido: string) void
	    +CambiarTelefono(nuevoTelefono: string) void
	    +CambiarCorreo(nuevoCorreo: string) void
	    +AsignarGenero(nuevoGenero: string) void
	    +AsignarEtiqueta(nuevaEtiqueta: string) void
	    +AsignarFechaDeNacimiento(nuevaFecha: string) void
	    +ToString() string
    }
    class RepoClientes {
	    - List~Cliente~ Clientes
	    + IEnumerable~Cliente~ Clientes2
	    - RepoEtiquetas etiquetas
	    - RepoUsuarios usuarios
	    + RepoClientes(RepoEtiquetas etiquetas, RepoUsuarios usuarios)
	    + AgregaCliente(Cliente cliente)
	    + EliminarCliente(Cliente cliente)
	    + BuscarCliente(string atributo, string valorBusqueda) List~Cliente~
	    + BuscarUnCliente(string ClienteId) Cliente
    }
    class RepoEtiquetas {
	    - List~string~ Etiquetas
	    + void AgregarEtiqueta(string etiqueta)
	    + bool BuscarEtiqueta(string etiqueta)
    }
    class RepoUsuarios {
	    +List Usuarios
	    +List Administradores
	    +List Vendedores
	    +List ClientesTotales
	    +AgregarUsuario(usuario: Usuario) void
	    +EliminarUsuario(usuario: Usuario) void
	    +BuscarUsuario(id: string) Usuario
	    +BuscarVendedor(id: string) Vendedor
	    +BuscarAdministrador(id: string) Administrador
	    +BuscarCliente(id: string) Cliente
    }
    class Vendedor {
	    + List~Cliente~ Clientes
	    + string Id
	    + string NombreCompleto
	    + Vendedor(string id, string nombre)
	    + AsignarCliente(Cliente cliente, Vendedor vendedor)
    }
    class Usuario {
	    - string ID
	    - string Nombre
	    - List~Interaccion~ InteraccionesUsuario
	    - List~Venta~ TotalVentas
	    - List~Venta~ VentaCliente
	    - List~Cotizacion~ CotizacionesUsuario
	    + Usuario(string id, string nombre)
	    + Recordatorio(string que, string cuando) void
	    + VentaClienteAdd(Venta venta) void
	    + AgregarCotizacion(Cotizacion cotizacion) void
	    + AgregarInteraccion(Interaccion interaccion) void
    }
    class Administrador {
	    + List~Usuario~ UsuariosSuspendidos
	    + Administrador(string id, string nombre)
    }
    class Interaccion {
	    + string Notas
	    + Cliente Cliente
	    + Usuario Usuario
	    + string Tema
	    + DateTime Fecha
	    + TipoInterracion Tipo
	    + string Contenido
	    + string Lugar
	    + Interaccion(Usuario usuario, Cliente cliente, string tema, string contenido, string cuando = "00/00/0000")
	    + AgergarNotas(string notas) void
	    # FechaIncorrecta(DateTime fecha) void
    }
    class Venta {
	    +Cliente Cliente
	    +string Producto
	    +DateTime Fecha
	    +string Importe
	    +Venta(cliente: Cliente, producto: string, fecha: DateTime, importe: string)
	    +Resumen() string
    }
    class Cotizacion {
	    + Cliente Cliente
	    + DateTime Fecha
	    + string Importe
	    + Cotizacion(Cliente cliente, DateTime fecha, string importe)
	    + Resumen() string
    }
    class TipoInterracion {
	    Mensaje
	    Llamada
	    Reunion
	    Correo
	    Nada
    }
    class Llamadas {
	    + Llamadas(Usuario usuario, Cliente cliente, string tema, string llamada, string cuando)
    }
    class Mensajes {
	    + Mensajes(Usuario usuario, Cliente cliente, string tema, string mensaje, string cuando)
    }
    class Correos {
	    + Correos(Usuario usuario, Cliente cliente, string tema, string correo, string cuando)
    }
    class Reunion {
	    + Reunion(Usuario usuario, Cliente cliente, string tema, string lugar, string reunion, string cuando)
	    # FechaIncorrecta(DateTime fecha) void
    }
    class RepoCotizaciones {
	    - List~Cotizacion~ Cotizaciones
	    + void AgregarCotizacion(Cliente cliente, string cuando, string precio, Usuario usuario)
    }
    class RepoInteracciones {
	    - List~Interaccion~ Interacciones
	    + IEnumerable~Interaccion~ Interacciones2
	    + Interaccion BuscarInteraccion(Usuario usuario, string tipo, string tema)
	    + List~Interaccion~ BuscarInteraccion(Usuario usuario, Cliente cliente, string tipo="", string fecha1="")
	    + void AgregarInteraccion(Interaccion interaccion, Usuario usuario)
	    + Dictionary~Cliente,Interaccion~ UltimasInteraccionesClientes(Usuario usuario)
	    + void eliminarinteraciones()
    }
    class RepoVentas {
	    - List~Venta~ Ventas
	    + void AgregarVenta(Cliente cliente, string cuando, string precio, string producto, Usuario usuario)
    }
    class Fachada {
	    - instancia : Fachada
	    - ClientesContacto : Dictionary~
	    - Etiquetas : RepoEtiquetas
	    - Clientes : RepoClientes
	    - Interacciones : RepoInteracciones
	    - Cotizaciones : RepoCotizaciones
	    - Ventas : RepoVentas
	    - Usuarios : RepoUsuarios
	    - UsuariosSuspendidos : List
	    + Instancia : Fachada
	    + RegistarMensaje(clienteId, mensaje, tema, usuarioId, cuando) string
	    + RegistrarCorreo(clienteId, correo, tema, usuarioId, cuando) string
	    + RegistarLlamada(clienteId, llamada, tema, usuarioId, cuando) string
	    + RegistarReunion(clienteId, reunion, tema, usuarioId, cuando, lugar) string
	    + AgregarNota(nota, tipointeraccion, tema, usuarioId) string
	    + InteraccionesCliente(clienteId, usuarioId, tipo, fecha) string
	    + InterraccionClienteAusente(usuarioId) string
	    + Panel(usuarioId) string
	    + AgregarClienteContacto(usuarioId, clienteId) string
	    + VerClienteContacto(usuarioId) string
	    + CrearEtiqueta(etiqueta, idUsuario) string
	    + AgregarEtiquetaCliente(clienteId, etiqueta, usuarioId) string
	    + RegistrarVenta(clienteId, producto, fecha, precio, usuarioId) void
	    + RegistarCotizacion(clienteId, fecha, precio, usuarioId) void
	    + CrearUsuario(id, nombre, idAdmin) string
	    + SuspenderUsuario(idSuspender, idAdmin) string
	    + EliminarUsuario(idEliminar, idAdmin) string
	    + AsignarClienteAOtroVendedor(idVendedorActual, idVendedorNuevo, nombreCliente, apellidoCliente) void
	    + BuscarClientesFachada(atributo, valorBusqueda) List~Cliente~
	    + CrearNuevoCliente(id, nombre, apellido, telefono, correo) Cliente
	    + ModificarInfo(id, atributo, nuevoValor) void
	    + EliminarClienteFachada(id) void
	    + VerClientes() RepoClientes
	    + BuscarUsuario(usuarioId) Usuario
	    + RegistrarVentaCliente(clienteId, producto, fecha, precio, usuarioId) string
	    + TotalDeVentasEnPeriodo(usuarioId, fechaInicioTexto, fechaFinTexto) string
    }
    class Excepciones {
    }
    class InvalidDateException {
	    +InvalidDateException(string mensaje = null)
    }
    class EmptyStringException {
	    +EmptyStringException(string mensaje = null)
    }
    class Exception {
    }

	<<enumeration>> TipoInterracion
	<<singleton>> Fachada

    Excepciones <|-- InvalidDateException
    Excepciones <|-- EmptyStringException
    InvalidDateException --|> Exception
    EmptyStringException --|> Exception
    RepoClientes "1" --> "*" Cliente
    RepoClientes "1" --> "1" RepoEtiquetas
    RepoClientes "1" --> "1" RepoUsuarios
    Vendedor --|> Usuario
    Administrador --|> Usuario
    Vendedor "1" --> "*" Cliente
    Administrador "1" --> "*" Usuario
    Usuario "1" o-- "*" Interaccion
    Usuario "1" o-- "*" Venta
    Usuario "1" o-- "*" Cotizacion
    Interaccion "1" o-- "1" Cliente
    Interaccion "1" o-- "1" Usuario
    Interaccion *-- TipoInterracion
    Llamadas --|> Interaccion
    Mensajes --|> Interaccion
    Correos --|> Interaccion
    Reunion --|> Interaccion
    Cotizacion "1" o-- "1" Cliente
    RepoUsuarios --> "0..*" Usuario
    RepoInteracciones --> Interaccion
    RepoInteracciones --> Usuario
    RepoInteracciones --> Cliente
    RepoVentas --> Venta
    RepoVentas --> Cliente
    RepoVentas --> Usuario
    RepoCotizaciones "1" --> "*" Cotizacion

	style Cliente stroke:#FF5978,fill:#FFDFE5,color:#8E2236

	style Vendedor stroke:#46EDC8,fill:#DEFFF8,color:#378E7A
	style Usuario stroke:#374D7C,fill:#E2EBFF,color:#374D7C
	style Administrador stroke:#46EDC8,fill:#DEFFF8,color:#378E7A
	style Venta stroke:#FBB35A,fill:#FFEFDB,color:#8F632D
	style Cotizacion stroke:#46EDC8,fill:#DEFFF8,color:#378E7A

	style Reunion stroke:#FF5978,fill:#FFDFE5,color:#8E2236

	style Fachada stroke:#46EDC8,fill:#DEFFF8,color:#378E7A

	class RepoClientes:::Sky
	class RepoEtiquetas:::Peach
	class RepoUsuarios:::Peach
	class Interaccion:::Peach
	class TipoInterracion:::Sky
	class Llamadas:::Aqua
	class Mensajes:::Rose
	class Correos:::Sky
	class RepoCotizaciones:::Aqua
	class RepoInteracciones:::Peach
	class RepoVentas:::Rose
	class Excepciones:::Peach
	class InvalidDateException:::Rose
	class EmptyStringException:::Sky
	class Exception:::Aqua

	classDef Sky :,stroke-width:1px,stroke-dasharray:none,stroke:#374D7C,fill:#E2EBFF,color:#374D7C,stroke-width:1px,stroke-dasharray:none,stroke:#374D7C,fill:#E2EBFF,color:#374D7C,stroke-width:1px,stroke-dasharray:none,stroke:#374D7C,fill:#E2EBFF,color:#374D7C,stroke-width:1px,stroke-dasharray:none,stroke:#374D7C,fill:#E2EBFF,color:#374D7C
	classDef Peach :,stroke-width:1px,stroke-dasharray:none,stroke:#FBB35A,fill:#FFEFDB,color:#8F632D,stroke-width:1px,stroke-dasharray:none,stroke:#FBB35A,fill:#FFEFDB,color:#8F632D,stroke-width:1px,stroke-dasharray:none,stroke:#FBB35A,fill:#FFEFDB,color:#8F632D,stroke-width:1px,stroke-dasharray:none,stroke:#FBB35A,fill:#FFEFDB,color:#8F632D,stroke-width:1px,stroke-dasharray:none,stroke:#FBB35A,fill:#FFEFDB,color:#8F632D
	classDef Aqua :,stroke-width:1px,stroke-dasharray:none,stroke:#46EDC8,fill:#DEFFF8,color:#378E7A,stroke-width:1px,stroke-dasharray:none,stroke:#46EDC8,fill:#DEFFF8,color:#378E7A,stroke-width:1px,stroke-dasharray:none,stroke:#46EDC8,fill:#DEFFF8,color:#378E7A
	classDef Rose :,stroke-width:1px,stroke-dasharray:none,stroke:#FF5978,fill:#FFDFE5,color:#8E2236,stroke-width:1px,stroke-dasharray:none,stroke:#FF5978,fill:#FFDFE5,color:#8E2236,stroke-width:1px,stroke-dasharray:none,stroke:#FF5978,fill:#FFDFE5,color:#8E2236

```

## 💻 Comandos e historias

| Historias | Comandos |
| --------- | -------- |
| Como usuario quiero crear un nuevo cliente con su información básica: nombre, apellido, teléfono y correo electrónico, para poder contactarme con ellos cuando lo necesite. | <b>!nuevoCliente</b> nombre apellido telefono correo |
| Como usuario quiero modificar la información de un cliente existente, para mantenerla actualizada. | <b>!modfInfo</b> id atributo nuevoValor |
| Como usuario quiero eliminar un cliente, para mantener limpia la base de datos. | <b>!eliminarCliente</b> id |
| Como usuario quiero buscar clientes por nombre, apellido, teléfono o correo electrónico, para identificarlos rápidamente. | <b>!buscarCliente</b> atributo busqueda |
| Como usuario quiero ver una lista de todos mis clientes, para tener una vista general de mi cartera. | <b>!verClientes</b> |
| Como usuario quiero registrar llamadas enviadas o recibidas de clientes, incluyendo cuándo fueron y de qué tema trataron, para poder saber mis interacciones con los clientes. | <b>!registrarLlamada</b> clienteId llamada tema usuarioId fecha |
| Como usuario quiero registrar reuniones con los clientes, incluyendo cuándo y dónde fueron, y de qué tema trataron, para poder saber mis interacciones con los clientes. | <b>!registrarReunion</b> clienteId reunion tema usuarioId fecha lugar |
| Como usuario quiero registrar mensajes enviados a o recibidos de los clientes, incluendo cuándo y de qué tema fueron, para poder saber mis interacciones con los clientes. | <b>!registrarMensaje</b> clienteId mensaje tema usuarioId fecha |
| Como usuario quiero registrar correos electrónicos enviados a o recibidos de los clientes, incluendo cuándo y de qué tema fueron, para poder saber mis interacciones con los clientes. | <b>!registrarCorreo</b> clienteId correo tema usuarioId fecha |
| Como usuario quiero agregar notas o comentarios a las llamadas, reuniones, mensajes y correos enviados o recibidos de los clientes, para tener información adicional de mis interacciones con los clientes. | <b>!agregarNota</b> tipoInteraccion tema usuarioId |
| Como usuario quiero registrar otros datos de los clientes como género y fecha de nacimiento de los clientes, para realizar campañas y saludarlos en sus cumpleaños. | <b>!modfInfo</b> id atributo nuevoValor |
| Como usuario quiero poder definir etiquetas para poder organizar y segmentar a mis clientes. | <b>!crearEtiqueta</b> usuarioId etiqueta |
| Como usuario quiero poder agregar una etiqueta a un cliente, para luego organizar y segmentar mi cartera de clientes. | <b>!agregarEtiqueta</b> clienteId etiqueta usuarioId |
| Como usuario quiero poder registrar una venta a un cliente, incluyendo qué le vendí, cuándo se lo vendí y cuánto le cobré, para saber lo que compran los clientes. | <b>!registrarVenta</b> clienteId producto fecha precio usuarioId |
| Como usuario quiero poder registrar que le envié una cotización a un cliente, cuándo se la mandé y por qué importe es la cotización, para hacer seguimiento de oportunidades de venta. | <b>!registrarCotiz</b> clienteId fecha precio usuarioId |
| Como usuario quiero ver todas las interacciones de un cliente, con o sin filtro por tipo de interacción y por fecha, para entender el historial de la relación comercial. | <b>!interaccionCliente</b> clienteId usuarioId tipo fecha |
| Cómo usuario quiero saber los clientes que hace cierto tiempo que no tengo ninguna interacción con ellos, para no peder contacto con ellos. | <b>!clienteAusente</b> usuarioId |
| Como usuario quiero saber los clientes que se pusieron en contacto conmigo y no les contesté hace cierto tiempo, para no dejar de responder mensajes o llamadas. | <b>!clienteContacto</b> usuarioId |
| Como administrador quiero crear usuarios. | <b>!crearUsuario</b> usuarioId nombre adminId |
| Como administrador quiero eliminar usuarios. | <b>!eliminarUsuario</b> usuarioId adminId |
| Como administrador quiero suspender usuarios. | <b>!suspenderUsuario</b> usuarioId adminId |
| Como vendedor, quiero poder asignar un cliente a otro vendedor para distribuir el trabajo en el equipo. | <b>!asignarCliente</b> clienteId vendedorId |
| Como usuario quiero saber el total de ventas de un periodo dado, para analizar en rendimiento de mi negocio. | <b>!totalVentas</b> usuarioId fechaInicio fechaFin |
| Como usuario quiero ver un panel con clientes totales, interacciones recientes y reuniones próximas, para tener un resumen rápido. | <b>!panel</b> usuarioId |

## 📜 Notas

Los principales desafios que encontramos al trabajar sobre el proyecto fueron la correcta distribución de responsabilidades entre las clases y sus relaciones entre sí, y el mantener una aplicación consistente de los principios SOLID, además de acostumbrarse a trabajar con y solucionar los conflicos de Git.<br><br>
En general, el proyecto viene siendo una buena oportunidad para poner en práctica lo visto en clase, tanto lo que se trata de conceptos como de código.
