using ParkBusinessLayer.Model;
using ParkDataLayer.Model;

namespace ParkDataLayer.Mappers
{
    public class ParkMapper
    {
        public static Park MapEntityToPark(ParkEntity park)
        {
            if (park == null) return null;

            Park p = new Park(
                park.Id,
                park.Naam,
                park.Locatie
            );

            return p;
        }

        public static ParkEntity MapParkToEntity(Park park)
        {
            if (park == null) return null;

            ParkEntity parkEntity = new ParkEntity(park.Id, park.Naam, park.Locatie);

            return parkEntity;
        }

    }
}
