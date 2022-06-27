using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileToTableApp.Services
{
    public interface IFileService
    {
        public abstract bool Validate(string fileData);

        public abstract List<Dictionary<string, string>> ReadData(string filePath);

        public abstract string AskForFile();
    }
}
