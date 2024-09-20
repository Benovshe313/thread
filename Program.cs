using System;
using System.IO;

class Program
{
    static void Main()
    {
        var path = (@"C:\Users\User\Desktop");

        while (true)
        {
            var folders = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);
            int rowNum = 1;

            Console.WriteLine("Folders on desktop:");
            foreach (var folder in folders)
            {
                Console.WriteLine($"{rowNum}. {folder}");
                rowNum++;
            }

            Console.WriteLine("Files on desktop:");
            foreach (var file in files)
            {
                Console.WriteLine($"{rowNum}. {file}");
                rowNum++;
            }

            Console.WriteLine($"{rowNum}. Exit");
            Console.Write("Make choice: ");
            var choice = Console.ReadLine();
            Console.Clear();
            if (int.TryParse(choice, out int option))
            {
                if (option == rowNum) 
                {
                    break;
                }

                if (option > 0 && option <= folders.Length)
                {
                    var choosenFolder = folders[option - 1];
                    exploreFolder(choosenFolder);
                }
                else if (option > folders.Length && option < rowNum)
                {
                    var choosenFile = files[option - folders.Length - 1];

                    for (int i = 0; i < folders.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {folders[i]}");
                    }
                    Console.Write("Select folder: ");
                    var opt = Console.ReadLine();

                    if (int.TryParse(opt, out int selectedFolder) && selectedFolder > 0 && selectedFolder <= folders.Length)
                    {
                        var copyToFolder = folders[selectedFolder - 1];
                        var destinationFile = Path.Combine(copyToFolder, Path.GetFileName(choosenFile));
                        try
                        {
                            File.Copy(choosenFile, destinationFile); 
                            Console.WriteLine("File copied");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        void exploreFolder(string choosenFolder)
        {
            var foldersInFolder = Directory.GetDirectories(choosenFolder);
            var filesInFolder = Directory.GetFiles(choosenFolder);
            int rowNum = 1;

            Console.WriteLine("Folders:");
            foreach (var folder in foldersInFolder)
            {
                Console.WriteLine($"{rowNum}. {folder}");
                rowNum++;
            }

            Console.WriteLine("Files:");
            foreach (var file in filesInFolder)
            {
                Console.WriteLine($"{rowNum}. {file}");
                rowNum++;
            }
        }
    }
}
