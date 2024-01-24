// Documentatie voor de HuizenRepositoryEF-klasse

using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    /// <summary>
    /// Implementatie van het interface voor het beheren van huizen in de database met Entity Framework.
    /// </summary>
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor voor het initialiseren van de repository met een verbindingsreeks naar de database.
        /// </summary>
        /// <param name="connectionString">De verbindingsreeks naar de database.</param>
        public HuizenRepositoryEF(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Haalt een huis op uit de database op basis van het opgegeven ID.
        /// </summary>
        /// <param name="id">ID van het op te vragen huis.</param>
        /// <returns>De opgevraagde huisentiteit.</returns>
        /// <exception cref="ArgumentException">Wordt gegenereerd als het opgegeven ID ongeldig is.</exception>
        public HuisEntity GeefHuis(int id)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    var huis = context.Huizen
                                       .Where(h => h.Id == id)
                                       .Select(HuisMapper.MapHuisToEntity)
                                       .FirstOrDefault();

                    if (huis == null)
                    {
                        throw new RepositoryException($"Huis met ID {id} niet gevonden in de database.", nameof(id));
                    }

                    return huis;
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("GeefHuis: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Controleert of er een huis bestaat met de opgegeven straatnaam, huisnummer en park.
        /// </summary>
        /// <param name="straat">Straatnaam van het huis.</param>
        /// <param name="nummer">Huisnummer.</param>
        /// <param name="park">Park waartoe het huis behoort.</param>
        /// <returns>True als het huis bestaat, anders False.</returns>
        public bool HeeftHuis(string straat, int nummer, ParkEntity park)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    return context.Huizen.Any(h => h.Straat == straat && h.Nummer == nummer && h.ParkId == park.Id);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("HeeftHuis: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Controleert of er een huis bestaat met het opgegeven ID.
        /// </summary>
        /// <param name="id">ID van het huis.</param>
        /// <returns>True als het huis bestaat, anders False.</returns>
        public bool HeeftHuis(int id)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    return context.Huizen.Any(h => h.Id == id);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("HeeftHuis: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Werkt de eigenschappen van een huis bij in de database.
        /// </summary>
        /// <param name="huis">De bij te werken huisentiteit.</param>
        public void UpdateHuis(HuisEntity huis)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    var bestaandHuis = context.Huizen.FirstOrDefault(h => h.Id == huis.Id);

                    if (bestaandHuis != null)
                    {
                        bestaandHuis.Straat = huis.Straat;
                        bestaandHuis.Nummer = huis.Nr;
                        bestaandHuis.Actief = huis.Actief;
                        bestaandHuis.ParkId = huis.Park.Id;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new RepositoryException($"Huis met ID {huis.Id} niet gevonden in de database.", nameof(huis.Id));
                    }
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("UpdateHuis: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Voegt een nieuw huis toe aan de database.
        /// </summary>
        /// <param name="h">De toe te voegen huisentiteit.</param>
        /// <returns>De toegevoegde huisentiteit.</returns>
        public HuisEntity VoegHuisToe(HuisEntity h)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    context.Parks.Attach(ParkMapper.MapEntityToPark(h.Park)); // Voeg het gerelateerde park toe aan de context
                    context.Huizen.Add(HuisMapper.MapToHuis(h));
                    context.SaveChanges();
                    return h;
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("VoegHuisToe: " + ex.Message, ex);
                }
            }
        }
    }
}
