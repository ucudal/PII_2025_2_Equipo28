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

<p align="center">
  <img src="https://github.com/user-attachments/assets/b4006d5b-7789-47f2-adc3-e9eb365f0715" width="800">
</p>

## Comandos e historias

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
