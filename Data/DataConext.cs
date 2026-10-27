using System;
using Microsoft.EntityFrameworkCore;
using SuperHeros.Api.Entities;

namespace SuperHero.Api.Data
{
    public class DataConext : DbContext
    {
        public DataConext(DbContextOptions<DataConext> options) : base(options)
        {
            
        }
        public DbSet<SuperHeroModel> SuperHeroes {get; set;}

    }
}


