Implementé una estructura "Entidad - GestorEntidad", con el objetivo de encapsular la comunicación con la base de datos y la lógica de cada entidad. Estos gestores no hacen a un lado al Gestor principal del CU, sino que se complementan para que no quede un código "espagueti". Ejemplifico un flujo de "Mensajes" para obtener todos los eventos sísmicos (basándome en el diagrama de secuencia).

Se inicializa la Pantalla, instanciando el método buscarEventosSismicoSinRevision del GestorCU. Este llamará al GestorEventosSismicos, el cual tiene un array con todos los eventos, y ejecutará los mensajes 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 sobre los mismos, devolviéndole al GestorCU la lista con los eventos sísmicos que no tienen revisión, para finalmente mostrarlos en el boundary.

Quizás no es la implementación más fiel al diagrama de secuencia, pero aun así los métodos y su navegabilidad se podrán ver reflejados en el proyecto. Considero que de esta forma podemos lograr un entorno escalable al no depositar toda la lógica solamente en el gestor del CU.

-Pedro-



