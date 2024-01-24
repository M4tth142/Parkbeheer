using ParkBusinessLayer.Exceptions;
using System;
using System.Collections.Generic;

namespace ParkBusinessLayer.Model
{
    public class HuurcontractEntity
    {
        public HuurcontractEntity(string id, HuurperiodeEntity huurperiode, HuurderEntity huurder, HuisEntity huis)
        {
            ZetId(id);
            ZetHuurperiode(huurperiode);
            ZetHuurder(huurder);
            ZetHuis(huis);
        }
        public string Id { get; private set; }
        public HuurperiodeEntity Huurperiode { get; private set; }
        public HuurderEntity Huurder { get; private set; }
        public HuisEntity Huis { get; private set; }
        public void ZetId(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ParkException("Park zetid");
            Id = id;
        }
        public void ZetHuis(HuisEntity huis)
        {
            if (huis == null) throw new ParkException("contract zethuis");
            Huis = huis;
        }
        public void ZetHuurperiode(HuurperiodeEntity huurperiode)
        {
            if (huurperiode == null) throw new ParkException("contract zethuurperiode");
            Huurperiode = huurperiode;
        }
        public void ZetHuurder(HuurderEntity huurder)
        {
            if (huurder == null) throw new ParkException("contract zethuurder");
            Huurder = huurder;
        }
        public override bool Equals(object obj)
        {
            return obj is HuurcontractEntity huurcontract &&
                   EqualityComparer<HuurperiodeEntity>.Default.Equals(Huurperiode, huurcontract.Huurperiode) &&
                   EqualityComparer<HuurderEntity>.Default.Equals(Huurder, huurcontract.Huurder) &&
                   EqualityComparer<HuisEntity>.Default.Equals(Huis, huurcontract.Huis);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Huurperiode, Huurder, Huis);
        }
    }
}
