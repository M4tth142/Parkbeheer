using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkBusinessLayer.Model;
using ParkDataLayer.Model;

namespace ParkDataLayer.Mappers
{
    public class HuurcontractMapper
    {
        public static Huurcontract MapToHuurcontract(HuurcontractEntity huurcontract)
        {
            if (huurcontract == null) return null;
            Huurcontract h = new Huurcontract(huurcontract.Id, huurcontract.Huurperiode.StartDatum, huurcontract.Huurperiode.EindDatum, huurcontract.Huurperiode.Aantaldagen, huurcontract.Huis.Id, huurcontract.Huurder.Id);
            return h;
        }

        public static HuurcontractEntity MapToHuurcontractEntity(Huurcontract huurcontract)
        {
            if (huurcontract == null) return null;

            HuurperiodeEntity huurperiode = new HuurperiodeEntity(huurcontract.StartDatum, huurcontract.AantalDagen);
            HuurderEntity huurderEntity = HuurderMapper.MapToHuurderEntity(huurcontract.Huurder);
            HuisEntity huisEntity = HuisMapper.MapHuisToEntity(huurcontract.Huis);
            HuurcontractEntity h = new HuurcontractEntity(huurcontract.Id, huurperiode, huurderEntity, huisEntity);
            return h;
        }

    }
}
