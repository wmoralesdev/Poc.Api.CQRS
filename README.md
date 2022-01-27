# Proof of concept - Ceii.Api with CQRS

## Lectura inicial
- [Dependency Injection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [MediatR](https://github.com/jbogard/MediatR)
- [Why use MediatR](https://codeopinion.com/why-use-mediatr-3-reasons-why-and-1-reason-not/)
- [CQRS Pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs#:~:text=CQRS%20stands%20for%20Command%20and,operations%20for%20a%20data%20store.&text=The%20flexibility%20created%20by%20migrating,conflicts%20at%20the%20domain%20level.)
- [CQRS Intro](https://www.youtube.com/watch?v=mdzEKGlH0_Q)


## Introducción

### Qué es CQRS
**C**ommand

**Q**uery

**R**esposibility

**S**egregation

Es una estructura o patrón de diseño que su filosofía consiste en realizar una separación semántica de las lecturas con las escrituras; dicho de otro modo,
separar los comandos de las consultas.
Cada comando y consulta es independiente entre sí, y al encontrarse un mal funcionamiento en uno de estos, no afecta como tal a los demás ya que no se
componen en una sola clase como lo podría ser un servicio o repositorio.

## Estructura de proyectos
Utilizando **Clean Architecture**:

### Poc.Api.Core
Contiene la definición de los controladores, y la creación de la aplicación web. Acá se definen todos los servicios e inyección de dependencias
necesarias para el funcionamiento correcto.
Los controladores únicamente se encargan de invocar a los comandos y consultas.

### Poc.Api.Application
Contiene toda la lógica de negocio. Acá se definen los mapeos necesarios, los viewmodel con los datos relevantes para los usuarios, y los comandos y consultas.
Los comandos y consultas van agrupados en carpetas según un solo contexto o entidad. 

Cada comando se compone de:
- Request o command: Son los datos que se reciben para funcionar
- Handler: Es la acción que se realizará en el comando
- Response: Es el resultado de la acción ejecutada

Cada consulta se compone de:
- Request o query: Son los datos que se reciben para funcionar
- Handler: Es la acción que se realizará en la consulta
- Response: Es el resultado de la acción ejecutada

Cada una de estas unidades debe ser separada en su propia clase o archivo correspondiente, se hace uso de **MediatR** para el manejo.

### Poc.Api.Domain
Contiene la lógica de dominio. Todos los datos que son relevantes para almacenar, aunque no todos sean expuestos en su totalidad.
Acá se manejan las entidades y el contexto de la base de datos, su única función es modelar la información y exponerse a la capa de la aplicación.