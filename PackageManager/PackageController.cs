using PackageManager.Models;
using System;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace PackageManager
{
    public partial class PackageController
    {
        static readonly string[] GUIDSyncExtensions =
        {
            "*.unity",
            "*.asset",
            "*.prefab",
            "*.mat",
            "*.anim"
        };

        const int SUCCESS_CODE = 0;
        const int FAIL_CODE = 1;

        const string PACKAGES_DIR = "Packages";
        const string SCRIPT_ASSEMBLIES_DIR = "Library/ScriptAssemblies";
        const string BUILDED_ASSEMBLIES_DIR = "Build/Build_Data/Managed";

        const string RUNTIME_PUBLISH_DIR = "Runtime/Plugins";
        const string EDITOR_PUBLISH_DIR = "Editor/Plugins";

        const string TARGET_PARSER = @"\s*>>>\s*";

        public event EventHandler<string> LogEvent;
        public event EventHandler<string> LogErrorEvent;

        PackageResourceContainer packageResourceContainer;

        UnityAssetGUID[] publishPackageAssetGUIDs;
        UnityAssetGUID[] publishProjectAssetGUIDs;

        public PackageResourceContainer PackageResourceContainer => this.packageResourceContainer;

        public PackageController()
        {
            this.packageResourceContainer = new PackageResourceContainer()
            {
                UnityEditorDirectory = "Set your unity editor directory",
                PackageProjectDirectory = "Set your package project directory",
                PackageDirectory = "Set your package directory",
                SimulationProjectDirectory = "Set your simulation project directory",
                PackageTitle = "Set your package title",
                BuildSourceMethod = "uprt.editor.UPRTPackageManager.BuildWin64",
                SyncGUIDMethod = "uprt.editor.UPRTPackageManager.GetGUIDs",
                PackageContent = new List<Content>(),
                GUIDSyncTargets = new GUIDSyncTargets()
                {
                    Start = "projectGUIDs.json",
                    Destination = "packageGUIDs.json",
                    TargetNames = new List<string>()
                }
            };
        }

        public PackageController(string configPath)
        {
            if (string.IsNullOrEmpty(configPath))
            {
                throw new ArgumentNullException("configPath", "Fail to generate PackageController");
            }

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"Can't not found PackageController({configPath})");
            }

            string configJson = File.ReadAllText(configPath);
            this.packageResourceContainer = JsonConvert.DeserializeObject<PackageResourceContainer>(configJson);
        }

        public async Task StartPackageAsync(CancellationToken token)
        {
            if (await BuildUnitySource(token) == FAIL_CODE) return;
            if (token.IsCancellationRequested) return;

            if (await GetSyncGUIDs(token) == FAIL_CODE) return;
            if (token.IsCancellationRequested) return;

            if (await CopyPackageItems(token) == FAIL_CODE) return;
            if (token.IsCancellationRequested) return;

            if (await GetSimulateSyncGUIDs(token) == FAIL_CODE) return;
            if (token.IsCancellationRequested) return;

            if (await SyncGUID(token) == FAIL_CODE) return;
            if (token.IsCancellationRequested) return;

            if (await CopySampleItems(token) == FAIL_CODE) return;
        }

        public void SaveResourceContainer(string path)
        {
            string json = JsonConvert.SerializeObject(this.packageResourceContainer, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        // 개같은 켄셀레이션토큰 잡아볼 것
        public async Task<int> BuildUnitySource(CancellationToken token)
        {
            SendLogToPackageTool("Build project source : Start");

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = this.packageResourceContainer.UnityEditorDirectory,
                    Arguments = $"-quit " +
                        $"-batchmode " +
                        $"-logFile - " +
                        $"-projectPath {this.packageResourceContainer.PackageProjectDirectory} " +
                        $"-executeMethod {this.packageResourceContainer.BuildSourceMethod}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                },
            };
            process.OutputDataReceived += Process_OutputDataReceived;
            process.EnableRaisingEvents = true;

            token.Register(() =>
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    SendLogErrorToPackageTool($"Build project source : This job was canceled by user");

                    this.LogEvent = null;
                    this.LogErrorEvent = null;
                }
            });

            try
            {
                process.Start();
                process.BeginOutputReadLine();
                await Task.Run(() => process.WaitForExit());
                SendLogToPackageTool($"Build project source : {GetJobResult(process.ExitCode)}");
                return process.ExitCode;
            }
            catch (Exception e)
            {
                SendLogErrorToPackageTool($"Build project source : {GetJobResult(FAIL_CODE)} ({e.Message})");
                return FAIL_CODE;
            }
        }

        public async Task<int> GetSyncGUIDs(CancellationToken token)
        {
            SendLogToPackageTool("Collect package project GUIDs : Start");

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = this.packageResourceContainer.UnityEditorDirectory,
                    Arguments = $"-quit " +
                        $"-batchmode " +
                        $"-logFile - " +
                        $"-projectPath {this.packageResourceContainer.PackageProjectDirectory} " +
                        $"-executeMethod {this.packageResourceContainer.SyncGUIDMethod} " +
                        $"-output {Path.Combine(Directory.GetCurrentDirectory(), this.packageResourceContainer.GUIDSyncTargets.Start)} " +
                        $"-packageTitle {this.packageResourceContainer.PackageTitle}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };
            process.OutputDataReceived += Process_OutputDataReceived;
            process.EnableRaisingEvents = true;

            token.Register(() =>
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    SendLogErrorToPackageTool($"Build project source : This job was canceled by user");

                    this.LogEvent = null;
                    this.LogErrorEvent = null;
                }
            });

            try
            {
                process.Start();
                process.BeginOutputReadLine();
                await Task.Run(() => process.WaitForExit());
                SendLogToPackageTool($"Collect package project GUIDs : {GetJobResult(process.ExitCode)}");
                return process.ExitCode;
            }
            catch (Exception e)
            {
                SendLogErrorToPackageTool($"Collect package project GUIDs : {GetJobResult(FAIL_CODE)} ({e.Message})");
                return FAIL_CODE;
            }
        }

        public async Task<int> CopyPackageItems(CancellationToken token)
        {
            SendLogToPackageTool("Copy unity project source : Start");
            
            try
            {
                foreach (var item in this.packageResourceContainer.PackageContent)
                {
                    
                    switch (item.ContentType)
                    {
                        case Enums.ContentType.Runtime:
                            await Task.Run(() => RuntimeCopier(item.Targets, item.CopyForce));
                            break;
                        case Enums.ContentType.Editor:
                            await Task.Run(() => EditorCopier(item.Targets, item.CopyForce));
                            break;
                        case Enums.ContentType.Package:
                            await Task.Run(() => PackageCopier(item.Targets, item.CopyForce));
                            break;
                        default:
                            break;
                    }
                    
                    if (token.IsCancellationRequested)
                    {
                        SendLogErrorToPackageTool($"Copy unity project source : This job was canceled by user");
                        return FAIL_CODE;
                    }
                }

                SendLogToPackageTool($"Copy unity project source : {GetJobResult(SUCCESS_CODE)}");
                return SUCCESS_CODE;
            }
            catch (Exception e)
            {
                SendLogErrorToPackageTool($"Copy unity project source : {GetJobResult(FAIL_CODE)} ({e.Message})");
                return FAIL_CODE;
            }
        }

        public async Task<int> CopySampleItems(CancellationToken token)
        {
            SendLogToPackageTool("Copy sample source : Start");

            try
            {
                foreach (var item in this.packageResourceContainer.PackageContent)
                {
                    switch (item.ContentType)
                    {
                        case Enums.ContentType.Sample:
                            await Task.Run(() => SampleCopier(item.Targets, item.CopyForce));
                            break;
                        default:
                            break;
                    }

                    if (token.IsCancellationRequested)
                    {
                        SendLogErrorToPackageTool($"Copy sample source : This job was canceled by user");
                        return FAIL_CODE;
                    }
                }

                SendLogToPackageTool($"Copy sample source : {GetJobResult(SUCCESS_CODE)}");
                return SUCCESS_CODE;
            }
            catch (Exception e)
            {
                SendLogErrorToPackageTool($"Copy sample source : {GetJobResult(FAIL_CODE)} ({e.Message})");
                return FAIL_CODE;
            }
        }

        public async Task<int> GetSimulateSyncGUIDs(CancellationToken token)
        {
            SendLogToPackageTool("Unity simulation project synchronize GUIDs : Start");
            
            Process process = new Process(){
                StartInfo = new ProcessStartInfo()
                {
                    FileName = this.packageResourceContainer.UnityEditorDirectory,
                    Arguments = $"-quit " +
                        $"-batchmode " +
                        $"-logFile - " +
                        $"-projectPath {this.packageResourceContainer.SimulationProjectDirectory} " +
                        $"-executeMethod {this.packageResourceContainer.SyncGUIDMethod} " +
                        $"-output {Path.Combine(Directory.GetCurrentDirectory(), this.packageResourceContainer.GUIDSyncTargets.Destination)} " +
                        $"-packageTitle {this.packageResourceContainer.PackageTitle}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };
            process.OutputDataReceived += Process_OutputDataReceived;

            token.Register(() =>
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    SendLogErrorToPackageTool($"Unity simulation project synchronize GUIDs : This job was canceled by user");
                    
                    this.LogEvent = null;
                    this.LogErrorEvent = null;
                }
            });

            try
            {
                process.Start();
                process.BeginOutputReadLine();
                await Task.Run(() => process.WaitForExit());
                SendLogToPackageTool($"Unity simulation project synchronize GUIDs : {GetJobResult(process.ExitCode)}");
                return process.ExitCode;
            }
            catch (Exception e)
            {
                SendLogErrorToPackageTool($"Unity simulation project synchronize GUIDs : {GetJobResult(FAIL_CODE)} ({e.Message})");
                return FAIL_CODE;
            }
        }

        public async Task<int> SyncGUID(CancellationToken token)
        {
            SendLogToPackageTool("Synchronize GUIDs : Start");
            int resultCode;
            try
            {
                resultCode = await Task<int>.Run(() => resultCode = ReplaceGUID(token), token);

                if (token.IsCancellationRequested)
                {
                    SendLogErrorToPackageTool($"Synchronize GUIDs : This job was canceled by user");
                    return FAIL_CODE;
                }
                SendLogToPackageTool($"Synchronize GUIDs : {GetJobResult(resultCode)}");
                return resultCode;
            }
            catch(Exception e)
            {
                resultCode = FAIL_CODE;
                SendLogErrorToPackageTool($"Synchronize GUIDs : {GetJobResult(FAIL_CODE)} ({e.Message})");
                return FAIL_CODE;
            }
        }

        private int ReplaceGUID(CancellationToken token)
        {
            try
            {
                // Start GUIDs
                using (StreamReader reader = new StreamReader(this.packageResourceContainer.GUIDSyncTargets.Start))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    TargetGUIDs guids = (TargetGUIDs)serializer.Deserialize(reader, typeof(TargetGUIDs));
                    publishPackageAssetGUIDs = guids.UnityAssetGUIDs.Where(Guid => this.packageResourceContainer.GUIDSyncTargets.TargetNames.Contains(Guid.Name)).
                        ToArray();
                }

                // Destination GUIDs
                using (StreamReader reader = new StreamReader(this.packageResourceContainer.GUIDSyncTargets.Destination))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    TargetGUIDs guids = (TargetGUIDs)serializer.Deserialize(reader, typeof(TargetGUIDs));
                    publishProjectAssetGUIDs = guids.UnityAssetGUIDs.Where(Guid => this.packageResourceContainer.GUIDSyncTargets.TargetNames.Contains(Guid.Name)).
                        ToArray();
                }

                List<string> fileList = new List<string>();

                // Package GUID
                foreach (var extension in GUIDSyncExtensions)
                    fileList.AddRange(Directory.GetFiles(this.packageResourceContainer.PackageDirectory, extension, SearchOption.AllDirectories));

                // Publish Test Project GUID
                foreach (var extension in GUIDSyncExtensions)
                    fileList.AddRange(Directory.GetFiles(this.packageResourceContainer.SimulationProjectDirectory, extension, SearchOption.AllDirectories));

                var syncItem = from packageGUIDs in this.publishPackageAssetGUIDs
                               join testProjectGUIDs in this.publishProjectAssetGUIDs on packageGUIDs.Name equals testProjectGUIDs.Name
                               select new
                               {
                                   Name = packageGUIDs.Name,
                                   PackageGUID = packageGUIDs.GUID,
                                   ProjectGUID = testProjectGUIDs.GUID,
                                   PackageFileID = packageGUIDs.FileID,
                                   ProjectFileID = testProjectGUIDs.FileID
                               };

                foreach (var fileItem in fileList)
                {
                    bool overwrite = false;
                    string[] fileLines = File.ReadAllLines(fileItem);

                    for (int i = 0; i < fileLines.Length; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return FAIL_CODE;
                        }

                        bool replaced = false;
                        string packageFileID = string.Empty;
                        string publishTestFileID = string.Empty;

                        // GUID Replace 작업
                        if (fileLines[i].Contains("guid: "))
                        {
                            int index = fileLines[i].IndexOf("guid: ") + 6;
                            string oldGUID = fileLines[i].Substring(index, 32);

                            var guidInformation = syncItem.FirstOrDefault(guid => guid.PackageGUID == oldGUID);

                            if (guidInformation != null)
                            {
                                fileLines[i] = fileLines[i].Replace(oldGUID, guidInformation.ProjectGUID);

                                packageFileID = guidInformation.PackageFileID.ToString();
                                publishTestFileID = guidInformation.ProjectFileID.ToString();

                                replaced = true;
                                overwrite = true;

                                SendLogToPackageTool($"Replace GUID : Update {fileItem}'s GUID ({oldGUID} to {guidInformation.ProjectGUID}).");
                            }
                        }

                        // FileID Replace 작업
                        if (replaced && fileLines[i].Contains("fileID: "))
                        {
                            int index = fileLines[i].IndexOf("fileID: ") + 8;
                            int indexPivot = fileLines[i].IndexOf(",", index);
                            string oldFileID = fileLines[i].Substring(index, indexPivot - index);

                            if (packageFileID == oldFileID)
                            {
                                fileLines[i] = fileLines[i].Replace(oldFileID, publishTestFileID);
                                overwrite = true;

                                SendLogToPackageTool($"Replace GUID : Update {fileItem}'s GUID ({oldFileID} to {publishTestFileID}).");
                            }
                        }
                    }

                    if (overwrite)
                    {
                        File.WriteAllLines(fileItem, fileLines);
                    }
                }
                return SUCCESS_CODE;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string GetJobResult(int resultCode, string success = "", string fail = "")
        {
            string successMsg = "Success";
            string failMsg = "Fail";
            if (!string.IsNullOrEmpty(success)) successMsg = success;
            if (!string.IsNullOrEmpty(fail)) failMsg = fail;
            return (resultCode == SUCCESS_CODE) ? successMsg : failMsg;
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                LogEvent?.Invoke(this, e.Data);
            }
        }

        private void SendLogToPackageTool(string data)
        {
            LogEvent?.Invoke(this, data);
        }

        private void SendLogErrorToPackageTool(string data)
        {
            LogErrorEvent?.Invoke(this, data);
        }
    }
}
