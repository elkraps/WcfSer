using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using WcfSer;

namespace Wcf_Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var host = new ServiceHost(typeof(WcfSer.Service1)))
            {
                host.Open();
                Console.WriteLine("The server is ready.");
                Console.ReadLine();
            }
        }
    }
}
