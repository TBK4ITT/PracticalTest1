using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace PracticalTest1.FileManagerService
{
    public class FileManager : IFileManager
    {
        public void WriteFileContents(string data)
        {
            File.WriteAllText("C:\\development\\Memela\\BDG_Output.json", data);
        }

        public string JsonConverter(List<User> users)
        {
            return JsonSerializer.Serialize(users); ;
        }

        public List<User> ReadFileContents(string dir)
        {
            var users = new List<User>();
            if (File.Exists(dir))
            {
                var file = new StreamReader(dir);
                int counter = 0;
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] rowData = line.Split("|");
                        users.Add(new User { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], 
                            Surname = rowData[2], EmailAddress = rowData[3], Gender = rowData[4], 
                            IpAddress = rowData[5] });
                    }
                    counter++;
                }
                file.Close();
            }

            return users;
        }
    }
}
