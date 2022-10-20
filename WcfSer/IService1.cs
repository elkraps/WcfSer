using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfSer
{
    
    [ServiceContract(CallbackContract= typeof(IMyContract))]
    public interface IService1
    {
        [OperationContract(IsOneWay = true)]

        Task MethodOpenFile(string sr);
    }
    [ServiceContract]
    public interface IMyContract
    {
        [OperationContract(IsOneWay = true)]
        
        Task CountCallback(Dictionary<string, int> concurrentDictionary);  
    }
}
