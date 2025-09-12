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

            break;
        
        case "2":

            break;
        
        case "3":
            loansReturns();
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

void loansReturns()
{
    bool flagLoans = true;
    string optionsLoans;
    
    while (flagLoans)
    {
        Console.Write(@"===== PRESTAMOS Y DEVOLUCIONES =====
                      1. Prestar un libro
                      2. Registrar la devolucion de un libro
                      3. Mostrar los libros actualmente prestados
                      4. Salir 
                      >> ");
        optionsLoans = Console.ReadLine();
        
        //declare initial variables
        string nameBook = "";
        int idBook = 0; //iterator and id of the book
        
        switch (optionsLoans)
        {
            case "1":
                Console.Write("Ingrese un el nombre del libro: ");
                nameBook = Console.ReadLine();
                bool findLoan = false;
                
                //Verify if the book exist
                foreach (Book book in books)
                {
                    if (book.title == nameBook)
                    {
                        findLoan = true;
                        break;
                    }
                    idBook++;
                }
                
                //If not exist, returned message, if exist continue with the flow
                if (findLoan)
                {
                    Console.Write("Ingrese el id del usuario: ");
                    string idUser = Console.ReadLine();
                    findLoan = false; //again asign false for another validation
                 
                    //The same but with the user
                    foreach (User user in users)
                    {
                        if (user.id == idUser)
                        {
                            findLoan = true;
                        }
                    }
                    
                    //Subtract a book of the lists of books and add a register to loans
                    if (findLoan)
                    {
                        //Add register to loans
                        loans.Add(new Loan(nameBook, idUser, DateTime.Today.ToString("dd-MM-yyyy"), "","No devuelto"));

                        books[idBook].amountAvailable -= 1;
                        Console.WriteLine("Libro prestado con exitosamente");
                    }
                    else
                    {
                        Console.WriteLine("El usuario no existe, intente de nuevo");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontro el libro, intentelo de nuevo");
                }
                
                break;
            case "2":
                Console.Write("Ingrese un el nombre del libro: ");
                nameBook = Console.ReadLine();
                bool findReturn = false;
                
                //Verify if the book exist
                foreach (Book book in books)
                {
                    if (book.title == nameBook)
                    {
                        findReturn = true;
                        break;
                    }
                    idBook++;
                }

                if (findReturn)
                {
                    Console.Write("Ingrese el id del usuario: ");
                    string idUser = Console.ReadLine();
                    
                    findReturn = false;
                    foreach (User user in users)
                    {
                        if (user.id == idUser)
                        {
                            findReturn = true;
                            break;
                        }
                    }

                    if (findReturn)
                    {
                        books[idBook].amountAvailable += 1;
                        Console.WriteLine("Libro devuelto con exitosamente");
                        
                        
                    }
                }

                break;
            case "3":
                Console.Write("Libros actualmente prestados");
                foreach (Loan loan in loans)
                {
                    if(loan.status == "No devuelto")
                    {
                           Console.WriteLine(@$"- {loan.titleBook}");
                    }
                }
                break;
            case "4":
                flagLoans = false;
                break;
        }
    }
}


class Book
{
    public string title { get; set; }
    public string author { get; set; }
    public int category { get; set; }
    public string year { get; set; }
    public int amountAvailable  { get; set; }
    public List<Review> Reviews { get; set; } = new();
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

    //Contruct
    public Loan(string titleBook, string userId, string loanDate, string returnDate, string status)
    {
        this.titleBook = titleBook;
        this.userId = userId;
        this.loanDate = loanDate;
        this.returnDate = returnDate;
        this.status = status;
    }
}   