using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BillSpliter.Services
{
    public static class ScreenshotService
    {
        public static async Task CaptureScreenshotAsync()
        {
            var screenshot = await Xamarin.Essentials.Screenshot.CaptureAsync();
            var fileName = $"{Guid.NewGuid()}.png";
            var filePath = Path.Combine(FileSystem.CacheDirectory, fileName);

            var stream = await screenshot.OpenReadAsync();
            using (FileStream fs = File.Open(filePath, FileMode.CreateNew))
            {
                await stream.CopyToAsync(fs);
                await fs.FlushAsync();
            }

            await ShareFile(fileName, filePath);
        }

        private static async Task ShareFile(string filename, string filepath)
        {
            await Share.RequestAsync(new ShareFileRequest()
            {
                Title = filename,
                File = new ShareFile(filepath),
            });
        }
    }
}
