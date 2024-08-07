using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;

namespace Music_Player_App
{
    internal static class GoogleDriveHandler
    {
        public static async Task<string> UploadFileToDrive(string filePath, Action<int> progressChangedAction)
        {
            // Get the credentials from a client_secret.json file (obtained from Google API Console)
            UserCredential credential;
            using (var stream = new FileStream("C:\\Users\\chleghem\\Downloads\\client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { DriveService.Scope.Drive, DriveService.Scope.DriveMetadata, DriveService.Scope.DriveAppdata, DriveService.Scope.DriveFile },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }

            // Create Drive API service
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Music Player App"
            });

            // Create the file metadata
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(filePath),
                Parents = new List<string> { "1NsztBaMbX9GmSd7X4WI3mbs5JbsHn-5f" }
            };

            // Define the upload stream
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                // Create the upload request
                var request = service.Files.Create(fileMetadata, stream, "audio/wav");
                request.Fields = "id,webViewLink"; // Specify the fields to include in the response
                long totalBytes = new FileInfo(filePath).Length;
                long bytesSent;
                request.ProgressChanged += progress =>
                {
                    // Calculate the progress percentage based on the bytes sent
                    int progressPercentage = (int)(progress.BytesSent * 100 / totalBytes);
                    progressChangedAction?.Invoke(progressPercentage);
                };

                var uploadProgress = await request.UploadAsync();

                // Check if the upload was successful
                if (uploadProgress.Status == UploadStatus.Completed)
                {
                    // Get the uploaded file ID and web view link
                    var file = request.ResponseBody;
                    return file.Id;
                }
                else
                {
                    throw new IOException($"File upload failed. Status: {uploadProgress.Status}");
                }
            }
        }

        public static async Task<byte[]> DownloadFileFromDrive(string fileId)
        {
            if (String.IsNullOrEmpty(fileId)) return Array.Empty<byte>();
            // Get the credentials from a client_secret.json file (obtained from Google API Console)
            UserCredential credential;
            using (var stream = new FileStream("C:\\Users\\chleghem\\Downloads\\client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { DriveService.Scope.DriveReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Drive API service
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Music Player App"
            });

            // Download file
            using (var stream = new MemoryStream())
            {
                await service.Files.Get(fileId).DownloadAsync(stream);
                return stream.ToArray();
            }
        }

        public static void DeleteFile(string fileId)
        {
            if (String.IsNullOrEmpty(fileId)) return;
            UserCredential credential;
            using (var stream = new FileStream("C:\\Users\\chleghem\\Downloads\\client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { DriveService.Scope.DriveReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create a Drive service using the credentials
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Music Player App"
            });

            // Delete the file
            service.Files.Delete(fileId).Execute();
        }
    }
}
