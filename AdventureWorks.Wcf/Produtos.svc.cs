using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AdventureWorks.Repositorios.SqlServer.EF;

namespace AdventureWorks.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Produtos : IProdutos
    {
        public Product Get(int id)
        {
            using (var dbContext = new AdventureWorks2012Entities1())
            {
                return dbContext.Products.Find(id);
            }
        }

        public List<Product> GetByName(string name)
        {
            using (var dbContext = new AdventureWorks2012Entities1())
            {
                return dbContext.Products.Where(p => p.Name.Contains(name)).ToList();
            }
        }
    }
}