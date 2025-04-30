using System;
using System.Threading;

public static class Server
{
    private static int count = 0;

    // Обеспечивает параллельное чтение и эксклюзивную запись
    private static readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

    public static int GetCount()
    {
        rwLock.EnterReadLock();
        try
        {
            // Можно читать параллельно с другими чтениями
            return count;
        }
        finally
        {
            rwLock.ExitReadLock();
        }
    }

    public static void AddToCount(int value)
    {
        rwLock.EnterWriteLock();
        try
        {
            // Только один поток может записывать, все чтения блокируются
            count += value;
        }
        finally
        {
            rwLock.ExitWriteLock();
        }
    }
}
