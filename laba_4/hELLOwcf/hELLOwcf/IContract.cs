using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace hELLOwcf
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        byte[] Say(string input);
    }
}
