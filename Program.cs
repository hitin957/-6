using Newtonsoft.Json;
int posit = 0;
do
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Выберете формат файла");
    Console.SetCursorPosition(2, 1);
    Console.WriteLine("TxT");
    Console.SetCursorPosition(2, 2);
    Console.WriteLine("Jons");
    Console.SetCursorPosition(2, 3);
    Console.WriteLine("XML");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.UpArrow)
    {
        Console.Clear();
        posit--;
        Console.SetCursorPosition(0, posit);
        Console.WriteLine("->");
    }
    if (key.Key == ConsoleKey.DownArrow)
    {
        Console.Clear();
        posit++;
        Console.SetCursorPosition(0, posit);
        Console.WriteLine("->");
    }
    if (posit == 1 && key.Key == ConsoleKey.Enter)
    {
        TXT();
    }
    if (posit == 2 && key.Key == ConsoleKey.Enter)
    {
        Json();
    }
    if (posit == 3 && key.Key == ConsoleKey.Enter)
    {
        XML();
    }
    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }
}
while (true);

static void TXT()
{
    Console.WriteLine("Введите текст, который хотите сохранить");
    string read = Console.ReadLine();
    Human andrey = new Human();
    andrey.Name = "Андрей";
    List<Human> humans = new List<Human>();
    humans.Add(andrey);
    string text = File.ReadAllText("C:\\Users\\nikol\\Desktop\\практическая №6.txt");
    File.AppendAllText("C:\\Users\\nikol\\Desktop\\практическая №6.txt", "\n");
    File.AppendAllText("C:\\Users\\nikol\\Desktop\\практическая №6.txt", andrey.Name);
    File.AppendAllText("C:\\Users\\nikol\\Desktop\\практическая №6.txt", "\n");
    File.AppendAllText("C:\\Users\\nikol\\Desktop\\практическая №6.txt", read);
    Console.SetCursorPosition(5, 5);
    Console.WriteLine(text);
    Console.ReadKey();
    Console.Clear();
}

static void XML()
{
    Console.WriteLine("Введите текст, который хотите сохранить");
    string read = Console.ReadLine();
    Human andrey = new Human();
    andrey.Name = "Андрей";

    List<Human> humans = new List<Human>();
    humans.Add(andrey);

    System.Xml.Serialization.XmlSerializer XML = new System.Xml.Serialization.XmlSerializer(typeof(Human));
    using (FileStream fs = new FileStream("C:\\Users\\nikol\\Desktop\\хамелеон.XML", FileMode.OpenOrCreate))
    {
        XML.Serialize(fs, andrey);
        XML.Serialize(fs, read);
    }

    Human human;

    System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(Human));
    using (FileStream fs = new FileStream("C:\\Users\\nikol\\Desktop\\хамелеон.XML", FileMode.Open))
    {
        human = (Human)XML.Deserialize(fs);
    }
}
static void Json()
{
    Console.WriteLine("Введите текст, который хотите сохранить");
    string read = Console.ReadLine();
    Human andrey = new Human();
    andrey.Name = "Андрей";
    List<Human> humans = new List<Human>();
    humans.Add(andrey);
    string json = JsonConvert.SerializeObject(humans);// сериализация
    File.AppendAllText("C:\\Users\\nikol\\Desktop\\джин.json", "\n"); // гипер-прыжок переменных из измерения Си-шарпа в измерение Джей-сона. 
    File.AppendAllText("C:\\Users\\nikol\\Desktop\\джин.json", json);
    File.AppendAllText("C:\\Users\\nikol\\Desktop\\джин.json", "\n");
    File.AppendAllText("C:\\Users\\nikol\\Desktop\\джин.json", read);
    string text = File.ReadAllText("C:\\Users\\nikol\\Desktop\\джин.json");// десериализация
    List<Human> result = JsonConvert.DeserializeObject<List<Human>>(text);// гипер-прыжок переменных из измерения Джей-сона в измерение Си-шарп. 
    Console.SetCursorPosition(5, 5);
    Console.WriteLine(text);
    Console.ReadKey();
    Console.Clear();
}
