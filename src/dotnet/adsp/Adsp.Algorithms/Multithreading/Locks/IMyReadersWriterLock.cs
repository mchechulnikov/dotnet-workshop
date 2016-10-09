using System;

namespace Adsp.Algorithms.Multithreading.Locks
{
    public interface IMyReadersWriterLock : IDisposable
    {
        void HoldReadLock();
        void HoldWriteLock();
        void ReleaseReadLock();
        void ReleaseWriteLock();
    }
}