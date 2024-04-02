using Intelectah.Models;
using Intelectah.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Intelectah.Controllers
{
    public class ExameController : Controller
    {
        private readonly IExameRepository _exameRepository;
        private readonly ITipoExameRepository _tipoExameRepository;



        public ExameController(IExameRepository exameRepository, ITipoExameRepository tipoExameRepository)
        {
            _exameRepository = exameRepository;
            _tipoExameRepository = tipoExameRepository;
        }

        [HttpPost]
        [Route("api/meucontroller/minhafuncao")]
        public JsonResult BuscarPorTipoExames(int tipoExameId)
        {
            List<ExameModel> exame = _exameRepository.BuscarPorTipoExame(tipoExameId);
            return Json(exame);
        }
        public IActionResult Index()
        {
            List<ExameModel> exames = _exameRepository.BuscarTodos();
            return View(exames);
        }
        public IActionResult Criar()
        {
            List<TipoExameModel> tipoExames = _tipoExameRepository.BuscarTodosExames();
            ViewBag.tipoExame = tipoExames ?? new List<TipoExameModel>();
            return View();
        }
        public IActionResult Editar(int id)
        {
            ExameModel exame = _exameRepository.ListarPorId(id);
            List<TipoExameModel> tipoExames = _tipoExameRepository.BuscarTodosExames();
            ViewBag.tipoExame = tipoExames;
            return View(exame);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ExameModel exame = _exameRepository.ListarPorId(id);
            return View(exame);

        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _exameRepository.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Exame apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar o exame";
                }
                return RedirectToAction("Index");

            }
            catch(Exception erro) 
            {
                TempData["MensagemErro"] = $"Não conseguimos apagar o exame, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Criar(ExameModel exame)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _exameRepository.Adicionar(exame);
                    TempData["MensagemSucesso"] = "Exame cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                List<TipoExameModel> tipoExames = _tipoExameRepository.BuscarTodosExames();
                ViewBag.tipoExame = tipoExames !=null ? tipoExames: new List<TipoExameModel>();
                return View(exame);

            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Exame não cadastrado, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(ExameModel exame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _exameRepository.Atualizar(exame);
                    TempData["MensagemSucesso"] = "Nome ou descrioção do exame alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", exame);
            }
            catch(Exception erro ) 
            {
                TempData["MensagemErro"] = $"Não conseguimos atualizar os dados do paciente, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
