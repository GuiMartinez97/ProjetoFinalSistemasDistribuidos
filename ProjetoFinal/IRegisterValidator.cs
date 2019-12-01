using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    [ServiceContract]
    public interface IRegisterValidator
    {
        [OperationContract]
        List<string> ValidateRegister(List<string> _cpfs);
    }
}
