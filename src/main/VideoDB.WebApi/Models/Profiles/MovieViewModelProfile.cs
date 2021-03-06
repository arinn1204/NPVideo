﻿using AutoMapper;
using Evo.WebApi.Models.DataModel;
using Evo.WebApi.Models.Enums;
using Evo.WebApi.Models.ViewModels;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoDB.WebApi.Models.Profiles
{
    public class MovieViewModelProfile : Profile
    {
        public MovieViewModelProfile()
        {
            CreateMap<IEnumerable<MovieDataModel>, MovieViewModel>()
                .ForMember(dest => dest.VideoId, src => src.MapFrom(
                    m => m.Select(s => s.imdb_id)
                          .Distinct()
                          .Single()))
                .ForMember(
                    dest => dest.IsUpdated,
                    src => src.MapFrom(
                        m => m.Select(s => s.updated)
                            .Distinct()
                            .Single()))
                .ForMember(dest => dest.Title, src => src.MapFrom(
                    m => m.Select(s => s.movie_title)
                          .Distinct()
                          .Single()))
                .ForMember(dest => dest.MpaaRating, src => src.MapFrom(
                    m => m.Select(s => s.movie_rating)
                          .Distinct()
                          .Single()))
                .ForMember(dest => dest.Runtime, src => src.MapFrom(
                    m => m.Select(s => s.runtime)
                          .Distinct()
                          .Single()))
                .ForMember(dest => dest.Plot, src => src.MapFrom(
                    m => m.Select(s => s.plot)
                          .Distinct()
                          .Single()))
                .ForMember(dest => dest.ReleaseDate, src => src.MapFrom(
                    m => m.Select(s => s.release_date)
                          .Distinct()
                          .Single()))
                .ForMember(dest => dest.VideoType, src => src.MapFrom(m => VideoType.Movie));
        }
    }
}
