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
                    dest => dest.SeriesId,
                    src => src.MapFrom(
                        m => m.Select(s => s.video_id)
                              .Distinct()
                              .Single()))
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
                              .Single()));
        }
    }
}
