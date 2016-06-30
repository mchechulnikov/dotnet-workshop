using System.Threading;

namespace Adsp.Multithreading.Locks
{
    public class MyReadersWriterLock : IMyReadersWriterLock
    {
        private int _readersCount;
        private int _writersCount;
        private int _writeRequestsCount;

        public void HoldReadLock()
        {
            while (_writersCount > 0 || _writeRequestsCount > 0)
            {
                Wait();
            }
            _readersCount++;
        }

        public void HoldWriteLock()
        {
            _writeRequestsCount++;
            while (_readersCount > 0 || _writersCount > 0)
            {
                Wait();
            }
            _writeRequestsCount--;
            _writersCount++;
        }

        public void ReleaseReadLock()
        {
            _readersCount--;
            // notify
        }

        public void ReleaseWriteLock()
        {
            _writersCount--;
            // notify
        }

        public void Dispose() {}

        private static void Wait()
        {
            Thread.Sleep(1);
        }
    }
}