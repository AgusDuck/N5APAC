Se registro la dependencia de la siguiente manera: builder.Services.AddScoped<IStudentLogic, StudentLogic>();
De esta forma se logra agregar la comunicacion sin tener que alerar grandes partes del codigo por lo que promueve un diseño desacoplado y más mantenible.

Sin Registro de Dependencias:
No necesitas registrar implementaciones concretas en el contenedor de DI en Startup.cs.
Se deberá utilizar técnicas de mocking o stubbing para crear objetos simulados que emulen el comportamiento de las dependencias, como bases de datos o servicios web. Esto implica crear clases simuladas (mocks) que implementen las interfaces y respondan de manera predefinida durante las pruebas.

Registro de Dependencias en Código Específico de Pruebas:
En lugar de registrar las dependencias en Startup.cs, se configura manualmente las dependencias en cada prueba unitaria, lo que significa que se proporciona implementaciones concretas o simuladas directamente en el código de prueba.
Esto es útil para pruebas unitarias rápidas y sencillas, pero puede volverse menos mantenible a medida que aumenta la complejidad de las pruebas y las dependencias
