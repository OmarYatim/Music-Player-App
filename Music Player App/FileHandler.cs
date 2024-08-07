using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player_App
{
    internal class FileHandler
    {
        private string serverUrl;

        public event Action<double> UploadProgressChanged;
        public event Action<double> DownloadProgressChanged;

        public FileHandler(string serverUrl, string connectionString)
        {
            this.serverUrl = serverUrl;
        }

        public async Task UploadFile(string localFilePath)
        {
            string fileName = Path.GetFileName(localFilePath);
            string serverFilePath = Path.Combine(serverUrl, fileName);

            if (File.Exists(serverFilePath))
            {
                Console.WriteLine("File already exists on the server. Upload aborted.");
                return;
            }

            try
            {
                using (FileStream fileStream = File.OpenRead(localFilePath))
                {
                    long totalBytes = fileStream.Length;
                    long uploadedBytes = 0;

                    using (Stream serverStream = File.Create(serverFilePath))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            serverStream.Write(buffer, 0, bytesRead);
                            uploadedBytes += bytesRead;

                            double progress = (double)uploadedBytes / totalBytes;
                            UploadProgressChanged?.Invoke(progress);
                        }
                    }
                }

                Console.WriteLine("File uploaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during file upload: " + ex.Message);
            }
        }

        public async Task DownloadFile(string fileName)
        {
            string localFilePath = Path.Combine(Environment.CurrentDirectory, fileName);
            string serverFilePath = Path.Combine(serverUrl, fileName);

            if (!File.Exists(serverFilePath))
            {
                Console.WriteLine("File does not exist on the server. Download aborted.");
                return;
            }

            try
            {
                using (FileStream fileStream = File.Create(localFilePath))
                {
                    using (Stream serverStream = WebRequest.Create(serverFilePath).GetResponse().GetResponseStream())
                    {
                        byte[] buffer = new byte[4096];
                        long totalBytes = serverStream.Length;
                        long downloadedBytes = 0;
                        int bytesRead;

                        while ((bytesRead = await serverStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            downloadedBytes += bytesRead;

                            double progress = (double)downloadedBytes / totalBytes;
                            DownloadProgressChanged?.Invoke(progress);
                        }
                    }
                }

                Console.WriteLine("File downloaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during file download: " + ex.Message);
            }
        }
    }
}
