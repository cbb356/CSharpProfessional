using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryMonitor
{
    internal class Monitor
    {
        private readonly long _maxMemoryBytes;
        private readonly double _warningThreshold; // percentage (0–1.0)

        public Monitor(long maxMemoryMB = 100, double warningTreshold = 0.8) 
        {
            _maxMemoryBytes = maxMemoryMB * 1024 * 1024;
            _warningThreshold = warningTreshold;
        }

        // Return current memory usage
        public double GetCurrentMemoryUsageMB()
        {
            return GC.GetTotalMemory(false) / (1024.0 * 1024.0);
        }

        // Check memory usage
        public void CheckMemoryUsage()
        {
            double memoryUsedMB = GetCurrentMemoryUsageMB();
            double memoryMaxMB = _maxMemoryBytes / (1024.0 * 1024.0);

            Console.WriteLine($"Memory used: {memoryUsedMB:F2} MB / {memoryMaxMB:F2} MB");

            if (memoryUsedMB >= memoryMaxMB)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Memory limit exceeded!");
                Console.ResetColor();
            }
            else if (memoryUsedMB >= memoryMaxMB * _warningThreshold)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Memory usage close to limit");
                Console.ResetColor();
            }
        }
    }
}
