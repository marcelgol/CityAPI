
using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    ID = 1,
                    Name = "Eldorado do Sul",
                    Description = "Best Lunch of Americas",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "Cafeteria",
                            Description = "Cafeteria #1"
                        },
                        new PointsOfInterestDto()
                        {
                            Id = 2,
                            Name = "Paneria",
                            Description = "Paneria #1"
                        }
                    }
                    
                },

                new CityDto()
                {
                    ID = 2,
                    Name = "Austin",
                    Description = "Texas",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto()
                        {
                            Id = 1,
                            Name = "Coffe Machine",
                            Description = "The amazing coffee machine in RR"
                        }
                    }
                        
                },
                
                new CityDto()
                {
                    ID = 3,
                    Name = "Hortolandia",
                    Description = "BR Factory"
                }
            };
        }
    }
}
