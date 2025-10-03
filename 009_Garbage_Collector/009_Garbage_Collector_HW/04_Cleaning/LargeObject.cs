using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning
{
    internal class LargeObject : IDisposable
    {
        private bool _disposed;
        private byte[]? _largeMemoryBlock;

        public LargeObject(int sizeMB)
        {
            _largeMemoryBlock = new byte[sizeMB * 1024 * 1024];
            Console.WriteLine($"Created an {this.GetHashCode()} object with size {sizeMB} MB");
        }

        public void DoWork()
        {
            Console.WriteLine("Doing some work with large memory block...");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // free managed resources
                    Console.WriteLine("Releasing managed resources...");
                    _largeMemoryBlock = null;
                    Console.WriteLine($"The {this.GetHashCode()} object disposed");
                }
                _disposed = true;
            }
        }

        ~LargeObject() 
        {
            Dispose(false);
            Console.WriteLine($"The {this.GetHashCode()} object destructed");
        }
    }
}
