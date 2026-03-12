# Sistema de realidad virtual para la simulación del vuelo de un UAV en robótica asistencial

Trabajo de Fin de Grado de Ingeniería Informática, presentado en el año 2019.

Escuela Superior de Ingeniería Informática de Albacete. Universidad de Castilla-La Mancha.

**Autor**: Anselmo Martínez Martínez

---

## Resumen

Para este trabajo de Fin de Grado se ha desarrollado una aplicación de realidad virtual para la simulación del vuelo de un UAV (un vehículo aéreo no tripulado) destinado a la robótica asistencial. Dentro de este sistema, la persona puede moverse por todo el entorno de manera autónoma o ser controlada por el usuario, mientras el UAV se encarga de realizar labores de seguimiento. 

La realización del entorno virtual de la aplicación se hace con el programa de Unity, donde se han diseñado varios escenarios en los que tanto la persona como el UAV pueden moverse. La persona puede controlarse dentro de Unity (mediante el uso del teclado del ordenador o un dispositivo de realidad virtual), mientras que para el dron se parte de un modelo ya implementado anteriormente en la herramienta de sistemas dinámicos Simulink dentro de MATLAB, el cual simula el control y movimiento de éste. Por tanto, los dos programas deben estar conectados, ya que Unity necesita los valores de la posición y orientación del UAV y Simulink en MATLAB necesita los de la persona para poder hacer su seguimiento. Para esto se ha usado el protocolo de mensajes MQTT, basado en un sistema de publicación y suscripción de temas a través de un servidor que se encarga de la gestión de los mensajes.

En la siguiente figura podemos ver un diagrama general del flujo que siguen los datos.

<img width="949" height="306" alt="diagrama_general" src="https://github.com/user-attachments/assets/c92de9fb-dd2c-4c65-bdb2-83d84d6fae8e" />

---

## Desarrollo

<img width="934" height="640" alt="SceneView" src="https://github.com/user-attachments/assets/79bf7319-0abf-49e7-9a69-e6934077a1fd" />


---

## Imagen de la aplicación

<img width="1030" height="623" alt="Game" src="https://github.com/user-attachments/assets/00b38aa2-08ba-47c7-99c2-37257a0190dc" />
