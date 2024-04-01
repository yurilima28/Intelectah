using Intelectah.Models;
using Intelectah.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Intelectah.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteController(IPacienteRepository PacienteRepository)
        {
            _pacienteRepository = PacienteRepository;
        }
        public IActionResult Index()
        {
            List<PacienteModel> paciente = _pacienteRepository.BuscarTodos();
            return View(paciente);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id) 
        {
            PacienteModel paciente = _pacienteRepository.ListarPorId(id);
            return View(paciente);
        }
        public IActionResult ApagarConfirmacao(int id) 
        {
            PacienteModel paciente = _pacienteRepository.ListarPorId(id);
            return View(paciente);
        }
    }
}
