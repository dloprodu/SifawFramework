# **Sifaw Framework** ![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/SffIco32x32.png "Logo") *WPF & Windows Form MVC*
---
## 1. Informaci�n general

*Sifaw Framework*, a partir de ahora *SF*, es una interpretaci�n del patr�n MVC para apliacaciones de escritorio en C# .NET, tanto **Windows Form** como **WPF**. Su objetivo es mantener el c�digo organizado, reutilizable, escalable y mantenible.

> *SF* aporta una soluci�n a la hora de definir controladores, sus vistas y como estos interactuan entre si. El modelo y acceso a datos queda fuera de su �mbido pudiendo usar cualquier otro framework como *EntityFramework*.

*SF* pone el foco en los controladores, sus vistas y en el desarrollo de componentes aislados y reutilizables. Un **componente** no es mas que una peque�a pieza de nuestra aplicaci�n con una funci�n bien definida. Un componente est� formado por un controlador y su vista.

> En una aplicaci�n de gesti�n de clientes, por ejemplo, un componente ser�a aquel que se encarga de cargar y mostrar un listado de clientes. Este componente podr�a permitir realizar filtros por nombre, roles, fecha de alta, etc. Este componente tendr�a, por un lado, el controlador que se encarga de acceder al modelo y cargar y manipular los datos, y por otro lado, la vista que se encarga de presentar los datos.

El **controlador** de la vista debe asumir todo el peso de la l�gica gesti�n de datos quedando solo para la **vista** la presentaci�n de esos datos.

En *SF* un componente pude alojar otros componentes. Esta caracter�stica promueve la reutilizaci�n y el **principio de responsabilidad �nica**. Un componente complejo podr�a estar formado por otros componentes aislados que interacturan entre si estando alojados en el componente hu�sped.

> En nuestra aplicaci�n de gesti�n de clientes podr�amos tener otro componente cuyo fin es la generaci�n de informes. Este componente puede alojar y hacer uso del componente que muestra la lista de clientes, de modo que, el usuario pueda filtrar y seleccionar que clientes van a aparecer en un informe.

## 2. Empieza 

Supongamos una aplicaci�n, para la gesti�n de socios de un club automovil�stico, llamada **XiCar**. Con *XiCar* veremos los pasos y conceptos necesarios para poder crear una applicaci�n con *SF*.

Lo primero, necesitamos al menos, cuatro proyectos:
- **XiCar.App**: Un proyecto como punto de arranque de nuestra aplicaci�n.
- **XiCar.Controllers**: Un proyecto para nuestros controladores.
- **XiCar.WPF**: Un proyecto con la implementaci�n concreta de los componentes (controles y/o ventanas **WPF** o **Windows Form**).
- **XiCar.Views**: Un proyecto para las interfaces de comunicaci�n entre los controladores y sus componentes gr�ficos. Se trata de una capa de abstracci�n entre los componentes de intefaz que est�n implementados en una tecnolog�a concreta (**WPF** por ejemplo) y su controlador. Esto permite que la UI de un componente pueda estar implementado en varias tecnolog�as, es m�s, un compomente puede tener varias implementaciones a nivel de UI. Esta capa est� basada en el patr�n de dise�o *Abstract Factory*. En esta capa de nuestra soluci�n tambi�n se puede definir los modelos de vistas (MVVM).

![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/00.png "Esquema")

Exceptuando al proyecto de inicio, pueden haber m�s de un proyecto destinados a controladores, vistas abstractas o implementaci�n concreta de UI.

## 3. Proyecto de inicio

El proyecto de inicio es el punto de arranque de nuestra aplicaci�n y b�sicamente lo que debe hacer es instanciar el controlador principal de nuestra applicaci�n e iniciarlo llamando a su m�todo `Start`.

```C#
MainViewController controller = new MainViewController();
...
controller.Start();
````

Dado que los constroladores est�n desacopladas de su representaci�n concreta de UI es en este punto donde debemos indicar a *SF* que UI va a usar. Para este fin tenemos la factoria `UILinkersManager`.

Un controlador s�lo puede estar vinculado a un elemento de UI y este v�nculo queda represetnado por un `UILinker`. Un `UILinker` es una interfaz que define el m�todo para instanciar un elemente de UI. Entonces cada proyecto, WPF o Windows Form, que implementa elementos UI de controladores debe implementar estas interfaces. Veremos esto m�s en detalle en los apartados siguientes.

Entonces usamos `UILinkersManager` para registrar las implementaciones concretas de los `UILinker`.

En nuestra aplicaci�n tenemos el proyecto **XiCar.WPF** para implementar nuestros elementos de UI. Adem�s tenemos los elementos de UI predefinidos por *SF*. Por lo tanto el registo queda como sigue:

```C#
UILinkersManager.SetUIElementLinker(new Sifaw.WPF.WPFLinkers());
UILinkersManager.SetUIElementLinker(new XiCar.WPF.WPFLinkers());
```

Por �ltimo establecemos algunos valores por defecto como el icono a usar en la aplicaci�n o la vista principal. 

![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/01.png "Proyecto de inicio")

## 4. Controladores

### 4.1. Par�metros de entrada

### 4.2. Par�metros de salida

### 4.3 Estados

## 5. Representaci�n abstracta de componentes de UI

### 5.1 Vistas hu�sped (guest)
 
### 5.2 Controles

## 6. Componentes definidos






