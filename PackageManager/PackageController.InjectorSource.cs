﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager
{
    public partial class PackageController
    {
        private string defaultBuildSourceCode = @"
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace uprt.editor
{
    /// <summary>
    /// UPRT Unity용 클래스
    /// </summary>
    public partial class UPRTPackageManager
    {
        [MenuItem(""UPRT/Builder/Win64"")]
        /// <summary>
        /// 윈도우 빌드
        /// </summary>
        public static void BuildWin64()
        {
            BuildPlayerOptions buildOptions = new BuildPlayerOptions();
            buildOptions.scenes = GetScenesToString();
            buildOptions.locationPathName = $""Build/Build.exe"";
            buildOptions.target = BuildTarget.StandaloneWindows64;
            buildOptions.options = BuildOptions.None;
            StartBuild(buildOptions);
        }

        private static string[] GetScenesToString()
        {
            List<string> scenes = new List<string>();

            foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (!scene.enabled) continue;
                scenes.Add(scene.path);
            }
            return scenes.ToArray();
        }

        private static void StartBuild(BuildPlayerOptions bpo)
        {
            BuildReport report = BuildPipeline.BuildPlayer(bpo);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
                Debug.Log($""Build succeeded : {summary.totalSize} bytes"");
            else if (summary.result == BuildResult.Failed)
                Debug.LogError(""Build failed"");
            else if (summary.result == BuildResult.Cancelled)
                Debug.LogWarning(""Build canceled"");
            else
                Debug.LogError(""Build failed by unknown issues"");
        }
    }
}
";
        private string defaultSyncSourceCode = @"
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace uprt.editor
{
    /// <summary>
    /// UPRT Unity Asset Sync를 위한 클래스
    /// </summary>
    [Serializable]
    public class UnityAssetGUID
    {
        /// <summary>
        /// 파일 경로
        /// </summary>
        public string Path;
        /// <summary>
        /// 에셋 이름
        /// </summary>
        public string Name;
        /// <summary>
        /// GUID
        /// </summary>
        public string GUID;
        /// <summary>
        /// File ID
        /// </summary>
        public long FileID;
    }

    [Serializable]
    public class TargetList
    {
        public List<UnityAssetGUID> UnityAssetGUIDs;
    }

    public partial class UPRTPackageManager
    {
        /// <summary>
        /// Unity Asset의 GUID를 수집하는 함수
        /// </summary>
        public static void GetGUIDs()
        {
            string outputPath = string.Empty;
            string packageTitle = string.Empty;
            string[] arguments = System.Environment.GetCommandLineArgs();
            bool isGetOutputPath = false;

            for (int idx = 0; idx < arguments.Length; idx++)
            {
                if (arguments[idx] == ""-output"")
                {
                    outputPath = arguments[idx + 1];
                    isGetOutputPath = true;
                    continue;
                }

                if (isGetOutputPath && arguments[idx] == ""-packageTitle"")
                {
                    packageTitle = arguments[idx + 1];
                    break;
                }
            }

            if (string.IsNullOrEmpty(outputPath) || string.IsNullOrEmpty(packageTitle))
                return;

            TargetList targetList = new TargetList()
            {
                UnityAssetGUIDs = new List<UnityAssetGUID>()
            };

            foreach (var path in AssetDatabase.GetAllAssetPaths())
            {
                if (path.IndexOf($""Packages/{packageTitle}"") != 0 && path.IndexOf(""Assets"") != 0)
                    continue;
                if (Path.GetExtension(path).ToLower() != "".cs"" && Path.GetExtension(path).ToLower() != "".dll"")
                    continue;

                foreach (var obj in AssetDatabase.LoadAllAssetsAtPath(path))
                {
                    string assetGuid;
                    long assetLocalID;

                    if (obj == null)
                        continue;

                    if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(obj, out assetGuid, out assetLocalID))
                    {
                        if (obj is MonoScript)
                        {
                            var classType = (obj as MonoScript)?.GetClass();
                            if (classType != null)
                            {
                                targetList.UnityAssetGUIDs.Add(new UnityAssetGUID
                                {
                                    Path = path,
                                    Name = classType.FullName,
                                    GUID = assetGuid,
                                    FileID = assetLocalID
                                });
                            }
                        }
                    }
                }
            }
            
            string json = JsonUtility.ToJson(targetList, true);
            File.WriteAllText(outputPath, json);
        }
    }
}
";
    }
}
