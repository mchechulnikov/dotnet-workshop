using System.Threading;
using System.Threading.Tasks;
using Multithreading.Locks;
using Xunit;

namespace Multithreading.Tests.Locks
{
    public class ReaderWriterLockTests
    {
        [Fact]
        internal void CanHoldReadLock_AsycReadWrite_WaitingForReaders()
        {
            var resource = new ProtectedResource();
            Task.Factory.StartNew(() => resource.Read());
            Thread.Sleep(300);
            resource.Write(42);

            Assert.Equal(42, resource.Value);
        }

        [Fact]
        internal void CanHoldWriteLock_AsycReadWrite_WaitingForReaders()
        {
            var resource = new ProtectedResource();
            Task.Factory.StartNew(() => resource.Write(42));
            Thread.Sleep(300);
            var result = resource.Read();

            Assert.Equal(42, result);
        }
    }

    internal class ProtectedResource
    {
        private readonly IReadWriteLock _mylock;
        public int Value;

        public ProtectedResource()
        {
            _mylock = new ReadWriteLock();
            Value = 5;
        }

        public int Read()
        {
            _mylock.HoldSharedLock();
            try
            {
                Thread.Sleep(2000);
                return Value;
            }
            finally
            {
                _mylock.ReleaseSharedLock();
            }
        }

        public void Write(int value)
        {
            _mylock.HoldExclusiveLock();
            try
            {
                Thread.Sleep(2000);
                Value = value;
            }
            finally
            {
                _mylock.ReleaseExclusiveLock();
            }
        }
    }
}
