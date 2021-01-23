using Google.Cloud.Storage.V1;
using System;
using System.IO;

namespace MyWebSite.Pages.Company
{
    public class UploadFileSample
    {
        public void UploadFile(
    string bucketName = "your-unique-bucket-name",
    string localPath = "my-local-path/my-file-name",
    string objectName = "my-file-name")
        {
            var storage = StorageClient.Create();
            using var fileStream = File.OpenRead(localPath);
            storage.UploadObject(bucketName, objectName, null, fileStream);
            Console.WriteLine($"Uploaded {objectName}.");
        }
    }
}
