using Delivery.Context;
using Delivery.Models;

namespace Delivery.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche? GetLancheById(int id);
    }
}
