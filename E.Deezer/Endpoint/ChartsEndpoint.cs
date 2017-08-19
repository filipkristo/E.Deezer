﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

using E.Deezer.Api;

namespace E.Deezer.Endpoint
{
    public interface IChartsEndpoint
    {
        //Complete charts
        Task<IChart> GetChart();
        Task<IChart> GetChart(int aGenreId);
        Task<IChart> GetChart(IGenre aGenre);

        //Album Charts
        Task<IEnumerable<IAlbum>> GetAlbumChart();
        Task<IEnumerable<IAlbum>> GetAlbumChartForGenre(int aGenreId);
        Task<IEnumerable<IAlbum>> GetAlbumChartForGenre(IGenre aGenre);

        Task<IEnumerable<IAlbum>> GetAlbumChart(uint aCount);
        Task<IEnumerable<IAlbum>> GetAlbumChartForGenre(int aGenreId, uint aCount);
        Task<IEnumerable<IAlbum>> GetAlbumChartForGenre(IGenre aGenre, uint aCount);

        Task<IEnumerable<IAlbum>> GetAlbumChart(uint aStart, uint aCount);
        Task<IEnumerable<IAlbum>> GetAlbumChartForGenre(int aGenreId, uint aStart, uint aCount);
        Task<IEnumerable<IAlbum>> GetAlbumChartForGenre(IGenre aGenre, uint aStart, uint aCount);


        //Artists
        Task<IEnumerable<IArtist>> GetArtistChart();
        Task<IEnumerable<IArtist>> GetArtistChartForGenre(int aGenreId);
        Task<IEnumerable<IArtist>> GetArtistChartForGenre(IGenre aGenre);

        Task<IEnumerable<IArtist>> GetArtistChart(uint aCount);
        Task<IEnumerable<IArtist>> GetArtistChartForGenre(int aGenreId, uint aCount);
        Task<IEnumerable<IArtist>> GetArtistChartForGenre(IGenre aGenre, uint aCount);

        Task<IEnumerable<IArtist>> GetArtistChart(uint aStart, uint aCount);
        Task<IEnumerable<IArtist>> GetArtistChartForGenre(int aGenreId, uint aStart, uint aCount);
        Task<IEnumerable<IArtist>> GetArtistChartForGenre(IGenre aGenre, uint aStart, uint aCount);

        //Playlists
        Task<IEnumerable<IPlaylist>> GetPlaylistChart();
        Task<IEnumerable<IPlaylist>> GetPlaylistChartForGenre(int aGenreId);
        Task<IEnumerable<IPlaylist>> GetPlaylistChartForGenre(IGenre aGenre);

        Task<IEnumerable<IPlaylist>> GetPlaylistChart(uint aCount);
        Task<IEnumerable<IPlaylist>> GetPlaylistChartForGenre(int aGenreId, uint aCount);
        Task<IEnumerable<IPlaylist>> GetPlaylistChartForGenre(IGenre aGenre, uint aCount);

        Task<IEnumerable<IPlaylist>> GetPlaylistChart(uint aStart, uint aCount);
        Task<IEnumerable<IPlaylist>> GetPlaylistChartForGenre(int aGenreId, uint aStart, uint aCount);
        Task<IEnumerable<IPlaylist>> GetPlaylistChartForGenre(IGenre aGenre, uint aStart, uint aCount);

        //Tracks
        Task<IEnumerable<ITrack>> GetTrackChart();
        Task<IEnumerable<ITrack>> GetTrackChartForGenre(int aGenreId);
        Task<IEnumerable<ITrack>> GetTrackChartForGenre(IGenre aGenre);

        Task<IEnumerable<ITrack>> GetTrackChart(uint aCount);
        Task<IEnumerable<ITrack>> GetTrackChartForGenre(int aGenreId, uint aCount);
        Task<IEnumerable<ITrack>> GetTrackChartForGenre(IGenre aGenre, uint aCount);

        Task<IEnumerable<ITrack>> GetTrackChart(uint aStart, uint aCount);
        Task<IEnumerable<ITrack>> GetTrackChartForGenre(int aGenreId, uint aStart, uint aCount);
        Task<IEnumerable<ITrack>> GetTrackChartForGenre(IGenre aGenre, uint aStart, uint aCount);
    }

