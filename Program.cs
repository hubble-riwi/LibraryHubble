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

    // Menú secundario
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
                Console.WriteLine("A continuación ingrese los datos del libro");
                Console.WriteLine("Nombre del libro: ");
                string title = Console.ReadLine();
                
                Console.WriteLine("Autor del libro: ");
                string author = Console.ReadLine();
                
                Console.WriteLine("Categorías del libro: ");
                int categories = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Año del libro: ");
                string age = Console.ReadLine();
                
                Console.WriteLine("Cantidad de libros: ");
                int amount = int.Parse(Console.ReadLine());
                
                books.Add(new Book(title, author, categories, age, amount));
                
                break;
            case "2":
                Console.WriteLine("Sub-opción 2 seleccionada.");
                break;
            case "3":
                foreach (var book in books)
                {
                    Console.WriteLine($"Titulo: {book.title} \nAutor: {book.author}");
                }
                Console.WriteLine("Regresando al menú principal...");
                break;
            default:
                Console.WriteLine("Opción no válida, intenta nuevamente.");
                break;
        }
    } while (booksOption != "3");
}


class Book
{
    public string title { get; set; }
    public string author { get; set; }
    public int category { get; set; }
    public string year { get; set; }
    public int amountAvailable  { get; set; }
    public List<Review> Reviews { get; set; }

    public Book(string title, string author, int category, string year, int amountAvailable)
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