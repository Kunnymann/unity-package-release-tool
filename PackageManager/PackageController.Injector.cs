using System;
using System.Diagnostics;
using System.IO;

namespace PackageManager
{
    public partial class PackageController
    {
        private const string DEFAULT_SOURCE_INJECTION_DIR = "Assets/UPRT/Editor";
        private const string DEFAULT_BUILD_SOURCE_FILENAME = "UPRTPackageManager.Builder.cs";
        private const string DEFAULT_SYNC_SOURCE_FILENAME = "UPRTPackageManager.SyncGUIDs.cs";

        private void InjectCode(string path, string code)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                SendLogToPackageTool($"Already exist file ({path})");
                return;
            }
            else
            {
                DirectoryInfo directoryInfo = fileInfo.Directory;
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }

                using (StreamWriter streamWriter = fileInfo.CreateText())
                {
                    streamWriter.Write(code);
                }
                SendLogToPackageTool($"Success to inject default code ({path})");
            }
        }
    }
}
