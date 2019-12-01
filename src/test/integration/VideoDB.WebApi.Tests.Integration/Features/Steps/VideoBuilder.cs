﻿using BoDi;
using Evo.WebApi.Models.Requests;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using VideoDB.WebApi.Tests.Helpers;
using VideoDB.WebApi.Tests.Integration.Features.Steps.Support;

namespace VideoDB.WebApi.Tests.Integration.Features.Steps
{
    [Binding]
    public class VideoBuilder
    {
        private readonly IObjectContainer _container;

        public VideoBuilder(IObjectContainer container)
        {
            _container = container;
        }

        [Given(@"a new (movie|tv episode)")]
        public void GivenANewVideo(string typeOfContent)
        {
            var request = typeOfContent.ToUpperInvariant() switch
            {
                "MOVIE" => RequestGenerator.GetMovieRequest(),
                "TV EPISODE" => RequestGenerator.GetTvEpisodeRequest(),
                _ => throw new Exception($"{typeOfContent} is not currently supported.")
            };
                
            _container.RegisterInstanceAs<object>(request, name: "RequestBody");
        }

        [Given(@"a (movie|tv episode) already exists in the record")]
        public void GivenAVideoAlreadyExistsInTheRecord(string typeOfContent)
        {
            object request;
            switch (typeOfContent.ToUpperInvariant())
            {
                case "MOVIE":
                    request = RequestGenerator.GetMovieRequest();
                    Database.AddRequestItem(request as MovieRequest, _container.Resolve<IConfiguration>());
                    break;
                case "TV EPISODE":
                    request = RequestGenerator.GetTvEpisodeRequest();
                    Database.AddRequestItem(request as TvEpisodeRequest, _container.Resolve<IConfiguration>());
                    break;
                default:
                    throw new Exception($"{typeOfContent} is not currently supported.");
            };


            _container.RegisterInstanceAs(request, name: "RequestBody");
        }

    }
}
