using ParkBusinessLayer.Exceptions;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Beheerders
{
    public class BeheerHuurders
    {
        private IHuurderRepository repo;

        public BeheerHuurders(IHuurderRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// voeg een nieuwe huurder toe via de interface checkt ook of de huurder al bestaat via de heefthuurder methode
        /// </summary>
        /// <param name="Naam"> naam van de huurder</param>
        /// <param name="contact">object met contactgegevens</param>
        /// <exception cref="BeheerderException"></exception>
        public void VoegNieuweHuurderToe(string Naam,ContactgegevensEntity contact)
        {
            try
            {
                if (repo.HeeftHuurder(Naam, contact)) throw new BeheerderException("huurder bestaat al");
                HuurderEntity h = new HuurderEntity(Naam, contact);
                repo.VoegHuurderToe(h);
            }
            catch(Exception ex)
            {
                throw new BeheerderException("nieuwe huurder", ex);
            }
        }
        /// <summary>
        /// update de huurder???
        /// </summary>
        /// <param name="huurder">huurder object</param>
        /// <exception cref="BeheerderException"></exception>
        public void UpdateHuurder(HuurderEntity huurder)
        {
            try
            {
                if (!repo.HeeftHuurder(huurder.Id)) throw new BeheerderException("huurder bestaat niet");
                repo.UpdateHuurder(huurder);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("updatehuurder", ex);
            }
        }
        /// <summary>
        /// geef een huurder terug via de interface op basis van id
        /// </summary>
        /// <param name="id">id van de huurder</param>
        /// <returns>een huurder object</returns>
        /// <exception cref="BeheerderException"></exception>
        public HuurderEntity GeefHuurder(int id)
        {
            try
            {
                return repo.GeefHuurder(id);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("geefhuurder", ex);
            }
        }
        /// <summary>
        /// geef een lijst van huurders terug via de interface op basis van naam ???
        /// </summary>
        /// <param name="naam">naam van de huurder in question</param>
        /// <returns>lijst van huurder objecten </returns>
        /// <exception cref="BeheerderException"></exception>
        public List<HuurderEntity> GeefHuurders(string naam)
        {
            try
            {
                return repo.GeefHuurders(naam);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("geefhuurders", ex);
            }
        }
    }
}
