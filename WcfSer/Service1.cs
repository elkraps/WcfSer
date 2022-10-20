using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace WcfSer
{
    [ServiceBehavior]
    public class Service1 : IService1
    {
        public async Task MethodOpenFile(string filePath)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMyContract>();

            ConcurrentDictionary<string, int> concurrentDictionary = new ConcurrentDictionary<string, int>();

            StreamReader sr = new StreamReader(filePath);

            Library1 library = new Library1();
           
            library.NewMethodText(sr, concurrentDictionary);

            sr.Close();
                    
            while (((IClientChannel)callback).State == CommunicationState.Opened)
            {
                await callback.CountCallback(concurrentDictionary.OrderByDescending(x => x.Value).ToDictionary(key => key.Key, value => value.Value));               
            }
        }
    }
}
