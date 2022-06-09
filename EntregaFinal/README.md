# App
#### José Luis Lobera del Castillo 0224643
#### Patrones de Diseño y Arquitecturas de Software
#### Mtra. Lidia Chávez López
#### Universidad Panamericana

## Entrega Final

Nuevamente le ofrezco una disculpa por el retraso en la entrega. Por lo mismo no tuve tiempo de añadir la interfaz gráfica, por lo que detalles como la visualización de la bitácora en textbox faltan.


### Usuarios para pruebas:
- Distributors: 
    - Usuario: 20001
    - Usuario: 20002
    - Usuario: 20003
- Suppliers:
    - Usuario: 30001
- Products:
    - Product: 10001 (Soda)
    - Product: 10002 (Bread)
    - Product: 10003 (Vegetables)

##### Dirección de las clases: `EntregaFinal/`

### Descripcion General:

El principal objectivo de la aplicación se divide en dos usuarios, por una parte está el distribuidor, quien debe escanear un código QR para autenticarse para después realizar su pedido y generar otro código QR con el pedido, y el provedor que puede levantar futuros pedidos mientras entrega los actuales y puede simular la entrega antes de realizarla.

### Patrones de Diseño:

#### Creacionales

##### Singleton

Durante la ejecución de la aplicación se van registrando ciertos eventos en la bitácora (`Logbook.cs`), en cada ejecución solo debe de existir una bitácora, por lo que no es. necesario instanciarla más de una vez, por lo que se decidió emplear el **Patrón de Instancia Unica** o **Singleton**.

##### Factory

La aplicación cuenta actualmente con dos tipos de usuarios, que aunque ambos realizan actividades similares, sus objetivos y métodos son diferentes. El patrón de diseño factory nos permite que ambos usuarios que heredan de la clase usuario (`User.cs`) se identifiquen por QR de la misma forma, pero el usuario distribuidor (`Distributor.cs`) solo podrá realizar pedidos y el usuario provedor (`Supplier.cs`) podrá repartir y simular entregas.

#### Estructurales

##### Facade

Conectarse a una API es un proceso complicado, ya que requiere de solicitudes y conecciones con elementos externos al programa, cada vez que los usuarios se identifican, levantan pedidos o los reparten se escanean códigos QR, para evitar realizar o escribir todo el proceso una y otra vez, la clase del código QR (`QRCode.cs`) compacta todos estos tediosos y complicados comandos en una sola función **ReadQR()**.

#### De comportamiento

##### Observer

Este patrón no existe actualmente en la entrega, pero la intención era que en el Windows Forms el usuario pudiera seleccionar checkboxes con los tipos de visualización de la bitácora. Si el checkbox del archivo txt se encontraba activo, entonces se escribiría dicho archivo, lo mismo para el grid y el textbox.

### Clases:

Lo que más destaca de la aplicación es el uso de códigos QR (`QRCode.cs`). Ésta clase contiene una función **ReadQR(String path)** que recibe un String con la dirección del código y que después de establecer conexión con la API de Códigos QR, devuelve una string con los datos en formato JSON.

Si algún día se desarrollara ésta aplicación para mobiles, se solicitaria acceso a la cámara para escanear los códigos, pero omo la aplicación solo es una simulación no es posible la lectura por cámara. Otra solución podría haber sido la selección de imagen por medio de un file chooser, pero éste proceso sería muy tedioso para el usuario, por lo que se me ocurrió una solución para simular el escaneo de los códigos, la solución consiste en transformar la información en JSONs y despues concatenar la liga de la API con la string del JSON, de esta forma "creamos" el código sin tenerlo como imagen.

Como se mencionó previamente, a la aplicación pueden ingresar dos tipos de usarios, distribuidores y provedores, ambos que heredan de la clase abstracta **User.cs** que tiene tres atributos: UserID (int), UserName (String) y scanner (QRCode), y dos métodos: **GetUserQRCode()** (Para la creación de código QR explicada previamente) y **AuthenticateWithQR()** para conectarse con la API y obtener los datos de usuario.

