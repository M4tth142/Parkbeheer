using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Interfaces
{
    public interface IContractenRepository
    {
        bool HeeftContract(DateTime startDatum, int huurderid, int huisid);
        void VoegContractToe(HuurcontractEntity contract);
        void AnnuleerContract(HuurcontractEntity contract);
        bool HeeftContract(string id);
        void UpdateContract(HuurcontractEntity contract);
        HuurcontractEntity GeefContract(string id);
        List<HuurcontractEntity> GeefContracten(DateTime dtBegin, DateTime? dtEinde);
    }
}
