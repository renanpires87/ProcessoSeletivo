using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;

namespace DevIO.Data.Repository
{
    public class BancoRepository : Repository<Banco>, IBancoRepository
    {
        public BancoRepository(MeuDbContext context) : base(context){}

    }
}