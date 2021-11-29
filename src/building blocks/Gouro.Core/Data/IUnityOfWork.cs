using System.Threading.Tasks;

namespace Gouro.Core.Data
{
    public interface IUnityOfWork
    {
        Task<bool> Commit();
    }
}
