using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgFilter.Filters.WordsFilter
{
    class Filter
    {
        WordCleaner wordCleaner = new WordCleaner();

        public void StartFiltering(string inputPath, string outputPath, int n)
        {
            Console.WriteLine("Start filtering ngram (" + n + "gram)...");
            int counter = 0;
            string line = String.Empty;

            using (StreamWriter outfile = new StreamWriter(outputPath))
            using (StreamReader sr = File.OpenText(inputPath))
            {
                while ((line = sr.ReadLine()) != null) // read file
                {
                    ++counter;
                    var processedLine = ProcessLine(line, n);

                    if (processedLine != String.Empty)
                        outfile.WriteLine(processedLine);

                    if (counter % 50000 == 0)
                        Console.Write("\r" + n + "gram - " + ((float)counter / 1000000f));
                }
            }

            Console.WriteLine("\nDone filtering ngram (" + n + "gram)");
        }

        private string ProcessLine(string line, int n)
        {
            string[] words = new string[n];
            string result = String.Empty;

            line = line.Trim();
            var data = line.Split(' ');
            result += data[0];

            if (data.Count() < n + 1) // end if there is to low data in line
                return String.Empty;

            for (int i = 0; i < n; ++i)
                words[i] = wordCleaner.Clear(data[i + 1]);

            for (int i = 0; i < words.Length; ++i)
            {
                if (words[i] != string.Empty)
                    result += " " + words[i];
                else
                    return string.Empty;
            }

            return result;
        }

    }
}
