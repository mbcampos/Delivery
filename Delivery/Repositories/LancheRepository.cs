using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(x => x.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(x => x.IsLanchePreferido).Include(x => x.Categoria);

        public Lanche GetLancheById(int id)
        {
            return _context.Lanches.FirstOrDefault(x => x.LancheId == id);
        }
    }
}
