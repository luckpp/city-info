using CityInfo.API.Model;
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
                new CityDto
                {
                    Id = 1,
                    Name = "New York",
                    Description = "The one with the big park",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Name 1",
                            Description = "Description 1"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Name 2",
                            Description = "Description 2"
                        }
                    }
                },
                new CityDto
                {
                    Id = 2,
                    Name = "Timisoara",
                    Description = "Along Bega river",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Name 3",
                            Description = "Description 3"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Name 4",
                            Description = "Description 4"
                        }
                    }
                },
                new CityDto
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with the big tower",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Name 3",
                            Description = "Description 3"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Name 4",
                            Description = "Description 4"
                        }
                    }
                }
            };
        }
    }
}
