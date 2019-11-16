using FotosCopias.DAL;
using FotosCopias.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotosCopias.BLL
{
    public class FacturaBLL : RepositorioBase<Articulos>
    {
        

        public override bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                foreach (var item in articulos.ArticuloDetalles)
                {
                    var Anterior = db.Articulos.Find(item.ArticulosId);

                    if (Anterior != null)
                        Anterior.Cantidad -= item.Cantidad;

                }
                if (db.Articulos.Add(articulos) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public override bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            var Anterior = db.Articulos.Find(articulos.ArticulosId);

            try
            {
                foreach (var item in Anterior.ArticuloDetalles)
                {
                    var Articulo = db.Articulos.Find(item.ArticulosId);
                    if (!articulos.ArticuloDetalles.Exists(f => f.DetalleArticuloId == item.DetalleArticuloId))
                    {
                        if (articulos != null)
                        {
                            articulos.Cantidad += item.Cantidad;
                            db.Entry(item).State = EntityState.Deleted;
                        }
                    }
                }

                foreach (var item in articulos.ArticuloDetalles)
                {
                    var Articulo = db.Articulos.Find(item.ArticulosId);

                    if (item.DetalleArticuloId == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                        if (articulos != null)
                            articulos.Cantidad -= item.Cantidad;
                        else
                            db.Entry(item).State = EntityState.Modified;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public override Articulos Buscar(int id)
        {
            Articulos articulos = new Articulos();
            Contexto db = new Contexto();

            try
            {
                articulos = db.Articulos.Find(id);
                if (articulos != null)
                {
                    articulos.ArticuloDetalles.Count();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return articulos;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();

            try
            {
                var Anterior = repositorio.Buscar(id);

                foreach(var item in Anterior.ArticuloDetalles)
                {
                    var Articulo = db.Articulos.Find(item.ArticulosId);

                    if (Articulo != null)
                        Articulo.Cantidad += item.Cantidad;
                }
                var eliminar = db.Articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

    }
}
