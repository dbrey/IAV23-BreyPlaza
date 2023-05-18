# Proyecto Final de IAV (Bumping Cars)

## Autores

- David Brey Plaza (https://github.com/dbrey)

## Propuesta
El objetivo de esta practica es extender y probar diferentes comportamientos del NavMesh en diversas situaciones, desde saltar en ciertas plataformas o evitar ciertos obstaculos en tiempo real, a la vez que la IA tambien debe tener en cuenta su cuerpo fisico por si ha chocado con alguien y actuar con su retroceso, dejando la persecucion por unos instantes. Los anteriores comportamientos se demuestran en diferentes mapas, cada uno con su propio objetivo para la IA.

El jugador, manejará un coche de choque que se desplazará mediante fuerzas, que hará rodar una esfera por todo el escenario, con bastante libertad, incluso con la capacidad de saltar ya sea para alcanzar ciertas plataformas o para esquivar enemigos y trampas.

Los enemigos tambien serán coches de choque, que perseguirán al jugador con el objetivo de chocar con el y con suerte empujarlo fuera del mapa. Estos tambien tienen una esfera fisica para actuar en los choques, pero a 
diferencia del jugador, cuando el enemigo se mueve, la esfera se queda en la misma posicion que el navmesh sin rotar pero cuando choca, se activa su rotacion haciendo que al moverse dicha esfera arrastre al agente (el cual no podrá moverse durante un cierto tiempo tras el choque)

## Punto de partida
Este proyecto se inició vacio, añadiendo apartados de otras plantillas (como el manejo del coche del jugador). Se empezo con un mapa con 2-3 plataformas para comprobar el movimiento del jugador y los enemigos y su interacción entre ellos. Una vez se comprobó que las anteriores ideas funcionaban, las cuales conformaban el minimo para empezar el proyecto, se subió al repositorio y se creo mas mapas para implementar otros obstaculos

### 1. Descripción de los mapas
Mapa Base (BasicScene): Una escena basica con plataformas separadas y algunos objetos sueltos para probar los saltos de los enemigos y la movilidad del jugador

Mapa 1: Una escena con 3 plataformas, distinguidas por sus colores y cada una mas elevada que la anterior. En este mapa, se obliga al jugador y a los enemigos a saltar para acceder a cualquier zona del mapa

Mapa 2: Una escena con una plataforma principal, rodeada de pequeñas plataformas, cada una con un cañon que dispara bombas cada cierto tiempo. Dichas bombas explotan al contactar con cualquier objeto excepto el suelo. Si chocan con el jugador o los enemigos, explotara provocando una gran fuerza repulsiva para luego desaparecer. Ademas, dichas bombas actuan como obstaculos, asi que las IAs procuraran dentro de lo posible evitar dichas bombas, incluso priorizando quedarse quietas antes que moverse sin pensar hacia el jugador.

### 2. Descripción del código

#### Componente: AgentLinkMover

Permite al NavMeshAgent, modificar ligeramente su ruta cuando interactua con un NavMeshLink de diferentes formas. En el editor de Unity, se puede modificar su altura y su tipo de movimiento. Este código es proporcionado por Unity: https://github.com/Unity-Technologies/NavMeshComponents/blob/master/Assets/Examples/Scripts/AgentLinkMover.cs
| Método  |  Descripción |
|---------|---------|
| NormalSpeed | Mueve hacia delante el NavMesh hacia su destino (modo por defecto) |
| Parabola | Mueve el Navmesh hacia su destino, formando una parabola |
| Curve | Mueve el Navmesh hacia su destino, formando una curva |

#### Componente: Bomb

Si choca con otra bomba, ambas desaparecerán, pero si choca con un enemigo o el jugador, explotará y se aplicará una fuerza repulsiva contra quien haya chocado con la bomba. Si no choca con nada, desaparecerá tras un tiempo
| Método  |  Descripción |
|---------|---------|
| OnCollisionEnter | Si choca con un objeto con cierto Tag, se aplicará el efecto correspondiente segun lo explicado anteriormente |

#### Componente: Bumping

Si choca con un enemigo o el jugador, se aplicara al objeto con el que se haya chocado una cierta fuerza hacia atrás (dicha fuerza se puede cambiar en el Editor de Unity)

#### Componente: CamFollow

Sigue al jugador teniendo en cuenta su propia posicion como cámara

#### Componente: Cannon

Dispara cada cierto tiempo una bomba
| Método  |  Descripción |
|---------|---------|
| Update | Tras acabarse un temporizador, instancia una bomba y le añade una fuerza a dicha bomba. Al terminar, reinicia el temporizador |

#### Componente: EnemyController

Si esta "activo", persigue al jugador y actualiza la posicion de su componente físico. Si no esta activo, se inicia un temporizador para reactivarse, hasta entonces se actualiza la posición del NavMeshAgent teniendo en cuenta la posicion de su componente físico, el cual se le permite rodar 

#### Componente: PlayerController

Mueve al jugador segun el input, sumando fuerzas a su componente físico, que al ser una esfera, acaba rodando
| Método  |  Descripción |
|---------|---------|
| Update | Actualiza la posicion del objeto usando la posicion de su componente físico, recibe todo el input y dependiendo de ello, actualiza el valor de la aceleración a aplicar |
| FixedUpdate | Teniendo en cuenta el input, suma su fuerza a su componente físico, aplica el salto en caso de haberlo y rota el objeto segun el input recibido |
| isGrounded | Comprueba si esta chocando con un objeto que sea categorizado como suelo. Si es así, permite al jugador saltar |

#### Componente: Spawner

Si el jugador choca con cualquier objeto con este componente, se traslada su posicion a una a elegir desde el editor de Unity. Si es otro objeto es automaticamente destruido

## Pruebas y métricas
            
Video de la práctica : 

## Producción

| Estado  |  Tarea  |  Fecha  |
|---------|---------|---------|
| x | Creación del repositorio | 9-5-2023 |
| x | NavMeshAgent enemies | 10-5-2023 |
| x | Movimiento Jugador | 12-5-2023 |
| x | Choque Jugador-Enemigos | 13-5-2023 |
| x | Salto Enemigos | 14-5-2023 |
| x | Salto Jugador | 15-5-2023 |
| x | Cañon y bombas | 15-5-2023 |
| x | Salto Jugador | 17-5-2023 |
| x | Creación de la documentación | 17-5-2023 |
| x | Propuesta, descripción de los mapas y del código| 18-5-2023 |

## Referencias

Los recursos de terceros utilizados son de uso público / con atribución.

- [Kaykit Variety Pack](https://kaylousberg.itch.io/kay-kit-mini-game-variety-pack)
- [Creatus - Pirate Pack](https://creatus.itch.io/creatus-pirate)
- [Bumper Car V1](https://sketchfab.com/3d-models/bumper-car-05e53156ee874c60ab14f5405bd9f086)
- [Bumper Car V2](https://sketchfab.com/3d-models/bumper-car-4b277e7d413648e8a1e3192b88a3f7d4)


