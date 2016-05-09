# Sifaw Framework ![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/SffIco32x32.png "Logo Title Text 1")

## Información general

*Sifaw Framework*, a partir de ahora *SF*, es una interpretación del patrón MVC para apliacaciones de escritorio en C# .NET, tanto **Windows Form** como **WPF**. Su objetivo es mantener el código organizado, reutilizable, escalable y mantenible.

> *SF* aporta una solución a la hora de definir controladores, sus vistas y como estos interactuan entre si. El modelo y acceso a datos queda fuera de su ámbido pudiendo usar cualquier otro framework o como *EntityFramework*.

*SF* pone el foco en las controladoras y sus vistas y en el desarrollo de componentes aislados y reutilizables. Un **componente** no es mas que una pequeña pieza de nuestra aplicación con una función bien definida y formado por un controlador y su vista.

> En una aplicación de gestión de clientes, por ejemplo, un componente sería aquel que se encarga de cargar y mostrar un listado de clientes, permitiendo realizar filtros por nombre, roles, fecha de alta, etc. Este componente tendría, por un lado, el controlador que se encarga de acceder al modelo y cargar y manipular los datos, y por otro lado, la vista que se encarga de presentar los datos.

El **controlador** de la vista debe asumir todo el peso de la lógica gestión de datos quedando solo para la **vista** la representación de esos datos.

En *SF* un componente pude alojar otros componentes. Esta característica promueve la reutilización y el principio de responsabilidad única. Un componente complejo podría estar formado por otros componentes aislados que interacturan entre si estando alojados en el componente huésped.

> En nuestra aplicación de gestión de clientes podríamos tener otro componente cuyo fin es la generación de informes. Este componente puede alojar y hacer uso del componente que muestra la lista de clientes, de modo que, el usuario pueda filtrar y seleccionar que clientes van a aparecer en un informe.

## Empieza 

![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/00.png "Esquema")

![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/01.png "Proyecto de inicio")

## El controlador

### El controlador - Parámetros de entrada

### El controlador - Parámetros de salida

## La Vista

### La Vista - Vistas huésped (guest)

### La Vista - Controles

## Componentes definidos







