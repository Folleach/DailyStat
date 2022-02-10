using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading;

namespace DailyStat
{
    public class Settings<T> : IDisposable
    {
        private readonly TimeSpan interval;
        private readonly Thread updater;
        private readonly string path;
        private readonly byte[] currentHash;
        private bool checking = true;
        private T value;
        
        public Settings(string path, TimeSpan? updateInterval = null)
        {
            this.path = path;
            interval = updateInterval ?? TimeSpan.FromMinutes(1);
            if (interval < TimeSpan.Zero)
                throw new ArgumentException($"{nameof(updateInterval)} can't be less than zero");
            if (!File.Exists(path))
                throw new ArgumentException($"File '{path}' doesn't contains");
            Update(true);
            updater = new Thread(() =>
            {
                while (checking)
                {
                    Update();
                    Thread.Sleep(interval);
                }
            })
            {
                IsBackground = true
            };
            updater.Start();
        }

        private void Update(bool force = false)
        {
            var sha1 = new SHA1Managed();
            if (!File.Exists(path))
            {
                // log
                return;
            }
            using var file = File.OpenRead(path);
            var hash = sha1.ComputeHash(file);
            if (!force && !hash.AsEnumerable().Equals(currentHash))
                return;

            file.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            value = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions());
        }

        public T Get() => value;

        public void Dispose()
        {
            checking = false;
        }
    }
}