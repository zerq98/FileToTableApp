using FileToTableApp.Services;

bool readFile = false;

do
{
    IFileService fileService = new JsonService();
    var path = fileService.AskForFile();
    if (path != "")
    {
        var data = fileService.ReadData(path);
        DisplayData(data);
    }


    Console.WriteLine("Do you want to read next file? ('Y')");
    var input = Console.ReadLine();
    readFile = input != null && input=="Y";
} while (readFile);


static void DisplayData(List<Dictionary<string, string>> data)
{
    WriteEmptyLine();
    foreach(var item in data[0])
    {
        Console.Write($"|   {item.Key}   ");
    }

    Console.Write("|");

    foreach(var item in data)
    {
        WriteEmptyLine();
        foreach (var prop in item)
        {
            Console.Write($"|   {prop.Value}   ");
        }

        Console.Write("|");
    }

    Console.WriteLine();
}

static void WriteEmptyLine()
{
    Console.WriteLine();
    for (int i = 0; i < 50; i++)
    {
        Console.Write('-');
    }

    Console.WriteLine();
}