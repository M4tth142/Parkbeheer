using ParkBusinessLayer.Exceptions;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;

namespace ParkBusinessLayer.Beheerders
{
    public class BeheerContracten
    {
        private IContractenRepository repo;

        public BeheerContracten(IContractenRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// roep de methode aan om een contract aan te maken via de interface checkt ook of het contract al bestaat via de heeftcontract methode
        /// </summary>
        /// <param name="id">id van het aan te maken contract</param>
        /// <param name="huurperiode">object huurperiod </param>
        /// <param name="huurder">huurder object</param>
        /// <param name="huis">huis object</param>
        /// <exception cref="BeheerderException"></exception>
        public void MaakContract(string id,HuurperiodeEntity huurperiode, HuurderEntity huurder, HuisEntity huis)
        {
            try
            {
                HuurcontractEntity contract = new HuurcontractEntity(id,huurperiode,huurder,huis);
                if (repo.HeeftContract(huurperiode.StartDatum, huurder.Id, huis.Id)) 
                    throw new BeheerderException("Maakcontract bestaat al");
                repo.VoegContractToe(contract);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
        /// <summary>
        /// roep de methode aan om een contract te annuleren via de interface
        /// </summary>
        /// <param name="contract">contract object</param>
        /// <exception cref="BeheerderException"></exception>
        public void AnnuleerContract(HuurcontractEntity contract )
        {
            try
            {
                repo.AnnuleerContract(contract);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }

        /// <summary>
        /// roep de methode aan om een contract te updaten via de interface checkt ook of het contract bestaat via de heeftcontract methode
        /// </summary>
        /// <param name="contract"></param>
        /// <exception cref="BeheerderException"></exception>
        public void UpdateContract(HuurcontractEntity contract)
        {
            try
            {
                if (!repo.HeeftContract(contract.Id)) throw new BeheerderException("updatecontract");
                repo.UpdateContract(contract);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
        /// <summary>
        /// roep de methode aan om een contract te geven via de interface
        /// </summary>
        /// <param name="id">id om een bepaald contract te zoeken</param>
        /// <returns></returns>
        /// <exception cref="BeheerderException"></exception>
        public HuurcontractEntity GeefContract(string id)
        {
            try
            {
                return repo.GeefContract(id);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
        /// <summary>
        /// roep de methode aan om een lijst van alle contracten te geven via de interface met een bepaalde startdatum en einddatum
        /// </summary>
        /// <param name="dtBegin">begindatum</param>
        /// <param name="dtEinde">einddatum</param>
        /// <returns> een lijst van contracten</returns>
        /// <exception cref="BeheerderException"></exception>
        public List<HuurcontractEntity> GeefContracten(DateTime dtBegin,DateTime? dtEinde)
        {
            try
            {
                return repo.GeefContracten(dtBegin,dtEinde);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
    }
}
