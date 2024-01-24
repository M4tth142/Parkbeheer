using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Interfaces
{
    public interface IHuurderRepository
    {
        HuurderEntity VoegHuurderToe(HuurderEntity h);
        bool HeeftHuurder(string naam, ContactgegevensEntity contact);
        bool HeeftHuurder(int id);
        void UpdateHuurder(HuurderEntity huurder);
        HuurderEntity GeefHuurder(int id);
        List<HuurderEntity> GeefHuurders(string naam);
    }
}
