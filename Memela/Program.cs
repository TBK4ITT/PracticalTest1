using PracticalTest1.FileManagerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Memela
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = @"C:\development\Memela\BDG_Input.txt";
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileManager, FileManager>()
                .BuildServiceProvider();

            
            Console.WriteLine("Starting application....");

            var fileManager = serviceProvider.GetService<IFileManager>();

            Console.WriteLine("Read the file from the directory");
            var fileContents = fileManager.ReadFileContents(dir);

            Console.WriteLine("Convert the file into json data");
            var jsonData = fileManager.JsonConverter(fileContents);

            Console.WriteLine("Create new json file with the data");
            fileManager.WriteFileContents(jsonData);

            Console.ReadLine();
        }
    }
}
