using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Interfaces
{
    public interface IHuizenRepository
    {
        bool HeeftHuis(string straat, int nummer, ParkEntity park);
        HuisEntity VoegHuisToe(HuisEntity h);
        bool HeeftHuis(int id);
        void UpdateHuis(HuisEntity huis);
        HuisEntity GeefHuis(int id);
    }
}
