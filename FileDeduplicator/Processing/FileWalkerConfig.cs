using System;
using System.Collections.Generic;
using System.Text;

namespace FileDeduplicator.Processing
{
    static class FileWalkerConfig
    {
        static public readonly int MaxFileProcessed = 100_000;
        static public readonly string[] ignoredFileNames = new string[1] { "Thumbs.db" };
    }
}
