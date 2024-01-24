using ParkBusinessLayer.Exceptions;
using System.Collections.Generic;

namespace ParkBusinessLayer.Model
{
    public class ParkEntity
    {
        public string Id { get; private set; }
        public string Naam { get; private set; }
        public string Locatie { get; private set; }
        private List<HuisEntity> _huis =new List<HuisEntity>(){ };

        public ParkEntity(string id, string naam, string locatie, List<HuisEntity> huis) : this(id,naam,locatie)
        {
            _huis = huis;
        }
        public ParkEntity(string id, string naam, string locatie)
        {
            ZetId(id);
            ZetNaam(naam);
            Locatie = locatie;
        }
        public void ZetId(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ParkException("Park zetid");
            Id = id;
        }
        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new ParkException("Park zetnaam");
            Naam = naam;
        }
        public IReadOnlyList<HuisEntity> Huizen()
        {
            return _huis.AsReadOnly();
        }
        public void VoegHuisToe(HuisEntity huis)
        {
            if (_huis.Contains(huis)) throw new ParkException("voeghuistoe");
            _huis.Add(huis);
        }
        public void VerwijderHuis(HuisEntity huis)
        {
            if (!_huis.Contains(huis)) throw new ParkException("verwijderhuis");
            _huis.Remove(huis);
        }
    }
}
