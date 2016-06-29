using System;

namespace Adsp.Multithreading.Locks
{
    public interface IMyReaderWriterLock : IDisposable
    {
        int ReadLocksCount { get; }
        void HoldReadLock();
        void HoldWriteLock();
        void ReleaseReadLock();
        void ReleaseWriteLock();
    }
}