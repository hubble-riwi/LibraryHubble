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
            usersManagement(users);
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

void usersManagement(List<User> users)
{
    bool userMenuActive = true;
    Console.WriteLine(" \nGestión de usuarios ");

    while (userMenuActive)
    {
        Console.WriteLine(" \nEscoge una opción: \n 1) Agregar usuario \n 2) Mostrar usuarios \n 3) Buscar usuario \n 4) Salir al menú");
        var uOption = Console.ReadLine();

        switch (uOption)
        {
            case "1":
                while (true)
                {
                    Console.Write("\nIngrese el documento del usuario: ");
                    string id = Console.ReadLine()?.Trim() ?? "";
                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Console.WriteLine(" ID inválido. Inténtalo de nuevo.");
                        continue;
                    }

                    Console.Write("\nIngrese el nombre del usuario: ");
                    string name = Console.ReadLine()?.Trim() ?? "";
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine(" Nombre inválido. Inténtalo de nuevo.");
                        continue;
                    }

                    Console.Write("\nIngrese el email del usuario: ");
                    string email = Console.ReadLine()?.Trim() ?? "";
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        Console.WriteLine(" Email inválido. Inténtalo de nuevo.");
                        continue;
                    }

                    if (users.Any(u => u.id == id))
                    {
                        Console.WriteLine("Ya existe un usuario con ese ID.");
                        continue;
                    }

                    users.Add(new User
                    {
                        id = id,
                        name = name,
                        email = email
                    });

                    Console.WriteLine("Usuario agregado correctamente.");

                    Console.Write("¿Deseas agregar otro usuario? (s/n): ");
                    string resp = Console.ReadLine()?.ToLower().Trim() ?? "n";
                    if (resp == "n")
                    {
                        break;
                    }
                }
                break;

            case "2":
                Console.WriteLine("Mostrando todos los usuarios: ");
                foreach (var user in users)
                {
                    Console.WriteLine($"- Documento: {user.id}");
                    Console.WriteLine($"- Nombre: {user.name}");
                    Console.WriteLine($"- Email: {user.email} \n");
                }
                break;

            case "3":
                while (true)
                {
                    Console.Write("\nIngrese el documento del usuario que quieres buscar: ");
                    string searchId = Console.ReadLine()?.Trim() ?? "";
                    if (string.IsNullOrWhiteSpace(searchId))
                    {
                        Console.WriteLine(" Documento inválido. Inténtalo de nuevo.");
                        continue;
                    }

                    var user = users.FirstOrDefault(u => u.id == searchId);
                    if (user is null)
                    {
                        Console.WriteLine("Usuario no encontrado.");
                        Console.WriteLine("¿Deseas intentar otra vez con la busqueda? (s/n): ");
                        string  leave = Console.ReadLine()?.Trim() ?? "";
                        if (leave == "s")
                        {
                            continue;
                        }
                        break;
                    }
                    Console.WriteLine($"\nUsuario encontrado:");
                    Console.WriteLine($"- Documento: {user.id}");
                    Console.WriteLine($"- Nombre: {user.name}");
                    Console.WriteLine($"- Email: {user.email}");

                    break;
                }
                break;

            case "4":
                Console.WriteLine("Volviendo al menú principal... \n");
                userMenuActive = false;
                break;

            default:
                Console.WriteLine(" Opción no válida");
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
}