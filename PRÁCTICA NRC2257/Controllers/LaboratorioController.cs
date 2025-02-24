using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace PRÁCTICA_NRC2257.Controllers
{
    public class LaboratorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<LaboratorioCLS> Listar()
        {
            return LaboratorioBL.Listar();
        }

        public List<LaboratorioCLS> Filtrar(LaboratorioCLS laboratorio)
        {
            return LaboratorioBL.Filtrar(laboratorio);
        }
    }
}
