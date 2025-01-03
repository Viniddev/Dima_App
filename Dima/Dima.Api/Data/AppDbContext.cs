﻿using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dima.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        //esse metodo aplica configurações iniciais ao banco se for sua primeira execucao
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
