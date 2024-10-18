# Instrucciones para clonar el repositorio

> [!IMPORTANT]
> IMPORTANTE!!!

### Asegúrate de reemplazar `<nombreDelGrupo>` con el nombre real del grupo del proyecto.

## Requisitos previos

Antes de comenzar, asegúrate de tener lo siguiente instalado en tu sistema:

- [Git](https://git-scm.com/) (para clonar el repositorio)
- Un editor de texto o entorno de desarrollo integrado (IDE), como [Visual Studio Code](https://code.visualstudio.com/) o [Visual Studio (community)](https://visualstudio.microsoft.com/free-developer-offers/)

## Pasos para clonar el repositorio

1. Abre una terminal o línea de comandos en tu sistema.

2. Navega hasta el directorio donde deseas clonar el repositorio. Por ejemplo, puedes usar el siguiente comando para cambiar al escritorio (esto es opcional, puedes elegir cualquier otra carpeta):

```bash
cd ~/Escritorio
```

3. Clona el repositorio usando el siguiente comando de Git:

```bash
git clone https://github.com/atarico/grupo-nombreDelGrupo.git
```

4. Después de que el repositorio se haya clonado correctamente, navega al directorio del proyecto:

```bash
cd grupo-nombreDelGrupo
```

5. Ahora puedes abrir el proyecto en tu editor de código.

> [!CAUTION]
> CUANDO SE LEVANTEN, ANTES DE IR AL BAÑO, HACEN UN PULL

## Actualizar el repositorio

Si ya tienes el repositorio clonado y deseas actualizarlo con los últimos cambios del repositorio remoto, sigue estos pasos:

1. Abre la terminal y navega al directorio del proyecto si aún no lo has hecho:

```bash
cd ~/ruta/al/proyecto/grupo-nombreDelGrupo
```

2. Ejecuta el siguiente comando para obtener los últimos cambios del repositorio remoto:

```bash
git pull origin main
```

## Contribuir al proyecto

Si deseas realizar contribuciones, asegúrate de seguir estos pasos:

1. Crea una nueva rama para tus cambios:

```bash
git checkout -b nombre-de-tu-rama
```

2. Realiza tus cambios y haz un commit:

```bash
git add .
git commit -m "Descripción de tus cambios"
```

5. Sube tus cambios a la rama remota:

```bash
git push origin nombre-de-tu-rama
```

> [!NOTE]
> Opcional

Abre un Pull Request en GitHub desde tu rama para que tus cambios puedan ser revisados e integrados.
