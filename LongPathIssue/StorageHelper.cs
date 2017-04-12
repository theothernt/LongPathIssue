using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace LongPathIssue
{
    public static class StorageHelper
    {
        // C:\Users\{username}\AppData\Local\Packages\{package-name-guid}\LocalState\
        // approx. 100 characters already used
        private static readonly string path = Path.Combine(ApplicationData.Current.LocalFolder.Path,
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\\" +
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\\" +
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\\" +
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\\" +
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\\" +
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\\" +
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\\");

        public static bool CreateFolder()
        {
            Debug.WriteLine($"Path length: {path.Length}");
            try
            {
                
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return false;
        }

        public static async Task<bool> CreateFile()
        {
            var filename = Path.Combine(path, "test.txt");
            var text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            
            Debug.WriteLine($"Path length: {filename.Length}");

            try
            {
                var file = await StorageFile.GetFileFromPathAsync(filename);
                await FileIO.WriteTextAsync(file, text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            
            return false;
        }
    }
}
