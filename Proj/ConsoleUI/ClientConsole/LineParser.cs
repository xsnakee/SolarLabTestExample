using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientConsole
{
    public class LineParser
    {
        private List<string> SplitLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return null;
            }

            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                       .ToList();
        }

        public int? AnalizeLine(string line)
        {
            var result = SplitLine(line);

            if (result == null || result.Count == 0 || result[0].ToLower() == "q")
            {
                return null;
            }

            if (result.Count > 1)
            {
                throw new ApplicationException("Не верный ввод!");
            }
            int id;
            if (Int32.TryParse(result[0], out id))
            {
                return id;
            }

            throw new ApplicationException("Ввод должен быть либо числом, либо q");
        }
    }
}
