using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Colegio.Data;
using Colegio.Models;

namespace Colegio.Controllers
{
    public class CursosMateriasController : Controller
    {
        private readonly ColegioContext _context;

        public CursosMateriasController(ColegioContext context)
        {
            _context = context;
        }

        // GET: CursosMaterias
        public async Task<IActionResult> Index()
        {
            var colegioContext = _context.ClientesVehiculos.Include(c => c.Curso).Include(c => c.Materia);
            return View(await colegioContext.ToListAsync());
        }

        // GET: CursosMaterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoMateria = await _context.ClientesVehiculos
                .Include(c => c.Curso)
                .Include(c => c.Materia)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoMateria == null)
            {
                return NotFound();
            }

            return View(cursoMateria);
        }

        // GET: CursosMaterias/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Ciclo");
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Nombre");
            return View();
        }

        // POST: CursosMaterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursoId,MateriaId")] CursoMateria cursoMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Ciclo", cursoMateria.CursoId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Nombre", cursoMateria.MateriaId);
            return View(cursoMateria);
        }

        // GET: CursosMaterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoMateria = await _context.ClientesVehiculos.FindAsync(id);
            if (cursoMateria == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Ciclo", cursoMateria.CursoId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Nombre", cursoMateria.MateriaId);
            return View(cursoMateria);
        }

        // POST: CursosMaterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursoId,MateriaId")] CursoMateria cursoMateria)
        {
            if (id != cursoMateria.CursoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoMateriaExists(cursoMateria.CursoId))
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
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Ciclo", cursoMateria.CursoId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Nombre", cursoMateria.MateriaId);
            return View(cursoMateria);
        }

        // GET: CursosMaterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoMateria = await _context.ClientesVehiculos
                .Include(c => c.Curso)
                .Include(c => c.Materia)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (cursoMateria == null)
            {
                return NotFound();
            }

            return View(cursoMateria);
        }

        // POST: CursosMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoMateria = await _context.ClientesVehiculos.FindAsync(id);
            if (cursoMateria != null)
            {
                _context.ClientesVehiculos.Remove(cursoMateria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoMateriaExists(int id)
        {
            return _context.ClientesVehiculos.Any(e => e.CursoId == id);
        }
    }
}
