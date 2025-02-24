using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class SucursalDAL
    {
        static public List<SucursalCLS> Leer(SqlDataReader reader)
        {
            List<SucursalCLS> lista = null;
            if (reader != null)
            {
                lista = new List<SucursalCLS>();
                SucursalCLS sucursal;
                int idOrdinal = reader.GetOrdinal("IIDSUCURSAL");
                int nombreOrdinal = reader.GetOrdinal("NOMBRE");
                int direccionOrdinal = reader.GetOrdinal("DIRECCION");
                while (reader.Read())
                {
                    sucursal = new SucursalCLS();
                    sucursal.Id = reader.GetInt32(idOrdinal);
                    sucursal.Nombre = reader.IsDBNull(nombreOrdinal) ? "" : reader.GetString(nombreOrdinal);
                    sucursal.Direccion = reader.IsDBNull(direccionOrdinal) ? "" : reader.GetString(direccionOrdinal);
                    lista.Add(sucursal);
                }
            }
            return lista;
        }

        static public List<SucursalCLS> Listar()
        {
            List<SucursalCLS> lista = null;
            Connection.ExecuteQuery("uspListarSucursal", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                lista = Leer(cmd.ExecuteReader());
            });
            return lista;
        }

        static public List<SucursalCLS> Filtrar(SucursalCLS sucursal)
        {
            List<SucursalCLS> lista = null;
            Connection.ExecuteQuery("uspFiltrarSucursal", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(sucursal.Nombre) ? "" : sucursal.Nombre);
                cmd.Parameters.AddWithValue("@direccion", string.IsNullOrEmpty(sucursal.Direccion) ? "" : sucursal.Direccion);
                lista = Leer(cmd.ExecuteReader());
            });
            return lista;
        }

        static public int Guardar(SucursalCLS sucursal)
        {
            int guardado = 0;
            Connection.ExecuteQuery("INSERT INTO SUCURSAL(NOMBRE, DIRECCION, BHABILITADO) VALUES(@nombre, @direccion, 1);", (cmd) =>
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", sucursal.Nombre);
                cmd.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                guardado = cmd.ExecuteNonQuery();
            });
            return guardado;
        }
    }
}
