using PackageManager.Utility;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PackageManager
{
    public partial class PackageController
    {
        void RuntimeCopier(string[] fileNames, bool force = true)
        {
            string projectPath = Path.Combine(packageResourceContainer.PackageProjectDirectory, BUILDED_ASSEMBLIES_DIR);
            string publishPath = Path.Combine(packageResourceContainer.PackageDirectory, RUNTIME_PUBLISH_DIR);
            foreach (var item in fileNames)
            {
                string target = Path.Combine(projectPath, item);
                string publish = Path.Combine(publishPath, item);

                CopyUtility.Copy(target, publish, force, SendLogToPackageTool);
            }
        }

        void EditorCopier(string[] fileNames, bool force = true)
        {
            string projectPath = Path.Combine(packageResourceContainer.PackageProjectDirectory, SCRIPT_ASSEMBLIES_DIR);
            string publishPath = Path.Combine(packageResourceContainer.PackageDirectory, EDITOR_PUBLISH_DIR);
            foreach (var item in fileNames)
            {
                string target = Path.Combine(projectPath, item);
                string publish = Path.Combine(publishPath, item);

                CopyUtility.Copy(target, publish, force, SendLogToPackageTool);
            }
        }

        void SampleCopier(string[] fileNames, bool force = true)
        {
            foreach (var item in fileNames)
            {
                string[] components = Regex.Split(item, TARGET_PARSER);

                if (components.Length != 2) throw new FormatException($"The file ({item}) is not formatted properly");

                string target = Path.Combine(packageResourceContainer.SimulationProjectDirectory, components[0]);
                string publish = Path.Combine(packageResourceContainer.PackageDirectory, components[1]);

                CopyUtility.Copy(target, publish, force, SendLogToPackageTool);
            }
        }

        void PackageCopier(string[] fileNames, bool force = true)
        {
            foreach (var item in fileNames)
            {
                string[] components = Regex.Split(item, TARGET_PARSER);

                if (components.Length != 2) throw new FormatException($"The file ({item}) is not formatted properly");

                string target = Path.Combine(packageResourceContainer.PackageProjectDirectory, PACKAGES_DIR, this.PackageResourceContainer.PackageTitle, components[0]);
                string publish = Path.Combine(packageResourceContainer.PackageDirectory, components[1]);

                CopyUtility.Copy(target, publish, force, SendLogToPackageTool);
            }
        }
    }
}
