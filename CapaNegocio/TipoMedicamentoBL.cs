using CapaDatos;

namespace CapaNegocio
{
    public class TipoMedicamentoBL
    {
        static public List<TipoMedicamentoCLS> Listar()
        {
            return TipoMedicamentoDAL.Listar();
        }

        static public List<TipoMedicamentoCLS> Filtrar(TipoMedicamentoCLS tipoMedicamento)
        {
            return TipoMedicamentoDAL.Filtrar(tipoMedicamento);
        }

        static public int Guardar(TipoMedicamentoCLS tipoMedicamento)
        {
            return TipoMedicamentoDAL.Guardar(tipoMedicamento);
        }

        static public TipoMedicamentoCLS Recuperar(int id)
        {
            return TipoMedicamentoDAL.Recuperar(id);
        }
    }
}
