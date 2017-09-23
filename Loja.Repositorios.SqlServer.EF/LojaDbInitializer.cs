using System.Data.Entity;

namespace Loja.Repositorios.SqlServer.EF
{
    internal class LojaDbInitializer : DropCreateDatabaseAlways<LojaDbContext>
    {

    }
}