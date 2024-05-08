using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestePositivo.Models;

namespace TestePositivo.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var alunos = await _context.AlunoModel.ToListAsync();
            var enderecos = await _context.EnderecoModel.Include(e => e.Aluno).ToListAsync();
            var model = new HomeModel
            {
                Alunos = alunos,
                Enderecos = enderecos
            };
            return View(model);
        }

    }
}
