using ParkBusinessLayer.Exceptions;
using System.Collections.Generic;

namespace ParkBusinessLayer.Model
{
    public class HuurderEntity
    {
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public ContactgegevensEntity Contactgegevens { get; private set; }

        public HuurderEntity(int id, string naam, ContactgegevensEntity contactgegevens)
        {
            ZetId(id);
            ZetNaam(naam);
            ZetContactgegevens(contactgegevens);
        }
        public HuurderEntity(string naam, ContactgegevensEntity contactgegevens)
        {
            ZetNaam(naam);
            ZetContactgegevens(contactgegevens);
        }
        public void ZetId(int id)
        {
            if (id <= 0) throw new ParkException("huurder - zetid");
            Id = id;
        }
        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new ParkException("huurder zetnaam");
            Naam = naam;
        }
        public void ZetContactgegevens(ContactgegevensEntity contactgegevens)
        {
            if (contactgegevens == null) throw new ParkException("Huurder zetcontactgegevens");
            Contactgegevens = contactgegevens;
        }
    }
}