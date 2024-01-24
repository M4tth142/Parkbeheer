using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkBusinessLayer.Model;
using ParkDataLayer.Model;

namespace ParkDataLayer.Mappers
{
    public class  HuisMapper
    {
        public static HuisEntity MapHuisToEntity(Huis huis)
        {
            if (huis == null) return null;
            HuisEntity h = new HuisEntity(huis.Straat, huis.Nummer,ParkMapper.MapParkToEntity(huis.Park));
            return h;
        }
        public static Huis MapToHuis(HuisEntity huis)
        {
            if (huis == null) return null;
            Huis h = new Huis(huis.Straat, huis.Nr, huis.Actief,ParkMapper.MapEntityToPark(huis.Park).Id);
            return h;
        }
    }
}
