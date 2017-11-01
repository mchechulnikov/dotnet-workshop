using System;

namespace Multithreading.Locks
{
    public interface IReadWriteLock : IDisposable
    {
        void HoldSharedLock();
        void HoldExclusiveLock();
        void HoldSharedIntentExclusiveLock();
        void ReleaseSharedLock();
        void ReleaseExclusiveLock();
        void ReleaseSharedIntentExclusiveLock();
    }
}