# Prototipo de VR - Interfaces Inteligentes.
## Miembros:
* Pablo Torres Albertos.
* Sebastián Daniel Tamayo Guzmán.
* Fabio Ovidio Bianchini Cano.
* Markus Schüller Perdigón.
## Descripción
![](./imgs/Lobby.gif)  

Este proyecto consiste en un conjunto de diferentes minijuegos o experiencias diseñadas en Realidad Virtual. El juego comenzará en un *Lobby*, un espacio donde podremos seleccionar a modo de menú inmersivo de entre los diferentes escenarios:
* **Experiencias visuales**: Habrán 3 diferentes experiencias visuales, que se tratarán de diversos vídeos en 360º.
![](./imgs/Visual.gif)  
* **Rythm**: Se trata de un minijuego al estilo Guitar Hero, donde podremos seleccionar de entre 2 canciones.
![](./imgs/Rythm.gif)  
* **Space Invader**: El segundo minijuego, donde te moverás en un espacio tridimensional y tendrás que defender un "nexo" disparando a enemigos que intentan destruirlo y de matarte.
![](./imgs/space.gif)  
## Uso
Naturalmente, el control de la cámara se hará mediante el movimiento del móvil, que debería encontrarse en un casco de realidad virtual para teléfonos.  

En cuanto al resto de controles, principalmente se harán con reconocimiento de voz junto con el uso de un mando de PS4. Estos controles dependerán del juego en el que se encuentre el usuario:  
* En el Lobby se usarán controles de mando:
  * Seleccionar escenario: Se deberá mirar hacia un escenario y pulsar X o decir su nombre.
* En las experiencias visuales, solo se usará reconocimiento de voz:
  * Subir y bajar volumen: Decir "subir volumen" o "bajar volumen".
  * Pausar o reanudar el vídeo: Decir "pausa" o "reanudar".
  * Salir: Diciendo "salir".
* En Rythm, se usarán controles de voz o acelerómetro y de mando:
  * Menú de pausa: Se abre y se cierra diciendo "pausa" y "reanudar".
  * Salir: Con el menú de pausa abierto diciendo "salir".
  * Tocar nota: Moviendo la cabeza o pulsando la X.
* En Space Invader, solo se podrá usar el mando:
  * Salir: Pulsar círculo.
  * Saltar nivel: Cuadrado.
  * Disparar: Pulsar X.
## Hitos de programación alcanzados
Los scripts de Unity que hemos desarrollado se corresponden con diversos objetos del escenario en cada juego, haciendo uso de clases abstractas y herencia cuando considerábamos útil y necesario.  

También usamos eventos, ya que hemos empleado el Input Manager nuevo de Unity, que hace uso de eventos para registrar los inputs y asignarle acciones (métodos de clase).
## Aspectos técnicos
En el proyecto se ha incluido el reconocimiento de voz usando el micrófono incoroporado en el teléfono móvil y la librería de [Speech And Text in Unity iOS and Unity Android](https://github.com/j1mmyto9/Speech-And-Text-Unity-iOS-Android) para poder reconocer las palabras en Android. Con esto, como se ha mencionado previamente, podremos utilizar parte de los controles.  

También se pueden controlar los juegos con un mando de PS4, haciendo uso del Input Manager de Unity, que permite definir distintos tipos de input y sus acciones asociadas de una manera directa.  

Además, en el juego de Rythm, se hace uso del acelerómetro del móvil para tocar las notas moviendo la cabeza.  

Hemos hecho uso de la nueva versión del *Cardboard VR SDK* para implementar lo necesario para que funcione para VR.
## Acta de los acuerdos del grupo
Las tareas del proyecto se han dividido más o menos de la siguiente manera:
* Pablo Torres Albertos: Desarrollo del minijuego "Rythm", el visualizador de experiencias visuales y el Lobby.
* Sebastián Daniel Tamayo Guzmán: Desarrollo del minijuego "Space Invader".
* Fabio Ovidio Bianchini Cano: Desarrollo del minijuego "Space Invader".
* Markus Schüller Perdigón: Desarrollo del Lobby y elaboración del informe.