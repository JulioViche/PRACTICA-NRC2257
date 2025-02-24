using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class LaboratorioDAL
    {
        static public List<LaboratorioCLS> Leer(SqlDataReader reader)
        {
            List<LaboratorioCLS> lista = new List<LaboratorioCLS>();
            if (reader != null)
            {
                lista = new List<LaboratorioCLS>();
                LaboratorioCLS laboratorio;
                int idOrdinal = reader.GetOrdinal("IIDLABORATORIO");
                int nombreOrdinal = reader.GetOrdinal("NOMBRE");
                int direccionOrdinal = reader.GetOrdinal("DIRECCION");
                int contactoOrdinal = reader.GetOrdinal("PERSONACONTACTO");
                while (reader.Read())
                {
                    laboratorio = new LaboratorioCLS();
                    laboratorio.Id = reader.GetInt32(idOrdinal);
                    laboratorio.Nombre = reader.IsDBNull(nombreOrdinal) ? "" : reader.GetString(nombreOrdinal);
                    laboratorio.Direccion = reader.IsDBNull(direccionOrdinal) ? "" : reader.GetString(direccionOrdinal);
                    laboratorio.Contacto = reader.IsDBNull(contactoOrdinal) ? "" : reader.GetString(contactoOrdinal);
                    lista.Add(laboratorio);
                }
            }
            return lista;
        }

        static public List<LaboratorioCLS> Listar()
        {
            List<LaboratorioCLS> lista = null;
            Connection.ExecuteQuery("uspListarLaboratorio", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                lista = Leer(cmd.ExecuteReader());
            });
            return lista;
        }

        static public List<LaboratorioCLS> Filtrar(LaboratorioCLS laboratorio)
        {
            List<LaboratorioCLS> lista = null;
            Connection.ExecuteQuery("uspFiltrarLaboratorio", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(laboratorio.Nombre) ? "" : laboratorio.Nombre);
                cmd.Parameters.AddWithValue("@direccion", string.IsNullOrEmpty(laboratorio.Direccion) ? "" : laboratorio.Direccion);
                cmd.Parameters.AddWithValue("@personacontacto", string.IsNullOrEmpty(laboratorio.Contacto) ? "" : laboratorio.Contacto);
                lista = Leer(cmd.ExecuteReader());
            });
            return lista;
        }
    }
}
