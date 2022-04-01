# Alumni API

##### José Luis Lobera del Castillo 0224643
##### Patrones de Diseño y Arquitecturas de Software
##### Mtra. Lidia Chávez López
##### Universidad Panamericana

## Segundo Examen Práctico

### Usuarios para pruebas:
- Alumno: 
    - Usuario: A0000
    - Contraseña: JP0000
- Docente:
    - Usuario: D0000
    - Contraseña: MT0000
- Supervisor:
    - Usuario: S0000
    - Contraseña: HA0000

##### Dirección de las clases: `SegundoExamen/`

##### Dirección de los JSON: `SegundoExamen/bin/Debug/net6.0`

### Descripcion General:

El principal objectivo de la aplicación es la consulta de información personal y la consulta y descarga de calificaciones para una escuela.

A la aplicación pueden ingresar tres tipos de usuarios: Alumnos, Docentes y Supervisores. Cada uno deberá de autenticarse previamente con usuario y contraseña para poder ingresar a la plataforma. Las opciones y funciones para cada usuario dependera del tipo de ésta.

La información que visualiza cada usuario es personalizada, cada usuario verá sus datos personales y los alumnos, además podrán visualizar y descargar sus calificaciones.

### Patrones de Diseño:

#### Singleton

Por ****uso de la aplicación**** entendemos la interacción del **un** dispositivo con **un** usuario. En cada uso de la aplicación solo hay un usuario activo a la vez. 
En cada uso de la aplicación solo habrá una instancia de la aplicacion ejecutandose, llevando el control de todo el programa.

Tanto la clase encargada de registar el usuario en uso (`UsuarioActivo.cs`) como la aplicación que dirigirá la interacción del usuario (`Aplicacion.cs`) solo necesitan existir una vez, no es necesario tener dos y en algunos casos no es recomendable. Por lo que se decidió emplear el **Patrón de Instancia Unica** o **Singleton** .

#### Adapter

La aplicación no es la encargada de la creación ni mantenimiento de las bases de datos (Back-end), la aplicación debe estar preparada para cambios de servidor, schema, archivos, etc. Es por eso que la aplicación, de manera local, guardará los datos que pueden ser útiles para el usuario activo, sin importar donde esten guardados siempre.

La aplicación utiliza diccionarios para almacenar la información de manera temporal, pero el problema requería que los datos fueran provenientes de un archivo JSON. Los datos no se transforman magicamente de JSON a diccionarios, por lo que es necesario adaptar esos datos para que funcionen en nuestra aplicación.

La clase Adapter (`Adapter.cs`) es la encargada de, por medio de sus métodos, obtener la información de un lugar solicitado y transformarla y adpatarla a diccionarios. En este momento solo existen métodos para transformar de JSON a Diccionario, pero en un futuro se pueden añadir más métodos que permitan transformar otro tipo de archivos para adaptarlos en nuetsra aplicación.

### Clases:
    
La aplicación debe obtener la información de algún lado, por lo que existe una clase (`DatabaseConnection.cs`) que tiene como atributos diccionarios en donde almacena la información. Los diccionarios que tenemos son:
-  **alumnos** < `string`, `Alumno` > -> Key: id_alumno , Value: Alumno (`Alumno.cs`)
-  **docentes** < `string`, `Docente` > -> Key: id_docente, Value: Docente (`Docente.cs`)
-  **supervisores** < `string`, `Supervisor` > -> Key: id_supervisor, Value: Supervisor (`Supervisor.cs`)
-  **materiasIIA** < `string`, `Materia` > -> Key: id_materia, Value: Materia (`Materia.cs`)
-  **calificaciones_por_materia** < `string`, `Diccionary< string, float` >> -> Key: id_materia, Value: (Dicctionary< `string`, `float` > -> Key: id_alumno, calificacion)
     
Todas las clases de usuarios (`Alumno.cs`, `Docente.cs`, `Supervicor.cs`) heredan de la clase abstracta Usuario (`Usuario.cs`) que tiene de atributos:
- \+  id: String
- \+  nombre: String
- \#  apellido: String
- \#  carrera: String
- \#  nacimiento: String
- \#  ciudad: String
- \#  contrasena: String
     
