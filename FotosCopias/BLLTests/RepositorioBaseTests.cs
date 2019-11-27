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
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            usuarios = repositorio.Buscar(1);
            Assert.IsNotNull(usuarios);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Assert.IsTrue(repositorio.Eliminar(1));
        }

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios(0, "Martin", "Administrador", "1425", DateTime.Now);
            Assert.IsTrue(repositorio.Guardar(usuarios));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios(1, "Martin", "Administrador", "1234", DateTime.Now);
            Assert.IsTrue(repositorio.Modificar(usuarios));
        }


        [TestMethod()]
        public void BuscarTest1()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos();
            articulos = repositorio.Buscar(1);
            Assert.IsNotNull(articulos);
        }

        [TestMethod()]
        public void EliminarTest1()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Assert.IsTrue(repositorio.Eliminar(1));
        }

        [TestMethod()]
        public void GuardarTest1()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos(0, "Fotos", 100);
            Assert.IsTrue(repositorio.Guardar(articulos));
        }

        [TestMethod()]
        public void ModificarTest1()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            Articulos articulos = new Articulos(1, "GGO", 100);
            Assert.IsTrue(repositorio.Modificar(articulos));
        }

        [TestMethod()]
        public void BuscarTest2()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = new Clientes();
            clientes = repositorio.Buscar(1);
            Assert.IsNotNull(clientes);
        }


        [TestMethod()]
        public void EliminarTest2()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Assert.IsTrue(repositorio.Eliminar(1));
        }


        [TestMethod()]
        public void GuardarTest2()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = new Clientes(0, "Martin", "Camilo", "402-1291299-8", "849-253-3607", "lama@gmail.com", "los grullones", 0);
            Assert.IsTrue(repositorio.Guardar(clientes));
        }

        [TestMethod()]
        public void ModificarTest2()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = new Clientes(1, "Martin", "Camilo", "403-1291299-8", "849-253-3607", "lama@gmail.com", "los grullones", 0);
            Assert.IsTrue(repositorio.Modificar(clientes));
        }

       
        [TestMethod()]
        public void BuscarTest3()
        {
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            Eventos eventos = new Eventos();
            eventos = repositorio.Buscar(1);
            Assert.IsNotNull(eventos);
        }
        [TestMethod()]
        public void EliminarTest3()
        {
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            Assert.IsTrue(repositorio.Eliminar(1));
        }

      
        [TestMethod()]
        public void GuardarTest3()
        {
           RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            Eventos eventos = new Eventos(0,1,"Fiesta","El madrigal",DateTime.Now);
            Assert.IsTrue(repositorio.Guardar(eventos));
        }

        [TestMethod()]
        public void ModificarTest3()
        {
            RepositorioBase<Eventos> repositorio = new RepositorioBase<Eventos>();
            Eventos eventos = new Eventos(1, 1, "Romo", "El madrigal", DateTime.Now);
            Assert.IsTrue(repositorio.Modificar(eventos));
        }
    }
}