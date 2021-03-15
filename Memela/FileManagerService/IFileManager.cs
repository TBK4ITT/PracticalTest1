using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTest1.FileManagerService
{
    public interface IFileManager
    {
        public List<User> ReadFileContents(string dir);
        public string JsonConverter(List<User> users);
        public void WriteFileContents(string data);

    }
}
