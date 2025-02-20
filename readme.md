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