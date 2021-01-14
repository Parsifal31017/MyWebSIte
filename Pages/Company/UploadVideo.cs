using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Google.Apis.YouTube.Samples
{
    /// <summary>
    /// YouTube Data API v3 sample: retrieve my uploads.
    /// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
    /// See https://developers.google.com/api-client-library/dotnet/get_started
    /// </summary>
    public class MyUploads
    {
        [STAThread]
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("YouTube Data API: My Uploads");
        //    Console.WriteLine("============================");

        //    try
        //    {
        //        new MyUploads().Run().Wait();
        //    }
        //    catch (AggregateException ex)
        //    {
        //        foreach (var e in ex.InnerExceptions)
        //        {
        //            Console.WriteLine("Error: " + e.Message);
        //        }
        //    }

        //    Console.WriteLine("Press any key to continue...");
        //    Console.ReadKey();
        //}

        public async Task Run()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                           GoogleClientSecrets.Load(stream).Secrets,
                           //Эта область доступа OAuth 2.0 допускает доступ 
                           //только для чтения к учетной записи аутентифицированного пользователя, 
                           //но не другие типы доступа к учетной записи.
                           new[] { YouTubeService.Scope.YoutubeReadonly },
                           "user",
                           CancellationToken.None,
                           new FileDataStore(this.GetType().ToString())
                       );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = this.GetType().ToString()
            });

            var channelsListRequest = youtubeService.Channels.List("contentDetails");
            channelsListRequest.Mine = true;

            // Извлеките часть сведений о содержимом ресурса канала для канала аутентифицированного пользователя.
            var channelsListResponse = await channelsListRequest.ExecuteAsync();

            foreach (var channel in channelsListResponse.Items)
            {
                //Из ответа API извлеките идентификатор списка воспроизведения, 
                //который идентифицирует список видео, загруженных на канал 
                //аутентифицированного пользователя.
                var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;

                Console.WriteLine("Videos in list {0}", uploadsListId);

                var nextPageToken = "";
                while (nextPageToken != null)
                {
                    var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
                    playlistItemsListRequest.PlaylistId = uploadsListId;
                    playlistItemsListRequest.MaxResults = 50;
                    playlistItemsListRequest.PageToken = nextPageToken;

                    // Извлеките список видео, загруженных на канал аутентифицированного пользователя.
                    var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();

                    foreach (var playlistItem in playlistItemsListResponse.Items)
                    {
                        // Распечатайте информацию о каждом видео.
                        Console.WriteLine("{0} ({1})", playlistItem.Snippet.Title, playlistItem.Snippet.ResourceId.VideoId);
                    }

                    nextPageToken = playlistItemsListResponse.NextPageToken;
                }
            }
        }
    }
}
