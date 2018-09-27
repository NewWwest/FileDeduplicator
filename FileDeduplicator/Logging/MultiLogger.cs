using System;
using System.Collections.Generic;
using System.Text;

namespace FileDeduplicator.Logging
{
    class MultiLogger : ILogger
    {
        IEnumerable<ILogger> _loggers;

        public MultiLogger(IEnumerable<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public void Dispose()
        {
            foreach (var logger in _loggers)
            {
                logger.Dispose();
            }
        }

        public void WriteLine(string text)
        {
            foreach (var logger in _loggers)
            {
                logger.WriteLine(text);
            }
        }

        public void WriteLine()
        {
            foreach (var logger in _loggers)
            {
                logger.WriteLine();
            }
        }
    }
}
