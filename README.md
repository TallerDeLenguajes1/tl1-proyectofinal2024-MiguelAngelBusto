# tl1-proyectofinal2024-MiguelAngelBusto

Api utilizada: "https://api.generadordni.es/v2/person/username"

Esta api genera 10 nombres aleatorios en su request.
Problema encontrado que esta misma tiene una cantidad maxima de request.
Se soluciono que cuando suceda un problema con la solicitud de la api se generara un Json con unos nombres precargados para el uso correcto.
El uso de la peticion de la Api se encuentra en la clase ServicioApi.cs

La API es utilizada como nombre de los rivales a los que nuestro personaje se enfrentara.

PersonajesJson.cs se encargara de utilizar este mismo ("nombres.json") y los utilizara para convertir a los mismos en una lista de string para su uso en la FabricaDePersonajes.cs.

Funcionamiento de : "Caracteristicas.cs"

Clase que tendra los atributos del pokemon que se utilizaran para realizar los combates.

Funcionamiento de : "Cobate.cs"

Clase donde se realizan todos los calculos de las peleas, se encuentra la logicaa detras de cada combate, ademas fue utilizado para evitar codigo repetido en el program.

Funcionamiento de : "Datos.cs"

Clase que tendra todos los datos del usuario, ademas del tipo de pokemon que desea el usuario.

Funcionamiento de : "FabricaDePersonajes.cs"

Clase encargada de la fabricacion de personajes aleatorios y de un personaje especifico.

Funcionamiento de : "Mensajes.cs"

Clase que devuelve la estetica de los menu y de otras partes visuales del programa

Funcionamiento de : "Personajes.cs"

Clase que tendra todos los atributos que necesitara un Personaje. Utiliza la clase Datos y la clase Caracteristicas.

Funcionamiento de : "PersonajesJson.cs"

Clase encargada de la Serializacion y Deserializacion de los Json, tanto para la Carga, el Guardado y la creacion de personajes basados en los Json utilizados.

Funcionamiento de : "ServicioApi.cs"

Clase encargada de las peticiones de la APi con sus respectivos controles en caso que la API no este funcionando.