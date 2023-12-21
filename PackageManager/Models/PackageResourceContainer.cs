using PackageManager.Enums;
using System.Collections.Generic;

namespace PackageManager.Models
{
    public class PackageResourceContainer
    {
        public string UnityEditorDirectory { get; set; }
        public string PackageProjectDirectory { get; set; }
        public string PackageDirectory { get; set; }
        public string SimulationProjectDirectory { get; set; }

        public string PackageTitle { get; set; }
        public string BuildSourceMethod { get; set; }
        public string SyncGUIDMethod { get; set; }

        public List<Content> PackageContent { get; set; }
        public GUIDSyncTargets GUIDSyncTargets { get; set; }
    }

    public class Content
    {
        public string Name { get; set; } = "No title";
        public ContentType ContentType { get; set; }
        public bool CopyForce { get; set; } = true;
        public string[] Targets { get; set; }
    }

    public class GUIDSyncTargets
    {
        public string Start { get; set; }
        public string Destination { get; set; }
        public List<string> TargetNames { get; set; }
    }

    public class UnityAssetGUID
    {
        public string Path;
        public string Name;
        public string GUID;
        public long FileID;
    }

    public class TargetGUIDs
    {
        public UnityAssetGUID[] UnityAssetGUIDs;
    }
}
