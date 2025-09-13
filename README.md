# 📄 Documentación Técnica – Sistema de Biblioteca en Consola (C#)

## 1. Propósito del Sistema
Este sistema es una **aplicación de consola en C#** que permite gestionar una biblioteca con las siguientes funcionalidades principales:
- **Gestión de Libros**: registro, modificación, búsqueda y listado de libros.  
- **Gestión de Usuarios**: creación, visualización y búsqueda de usuarios.  
- **Préstamos y Devoluciones**: permitir que los usuarios soliciten libros, registren devoluciones y agreguen reseñas.  
- **Estadísticas (pendiente de implementación)**.  
- **Salir del sistema**.  

---

## 2. Arquitectura General
El sistema sigue una **arquitectura procedural** con funciones locales para manejar cada módulo. Las entidades principales están modeladas mediante **clases**.

### Componentes principales:
1. **Programa principal (Main Loop)**  
   - Muestra un menú general.  
   - Controla la navegación hacia los submódulos.  

2. **Módulos**  
   - `MenuBooks()`: gestión de libros.  
   - `usersManagement()`: gestión de usuarios.  
   - `loansReturns()`: préstamos y devoluciones.
   - `Statistics()`: estadísticas generales del sistema.

3. **Entidades (Clases)**  
   - `Book`: representa un libro de la biblioteca.  
   - `User`: representa un usuario registrado.  
   - `Loan`: representa un préstamo realizado.  
   - `Review`: reseña asociada a un libro.  

---

## 3. Estructuras de Datos
El sistema utiliza **listas en memoria** para almacenar la información mientras se ejecuta:

- `List<Book> books`: lista de libros disponibles.  
- `List<User> users`: lista de usuarios registrados.  
- `List<Loan> loans`: lista de préstamos realizados.  

⚠️ **Limitación**: los datos no se persisten en archivos ni bases de datos. Al cerrar la aplicación, la información se pierde.

---

## 4. Clases y Objetos

### 🔹 Clase `Book`
- **Atributos**  
  - `title` (string): título del libro.  
  - `author` (string): autor del libro.  
  - `category` (string): categoría del libro.  
  - `year` (string): año de publicación.  
  - `amountAvailable` (int): cantidad disponible en inventario.  
  - `Reviews` (List<Review>): reseñas asociadas.  

- **Constructor**: recibe todos los atributos y crea una lista vacía de reseñas.  

---

### 🔹 Clase `User`
- **Atributos**  
  - `id` (string): documento de identidad del usuario.  
  - `name` (string): nombre completo.  
  - `email` (string): correo electrónico.  

---

### 🔹 Clase `Loan`
- **Atributos**  
  - `titleBook` (string): título del libro prestado.  
  - `userId` (string): identificador del usuario que tomó el préstamo.  
  - `loanDate` (string): fecha de préstamo.  
  - `returnDate` (string): fecha de devolución.  
  - `status` (string): estado actual (“No devuelto” o “Devuelto”).  

- **Constructor**: inicializa todos los atributos.  

---

### 🔹 Clase `Review`
- **Atributos**  
  - `qualification` (double): calificación del libro.  
  - `comment` (string): reseña escrita por el usuario.  

---

## 5. Funciones y Módulos

### 🔹 Bucle Principal
- Muestra el menú principal.  
- Llama a los módulos según la opción elegida.  
- Permite salir del sistema (`flag = false`).  

---

### 🔹 `MenuBooks()`
Gestión de libros con opciones:
1. Registrar libro.  
2. Modificar libro existente.  
3. Ver todos los libros registrados.  
4. Buscar un libro (por título, autor o categoría).  
5. Regresar al menú principal.  

---

### 🔹 `usersManagement(List<User> users)`
Gestión de usuarios:
1. Agregar usuario (validando duplicados y datos vacíos).  
2. Mostrar todos los usuarios.  
3. Buscar usuario por documento.  
4. Regresar al menú principal.  

---

### 🔹 `loansReturns()`
Gestión de préstamos y devoluciones:
1. **Prestar un libro**  
   - Verifica que el libro exista.  
   - Verifica que el usuario exista.  
   - Resta una unidad al inventario del libro.  
   - Registra el préstamo en la lista `loans`.  

2. **Registrar devolución**  
   - Verifica que el libro y usuario existan.  
   - Aumenta el stock del libro.  
   - Marca el préstamo como “Devuelto”.  
   - Solicita reseña y calificación, agregándolas al libro.  

3. **Mostrar libros prestados**  
   - Lista todos los libros cuyo estado en `loans` sea “No devuelto”.  

4. **Salir**  
   - Regresa al menú principal.  

---

### 🔹 `Statistics()`
**Estadísticas de la biblioteca:**
- Calcula el total de libros registrados.
- Calcula el total de usuarios registrados.
- Calcula el total de prestamos realizados.
- Muestra el libro con más prestamos realizados.
---

## 6. Flujo de Ejecución

1. Inicia el programa.  
2. Muestra el menú principal.  
3. Usuario selecciona una opción:  
   - Si elige **1**, va a gestión de libros.  
   - Si elige **2**, va a gestión de usuarios.  
   - Si elige **3**, va a préstamos y devoluciones.  
   - Si elige **4**, muestra las estadísticas del sistema
   - Si elige **5**, termina la ejecución.  

---

## 7. Posibles Mejoras Futuras
- Persistencia de datos en **archivos** o **base de datos**.  
- Validación más estricta de entradas de usuario.  
- Implementar el menú de **reseñas y estadísticas**.  
- Reportes automáticos (cantidad de préstamos, usuarios con más préstamos, libro más popular).  
- Interfaz gráfica en lugar de consola.  
