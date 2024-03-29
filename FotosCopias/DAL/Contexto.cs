﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Usuarios>Usuarios { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public Contexto(): base("ConStr") { }
    }
}
