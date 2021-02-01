//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3;
//using Google.Apis.Drive.v3.Data;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace MyWebSite.Models
//{
//    public class Program
//    {
//        //При изменении этих областей удалите ранее сохраненные учетные данные в ~/.credentials/drive-dotnet-quickstart.json
//        static string[] Scopes = { DriveService.Scope.DriveReadonly };
//        static string ApplicationName = "Drive API .NET Quickstart";

//        static void Main(string[] args)
//        {
//            UserCredential credential;

//            using (var stream =
//                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
//            {
//                //Маркер файла.json хранит маркеры доступа и обновления пользователя и создается автоматически, когда поток авторизации завершается в первый раз.
//                string credPath = "token.json";
//                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
//                    GoogleClientSecrets.Load(stream).Secrets,
//                    Scopes,
//                    "user",
//                    CancellationToken.None,
//                    new FileDataStore(credPath, true)).Result;
//                Console.WriteLine("Credential file saved to: " + credPath);
//            }

//            // Создайте службу API диска.
//            var service = new DriveService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = ApplicationName,
//            });

//            // Определите параметры запроса.
//            FilesResource.ListRequest listRequest = service.Files.List();
//            listRequest.PageSize = 10;
//            listRequest.Fields = "nextPageToken, files(id, name)";

//            // Список файлов.
//            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
//                .Files;
//            Console.WriteLine("Files:");
//            if (files != null && files.Count > 0)
//            {
//                foreach (var file in files)
//                {
//                    Console.WriteLine("{0} ({1})", file.Name, file.Id);
//                }
//            }
//            else
//            {
//                Console.WriteLine("No files found.");
//            }
//            Console.Read();

//        }
//    }
//}
