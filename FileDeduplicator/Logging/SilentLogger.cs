using System;
using System.Collections.Generic;
using System.Text;

namespace FileDeduplicator.Logging
{
    class SilentLogger : ILogger
    {
        public void Dispose() { }

        public void WriteLine(string text) { }

        public void WriteLine() { }
    }
}
