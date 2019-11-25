using AutoMapper;
using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Enums;
using Evo.WebApi.Models.ViewModels;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoDB.WebApi.Models.ViewModels;

namespace VideoDB.WebApi.Models.Profiles
{
    public class SeriesProfile : Profile
    {
        public SeriesProfile()
        {
            CreateMap<IEnumerable<SeriesDataModel>, SeriesViewModel>()
                .ForMember(
                    dest => dest.VideoId,
                    src => src.MapFrom(
                        m => m.Select(s => s.imdb_id)
                              .Distinct()
                              .Single()))
                .ForMember(
                    dest => dest.IsUpdated,
                    src => src.MapFrom(
                        m => m.Select(s => s.updated)
                            .Distinct()
                            .Single()))
                .ForMember(
                    dest => dest.Title,
                    src => src.MapFrom(
                        m => m.Select(s => s.title)
                              .Distinct()
                              .Single()))
                .ForMember(
                    dest => dest.Plot,
                    src => src.MapFrom(
                        m => m.Select(s => s.plot)
                              .Distinct()
                              .Single()))
                .ForMember(
                    dest => dest.ReleaseDate,
                    src => src.MapFrom(
                        m => m.Select(s => s.release_date)
                              .Distinct()
                              .Single()))
                .ForMember(
                    dest => dest.Genres,
                    src => src.MapFrom(
                        m => m.DistinctBy(d => d.genre_name)
                              .Select(s => new GenreViewModel
                              {
                                  Name = s.genre_name
                              })))
                .ForMember(dest => dest.Ratings, src => src.MapFrom(
                    m => m.DistinctBy(d => new { d.rating_source, d.rating_value })
                          .Select(s => new RatingViewModel
                          {
                              Source = s.rating_source,
                              RatingValue = s.rating_value
                          })))
                .ForMember(dest => dest.Stars, src => src.MapFrom(
                    m => m.DistinctBy(d => new
                    {
                        d.first_name,
                        d.middle_name,
                        d.last_name,
                        d.suffix,
                        d.person_role
                    })
                          .Select(s => CreateStarModel(s))));
        }

        private StarViewModel CreateStarModel(SeriesDataModel source)
        {
            Enum.TryParse<PersonType>(source.person_role, out var role);
            return new StarViewModel
            {
                FirstName = source.first_name,
                MiddleName = source.middle_name,
                LastName = source.last_name,
                Suffix = source.suffix,
                Role = role
            };
        }
    }
}
