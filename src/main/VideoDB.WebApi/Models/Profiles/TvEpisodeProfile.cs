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
    public class TvEpisodeProfile : Profile
    {
        public TvEpisodeProfile()
        {
            CreateMap<IEnumerable<TvEpisodeDataModel>, TvEpisode>()
                .ForMember(
                    dest => dest.VideoId,
                    src => src.MapFrom(
                        m => m.Select(s => s.episode_imdb_id)
                              .Distinct()
                              .Single()))
                .ForMember(
                    dest => dest.IsUpdated,
                    src => src.MapFrom(
                        m => m.Select(s => s.updated)
                            .Distinct()
                            .Single()))
                .ForMember(
                    dest => dest.MpaaRating,
                    src => src.MapFrom(
                        m => m.Select(s => s.rating)
                              .Distinct()
                              .Single()))
                .ForMember(
                    dest => dest.Runtime,
                    src => src.MapFrom(
                        m => m.Select(s => s.runtime)
                              .Distinct()
                              .Single()))
                .ForMember(
                    dest => dest.SeasonNumber,
                    src => src.MapFrom(
                        m => m.Select(s => s.season_number)
                              .Distinct()
                              .Single()))
                .ForMember(
                    dest => dest.EpisodeNumber,
                    src => src.MapFrom(
                        m => m.Select(s => s.episode_number)
                              .Distinct()
                              .Single()))
                .ForMember(
                    dest => dest.EpisodeName,
                    src => src.MapFrom(
                        m => m.Select(s => s.episode_name)
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
