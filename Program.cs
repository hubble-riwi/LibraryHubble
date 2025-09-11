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