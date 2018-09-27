using FileDeduplicator.Logging;
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
        public Dictionary<string, int> filesCountPerFolder = new Dictionary<string, int>();

        ILogger _logger;
        string _path;
        public FileWalker(string path, ILogger logger)
        {
            _logger = logger;
            _path=path;
        }

        public void DoWork()
        {
            ListFiles(_path);
        }

        private object ListFiles(string path)
        {
            foreach (var file in Directory.EnumerateFiles(path))
            {
                _logger.WriteLine(file);
                AddFile(file);
            }
            foreach (var dir in Directory.EnumerateDirectories(path))
            {
                _logger.WriteLine(dir);
                ListFiles(dir);
            }

            if (fileToPath.Count > FileWalkerConfig.MaxFileProcessed)
                throw new OperationCanceledException();

            return null;
        }

        private void AddFile(string file)
        {
            string fileName = Path.GetFileName(file);
            string folderName = Path.GetDirectoryName(file);
            _logger.WriteLine(fileName);

            if (fileToPath.ContainsKey(fileName))
            {
                fileToPath[fileName].Add(folderName);
            }
            else
            {
                fileToPath[fileName] = new List<string>();
                fileToPath[fileName].Add(folderName);
            }

            if (filesCountPerFolder.ContainsKey(folderName))
                filesCountPerFolder[folderName]++;
            else
                filesCountPerFolder[folderName] = 1;
        }


        public void ProcessResult()
        {
            var duplicatesPerFolder = new Dictionary<string, int>();
            _logger.WriteLine();
            _logger.WriteLine("SUMMARY");
            _logger.WriteLine();
            int dubbedKeys = 0;
            int dubbedValues = 0;
            foreach (var item in fileToPath.Where(kv => kv.Value.Count > 2).Where(kv=> !FileWalkerConfig.ignoredFileNames.Contains(kv.Key)))
            {
                dubbedKeys++;
                _logger.WriteLine($"FILE: {item.Key} is in multiple folders:");
                foreach (var folder in item.Value)
                {
                    dubbedValues++;
                    _logger.WriteLine(folder);
                    if (duplicatesPerFolder.ContainsKey(folder))
                        duplicatesPerFolder[folder]++;
                    else
                        duplicatesPerFolder[folder] = 1;
                }
            }
            _logger.WriteLine();
            _logger.WriteLine();
            _logger.WriteLine($"You can remove {dubbedValues-dubbedKeys} files");


            _logger.WriteLine($"Directories with duplicates ({duplicatesPerFolder.Keys.Count}):");
            foreach (var folder in duplicatesPerFolder.Keys.OrderBy(f=>f))
            {
                float percentage = (float)duplicatesPerFolder[folder] / filesCountPerFolder[folder];
                _logger.WriteLine($"{folder} is in {percentage.ToString("p")} duplicated");
            }
        }
    }
}
