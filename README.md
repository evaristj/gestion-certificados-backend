# Gestion certificados backend

Este proyecto ha sido desarrollado como trabajo final del Bootcamp con [GeeksHubs Academy.](https://geekshubs.com/)

[DEMO del preoyecto](https://www.youtube.com/watch?v=suLfYeIugZY)

Te presento la parte del backend de [Gestión de Certificados.](https://github.com/evaristj/gestion-certificados)

Hemos usado ASP.NET con Entity Framework para la creación del modelo de base de datos y agilizar el trabajo.
Tiene numerosas funciones, las más destacables son:

* Proceso automático que revisa cada 15 minutos con la base de datos que un certificado esté a punto de caducar, esté caducado o esté activo.
* Control de length para registrar username y password.
* JWT integrado y authorization en cabeceras.
* Encripta las contraseñas antes de almacenarlas en base de datos.
* Obtiene los datos encriptados en base64 de la parte privada de un certificado, los desencripta y los almacena en base de datos.

## Descarga

Para su uso es aconsejable descargar el proyecto, usar Docker para levantar una imagen de PostgreSQL y realizar un update-database en la consola de NuGet antes de arrancar el servidor.
