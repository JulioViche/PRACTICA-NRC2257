using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class LaboratorioBL
    {
        static public List<LaboratorioCLS> Listar()
        {
            return LaboratorioDAL.Listar();
        }

        static public List<LaboratorioCLS> Filtrar(LaboratorioCLS laboratorio)
        {
            return LaboratorioDAL.Filtrar(laboratorio);
        }
    }
}
