using System.Threading;
using System.Threading.Tasks;
using Adsp.Multithreading.Locks;
using Xunit;

namespace Adsp.Multithreading.Tests.Locks
{
    public class ReaderWriterLockTests
    {
        [Fact]
        internal void CanHoldReadLock_AsycReadWrite_WaitingForReaders()
        {
            var resource = new ProtectedResource();
            Task.Factory.StartNew(() => resource.Read());
            Thread.Sleep(100);
            resource.Write(42);

            Assert.Equal(42, resource.Value);
        }

        [Fact]
        internal void CanHoldWriteLock_AsycReadWrite_WaitingForReaders()
        {
            var resource = new ProtectedResource();
            Task.Factory.StartNew(() => resource.Write(42));
            Thread.Sleep(100);
            var result = resource.Read();

            Assert.Equal(42, result);
        }
    }

    internal class ProtectedResource
    {
        private readonly IMyReadersWriterLock _mylock;
        public int Value;

        public ProtectedResource()
        {
            _mylock = new MyReadersWriterLock();
            Value = 5;
        }

        public int Read()
        {
            _mylock.HoldReadLock();
            try
            {
                Thread.Sleep(1000);
                return Value;
            }
            finally
            {
                _mylock.ReleaseReadLock();
            }
        }

        public void Write(int value)
        {
            _mylock.HoldWriteLock();
            try
            {
                Thread.Sleep(1000);
                Value = value;
            }
            finally
            {
                _mylock.ReleaseWriteLock();
            }
        }
    }
}