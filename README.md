# Asteroids
Asteroids microgame developed in Unity as part of Videogames Fundamentals subject

# Microjuego Asteroids

## Resumen

Este documento describe el diseño y desarrollo de un microjuego desarrollado en Unity como parte de la asignatura. El objetivo principal del juego es consolidar los aspectos básicos del desarrollo de videojuegos utilizando Unity, así como introducir elementos avanzados mediante la investigación y revisión de documentación. El juego consta de dos iteraciones, la primera guiada en clase y la segunda basada en aprendizaje autónomo.

## Información General

**Desarrolladores**: Nihel Kella Bouziane
**Plataforma**: Windows PC

## Mecánicas

### Iteración 1:  Mecánicas Básicas

* **Movimiento**: El personaje se mueve utilizando fuerzas, lo que proporciona una sensación más kinestésica y controlada.
* **Disparo**: El jugador puede disparar proyectiles desde una pistola (gun) para destruir asteroides.
* **Spawn de Enemigos**: Los asteroides aparecen en la pantalla de forma aleatoria y se desplazan automáticamente.
* **UI - Scoring**: Se muestra una interfaz de usuario que incluye una puntuación que se incrementa con cada asteroide destruido.

### Iteración 2:  Mecánicas Avanzadas

* **Mecánica Extra - Fragmentos**: Cuando un asteroide es destruido por una bala, se dividen en dos mini-asteroides que se separan en ángulos fijos con respecto al vector de la bala. Los mini-asteroides desaparecen si vuelven a colisionar con una bala.
* **UI - Pausa/Reinicio**: Se ha implementado la capacidad de pausar el juego. Al pausar, la escena se detiene y se puede reanudar.
* **Patrón de Diseño Pooling**: Se ha implementado este patrón de diseño para una gestión eficiente de objetos. Este patrón permite la creación anticipada y reutilización de objetos en lugar de crear y destruir objetos bajo demanda, lo que mejora el rendimiento del juego.

## Scripts

### Bullet

Este script controla el comportamiento de las balas disparadas por el jugador. Establece su velocidad y tiempo de vida, maneja su movimiento en la dirección objetivo y gestiona las colisiones con enemigos. Cuando una bala colisiona con un enemigo, divide el asteroide en dos mini-asteroides, aumenta la puntuación y desactiva tanto la bala como el enemigo.

### EnemySpawner

Este script se encarga de generar asteroides de manera continua en el juego. Controla la tasa de generación y la posición de spawn de los asteroides. Los asteroides tienen un tiempo de vida limitado antes de ser destruidos automáticamente.

### GameManager

El GameManager controla la pausa y reanudación del juego. Detecta si se presiona la tecla "Escape" y pausa el juego si no está pausado, o lo reanuda si ya lo está.

### MiniAsteroidController

Este script controla el movimiento de los mini-asteroides que se generan cuando un asteroide grande es destruido. Les asigna una dirección y velocidad, permitiendo que se muevan de manera autónoma en la escena.

### ObjectPool

Este script implementa un patrón de diseño de "Object Pooling" para las balas del jugador. Crea un conjunto de balas al comienzo del juego y recicla las balas cuando se disparan. Si no hay balas reciclables disponibles, crea nuevas. Esto mejora el rendimiento del juego al evitar la creación y destrucción frecuente de balas.

Inicialmente se intentó seguir el patrón para todos los objetos reciclables (balas y asteroides), pero se ha dejado finalmente solo para la generación de balas. Esto es porque el efecto de gravedad de los asteroides se mantenía en los objetos reciclados, haciendo que desciendan a gran velocidad.

### Player

El script del jugador controla la nave del jugador. Gestiona el movimiento, la rotación y el disparo de la nave. También controla los límites de pantalla para que la nave no se salga de la vista. Cuando la nave colisiona con un asteroide, la puntuación se reinicia y se reinicia la escena.

## Interacción

* Flechas para interactuar con la nave. 
* Espacio para disparar
* ESC para pausar/reanudar
