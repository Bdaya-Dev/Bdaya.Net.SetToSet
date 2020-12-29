using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Bdaya.SetToSet.Extensions
{
    public static class Json
    {
        public async static void DbsetToJsonFile<T>(this DbContext context, string path ) where T: class
        {
            var set = context.Set<T>();

            using var file = File.Create(path);
            var json = JsonConvert.SerializeObject(await set.ToListAsync());
            await file.WriteAsync(Encoding.UTF8.GetBytes(json));
        }

        public async static void DbsetToCSVFile<T>(this DbContext context, string path) where T : class
        {
            var set = context.Set<T>();

            using var file = File.Create(path);
            var json = JsonConvert.SerializeObject(await set.ToListAsync());
            await file.WriteAsync(Encoding.UTF8.GetBytes(json));
        }

    }
}
