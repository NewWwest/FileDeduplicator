using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileDeduplicator
{
    class FileWalker
    {
        public Dictionary<string, List<string>> fileToPath = new Dictionary<string, List<string>>();
        int MAX_COUNT = 100_000;
        string[] ignoredFileNames = new string[1] { "Thumbs.db" };
        public object ListFiles(string path)
        {
            foreach (var file in Directory.EnumerateFiles(path))
            {
                Console.WriteLine(file);
                AddFile(file);
            }
            foreach (var dir in Directory.EnumerateDirectories(path))
            {
                Console.WriteLine(dir);
                ListFiles(dir);
            }
            if (fileToPath.Count > MAX_COUNT)
                throw new OperationCanceledException();
            return null;
        }

        private void AddFile(string file)
        {
            string fileName = Path.GetFileName(file);
            Console.WriteLine(fileName);

            if (fileToPath.ContainsKey(fileName))
            {
                fileToPath[fileName].Add(file);
            }
            else
            {
                fileToPath[fileName] = new List<string>();
                fileToPath[fileName].Add(file);
            }
        }


        public void ProcessResult()
        {
            Console.WriteLine();
            Console.WriteLine("SUMMARY");
            Console.WriteLine();
            int dubbedKeys = 0;
            int dubbedValues = 0;
            foreach (var item in fileToPath.Where(kv => kv.Value.Count > 2).Where(kv=> !ignoredFileNames.Contains(kv.Key)))
            {
                dubbedKeys++;
                Console.WriteLine($"FILE: {item.Key} is in multiple folders:");
                foreach (var folder in item.Value)
                {
                    dubbedValues++;
                    Console.WriteLine(folder);
                }
            }
            Console.WriteLine();
            Console.WriteLine("SUMMARY of SUMMARY");
            Console.WriteLine();
            Console.WriteLine($"You can remove {dubbedValues-dubbedKeys}");
        }
    }
}
