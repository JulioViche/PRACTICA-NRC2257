using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class SucursalBL
    {
        static public List<SucursalCLS> Listar()
        {
            return SucursalDAL.Listar();
        }

        static public List<SucursalCLS> Filtrar(SucursalCLS sucursal)
        {
            return SucursalDAL.Filtrar(sucursal);
        }

        static public SucursalCLS Recuperar(int id)
        {
            return SucursalDAL.Recuperar(id);
        }

        static public int Guardar(SucursalCLS sucursal)
        {
            return SucursalDAL.Guardar(sucursal);
        }

        static public int Eliminar(int id)
        {
            return SucursalDAL.Eliminar(id);
        }
    }
}
