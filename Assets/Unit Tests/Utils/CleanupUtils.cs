using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CleanupUtils
{
    public static void RecursiveCleanup(string startFolder, System.Func<string, bool> predicate)
    {
        Queue<string> directoryQueue = new Queue<string>();
        directoryQueue.Enqueue(startFolder);

        while (directoryQueue.Count > 0)
        {
            string currentFolder = directoryQueue.Dequeue();

            foreach (string filePath in Directory.GetFiles(currentFolder))
            {
                if (predicate(filePath))
                    File.Delete(filePath);
            }

            foreach (string subDirectory in Directory.GetDirectories(currentFolder))
            {
                directoryQueue.Enqueue(subDirectory);
            }
        }
    }
}
