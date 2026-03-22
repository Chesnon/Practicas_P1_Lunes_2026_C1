Console.WriteLine("Bienvenido a mi lista de Contactes");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("\nDigite el número de la opción deseada\n");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                ViewContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 3: //search
            { 
                SearchContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 4: //modify
            { 
                ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 5: //delete
            { 
                DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}

static void ViewContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine($"____________________________________________________________________________________________________________________________");
    foreach (var id in ids)
    {
        var isBestFriend = bestFriends[id];

        string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}\n");
    }

}
static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Buscar por: 1. Nombre 2. Apellido 3. Telefono 4. Email");
    var opt = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese el término de búsqueda:");
    var term = Console.ReadLine();

    var found = new List<int>();
    foreach (var id in ids)
    {
        switch (opt)
        {
            case 1:
                if (names[id].Contains(term, StringComparison.OrdinalIgnoreCase)) found.Add(id);
                break;
            case 2:
                if (lastnames[id].Contains(term, StringComparison.OrdinalIgnoreCase)) found.Add(id);
                break;
            case 3:
                if (telephones[id].Contains(term, StringComparison.OrdinalIgnoreCase)) found.Add(id);
                break;
            case 4:
                if (emails[id].Contains(term, StringComparison.OrdinalIgnoreCase)) found.Add(id);
                break;
            default:
                Console.WriteLine("Opción inválida");
                return;
        }
    }

    if (found.Count == 0)
    {
        Console.WriteLine("No se encontraron contactos.");
        return;
    }

    Console.WriteLine($"Se encontraron {found.Count} contacto(s):");
    foreach (var id in found)
    {
        var isBestFriendStr = bestFriends[id] ? "Si" : "No";
        Console.WriteLine($"Id:{id} {names[id]} {lastnames[id]} {addresses[id]} {telephones[id]} {emails[id]} {ages[id]} MejorAmigo:{isBestFriendStr}");
    }
}

static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el id del contacto a modificar:");
    if (!int.TryParse(Console.ReadLine(), out var id) || !ids.Contains(id))
    {
        Console.WriteLine("Id inválido o no existe.");
        return;
    }

    Console.WriteLine($"Nombre actual: {names[id]}. Dejar vacío para no cambiar.");
    var input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) names[id] = input;

    Console.WriteLine($"Apellido actual: {lastnames[id]}.");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) lastnames[id] = input;

    Console.WriteLine($"Dirección actual: {addresses[id]}.");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) addresses[id] = input;

    Console.WriteLine($"Teléfono actual: {telephones[id]}.");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) telephones[id] = input;

    Console.WriteLine($"Email actual: {emails[id]}.");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input)) emails[id] = input;

    Console.WriteLine($"Edad actual: {ages[id]}.");
    input = Console.ReadLine();
    if (int.TryParse(input, out var age)) ages[id] = age;

    Console.WriteLine($"Es mejor amigo? Actual: {(bestFriends[id] ? "Si" : "No")} (1=Si, 2=No, Enter para no cambiar)");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input))
    {
        bestFriends[id] = Convert.ToInt32(input) == 1;
    }

    Console.WriteLine("Contacto modificado.");
}

static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el id del contacto a eliminar:");
    if (!int.TryParse(Console.ReadLine(), out var id) || !ids.Contains(id))
    {
        Console.WriteLine("Id inválido o no existe.");
        return;
    }

    ids.Remove(id);
    names.Remove(id);
    lastnames.Remove(id);
    addresses.Remove(id);
    telephones.Remove(id);
    emails.Remove(id);
    ages.Remove(id);
    bestFriends.Remove(id);

    Console.WriteLine("Contacto eliminado.");
}