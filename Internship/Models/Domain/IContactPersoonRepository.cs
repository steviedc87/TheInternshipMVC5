﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.Models.Domain
{
    public interface IContactPersoonRepository
    {
        void VerwijderContact(ContactPersoon contact);
        ContactPersoon FindContactPersoon(int id);
        ContactPersoon FindPersoonWithNaamVoornaamEmail(String naam, String voornaam, String email);
        void SaveChanges();

    }
}
