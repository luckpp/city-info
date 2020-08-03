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
                            Name = "Central Park",
                            Description = "Central Park is an urban park in New York City located between the Upper West and Upper East Sides of Manhattan."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Statue of Liberty",
                            Description = "Colossal neoclassical sculpture on Liberty Island in New York Harbor within New York City"
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
                            Name = "Botanic Park",
                            Description = "A nice park close to the central old city , green and shadowy."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Theresia Bastion",
                            Description = "Named after the Austrian Empress Maria Theresa, is the largest preserved piece of defensive wall of the Austrian-Hungarian fortress of Timișoara."
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
                            Name = "Eiffel Tower",
                            Description = "Is a wrought-iron lattice tower on the Champ de Mars."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Louvre",
                            Description = "Is the world's largest art museum and a historic monument."
                        }
                    }
                }
            };
        }
    }
}
