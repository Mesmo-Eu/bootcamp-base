using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using AutoMapper;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        public List<TarefaViewModel> listaDeTarefas { get; set; }
        private readonly ITarefaDAO _tarefaDAO;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaDAO tarefaDAO, IMapper mapper)
        {
            _tarefaDAO = tarefaDAO;
            _mapper = mapper;
        }
        
        public IActionResult Details(int id)
        {
            
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);
            
            return View(tarefa);
        }

        public IActionResult Index()
        {            
            
            var listaDeTarefasDTO = _tarefaDAO.Consultar();

            var listaDeTarefa = new List<TarefaViewModel>();

            foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefa.Add(_mapper.Map<TarefaViewModel>(tarefaDTO));
            }
             
            return View(listaDeTarefa);
        }

        public IActionResult Create()
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(TarefaViewModel tarefaViewModel)
        {

            if(!ModelState.IsValid)
            {
                return View();
            }

            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefaViewModel);

            
            _tarefaDAO.Criar(tarefaDTO);

            return View();
        }

        [HttpPost]
        public IActionResult Update(TarefaViewModel tarefaViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            
            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefaViewModel);

           
            _tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

            return View(tarefa);
            
        }

        public IActionResult Delete(int id)
        {
            
            _tarefaDAO.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}