List<Book> books = new();
List<User> users = new();
List<Loan> loans = new();

bool flag = true;
string option;

while (flag)
{
    Console.Write(@"===== SISTEMA DE BIBLIOTECA =====
    1. Gestión de Libros
    2. Gestión de Usuarios
    3. Préstamos y Devoluciones
    4. Reseñas y Calificaciones
    5. Estadísticas
    6. Salir
    >> ");
    option =  Console.ReadLine();
    
    switch (option)
    {
        case "1":
            MenuSecundario();
            break;
        
        case "2":

            break;
        
        case "3":

            break;
        
        case "4":

            break;
        
        case "5":

            break;
        
        case "6":
            flag = false;
            break;
        
        default:
            
            Console.WriteLine("Opcion no valida");
            break;
    }
}


void MenuSecundario()
{
    string booksOption;

        do
        {
            Console.Clear();
            Console.WriteLine(@"===== Gestión de Libros =====
1. Registrar un libro
2. Modificar un libro
3. Ver todos los libros
4. Buscar un libro
5. Salir
>> ");
            booksOption = Console.ReadLine();

            switch (booksOption)
            {
                case "1":
                    // Register a new book
                    Console.WriteLine("A continuación ingrese los datos del libro");
                    Console.WriteLine("Nombre del libro: ");
                    string title = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        Console.WriteLine("Debe ingresar un dato");
                        continue;
                    }

                    Console.WriteLine("Autor del libro: ");
                    string author = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(author))
                    {
                        Console.WriteLine("Debe ingresar un dato");
                        continue;
                    }

                    Console.WriteLine("Categorías del libro: ");
                    string categories = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(categories))
                    {
                        Console.WriteLine("Debe ingresar un dato");
                        continue;
                    }

                    Console.WriteLine("Año del libro: ");
                    string year = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(year))
                    {
                        Console.WriteLine("Debe ingresar un dato");
                        continue;
                    }

                    Console.WriteLine("Cantidad de libros: ");
                    string amount = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(amount))
                    {
                        Console.WriteLine("Debe ingresar un dato");
                        continue;
                    }
                    else
                    {
                        int amountN;
                        if (int.TryParse(amount, out amountN))
                        {
                            books.Add(new Book(title, author, categories, year, amountN));
                            Console.WriteLine("Libro registrado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("La cantidad no es un número válido.");
                        }
                    }
                    break;

                case "2":
                    // Update a book
                    Console.WriteLine("Ingrese el título del libro que desea modificar: ");
                    string modifyTitle = Console.ReadLine()?.Trim();

                    var bookToModify = books.Find(b => b.title.Equals(modifyTitle, StringComparison.OrdinalIgnoreCase));
                    if (bookToModify != null)
                    {
                        Console.WriteLine("Libro encontrado. Ingrese los nuevos datos.");
                        
                        Console.WriteLine("Nuevo autor del libro: ");
                        bookToModify.author = Console.ReadLine()?.Trim();

                        Console.WriteLine("Nuevas categorías del libro: ");
                        bookToModify.category = Console.ReadLine()?.Trim();

                        Console.WriteLine("Nuevo año del libro: ");
                        bookToModify.year = Console.ReadLine()?.Trim();

                        Console.WriteLine("Nueva cantidad de libros: ");
                        string newAmount = Console.ReadLine()?.Trim();
                        if (int.TryParse(newAmount, out int newAmountInt))
                        {
                            bookToModify.amountAvailable = newAmountInt;
                            Console.WriteLine("Libro modificado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("La cantidad no es un número válido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el libro con ese título.");
                    }
                    break;

                case "3":
                    // Show all books
                    Console.WriteLine("===== Lista de Libros =====");
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No hay libros registrados.");
                    }
                    else
                    {
                        foreach (var book in books)
                        {
                            Console.WriteLine($"Título: {book.title} \nAutor: {book.author} \nCategoría: {book.category} \nAño: {book.year} \nCantidad Disponible: {book.amountAvailable}\n");
                        }
                    }
                    break;

                case "4":
                    // Search a book
                    Console.WriteLine(@"Seleccione el tipo de búsqueda:
1. Buscar por Título
2. Buscar por Autor
3. Buscar por Categoría
Seleccione una opción: ");
                    string searchOption = Console.ReadLine();

                    switch (searchOption)
                    {
                        case "1":
                            // By title
                            Console.WriteLine("Ingrese el título del libro a buscar: ");
                            string searchTitle = Console.ReadLine()?.Trim();
                            var bookByTitle = books.Find(b => b.title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase));
                            if (bookByTitle != null)
                            {
                                Console.WriteLine($"Libro encontrado: Título: {bookByTitle.title}, Autor: {bookByTitle.author}, Año: {bookByTitle.year}, Categoría: {bookByTitle.category}, Cantidad disponible: {bookByTitle.amountAvailable}");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró un libro con ese título.");
                            }
                            break;

                        case "2":
                            // By author
                            Console.WriteLine("Ingrese el autor del libro a buscar: ");
                            string searchAuthor = Console.ReadLine()?.Trim();
                            var booksByAuthor = books.Find(b => b.author.Equals(searchAuthor, StringComparison.OrdinalIgnoreCase));
                            if (booksByAuthor != null)
                            {
                                Console.WriteLine($"Libro encontrado: Título: {booksByAuthor.title}, Autor: {booksByAuthor.author}, Año: {booksByAuthor.year}, Categoría: {booksByAuthor.category}, Cantidad disponible: {booksByAuthor.amountAvailable}");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró un libro con ese autor.");
                            }
                            break;

                        case "3":
                            // By category
                            Console.WriteLine("Ingrese la categoría del libro a buscar: ");
                            string searchCategory = Console.ReadLine()?.Trim();
                            var booksByCategory = books.Find(b => b.category.Equals(searchCategory, StringComparison.OrdinalIgnoreCase));
                            if (booksByCategory != null)
                            {
                                Console.WriteLine($"Libro encontrado: Título: {booksByCategory.title}, Autor: {booksByCategory.author}, Año: {booksByCategory.year}, Categoría: {booksByCategory.category}, Cantidad disponible: {booksByCategory.amountAvailable}");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró un libro con esa categoría.");
                            }
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Regresando al menú principal...");
                            break;
                    }
                    break;


                case "5":
                    // Exit
                    Console.WriteLine("Saliendo del menú...");
                    break;

                default:
                    Console.WriteLine("Opción no válida, intenta nuevamente.");
                    break;
            }

            if (booksOption != "5")
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (booksOption != "5");
    }


class Book
{
    public string title { get; set; }
    public string author { get; set; }
    public string category { get; set; }
    public string year { get; set; }
    public int amountAvailable  { get; set; }
    public List<Review> Reviews { get; set; }

    public Book(string title, string author, string category, string year, int amountAvailable)
    {
        this.title = title;
        this.author = author;
        this.category = category;
        this.year = year;
        this.amountAvailable = amountAvailable;
        this.Reviews = new List<Review>();
    }
}

class Review
{
    public int qualification { get; set; } 
    public string comment { get; set; }
}


class User
{
    public string id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
}

class Loan
{
    public string titleBook { get; set; }
    public string userId { get; set; }
    public string loanDate { get; set; }
    public string returnDate { get; set; }
    public string status { get; set; }
}
