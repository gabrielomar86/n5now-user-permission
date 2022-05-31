\### Project status

- [x] Create a Permissions table
- [x] Create a PermissionTypes table
- [x] Create relationship between Permission and PermissionType
- [x] Create a Web API using net core on Visual Studio and persist data on SQL Server.
- [x] Make use of EntityFramework.
- [x] The Web API must have 3 services “Request Permission”, “Modify Permission” and “Get Permissions”
- [ ]  Every service should persist a permission registry in an elasticsearch index
- [ ] Create apache kafka in local environment and create new topic
- [x]  Making use of repository pattern and Unit of Work
- [ ]  CQRS pattern
- [x]  creating different layers and dependency injection is a must-have.
- [x]  Create Unit Testing
- [x]  Prepare the solution to be containerized in a docker image
- [x]  Upload exercise to some repository (github, gitlab,etc).

Adicionalmente tambien se creo lo siguiente:

--> Archivos de configuracion para publicar la app en k8s.

--> EF Migrations para crear las tablas e insertar datos semilla.

--> Archivo docker-compose para levantar app en docker (docker-compose up --build -d )

--> Archivo .gitlab-ci para poder realizar integracion continua en gitlab.

--> Archivo MSSQLDockerFile para levantar sql server en un contenedor docker

La carpeta dev-environment, es para poder desarrollar desde un contenedor docker (un plus que nos evita instalar los sdk en la maquina host y a su vez nos permite liberar recursos una vez apagado el contenedor de desarrollo)

El proyecto se encuentra dividido en los siguientes proyectos (capas):
core: Aqui basicamente se encuentra todo lo referente a intercambio de datos como dtos, entities y tambien la abstraccion del negocio que se basa en Interfaces, la unica dependencia instalada en esta capa es la de Automapper.
infrastructure: En esta capa se implementan las Repositorios, se crean las migraciones y los datos semilla.
services: En esta capa se implementan las interfaces de los servicios del proyecto core.
api: se crean los controladores.
