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

        static private TipoMedicamentoCLS Buscar(SqlDataReader reader)
        {
            TipoMedicamentoCLS tipoMedicamento = null;
            if (reader != null)
            {
                int idOrdinal = reader.GetOrdinal("IIDTIPOMEDICAMENTO");
                int nombreOrdinal = reader.GetOrdinal("NOMBRE");
                int descripcionOrdinal = reader.GetOrdinal("DESCRIPCION");
                while (reader.Read())
                {
                    tipoMedicamento = new TipoMedicamentoCLS();
                    tipoMedicamento.Id = reader.GetInt32(idOrdinal);
                    tipoMedicamento.Nombre = reader.IsDBNull(nombreOrdinal) ? "" : reader.GetString(nombreOrdinal);
                    tipoMedicamento.Descripcion = reader.IsDBNull(descripcionOrdinal) ? "" : reader.GetString(descripcionOrdinal);
                }
            }
            return tipoMedicamento;
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

        static public TipoMedicamentoCLS Recuperar(int id)
        {
            TipoMedicamentoCLS tipoMedicamento = null;
            Connection.ExecuteQuery("SELECT * FROM TipoMedicamento WHERE BHABILITADO = 1 AND IIDTIPOMEDICAMENTO = @id", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                tipoMedicamento = Buscar(cmd.ExecuteReader());
            });
            return tipoMedicamento;
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

        static public int Actualizar(TipoMedicamentoCLS tipoMedicamento)
        {
            int actualizado = 0;
            Connection.ExecuteQuery("uspActualizarTipoMedicamento", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", tipoMedicamento.Id);
                cmd.Parameters.AddWithValue("@nombre", tipoMedicamento.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", tipoMedicamento.Descripcion);
                actualizado = cmd.ExecuteNonQuery();
            });
            return actualizado;
        }

        static public int Eliminar(int id)
        {
            int eliminado = 0;
            Connection.ExecuteQuery("uspEliminarTipoMedicamento", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                eliminado = cmd.ExecuteNonQuery();
            });
            return eliminado;
        }
    }
}
