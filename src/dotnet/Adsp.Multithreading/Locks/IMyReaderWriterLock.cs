using System;

namespace Adsp.Multithreading.Locks
{
    public interface IMyReaderWriterLock : IDisposable
    {
        void HoldReadLock();
        void HoldWriteLock();
        void ReleaseReadLock();
        void ReleaseWriteLock();
    }
}