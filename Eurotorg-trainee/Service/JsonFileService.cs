using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Eurotorg_trainee.Service
{
    public class JsonFileService
    {
        public static async Task WriteJson<T>(T data, string filePath)
        {
            FileStream createStream = null;
            try
            {
                createStream = File.Create(filePath);
                await JsonSerializer.SerializeAsync<T>(createStream, data);
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                createStream?.Close();
            }
        }

        public static async ValueTask<T> ReadFromJson<T>(string filePath)
        {
            FileStream readStream = null;
            try
            {
                readStream = File.OpenRead(filePath);
                return await JsonSerializer.DeserializeAsync<T>(readStream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readStream?.Close();
            }
        }
    }
}
