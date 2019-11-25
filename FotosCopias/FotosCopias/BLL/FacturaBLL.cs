using FotosCopias.DAL;
using FotosCopias.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FotosCopias.BLL
{
    public class FacturaBLL : RepositorioBase<Articulos>
    {
        public override Articulos Buscar(int id)
        {
            Articulos articulos = new Articulos();
            Contexto db = new Contexto();

            try
            {
                articulos = db.Articulos.Find(id);
                if(articulos != null)
                {
                    articulos.DetalleArticulos.Count();
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
            FacturaBLL repositorio = new FacturaBLL();
            var Anteriro = repositorio.Buscar(id);
            Contexto db = new Contexto();

            try
            {
                foreach(var item in Anteriro.DetalleArticulos)
                {
                    var articulos = db.Articulos.Find(item.ArticulosId);
                    if (articulos != null)
                        articulos.Cantidad -= item.Cantidad;
                }

                var eliminar = db.Articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = -db.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public override bool Guardar(Articulos entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                foreach(var item in entity.DetalleArticulos)
                {
                    var articulos = db.Articulos.Find(item.ArticulosId);
                    if (articulos != null)
                        articulos.Cantidad -= item.Cantidad;
                }

                if (db.Articulos.Add(entity) != null)
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

        public override bool Modificar(Articulos entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            var anterior = Buscar(entity.ArticulosId);
            try
            {
                foreach(var item in anterior.DetalleArticulos)
                {
                    var articulos = db.Articulos.Find(item.ArticulosId);
                    if(!entity.DetalleArticulos.Exists(d=>d.DetalleArticuloId == item.DetalleArticuloId))
                    {
                        if (articulos != null)
                        {
                            articulos.Cantidad += item.Cantidad;
                            db.Entry(item).State = EntityState.Deleted;
                        }
                    }
                }

                foreach(var item in entity.DetalleArticulos)
                {
                    if (item.DetalleArticuloId == 0)
                    {
                        var articulos = db.Articulos.Find(item.ArticulosId);
                        db.Entry(item).State = EntityState.Added;
                        if (articulos != null)
                            articulos.Cantidad -= item.Cantidad;
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                        paso = db.SaveChanges() > 0;
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
    }
}
