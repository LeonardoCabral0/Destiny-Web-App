using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristSpot.Application.UseCases.TouristSpotServices.Get;

namespace Application.UseCases.TouristSpot.Get
{
    public interface IGetTouristSpots
    {
        public Task<OutputGetTouristSpot> Execute(InputGetTouristSpot input);
    }
}
