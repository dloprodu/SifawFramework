# **Sifaw Framework** ![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/SffIco32x32.png "Logo") *WPF & Windows Form MVC*
---
## 1. Información general

*Sifaw Framework*, a partir de ahora *SF*, es una interpretación del patrón MVC para apliacaciones de escritorio en C# .NET, tanto **Windows Form** como **WPF**. Su objetivo es mantener el código organizado, reutilizable, escalable y mantenible.

> *SF* aporta una solución a la hora de definir controladores, sus vistas y como estos interactuan entre si. El modelo y acceso a datos queda fuera de su ámbido pudiendo usar cualquier otro framework como *EntityFramework*.

*SF* pone el foco en los controladores, sus vistas y en el desarrollo de componentes aislados y reutilizables. Un **componente** no es mas que una pequeña pieza de nuestra aplicación con una función bien definida. Un componente está formado por un controlador y su vista.

> En una aplicación de gestión de clientes, por ejemplo, un componente sería aquel que se encarga de cargar y mostrar un listado de clientes. Este componente podría permitir realizar filtros por nombre, roles, fecha de alta, etc. Este componente tendría, por un lado, el controlador que se encarga de acceder al modelo y cargar y manipular los datos, y por otro lado, la vista que se encarga de presentar los datos.

El **controlador** de la vista debe asumir todo el peso de la lógica gestión de datos quedando solo para la **vista** la presentación de esos datos.

En *SF* un componente pude alojar otros componentes. Esta característica promueve la reutilización y el **principio de responsabilidad única**. Un componente complejo podría estar formado por otros componentes aislados que interacturan entre si estando alojados en el componente huésped.

> En nuestra aplicación de gestión de clientes podríamos tener otro componente cuyo fin es la generación de informes. Este componente puede alojar y hacer uso del componente que muestra la lista de clientes, de modo que, el usuario pueda filtrar y seleccionar que clientes van a aparecer en un informe.

## 2. Empieza 

Supongamos una aplicación, para la gestión de socios de un club automovilístico, llamada **XiCar**. Con *XiCar* veremos los pasos y conceptos necesarios para poder crear una applicación con *SF*.

Lo primero, necesitamos al menos, cuatro proyectos:
- **XiCar.App**: Un proyecto como punto de arranque de nuestra aplicación.
- **XiCar.Controllers**: Un proyecto para nuestros controladores.
- **XiCar.WPF**: Un proyecto con la implementación concreta de los componentes (controles y/o ventanas **WPF** o **Windows Form**).
- **XiCar.Views**: Un proyecto para las interfaces de comunicación entre los controladores y sus componentes gráficos. Se trata de una capa de abstracción entre los componentes de intefaz que están implementados en una tecnología concreta (**WPF** por ejemplo) y su controlador. Esto permite que la UI de un componente pueda estar implementado en varias tecnologías, es más, un compomente puede tener varias implementaciones a nivel de UI. Esta capa está basada en el patrón de diseño *Abstract Factory*. En esta capa de nuestra solución también se puede definir los modelos de vistas (MVVM).

![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/00.png "Esquema")

Exceptuando al proyecto de inicio, pueden haber más de un proyecto destinados a controladores, vistas abstractas o implementación concreta de UI.

## 3. Proyecto de inicio

El proyecto de inicio es el punto de arranque de nuestra aplicación y básicamente lo que debe hacer es instanciar el controlador principal de nuestra applicación e iniciarlo llamando a su método `Start`.

```C#
MainViewController controller = new MainViewController();
...
controller.Start();
````

Dado que los constroladores están desacopladas de su representación concreta de UI es en este punto donde debemos indicar a *SF* que UI va a usar. Para este fin tenemos la factoria `UILinkersManager`.

Un controlador sólo puede estar vinculado a un elemento de UI y este vínculo queda represetnado por un `UILinker`. Un `UILinker` es una interfaz que define el método para instanciar un elemente de UI. Entonces cada proyecto, WPF o Windows Form, que implementa elementos UI de controladores debe implementar estas interfaces. Veremos esto más en detalle en los apartados siguientes.

Entonces usamos `UILinkersManager` para registrar las implementaciones concretas de los `UILinker`.

En nuestra aplicación tenemos el proyecto **XiCar.WPF** para implementar nuestros elementos de UI. Además tenemos los elementos de UI predefinidos por *SF*. Por lo tanto el registo queda como sigue:

```C#
UILinkersManager.SetUIElementLinker(new Sifaw.WPF.WPFLinkers());
UILinkersManager.SetUIElementLinker(new XiCar.WPF.WPFLinkers());
```

Por último establecemos algunos valores por defecto como el icono a usar en la aplicación o la vista principal. 

![alt text](https://raw.githubusercontent.com/dloprodu/SifawFramework/master/Resources/01.png "Proyecto de inicio")

## 4. Controladores

### 4.1. Parámetros de entrada

### 4.2. Parámetros de salida

### 4.3 Estados

## 5. Representación abstracta de componentes de UI

### 5.1 Vistas huésped (guest)
 
### 5.2 Controles

## 6. Componentes definidos






