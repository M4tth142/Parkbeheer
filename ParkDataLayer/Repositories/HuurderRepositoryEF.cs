using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;

namespace ParkDataLayer.Repositories
{
    /// <summary>
    /// Repository class for managing operations related to 'Huurder' (Tenant) entities using Entity Framework.
    /// Implements the IHuurderRepository interface.
    /// </summary>
    public class HuurderRepositoryEF : IHuurderRepository
    {
        /// <summary>
        /// Retrieves a 'HuurderEntity' by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the 'Huurder' entity.</param>
        /// <returns>The 'HuurderEntity' associated with the provided identifier.</returns>
        public HuurderEntity GeefHuurder(int id)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    var huurder = context.Huurders
                        .Where(h => h.Id == id)
                        .Select(HuurderMapper.MapToHuurderEntity)
                        .FirstOrDefault();

                    if (huurder == null)
                    {
                        throw new RepositoryException($"Huurder with ID {id} not found in the database.", nameof(id));
                    }

                    return huurder;
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("GeefHuurder: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Retrieves a list of 'HuurderEntity' objects based on the provided name.
        /// </summary>
        /// <param name="naam">The name of the 'Huurder' entity to search for.</param>
        /// <returns>A list of 'HuurderEntity' objects with the specified name.</returns>
        public List<HuurderEntity> GeefHuurders(string naam)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    var huurders = context.Huurders
                        .Where(h => h.Naam == naam)
                        .Select(HuurderMapper.MapToHuurderEntity)
                        .ToList();

                    if (huurders.Count == 0)
                    {
                        throw new RepositoryException($"Huurder with name {naam} not found in the database.", nameof(naam));
                    }

                    return huurders;
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("GeefHuurders: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Checks if a 'Huurder' entity with the specified name and contact details exists.
        /// </summary>
        /// <param name="naam">The name of the 'Huurder' entity.</param>
        /// <param name="contact">Contact details of the 'Huurder' entity.</param>
        /// <returns>True if a matching 'Huurder' entity is found; otherwise, false.</returns>
        public bool HeeftHuurder(string naam, ContactgegevensEntity contact)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    return context.Huurders.Any(h =>
                        h.Naam == naam &&
                        h.Email == contact.Email &&
                        h.Telefoon == contact.Tel &&
                        h.Adres == contact.Adres);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("HeeftHuurder: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Checks if a 'Huurder' entity with the specified identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier of the 'Huurder' entity.</param>
        /// <returns>True if a 'Huurder' entity with the provided identifier exists; otherwise, false.</returns>
        public bool HeeftHuurder(int id)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    return context.Huurders.Any(h => h.Id == id);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("HeeftHuurder: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Updates the information of a 'Huurder' entity.
        /// </summary>
        /// <param name="huurder">The 'HuurderEntity' object containing updated information.</param>
        public void UpdateHuurder(HuurderEntity huurder)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    var h = context.Huurders.Find(huurder.Id);
                    h.Naam = huurder.Naam;
                    h.Email = huurder.Contactgegevens.Email;
                    h.Telefoon = huurder.Contactgegevens.Tel;
                    h.Adres = huurder.Contactgegevens.Adres;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("UpdateHuurder: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Adds a new 'Huurder' entity to the database.
        /// </summary>
        /// <param name="h">The 'HuurderEntity' object to be added.</param>
        /// <returns>The added 'HuurderEntity' object.</returns>
        public HuurderEntity VoegHuurderToe(HuurderEntity h)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    context.Huurders.Add(HuurderMapper.MapToHuurder(h));
                    context.SaveChanges();
                    return h;
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("VoegHuurderToe: " + ex.Message, ex);
                }
            }
        }
    }
}
