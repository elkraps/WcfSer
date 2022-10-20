using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    public class Library1
    {
        public void NewMethodText(StreamReader sr, ConcurrentDictionary<string, int> concurrentDictionary)
        {
            string line = sr.ReadLine();

            string text = "";
            while (line != null)
            {
                line = sr.ReadLine();
                text += "\n";
                text += line;
            }

            text = Regex.Replace(text, "[!\"#$%&'()*+,-./:;<=>?@\\[\\]^_`{|}~[0-9]]", "").ToLower();

            string[] words = text.Split(' ', '\n', '\t');

             Parallel.ForEach(words, word => 
            {
                concurrentDictionary.AddOrUpdate(word,1, (key, oldValue) => oldValue +1);

            });
           
            
        }
    }
}
