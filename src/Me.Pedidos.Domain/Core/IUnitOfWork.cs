using System.Threading.Tasks;

namespace Me.Pedidos.Domain.Core
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}