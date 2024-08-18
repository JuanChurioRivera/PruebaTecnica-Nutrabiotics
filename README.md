# PruebaTenicaTodos

Este es una prueba tecnica en donde se me pidio crear un api con los siguientes requerimientos:

Modelo de Datos:
    -Diseñar un modelo simple para las tareas que incluya al menos los siguientes
    campos: ID, título, descripción, estado (completa/incompleta), y fecha de
    creación.
Endpoints:
    -Crear una tarea: Endpoint que permita añadir una nueva tarea.
    Listar todas las tareas: Endpoint que retorne todas las tareas existentes.
    Obtener una tarea por ID: Endpoint para obtener los detalles de una tarea
    específica.
    -Actualizar una tarea: Endpoint que permita modificar los campos de una
    tarea existente (por ejemplo, marcar como completa).
    Eliminar una tarea: Endpoint para eliminar una tarea existente.
Validaciones:
    -Asegurar que todos los campos necesarios estén presentes al crear o
    actualizar tareas.
    -Implementar manejo de errores adecuado, por ejemplo, para casos donde
    una tarea no exista.
Persistencia:
    -Utilizar una base de datos en memoria como SQLite o un sistema de
    almacenamiento simple como archivos JSON para persistir las tareas entre
    llamadas API.
Documentación (Opcional):
    -Documentar brevemente cada endpoint, incluyendo el método HTTP, la URL,
    y el cuerpo de solicitud/respuesta esperado.
