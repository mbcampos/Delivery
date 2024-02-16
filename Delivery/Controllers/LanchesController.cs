using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Delivery.Context;
using Delivery.Models;
using Delivery.ViewModels;

namespace Delivery.Controllers
{
    public class LanchesController : Controller
    {
        private readonly AppDbContext _context;

        public LanchesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lanches
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Lanches";

            var lanchesListViewModel = new LancheListViewModel();

            lanchesListViewModel.Lanches = _context.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lanchesListViewModel);
        }

        public async Task<IActionResult> List(string categoria)
        {
            ViewData["Title"] = "Lanches";

            var lanchesListViewModel = new LancheListViewModel();

            if (string.IsNullOrEmpty(categoria))
            {
                lanchesListViewModel.Lanches = _context.Lanches;
                lanchesListViewModel.CategoriaAtual = "Categoria Atual";
            } 
            else
            {
                lanchesListViewModel.Lanches = _context.Lanches.Include(x => x.Categoria)
                    .Where(x => x.Categoria.CategoriaNome.ToLower().Equals(categoria.ToLower())).ToList();
            }

            return View("Index", lanchesListViewModel);
        }

        // GET: Lanches/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Lanches == null)
        //    {
        //        return NotFound();
        //    }

        //    var lanche = await _context.Lanches
        //        .Include(l => l.Categoria)
        //        .FirstOrDefaultAsync(m => m.LancheId == id);
        //    if (lanche == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(lanche);
        //}

        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Lanches == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanches.Include(l => l.Categoria).FirstOrDefaultAsync(m => m.LancheId == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // GET: Lanches/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId");
            return View();
        }

        // POST: Lanches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LancheId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lanche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", lanche.CategoriaId);
            return View(lanche);
        }

        // GET: Lanches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lanches == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanches.FindAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", lanche.CategoriaId);
            return View(lanche);
        }

        // POST: Lanches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LancheId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId")] Lanche lanche)
        {
            if (id != lanche.LancheId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lanche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancheExists(lanche.LancheId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", lanche.CategoriaId);
            return View(lanche);
        }

        // GET: Lanches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lanches == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanches
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.LancheId == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // POST: Lanches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lanches == null)
            {
                return Problem("Entity set 'AppDbContext.Lanches'  is null.");
            }
            var lanche = await _context.Lanches.FindAsync(id);
            if (lanche != null)
            {
                _context.Lanches.Remove(lanche);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancheExists(int id)
        {
          return (_context.Lanches?.Any(e => e.LancheId == id)).GetValueOrDefault();
        }
    }
}
