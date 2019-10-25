using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace set_memory_usage.Services
{
    public interface IMemoryService
    {
        string Reset();
        string Set(int size);
        string Get();
    }

    public class MemoryService : IMemoryService
    {
        private List<byte> memory;

        public MemoryService()
        {
            memory = new List<byte>();
        }

        public string Reset()
        {
            memory = new List<byte>();

            GCollect();

            return Get();
        }

        public string Set(int size)
        {
            var reset = Reset();

            if (size > 1100)
                size = 1100;

            byte[] memoryFile = System.IO.File.ReadAllBytes("memory");

            for (int i = 0; i < size; i++)
            {
                memory.AddRange(memoryFile);
            }

            memoryFile = new byte[0];

            GCollect();

            return Get();
        }

        public string Get()
        {
            return $"Application Memory : {(memory.Count / 1048576)} MB";
        }

        private void GCollect()
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
        }
    }

}