La clase Usuario también tiene un método abstracto **ConsultarInformacion()** para que cada clase muestre diferentes atributos.
También tiene un método Consultar Contraseña que devuelve dicho atributo.
  
La clase Alumno (`Alumno.cs`), que hereda de Usuario (`Usuario.cs`), cuenta con el método **ConsultarCalificaciones()** que le regresa sus calificaciones por materia, un método que calcula su promedio, además implemente el método abracto **ConsultarInformacion()** para mostrar sus atributos, calificaciones y promedio. Finalmente tiene un método **DescargarCalificaciones()** que le descargará un archivo .txt o .docx según esté configurado.
  
La clase Docente (`Docete.cs`) también tiene el método de **ConsultarCalificaciones()**, pero a diferencia de la clase Alumno (`Alumno.cs`) el docente visualizará
las calificaciones de sus alumnos. Docente también implementa **ConsultarInformacion()**.
  
La clase Supervisor (`Supervisor.cs`) solo implementa el método **ConsultarInformacion()**.
  
Ahora que ya están explicadas la mayoría de las clases, podemos regresar a los métodos de la clase DatabaseConnection (`DatabaseConnection.cs`) que, además de guardar de manera temporal la información que requerirá el usuario para interactuar con la aplicación, es la encargada de solicitar que los datos se transfieran a la memoria.

Actualmente tenemo un método que lee un JSON y tres métodos que solicitan que se adapten dichos datos para ser compatibles con C#:
- **GetDataFromJSON(string fileName)**: lee el archivo JSON y lo transforma a objeto C# tipo JSON
- **LoadUsuariosFromJSON(dynamic usuarios)**: recibe un objeto tipo C# y le solicita al adaptador (`adapter.cs`) que transforme el archivo en datos que nuestra aplicación entiende.
-  **LoadMateriasFromJSON(dynamic materias)**: recibe un objeto tipo C# y le solicita al adaptador (`adapter.cs`) que transforme el archivo en datos que nuestra aplicación entiende.
-  **LoadCalificacionesFromJSON(dynamic calificaciones)**: recibe un objeto tipo C# y le solicita al adaptador (`adapter.cs`) que transforme el archivo en datos que nuestra aplicación entiende.

En clase queda abierta a edición, para poder agregar métodos por si en un momento la base de datos ya no proviene de un JSON.

La clase que permite al usuario interactuar con el sistema es la Aplicacion (`Aplicacion.cs`), por medio de **Concole.WriteLine()** y **Console.ReadLine()** le hace saber al usuario como interactuar para poder hacer sus consultas.

Dichas consultas van a variar dependiendo del Usuario que haya iniciado sesión, por lo que durante tiempo de ejecución se debe de informar al sistema el usuario activo, la clase UsuarioActivo (UsuarioActivo.cs) se inicializa dos parametros de tipo **string** vacios: `id` y `tipo_de_usuario`. La aplicación (`Aplicacion.cs`), al autenticar al usuario, asigna estas variables para que la aplicación y otras clases sepan que usuario solicitar de manera global, sin pasar el id como argumento en cada método.

### Justificación

El motivo de usar Singleton en las clases ActiveUser y fue que consideré innecesaria la posibilidad de tener más de un usuario o más de una aplicación ejecutandose al mismo tiempo porque, aunque yo programé el código y se que en ningún momento se van a crear más instancias, existe la posibilidad de que alguien más llegue e intente instanciar un usuario o aplicación en lugar de llamar a la instancia ya existente.

En el caso del adapter fue un patron que no había considerado, la primera idea era consultar siempre directamente al JSON, pero cuando la maestra sugirió que no nos "casáramos" con JSON fue cuando me percaté de la necesidad de tener un tipo de memoria constante en la aplicación sin importar la fuente de proveniencia. Es por eso que la clase DatabaseConnection (`DatabaseConnection.cs`) está abierta a la creación de nuevos métodos, por si en algún momento la fuente de la información cambia.

### Propuestas de Mejora
     
    

