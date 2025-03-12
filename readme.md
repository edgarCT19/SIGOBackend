1. Abre una terminal y navega al directorio donde se encuentra tu archivo `dockerfile.mongodb`.

2. Construye la imagen de Docker con el siguiente comando:
    ```sh
    docker build -t mongodb-image -f dockerfile.mongodb .
    ```

3. Una vez que la imagen se haya construido, ejecuta un contenedor basado en esa imagen con el siguiente comando:
    ```sh
    docker run -d --name mongodb-container -p 27017:27017 mongodb-image
    ```

Esto iniciará un contenedor de MongoDB en segundo plano (`-d`) y mapeará el puerto 27017 del contenedor al puerto 27017 de tu máquina local.

# NOTAS 
1. Relación entre UnidadResponsable y Facturas

📌 Problema:

    Actualmente, Facturas es una propiedad dentro de UnidadResponsable, pero no está modelado como una entidad en sí misma.
    Las facturas deberían tener una relación clara con las Subestaciones, ya que una Unidad Responsable puede tener varias Subestaciones, y cada Subestación puede tener facturas asociadas.

✅ Sugerencia:

    Separar Facturas en una entidad independiente y asociarlas a Subestaciones.
    Cambiar la relación de UnidadResponsable → Facturas a Subestacion → Facturas.


3. Relaciones de Inventario Energético

📌 Problema:

    InventarioEnergético está definido dentro de UnidadResponsable como un objeto y no como una entidad en la base de datos.
    Si el inventario crece, puede ser difícil manejarlo en consultas o reportes.

✅ Sugerencia:

    Convertir InventarioEnergético en una entidad con relaciones claras.
    Definir una tabla InventarioEnergético con un campo UnidadResponsableId.
    Hacer que AireAcondicionado, Miscelaneos y Luminarias sean tablas con una relación 1:N con InventarioEnergético.

📌 Beneficio:

    Mejora la escalabilidad y permite manejar mejor la información.

6. Falta Relación entre Edificio y UnidadResponsable

📌 Problema:

    Edificio no tiene una relación directa con UnidadResponsable.
    Se asume que un Edificio pertenece a un Campus, pero no hay una referencia a la UnidadResponsable.

✅ Sugerencia:

    Agregar un UnidadResponsableId en Edificio para reflejar la relación.

📌 Beneficio:

    Permite gestionar los edificios por unidad responsable de manera clara.

    