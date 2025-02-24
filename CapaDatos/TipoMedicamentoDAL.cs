using System.Data.SqlClient;
using CapaNegocio;

namespace CapaDatos
{
    public class TipoMedicamentoDAL
    {
        static private List<TipoMedicamentoCLS> Leer(SqlDataReader reader)
        {
            List<TipoMedicamentoCLS> lista = null;
            if (reader != null)
            {
                lista = new List<TipoMedicamentoCLS>();
                TipoMedicamentoCLS tipoMedicamento;
                int idOrdinal = reader.GetOrdinal("IIDTIPOMEDICAMENTO");
                int nombreOrdinal = reader.GetOrdinal("NOMBRE");
                int descripcionOrdinal = reader.GetOrdinal("DESCRIPCION");
                while (reader.Read())
                {
                    tipoMedicamento = new TipoMedicamentoCLS();
                    tipoMedicamento.Id = reader.GetInt32(idOrdinal);
                    tipoMedicamento.Nombre = reader.IsDBNull(nombreOrdinal) ? "" : reader.GetString(nombreOrdinal);
                    tipoMedicamento.Descripcion = reader.IsDBNull(descripcionOrdinal) ? "" : reader.GetString(descripcionOrdinal);
                    lista.Add(tipoMedicamento);
                }
            }
            return lista;
        }

        static public List<TipoMedicamentoCLS> Listar()
        {
            List<TipoMedicamentoCLS> lista = null;
            Connection.ExecuteQuery("uspListarTipoMedicamento", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                lista = Leer(cmd.ExecuteReader());
            });
            return lista;
        }

        static public List<TipoMedicamentoCLS> Filtrar(TipoMedicamentoCLS tipoMedicamento)
        {
            List<TipoMedicamentoCLS> lista = null;
            Connection.ExecuteQuery("uspFiltrarTipoMedicamento", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descmedicamento", string.IsNullOrEmpty(tipoMedicamento.Descripcion) ? "" : tipoMedicamento.Descripcion);
                lista = Leer(cmd.ExecuteReader());
            });
            return lista;
        }

        static public int Guardar(TipoMedicamentoCLS tipoMedicamento)
        {
            int guardado = 0;
            Connection.ExecuteQuery("uspGuardarTipoMedicamento", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", tipoMedicamento.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", tipoMedicamento.Descripcion);
                guardado = cmd.ExecuteNonQuery();
            });
            return guardado;
        }
    }
}