    internal class ChartsEndpoint : IChartsEndpoint
    {
        private DeezerClient iClient;
        public ChartsEndpoint(DeezerClient aClient) { iClient = aClient; }

        //-1 here means not to add any ID param, which will return the complete Deezer Chart
        public Task<IChart> GetChart()              => Get(-1);
        public Task<IChart> GetChart(int aGenreId)  => Get(aGenreId);
        public Task<IChart> GetChart(IGenre aGenre) => Get(aGenre.Id);

        /* ALBUMS */
        public Task<IEnumerable<IAlbum>> GetAlbumChart()                                        => GetAlbumChart(0);
        public Task<IEnumerable<IAlbum>> GetAlbumChart(int aGenreId)                            => GetAlbumChart(aGenreId, 0, iClient.ResultSize);
        public Task<IEnumerable<IAlbum>> GetAlbumChart(IGenre aGenre)                           => GetAlbumChart(aGenre.Id, 0, iClient.ResultSize);

        public Task<IEnumerable<IAlbum>> GetAlbumChart(uint aCount)                             => GetAlbumChart(0, 0, aCount);
        public Task<IEnumerable<IAlbum>> GetAlbumChart(int aGenreId, uint aCount)               => GetAlbumChart(aGenreId, 0, aCount);
        public Task<IEnumerable<IAlbum>> GetAlbumChart(IGenre aGenre, uint aCount)              => GetAlbumChart(aGenre.Id, 0, aCount);

        public Task<IEnumerable<IAlbum>> GetAlbumChart(uint aStart, uint aCount)                => GetAlbumChart(0, aStart, aCount);
        public Task<IEnumerable<IAlbum>> GetAlbumChart(IGenre aGenre, uint aStart, uint aCount) => GetAlbumChart(aGenre.Id, aStart, aCount);
        public Task<IEnumerable<IAlbum>> GetAlbumChart(int aGenreId, uint aStart, uint aCount)  => Get<Album, IAlbum>("chart/{id}/albums", aGenreId, aStart, aCount);


        /* ARTISTS */
        public Task<IEnumerable<IArtist>> GetArtistChart() => GetArtistChart(0);
        public Task<IEnumerable<IArtist>> GetArtistChart(int aGenreId) => GetArtistChart(aGenreId, 0, iClient.ResultSize);
        public Task<IEnumerable<IArtist>> GetArtistChart(IGenre aGenre) => GetArtistChart(aGenre.Id, 0, iClient.ResultSize);

        public Task<IEnumerable<IArtist>> GetArtistChart(uint aCount) => GetArtistChart(0, 0, aCount);
        public Task<IEnumerable<IArtist>> GetArtistChart(int aGenreId, uint aCount) => GetArtistChart(aGenreId, 0, aCount);
        public Task<IEnumerable<IArtist>> GetArtistChart(IGenre aGenre, uint aCount) => GetArtistChart(aGenre.Id, 0, aCount);

        public Task<IEnumerable<IArtist>> GetArtistChart(uint aStart, uint aCount) => GetArtistChart(0, aStart, aCount);
        public Task<IEnumerable<IArtist>> GetArtistChart(IGenre aGenre, uint aStart, uint aCount) => GetArtistChart(aGenre.Id, aStart, aCount);
        public Task<IEnumerable<IArtist>> GetArtistChart(int aGenreId, uint aStart, uint aCount) => Get<Artist, IArtist>("chart/{id}/artists", aGenreId, aStart, aCount);


        /* PLAYLISTS */
        public Task<IEnumerable<IPlaylist>> GetPlaylistChart() => GetPlaylistChart(0);
        public Task<IEnumerable<IPlaylist>> GetPlaylistChart(int aGenreId) => GetPlaylistChart(aGenreId, 0, iClient.ResultSize);
        public Task<IEnumerable<IPlaylist>> GetPlaylistChart(IGenre aGenre) => GetPlaylistChart(aGenre.Id, 0, iClient.ResultSize);

