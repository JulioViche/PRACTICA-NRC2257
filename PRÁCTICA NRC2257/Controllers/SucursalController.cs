﻿using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace PRÁCTICA_NRC2257.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<SucursalCLS> Listar()
        {
            return SucursalBL.Listar();
        }

        public List<SucursalCLS> Filtrar(SucursalCLS sucursal)
        {
            return SucursalBL.Filtrar(sucursal);
        }

        public SucursalCLS Recuperar(int id)
        {
            return SucursalBL.Recuperar(id);
        }

        public int Guardar(SucursalCLS sucursal)
        {
            return SucursalBL.Guardar(sucursal);
        }

        public int Eliminar(int id)
        {
            return SucursalBL.Eliminar(id);
        }
    }
}
