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

        static public TipoMedicamentoCLS Recuperar(int id)
        {
            return TipoMedicamentoDAL.Recuperar(id);
        }

        static public int Guardar(TipoMedicamentoCLS tipoMedicamento)
        {
            return tipoMedicamento.Id == 0 ? TipoMedicamentoDAL.Guardar(tipoMedicamento) : TipoMedicamentoDAL.Actualizar(tipoMedicamento);
        }
    }
}
