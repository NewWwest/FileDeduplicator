using FileDeduplicator.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileDeduplicator.Processing
{
    static class FileWalker
    {
        static public FileWalkerResult Walk(string path, ILogger logger)
        {
            FileWalkerResult result = new FileWalkerResult();
            ListFiles(path);

            return result;

            void ListFiles(string currentPath)
            {
                foreach (var file in Directory.EnumerateFiles(currentPath))
                {
                    logger.WriteLine(file);
                    AddFile(file);
                }
                foreach (var dir in Directory.EnumerateDirectories(currentPath))
                {
                    logger.WriteLine(dir);
                    ListFiles(dir);
                }

                if (result.fileToPath.Count > FileWalkerConfig.MaxFileProcessed)
                    throw new OperationCanceledException();
            }

            void AddFile(string file)
            {
                string fileName = Path.GetFileName(file);
                string folderName = Path.GetDirectoryName(file);
                logger.WriteLine(fileName);

                if (result.fileToPath.ContainsKey(fileName))
                {
                    result.fileToPath[fileName].Add(folderName);
                }
                else
                {
                    result.fileToPath[fileName] = new List<string>();
                    result.fileToPath[fileName].Add(folderName);
                }

                if (result.filesCountPerFolder.ContainsKey(folderName))
                    result.filesCountPerFolder[folderName]++;
                else
                    result.filesCountPerFolder[folderName] = 1;
            }
        }
    }
}
