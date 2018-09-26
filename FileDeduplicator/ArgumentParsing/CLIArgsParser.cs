using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileDeduplicator.ArgumentParsing
{
    static class CLIArgsParser
    {

        public static Args Parse(string[] args)
        {
            Args result = new Args();
            for (int i = 0; i < args.Length; i++)
            {
                if (Args.LongParams.Contains(args[i]))
                {
                    var key = args[i];
                    key = key.Substring(2, key.Length - 2);
                    string value = args[i + 1];
                    result.SetLongParam(key, value);
                    continue;
                }
                if (Args.ShortParams.Contains(args[i]))
                {
                    var key = args[i];
                    key = key.Substring(1, key.Length - 1);
                    string value = args[i + 1];
                    result.SetShortParam(key, value);
                    continue;
                }

            }
            return result;
        }

        

        

        
    }
}
