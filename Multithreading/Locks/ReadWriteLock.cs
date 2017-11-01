using System;
using System.Threading;

namespace Multithreading.Locks
{
    public class ReadWriteLock : IReadWriteLock
    {
        private int _sLocksCount;
        private int _xLocksCount;
        private int _sixLocksCount;

        public void HoldSharedLock()
        {
            while (_xLocksCount > 0 || _sixLocksCount > 0)
            {
            }
            Interlocked.Increment(ref _sLocksCount);
        }

        public void HoldExclusiveLock()
        {
            while (_sLocksCount > 0 || _xLocksCount > 0)
            {
            }
            Interlocked.Increment(ref _xLocksCount);
        }

        public void HoldSharedIntentExclusiveLock()
        {
            while (_sLocksCount > 0 || _xLocksCount > 0)
            {
            }
            Interlocked.Increment(ref _sixLocksCount);
        }

        public void ReleaseSharedLock()
        {
            Interlocked.Decrement(ref _sLocksCount);
        }

        public void ReleaseExclusiveLock()
        {
            Interlocked.Decrement(ref _xLocksCount);
        }

        public void ReleaseSharedIntentExclusiveLock()
        {
            Interlocked.Decrement(ref _sixLocksCount);
        }

        public void Dispose()
        {
            _sLocksCount = 0;
            _xLocksCount = 0;
            _sixLocksCount = 0;
        }

        private class Lock
        {
            public Lock()
            {
                ThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            public int ThreadId { get; }
        }
    }
}