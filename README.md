# Sifaw Framework ![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/SffIco32x32.png "Logo Title Text 1")

## Informaci�n general

*Sifaw Framework*, a partir de ahora *SF*, es una interpretaci�n del patr�n MVC para apliacaciones de escritorio en C# .NET, tanto **Windows Form** como **WPF**. Su objetivo es mantener el c�digo organizado, reutilizable, escalable y mantenible.

> *SF* aporta una soluci�n a la hora de definir controladores, sus vistas y como estos interactuan entre si. El modelo y acceso a datos queda fuera de su �mbido pudiendo usar cualquier otro framework o como *EntityFramework*.

*SF* pone el foco en las controladoras y sus vistas y en el desarrollo de componentes aislados y reutilizables. Un **componente** no es mas que una peque�a pieza de nuestra aplicaci�n con una funci�n bien definida y formado por un controlador y su vista.

> En una aplicaci�n de gesti�n de clientes, por ejemplo, un componente ser�a aquel que se encarga de cargar y mostrar un listado de clientes, permitiendo realizar filtros por nombre, roles, fecha de alta, etc. Este componente tendr�a, por un lado, el controlador que se encarga de acceder al modelo y cargar y manipular los datos, y por otro lado, la vista que se encarga de presentar los datos.

El **controlador** de la vista debe asumir todo el peso de la l�gica gesti�n de datos quedando solo para la **vista** la representaci�n de esos datos.

En *SF* un componente pude alojar otros componentes. Esta caracter�stica promueve la reutilizaci�n y el principio de responsabilidad �nica. Un componente complejo podr�a estar formado por otros componentes aislados que interacturan entre si estando alojados en el componente hu�sped.

> En nuestra aplicaci�n de gesti�n de clientes podr�amos tener otro componente cuyo fin es la generaci�n de informes. Este componente puede alojar y hacer uso del componente que muestra la lista de clientes, de modo que, el usuario pueda filtrar y seleccionar que clientes van a aparecer en un informe.

## Empieza 

![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/00.png "Esquema")

![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/01.png "Proyecto de inicio")

## El controlador

### El controlador - Par�metros de entrada

### El controlador - Par�metros de salida

## La Vista

### La Vista - Vistas hu�sped (guest)

### La Vista - Controles

## Componentes definidos







