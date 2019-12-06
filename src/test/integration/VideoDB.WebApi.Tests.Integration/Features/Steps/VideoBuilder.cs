using BoDi;
using Evo.WebApi.Models.Requests;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Given(@"^a user that wants to add a new (movie|tv episode)$")]
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
                    (request as MovieRequest).Plot = "Original Plot";
                    Database.AddRequestItem(request as MovieRequest, _container.Resolve<IConfiguration>());
                    (request as MovieRequest).Plot = "New Plot";
                    break;
                case "TV EPISODE":
                    request = RequestGenerator.GetTvEpisodeRequest();
                    (request as TvEpisodeRequest).EpisodePlot = "Original Plot";
                    Database.AddRequestItem(request as TvEpisodeRequest, _container.Resolve<IConfiguration>());
                    (request as TvEpisodeRequest).EpisodePlot = "New Plot";
                    break;
                default:
                    throw new Exception($"{typeOfContent} is not currently supported.");
            };


            _container.RegisterInstanceAs(request, name: "RequestBody");
        }

        [Given(@"a user that wants to see what (movie|tv episode|show)s already exist")]
        public void GivenAUserThatWantsToSeeWhatMoviesAlreadyExist(string typeOfContent)
        {
            object request;
            var config = _container.Resolve<IConfiguration>();
            switch (typeOfContent.ToUpperInvariant())
            {
                case "MOVIE":
                    foreach (var videoId in Enumerable.Range(1000000, 10))
                    {
                        request = RequestGenerator.GetMovieRequest(videoId);
                        Database.AddRequestItem(request as MovieRequest, config);
                    }
                    break;
                case "SHOW":
                case "TV EPISODE":
                    foreach (var tvId in Enumerable.Range(10000000, 10))
                    {
                        request = RequestGenerator.GetTvEpisodeRequest(1000000, tvId);
                        Database.AddRequestItem(request as TvEpisodeRequest, config);
                    }
                    
                    break;
                default:
                    throw new Exception($"{typeOfContent} is not currently supported.");
            };
        }

        [Given(@"a user that wants to see a (movie|tv episode|show) that already exists")]
        public void GivenAUserThatWantsToSeeAMovieThatAlreadyExists(string typeOfContent)
        {
            var config = _container.Resolve<IConfiguration>();
            switch (typeOfContent.ToUpperInvariant())
            {
                case "MOVIE":
                    foreach (var videoId in Enumerable.Range(1000000, 10))
                    {
                        var movieRequest = RequestGenerator.GetMovieRequest(videoId);
                        Database.AddRequestItem(movieRequest as MovieRequest, config);
                    }
                    _container.RegisterInstanceAs<object>("tt1000005", name: "RequestID");
                    break;
                case "SHOW":
                    foreach (var tvId in Enumerable.Range(10000000, 10))
                    {
                        var tvRequest = RequestGenerator.GetTvEpisodeRequest(1000000, tvId);
                        Database.AddRequestItem(tvRequest as TvEpisodeRequest, config);
                    }
                    _container.RegisterInstanceAs<object>("tt1000000", name: "RequestID");
                    break;
                case "TV EPISODE":
                    foreach (var tvId in Enumerable.Range(10000000, 10))
                    {
                        var tvRequest = RequestGenerator.GetTvEpisodeRequest(1000000, tvId);
                        Database.AddRequestItem(tvRequest as TvEpisodeRequest, config);
                    }
                    _container.RegisterInstanceAs<object>("tt10000005", name: "RequestID");

                    break;
                default:
                    throw new Exception($"{typeOfContent} is not currently supported.");
            };

        }

    }
}
