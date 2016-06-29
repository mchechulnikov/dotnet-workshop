namespace Adsp.Multithreading.Locks
{
    public class MyReaderWriterLock : IMyReaderWriterLock
    {
        public int ReadLocksCount { get; private set; }

        public void HoldReadLock()
        {

            ReadLocksCount++;
        }

        public void HoldWriteLock()
        {
            throw new System.NotImplementedException();
        }

        public void ReleaseReadLock()
        {
            ReadLocksCount--;
        }

        public void ReleaseWriteLock()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}