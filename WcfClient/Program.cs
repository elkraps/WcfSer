using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using System.Threading;

namespace WcfClient
{
    internal class CountClient : ServiceReference1.IService1Callback
    {
        static InstanceContext context;
        static void Main(string[] args) 
        { 
            Console.WriteLine("Press any key to count words");

            string filePath = $"I:\\DZ\\Voina_i_mir.txt";

            CountClient handler = new CountClient();

            context = new InstanceContext(handler);

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client(context);

            client.MethodOpenFile(filePath);
            
            Thread.Sleep(10000);

        }

        string newFile = "I:\\DZ\\Save\\Words.txt";
        public void CountCallback(Dictionary<string, int> concurrentDictionary)
        {
            if (concurrentDictionary == null || concurrentDictionary.Count == 0) throw new Exception("Слова не найдены");

            if (!File.Exists(newFile))
            {
                var fileWord = File.Create(newFile);
                fileWord.Close();
            }
            else
            {
                File.Delete(newFile);
                var fileWord = File.Create(newFile);
                fileWord.Close();
            }


            StreamWriter sw = new StreamWriter(newFile);
            foreach (var wc in concurrentDictionary)
            {

                sw.WriteLine(String.Format(($"Слово: {wc.Key}\t Количество: {wc.Value}")));

            }
            sw.Close();
        }       

    }
}
