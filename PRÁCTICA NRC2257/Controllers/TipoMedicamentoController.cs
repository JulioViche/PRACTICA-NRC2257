using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace PRÁCTICA_NRC2257.Controllers
{
    public class TipoMedicamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<TipoMedicamentoCLS> Listar()
        {
            return TipoMedicamentoBL.Listar();
        }

        public List<TipoMedicamentoCLS> Filtrar(TipoMedicamentoCLS tipoMedicamento)
        {
            return TipoMedicamentoBL.Filtrar(tipoMedicamento);
        }

        public int Guardar(TipoMedicamentoCLS tipoMedicamento)
        {
            return TipoMedicamentoBL.Guardar(tipoMedicamento);
        }
    }
}
