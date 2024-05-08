using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestePositivo.Models;

namespace TestePositivo.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AppDbContext _context;

        public AlunoController(AppDbContext context)
        {
            _context = context;
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private (string Serie, string Segmento) DetermineSerieAndSegmento(int age)
        {
            string serie = null;
            string segmento = null;

            if (age >= 3 && age <= 5)
            {
                serie = $"G{age - 2}";
                segmento = "Infantil";
            }
            else if (age >= 6 && age <= 10)
            {
                serie = $"{age - 5}º ano";
                segmento = "Anos iniciais";
            }
            else if (age >= 11 && age <= 14)
            {
                serie = $"{age - 5}º ano";
                segmento = "Anos finais";
            }
            else if (age >= 15 && age <= 17)
            {
                serie = $"{age - 14}º ano ensino médio";
                segmento = "Ensino Médio";
            }

            return (serie, segmento);
        }


        // GET: Aluno
        public async Task<IActionResult> Index()
        {
            var alunos = await _context.AlunoModel.ToListAsync();

            return View(alunos);
        }



        // GET: Aluno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.AlunoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            return View(alunoModel);
        }

        // GET: Aluno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCompleto,DataNascimento,NomePai,NomeMae")] AlunoModel alunoModel)
        {
            ModelState.Remove("Serie");
            ModelState.Remove("Segmento");
            if (ModelState.IsValid)
            {
                var age = CalculateAge(alunoModel.DataNascimento);
                (string serie, string segmento) = DetermineSerieAndSegmento(age);
                alunoModel.Serie = serie;
                alunoModel.Segmento = segmento;

                _context.Add(alunoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alunoModel);
        }


        // GET: Aluno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.AlunoModel.FindAsync(id);
            if (alunoModel == null)
            {
                return NotFound();
            }
            return View(alunoModel);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCompleto,DataNascimento,NomePai,NomeMae")] AlunoModel alunoModel)
        {
            if (id != alunoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var age = CalculateAge(alunoModel.DataNascimento);
                (string serie, string segmento) = DetermineSerieAndSegmento(age);
                alunoModel.Serie = serie;
                alunoModel.Segmento = segmento;

                try
                {
                    _context.Update(alunoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoModelExists(alunoModel.Id))
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
            return View(alunoModel);
        }

        // GET: Aluno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.AlunoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            return View(alunoModel);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alunoModel = await _context.AlunoModel.FindAsync(id);
            if (alunoModel != null)
            {
                _context.AlunoModel.Remove(alunoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoModelExists(int id)
        {
            return _context.AlunoModel.Any(e => e.Id == id);
        }
    }
}