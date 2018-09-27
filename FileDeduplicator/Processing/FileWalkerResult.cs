using System;
using System.Collections.Generic;
using System.Text;

namespace FileDeduplicator.Processing
{
    class FileWalkerResult
    {
        public Dictionary<string, List<string>> fileToPath = new Dictionary<string, List<string>>();
        public Dictionary<string, int> filesCountPerFolder = new Dictionary<string, int>();
    }
}