El usuario distribuidor (`Distributor.cs`) tiene como atributos: un diccionario <int, int> para almacenar la orden actual, donde la llava es el ID del Producto y el valor es la cantidad de unidades. También cuenta con un scanner (QRCode) para poder encriptar su información y una string donde se guardan los valores de la orden actual en formato JSON.

El usuario provedor (`Supplier.cs`) tiene como atributos un diccionario de diccionarios (Dictionary<int, Dictionary<int, int>>) en donde guarda las ordenes de los usuarios, un diccionario de listas de vehiculos repartidores (Dictionary<int, List<DeliveryVehicle>>) y un diccionario de productos  disponibles (Dictionary<int, Product>). La clase provedor tiene varios métodos:
  - Métodos para la simulación:
    - **CanSupplyOrders(Dictionary<int, List<DeliveryVehicle>> vehiclesSimulation)** recibe un diccionario de listas con n numeros de tipos de vehiculos y m cantidad de cada tipo, regresa verdadero si con los camiones disponibles se puede satisfacer la orden.
  - Métodos para entrega de productos:
    - **SortedOrders()** regresa un diccionario del mismo tipo que el atributo **orders**, solamente que este diccionario estará ordenado de acuerdo a la ganancia que genera cada orden.
    - **CalulateOrderTotal()** recibe un diccionario de una orden de un provedor y regresa el total de la venta.
    - **ReadOrderQR(string v)** recibe una string en con un JSON y regresa un diccionario tipo orden (<int, int>).
    - **AddToOrders(int distributorID, string QRCode)** agrega al diccionario de ordenes el Id del distribuidor y el resultado de llamar a **ReadOrderQR(string v)** con QRCode como argumento.
    - **ScanQRCodeFromDistributor(Distributor client)** obtiene el pedido de un distribuidor y manda llamar a la función **AddToOrders(int distributorID, string QRCode)** para guardar el pedido.

La clase producto (`Product.cs`) es una de las más simples ya que solo contiene 3 atributos: Name (String), ProductID (int) y Price (float).
    
También existe la clase abstracta vehículo repartidor (`DeliveryVehicle.cs`) que cuenta con 3. atributos: VehicleID (int), maxCapacity (float), curCapacity (float). La clase cuenta con tres métodos, **FullLoad()** que rellena el numero actual de productos a la capacidad maxima, **Deliver(float amount)** que resta la cantidad repartida a la cantidad actual, y **CanDeliver(float amount)** que regresa verdadero si su numero actual es mayor que la demanda.
    De la clase abstracta vehículo repartidor (`DeliveryVehicle.cs`) hereda la clase camión repartidor(`DeliveryTruck.cs`) que en un futuro nos podría ayudar a implementar un patrón factory, ya que por tierra no es la unica forma de repartir productos.
    
La clase bitácora (`Logbook.cs`) la cual es una unica instancia (Singleton) es la encargada de llevar registro de eventos (`Log.cs`) en una lista de eventos, debería de tener tres métodos, en donde se aplicaría el patrón Observer, dichos métodos serían los encargados de mostrar en pantalla la bitácora en sus distintas presentaciones (txt file, grid layout y textbox). Por ahora solo existe el método **printLogs()** que muestra en pantalla todos los eventos. Los eventos (`Log.cs`) tienen tres atributos userId (int), eventId (int), dateTime (DateTime).
    
Finalmente la clase aplicación (`App.cs`) es la encargada de llevar el flujo de la ejecución, primero pregunta por el tipo de usuario y de acuerdo a éste, autenticará al usuario para poder realizar sus actividades. En el menu principal se encuentra la opción de visualizar la bitácora sin restricción de usuarios.
     

### Justificación

### Propuestas de Mejora
     
    
