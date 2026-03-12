# Sistema de realidad virtual para la simulación del vuelo de un UAV en robótica asistencial

Trabajo de Fin de Grado de Ingeniería Informática, presentado en el año 2019.

Escuela Superior de Ingeniería Informática de Albacete. Universidad de Castilla-La Mancha.

**Autor**: Anselmo Martínez Martínez

---

## Resumen

Para este trabajo de Fin de Grado se ha desarrollado una aplicación de realidad virtual para la simulación del vuelo de un UAV (un vehículo aéreo no tripulado) destinado a la robótica asistencial. Dentro de este sistema, la persona puede moverse por todo el entorno de manera autónoma o ser controlada por el usuario, mientras el UAV se encarga de realizar labores de seguimiento. 

La realización del entorno virtual de la aplicación se hace con el programa de Unity, donde se han diseñado varios escenarios en los que tanto la persona como el UAV pueden moverse. La persona puede controlarse dentro de Unity (mediante el uso del teclado del ordenador o un dispositivo de realidad virtual), mientras que para el dron se parte de un modelo ya implementado anteriormente en la herramienta de sistemas dinámicos Simulink dentro de MATLAB, el cual simula el control y movimiento de éste. Por tanto, los dos programas deben estar conectados, ya que Unity necesita los valores de la posición y orientación del UAV y Simulink en MATLAB necesita los de la persona para poder hacer su seguimiento. Para esto se ha usado el protocolo de mensajes MQTT, basado en un sistema de publicación y suscripción de temas (topics) a través de un servidor que se encarga de la gestión de los mensajes.

En la siguiente figura podemos ver un diagrama general del flujo que siguen los datos.

<img width="949" height="306" alt="diagrama_general" src="https://github.com/user-attachments/assets/c92de9fb-dd2c-4c65-bdb2-83d84d6fae8e" />

---

## Desarrollo

Este TFG se centra en el desarrollo en Unity de una aplicación interactiva con un sistema de realidad virtual donde controlar a un personaje por un escenario y en la comunicación de este programa con el simulador del UAV en MATLAB/Simulink, el cual posee un modelo dinámico que se encargará de controlar al dron y planificar su trayectoria. 

### Comunicación entre programas
Se ha establecido un sistema de comunicación entre los programas de Unity y MATLAB/Simulink mediante el uso del protocolo de mensajes MQTT, el cual permite un intercambio de datos en tiempo real entre ambos. Para ello el broker de MQTT se encarga de gestionar el envío de mensajes a cada cliente que se haya suscrito a un tema o topic específico. Desde Unity, para los scripts escritos en C#, la librería de "M2Mqtt" nos proporciona métodos para crear clientes, conectarnos al broker y poder publicar mensajes o suscribirnos a ellos en un topic específico, mientras que desde MATLAB estos mismos métodos nos lo proporciona el complemento "MQTT in MATLAB". 

Desde la parte de Unity se genera un mensaje JSON a partir de las variables de la persona y se publica en un topic específico mediante el servidor de MQTT. A continuación MATLAB/Simulink recibe estos datos al estar suscrito a ese mismo topic, descodifica el mensaje JSON y lo lee como un objeto con sus diferentes variables, las cuales corresponden a cada uno de los datos de la persona. De la misma manera Unity recibe correctamente los datos del UAV que publica MATLAB/Simulink en un topic específico (diferente al de los datos de la persona) al que está suscrito y actualiza correctamente la posición y orientación del modelo de éste dentro de la simulación.

### Personajes
Los personajes de la aplicación han sido creados mediante el uso del programa de Adobe Fuse, el cual permite editar de una forma sencilla una gran cantidad de características faciales y corporales mediante barras deslizables, además de poder elegir la ropa que llevan. De esta manera se ha diseñado un avatar masculino y otro femenino.

### Control
Diferentes tipos de controles:
- Control del personaje mediante el teclado, con las teclas de flechas para moverse y las teclas WASD para girar la cabeza.
- Control mediante un dispositivo de realidad virtual con casco y un mando para cada mano con los que poder elegir hacia donde moverse.
- Control automático del personaje. En este modo el personaje se pasea automáticamente por toda la zona sin necesidad de tocar ningún botón. 

### Escenarios
Los escenarios se han diseñado con la ayuda de la herramienta de ProBuilder para Unity. Se han creado varios en los que llevar a cabo la simulación, con diferentes zonas del hogar que recrean escenas de la vida diaria normal de la persona (como la habitación del salón o el patio).

<img alt="SceneView" src="https://github.com/user-attachments/assets/79bf7319-0abf-49e7-9a69-e6934077a1fd" />

### Interfaz
Dentro de la simulación se ha diseñado una interfaz personalizable con diferentes pantallas para mostrar todo lo que ocurre (como lo que ve el personaje, la cámara del UAV o distintas cámaras ubicadas por todo el escenario). En cualquier momento se puede personalizar la disposición de estas pantallas según el gusto del usuario. 

- Pantalla principal: Es la más grande de las tres, ocupando la mayor parte de toda la ventana. Muestra la vista de la persona, una cámara colocada en la cabeza del personaje que permite ver lo que está mirando en ese momento.
- Pantalla secundaria 1: La pantalla pequeña superior. Muestra la cámara del UAV, mediante la cual se puede ver en todo momento hacia donde se dirige.
- Pantalla secundaria 2: La pantalla pequeña inferior. Muestra una de las cámaras de la escena. En cada escenario hay una serie de cámaras colocadas por toda la zona, las cuales pueden mostrar diferentes vistas de la misma escena desde varios ángulos. De entre éstas, se selecciona la camara activa, mediante el desplegable en el panel del título de pantalla (en la parte superior derecha).

<img width="1030" height="623" alt="Game" src="https://github.com/user-attachments/assets/00b38aa2-08ba-47c7-99c2-37257a0190dc" />
