using System;
using System.IO;

namespace PackageManager.Utility
{
    internal class CopyUtility
    {
        public static void Copy(string start, string dest, bool force, Action<string> action = null)
        {
            if (File.GetAttributes(start).HasFlag(FileAttributes.Directory))
            {
                CopyDirectory(start, dest, force, action);
            }
            else
            {
                CopyFile(start, dest, force, action);
            }
        }

        public static void CopyDirectory(string start, string dest, bool force, Action<string> action)
        {
            DirectoryInfo startDirInfo = new DirectoryInfo(start);

            if (!startDirInfo.Exists)
                throw new DirectoryNotFoundException($"Can not find the directory ({startDirInfo.FullName})");

            if (Directory.Exists(dest))
            {
                if (!force)
                {
                    action?.Invoke($"Since the directory ({dest}) already exists, this task will be skipped according to your settings (force : {force}).");
                    return;
                }
                else
                {
                    action?.Invoke($"Since the directory ({dest}) already exists, delete the existing directory and copy new one (force : {force}).");
                    Directory.Delete(dest, true);
                }
            }

            action?.Invoke($"Create a new directory ({dest})");
            Directory.CreateDirectory(dest);

            foreach (FileInfo file in startDirInfo.GetFiles())
            {
                CopyFile(file.FullName, Path.Combine(dest, file.Name), force, action);
            }

            DirectoryInfo[] startDirInfos = startDirInfo.GetDirectories();
            foreach (DirectoryInfo subDir in startDirInfos)
            {
                CopyDirectory(subDir.FullName, Path.Combine(dest, subDir.Name), force, action);
            }
        }

        public static void CopyFile(string start, string dest, bool force, Action<string> action)
        {
            FileInfo startFileInfo = new FileInfo(start);

            if (!startFileInfo.Exists)
                throw new FileNotFoundException($"Can not find the file ({startFileInfo.FullName})");

            if (File.Exists(dest))
            {
                if (!force)
                {
                    action?.Invoke($"Since the file ({dest}) already exists, this task will be skipped according to your settings (force : {force}).");
                    return;
                }
                else
                {
                    action?.Invoke($"Since the file ({dest}) already exists, delete the existing file and copy new one (force : {force}).");
                    File.Delete(dest);
                }
            }

            action.Invoke($"Copy file ({startFileInfo.FullName} => {dest})");

            FileInfo destFileInfo = new FileInfo(dest);

            if (!Directory.Exists(destFileInfo.Directory.FullName))
                Directory.CreateDirectory(destFileInfo.Directory.FullName);
            startFileInfo.CopyTo(dest);
        }
    }
}
