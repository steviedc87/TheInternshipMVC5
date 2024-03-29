﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Internship.Models.Domain;

namespace Internship.Models.DAL
{
    public class StagebegeleiderRepository : IStagebegeleiderRepository
    {
        // Context en DbSet
        private InternshipContext context;
        private DbSet<Stagebegeleider> stagebegeleiders;

        // Constructor
        public StagebegeleiderRepository(InternshipContext context)
        {
            this.context = context;
            stagebegeleiders = context.Stagebegeleiders;
        }

        public IQueryable<Stagebegeleider> FindAll()
        {
            return stagebegeleiders.OrderBy(s => s.Naam);
        }

        public Stagebegeleider FindByEmail(string email)
        {
            return stagebegeleiders.SingleOrDefault(s => s.UserName.Equals(email));
        }

        public Stagebegeleider FindById(String id)
        {
            return stagebegeleiders.Find(id);
        }

       

        public IQueryable<Stagebegeleider> FindByName(string naam)
        {
            return stagebegeleiders.Where(s => s.Naam == naam || s.Voornaam == naam);
        }

        public void UpdateFirstTime(String username)
        {
            Stagebegeleider s = FindByEmail(username);
            s.IsFirstTime= false;
            stagebegeleiders.AddOrUpdate(s);
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}