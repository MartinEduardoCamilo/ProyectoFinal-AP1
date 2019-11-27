using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL.Tests
{
    [TestClass()]
    public class FacturaBLLTests
    {
        [TestMethod()]
        public void BuscarTest()
        {
            FacturaBLL repositorio = new FacturaBLL();
            Facturas factura = new Facturas();
            factura = repositorio.Buscar(1);
            Assert.IsNotNull(factura);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            FacturaBLL repositorio = new FacturaBLL();
            Assert.IsTrue(repositorio.Eliminar(1));
        }

        [TestMethod()]
        public void GuardarTest()
        {

            FacturaBLL repositorio = new FacturaBLL();
            Facturas factura = new Facturas();
            List<DetalleFactura> detalle = new List<DetalleFactura>();
            factura.FacturaId = 0;
            factura.ClienteId = 1;
            factura.Fecha = DateTime.Now;
            factura.EventoId = 1;
            factura.Detalles = detalle;
            factura.Total = 0;
            Assert.IsTrue(repositorio.Guardar(factura));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            FacturaBLL repositorio = new FacturaBLL();
            Facturas factura = new Facturas();
            List<DetalleFactura> detalle = new List<DetalleFactura>();
            factura.FacturaId = 0;
            factura.ClienteId = 1;
            factura.Fecha = DateTime.Now;
            factura.EventoId = 1;
            factura.Detalles = detalle;
            factura.Total = 100;
            Assert.IsTrue(repositorio.Modificar(factura));
        }
    }
}