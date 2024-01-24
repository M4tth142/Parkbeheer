using ParkBusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Model
{
    public class HuisEntity
    {
        // Properties
        public int Id { get; private set; }
        public string Straat { get; private set; }
        public int Nr { get; private set; }
        public bool Actief { get; set; }
        public ParkEntity Park { get; private set; }

        private Dictionary<HuurderEntity, List<HuurcontractEntity>> _huurcontracten = new Dictionary<HuurderEntity, List<HuurcontractEntity>>();

        // Constructors
        public HuisEntity(int id, string straat, int nr, bool actief, ParkEntity park, Dictionary<HuurderEntity, List<HuurcontractEntity>> huurcontracten)
            : this(id, straat, nr, actief, park)
        {
            _huurcontracten = huurcontracten;
        }
        public HuisEntity(string straat, int nr, ParkEntity park)
        {
            ZetStraat(straat);
            ZetNr(nr);
            Park = park;
            Actief = true;
        }
        public HuisEntity(int id, string straat, int nr, bool actief, ParkEntity park) : this(straat, nr, park)
        {
            ZetId(id);
            Actief = actief;
        }

        /// <summary>
        /// readonly list of huurcontracten
        /// </summary>
        /// <returns> list of contracts </returns>
        public IReadOnlyList<HuurcontractEntity> Huurcontracten()
        {
            return _huurcontracten.Values.SelectMany(x => x).ToList();
        }
        
        /// <summary>
        /// method to add a contract to a house
        /// </summary>
        /// <param name="huurcontract"></param>
        /// <exception cref="ParkException"></exception>
        public void VoegHuurcontractToe(HuurcontractEntity huurcontract)
        {
            if (huurcontract == null) throw new ParkException("voeghuurcontracttoe");
            if (_huurcontracten.ContainsKey(huurcontract.Huurder))
            {
                if (_huurcontracten[huurcontract.Huurder].Contains(huurcontract)) throw new ParkException("voegcontracttoe");
                _huurcontracten[huurcontract.Huurder].Add(huurcontract);
            }
            else
            {
                _huurcontracten.Add(huurcontract.Huurder, new List<HuurcontractEntity>() { huurcontract });
            }
        }
        /// <summary>
        /// method to remove a contract from a house
        /// </summary>
        /// <param name="huurcontract"></param>
        /// <exception cref="ParkException"></exception>
        public void VerwijderHuurcontract(HuurcontractEntity huurcontract)
        {
            if (huurcontract == null) throw new ParkException("verwijderhuurcontract");
            if (_huurcontracten.ContainsKey(huurcontract.Huurder))
            {
                if (!_huurcontracten[huurcontract.Huurder].Contains(huurcontract)) throw new ParkException("verwijderhuurcontract");
                _huurcontracten[huurcontract.Huurder].Remove(huurcontract);
            }
            else
            {
                throw new ParkException("verwijderhuurcontract");
            }
        }
        /// <summary>
        /// method to get a list of contracts from a house
        /// </summary>
        /// <param name="huurder"></param>
        /// <returns></returns>
        /// <exception cref="ParkException"></exception>
        public IReadOnlyList<HuurcontractEntity> Huurcontracten(HuurderEntity huurder)
        {
            if (huurder == null) throw new ParkException("huurder is null");
            if (!_huurcontracten.ContainsKey(huurder)) throw new ParkException("huurder bestaat niet");
            return _huurcontracten[huurder].AsReadOnly();
        }
        /// <summary>
        /// set street
        /// </summary>
        /// <param name="straat"></param>
        /// <exception cref="ParkException"></exception>
        public void ZetStraat(string straat)
        {
            if (string.IsNullOrEmpty(straat)) throw new ParkException("zetstraat");
            Straat = straat;
        }
        /// <summary>
        /// set number
        /// </summary>
        /// <param name="nr"></param>
        /// <exception cref="ParkException"></exception>
        public void ZetNr(int nr)
        {
            if (nr <= 0) throw new ParkException("zetnr");
            Nr = nr;
        }
        /// <summary>
        /// set contracts
        /// </summary>
        /// <param name="huurcontracten"></param>
        /// <exception cref="ParkException"></exception>
        public void ZetContracten(Dictionary<HuurderEntity, List<HuurcontractEntity>> huurcontracten)
        {
            if (huurcontracten == null) throw new ParkException("zetcontracten");
            _huurcontracten = huurcontracten;
        }
        /// <summary>
        /// set id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ParkException"></exception>
        public void ZetId(int id)
        {
            if (id <= 0) throw new ParkException("zetid");
            Id = id;
        }
    }
}