        public Task<IEnumerable<IPlaylist>> GetPlaylistChart(uint aCount) => GetPlaylistChart(0, 0, aCount);
        public Task<IEnumerable<IPlaylist>> GetPlaylistChart(int aGenreId, uint aCount) => GetPlaylistChart(aGenreId, 0, aCount);
        public Task<IEnumerable<IPlaylist>> GetPlaylistChart(IGenre aGenre, uint aCount) => GetPlaylistChart(aGenre.Id, 0, aCount);

        public Task<IEnumerable<IPlaylist>> GetPlaylistChart(uint aStart, uint aCount) => GetPlaylistChart(0, aStart, aCount);
        public Task<IEnumerable<IPlaylist>> GetPlaylistChart(IGenre aGenre, uint aStart, uint aCount) => GetPlaylistChart(aGenre.Id, aStart, aCount);
        public Task<IEnumerable<IPlaylist>> GetPlaylistChart(int aGenreId, uint aStart, uint aCount) => Get<Playlist, IPlaylist>("chart/{id}/playlists", aGenreId, aStart, aCount);


        /* TRACKS */
        public Task<IEnumerable<ITrack>> GetTrackChart() => GetTrackChart(0);
        public Task<IEnumerable<ITrack>> GetTrackChart(int aGenreId) => GetTrackChart(aGenreId, 0, iClient.ResultSize);
        public Task<IEnumerable<ITrack>> GetTrackChart(IGenre aGenre) => GetTrackChart(aGenre.Id, 0, iClient.ResultSize);

        public Task<IEnumerable<ITrack>> GetTrackChart(uint aCount) => GetTrackChart(0, 0, aCount);
        public Task<IEnumerable<ITrack>> GetTrackChart(int aGenreId, uint aCount) => GetTrackChart(aGenreId, 0, aCount);
        public Task<IEnumerable<ITrack>> GetTrackChart(IGenre aGenre, uint aCount) => GetTrackChart(aGenre.Id, 0, aCount);

        public Task<IEnumerable<ITrack>> GetTrackChart(uint aStart, uint aCount) => GetTrackChart(0, aStart, aCount);
        public Task<IEnumerable<ITrack>> GetTrackChart(IGenre aGenre, uint aStart, uint aCount) => GetTrackChart(aGenre.Id, aStart, aCount);
        public Task<IEnumerable<ITrack>> GetTrackChart(int aGenreId, uint aStart, uint aCount) => Get<Track, ITrack>("chart/{id}/tracks", aGenreId, aStart, aCount);


        //Internal wrapper around get for all ChartEndpoint methods :)
        private Task<IEnumerable<TDest>> Get<TSource, TDest>(string aMethod, int aId, uint aStart, uint aCount) where TSource : TDest, IDeserializable<DeezerClient>
        {
            List<IRequestParameter> parms = new List<IRequestParameter>()
            {
                RequestParameter.GetNewUrlSegmentParamter("id", aId)
            };

            return iClient.Get<TSource>(aMethod, parms, aStart, aCount).ContinueWith<IEnumerable<TDest>>((aTask) =>
            {
                List<TDest> items = new List<TDest>();

                foreach (var item in aTask.Result.Items)
                {
                    item.Deserialize(iClient);
                    items.Add(item);
                }
                return items;
            }, iClient.CancellationToken, TaskContinuationOptions.NotOnCanceled, TaskScheduler.Default);
        }

        private Task<IChart> Get(int aId)
        {
            IList<IRequestParameter> parms = (aId == -1) ? RequestParameter.EmptyList
                                                        : new List<IRequestParameter>()
                                                            {
                                                                RequestParameter.GetNewUrlSegmentParamter("id", aId),
                                                            };

            string method = (aId == -1) ? "chart" : "chart/{id}";

            return iClient.GetPlain<Chart>(method, parms).ContinueWith((aTask) =>
            {
                aTask.Result.Deserialize(iClient);
                return aTask.Result as IChart;
            }, iClient.CancellationToken, TaskContinuationOptions.NotOnCanceled, TaskScheduler.Default);

        }
    }
}
