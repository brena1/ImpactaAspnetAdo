using AdventureWorks.Repositorios.SqlServer.EF;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AdventureWorks.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProdutos
    {

        [OperationContract]
        Product Get(int id);

        [OperationContract]
        List<Product> GetByName(string name);

    }
}
