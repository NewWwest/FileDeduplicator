using FileDeduplicator.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDeduplicator.Processing
{
    static class FileWalkerAnalyzer
    {
        static public void AnalyzeResult(FileWalkerResult data, ILogger logger)
        {
            var duplicatesPerFolder = new Dictionary<string, int>();
            logger.WriteLine();
            logger.WriteLine("SUMMARY");
            logger.WriteLine();
            int dubbedKeys = 0;
            int dubbedValues = 0;
            foreach (var item in data.fileToPath.Where(kv => kv.Value.Count > 2).Where(kv => !FileWalkerConfig.ignoredFileNames.Contains(kv.Key)))
            {
                dubbedKeys++;
                logger.WriteLine($"FILE: {item.Key} is in multiple folders:");
                foreach (var folder in item.Value)
                {
                    dubbedValues++;
                    logger.WriteLine(folder);
                    if (duplicatesPerFolder.ContainsKey(folder))
                        duplicatesPerFolder[folder]++;
                    else
                        duplicatesPerFolder[folder] = 1;
                }
            }
            logger.WriteLine();
            logger.WriteLine();
            logger.WriteLine($"You can remove {dubbedValues - dubbedKeys} files");


            logger.WriteLine($"Directories with duplicates ({duplicatesPerFolder.Keys.Count}):");
            foreach (var folder in duplicatesPerFolder.Keys.OrderBy(f => f))
            {
                float percentage = (float)duplicatesPerFolder[folder] / data.filesCountPerFolder[folder];
                logger.WriteLine($"{folder} is in {percentage.ToString("p")} duplicated");
            }
        }
    }
}
