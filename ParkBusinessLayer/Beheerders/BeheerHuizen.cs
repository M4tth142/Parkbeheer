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
    public class BeheerHuizen
    {
        private IHuizenRepository repo;

        public BeheerHuizen(IHuizenRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// voegt een nieuwe huis toe aan de database via de interface checkt ook of het huis al bestaat via de heefthuis methode
        /// </summary>
        /// <param name="straat">straatnaam</param>
        /// <param name="nummer">huisnr</param>
        /// <param name="park">park object mee te geven</param>
        /// <exception cref="BeheerderException"></exception>
        public void VoegNieuwHuisToe(string straat,int nummer,ParkEntity park)
        {
            try
            {
                if (repo.HeeftHuis(straat, nummer, park)) throw new BeheerderException("voeghuistoe");
                HuisEntity h = new HuisEntity(straat,nummer, park);
                repo.VoegHuisToe(h);

            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
        /// <summary>
        /// roep de methode aan om een huis te updaten via de interface checkt ook of het huis bestaat via de heefthuis methode
        /// </summary>
        /// <param name="huis">welk huis object </param>
        /// <exception cref="BeheerderException"></exception>
        public void UpdateHuis(HuisEntity huis)
        {
            try
            {
                if (!repo.HeeftHuis(huis.Id)) throw new BeheerderException("updatehuis");
                repo.UpdateHuis(huis);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
        /// <summary>
        /// zet het huis op niet actief via de interface checkt ook of het huis bestaat via de heefthuis methode
        /// </summary>
        /// <param name="huis"> welk huisobject </param>
        /// <exception cref="BeheerderException"></exception>
        public void ArchiveerHuis(HuisEntity huis)
        {
            try
            {
                if (!repo.HeeftHuis(huis.Id)) throw new BeheerderException("archiveerhuis");
                huis.Actief = false;
                repo.UpdateHuis(huis);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
        /// <summary>
        /// zoek een huis via de interface met het gegeven id
        /// </summary>
        /// <param name="id">id voor het huis te zoeken</param>
        /// <returns>huis object</returns>
        /// <exception cref="BeheerderException"></exception>
        public HuisEntity GeefHuis(int id)
        {
            try
            {
                return repo.GeefHuis(id);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
    }
}
