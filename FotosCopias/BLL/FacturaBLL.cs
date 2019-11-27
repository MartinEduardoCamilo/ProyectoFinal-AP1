using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturaBLL : RepositorioBase<Facturas>
    {
        public override Facturas Buscar(int id)
        {
            Facturas facturas = new Facturas();
            Contexto db = new Contexto();

            try
            {
                facturas = db.Facturas.Find(id);
                if (facturas != null)
                {
                    facturas.Detalles.Count();
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
            return facturas;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Facturas> repositorio = new RepositorioBase<Facturas>();

            try
            {
                var Anterior = repositorio.Buscar(id);
                foreach (var item in Anterior.Detalles)
                {
                    var articulo = db.Articulos.Find(item.ArticulosId);
                    if (articulo != null)
                        articulo.Cantidad += item.Cantidad;
                }
                var eliminar = db.Facturas.Find(id);
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

        public override bool Guardar(Facturas entity)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                foreach (var item in entity.Detalles)
                {
                    var Articulo = db.Articulos.Find(item.ArticulosId);
                    if (Articulo != null)
                        Articulo.Cantidad -= item.Cantidad;
                }

                db.Clientes.Find(entity.ClienteId).Consumo += entity.Total;

                if (db.Facturas.Add(entity)!=null)
                {
                    paso = db.SaveChanges() > 0;
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

        public override bool Modificar(Facturas entity)
        {
            bool paso = false;
            var Anterior = Buscar(entity.FacturaId);
            decimal anteriorbalance = Buscar(entity.FacturaId).Total;
            Contexto db = new Contexto();

            try
            {
                foreach (var item in Anterior.Detalles)
                {
                    var articulo = db.Articulos.Find(item.ArticulosId);
                    if (!entity.Detalles.Exists(d => d.DetalleFacturaId == item.DetalleFacturaId))
                    {
                        if (articulo != null)
                            articulo.Cantidad += item.Cantidad;
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in entity.Detalles)
                {
                    var articulo = db.Articulos.Find(item.ArticulosId);
                    if (item.DetalleFacturaId == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                        if (articulo != null)
                            articulo.Cantidad -= item.Cantidad;
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }

                }

              

                db.Entry(entity).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
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