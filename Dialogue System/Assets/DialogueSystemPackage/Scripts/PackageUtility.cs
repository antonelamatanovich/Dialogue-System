#if UNITY_EDITOR
using UnityEngine;
using System.IO;
using UnityEditor;
using System;
using System.Collections.Generic;
#if NEWTONSOFT_JSON_PRESENT
using Newtonsoft.Json;
#endif
using System.Linq;
using UnityEditor.Build;

// Add Newtonsoft package by name: com.unity.nuget.newtonsoft-json

namespace Toph.UnityUtilities.Package
{
    [Serializable]
    public class PackageUtility : ScriptableObject // ToDo: Add extended editor UI to add more functionality (see ToDos below)
                                                   // ToDo: Add descriptions and how to use explanation
    {
#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        public string domainName = "com";
#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        public string companyName = "company";
#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        [SerializeField] private bool useSettingsCompanyName = true;
#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        public string packageName = "package-name";
#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        [SerializeField] private bool useSettingsProductName = true;
        public new string name => $"{domainName.ToLower()}.{companyName.ToLower()}.{packageName.ToLower()}";
        public string version = "0.0.0";

#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        [SerializeField] private bool useSettingsVersion = true;
        public string displayName = string.Empty;
#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        [SerializeField] private bool _useSettingsProductName = true;
        public string description = string.Empty;
        public string unity = "2021.3";
#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        [SerializeField] private bool useCurrentUnityVersion = true;
        public string unityRelease = ".0f1";
#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        [SerializeField] private bool useCurrentUnityRelease = true;
        public Dictionary<string, string> dependencies
        {
            get
            {
                Dictionary<string, string> dictionary = new();
                foreach (var dependency in _dependencies)
                    dictionary.Add(dependency.name, dependency.version);
                return dictionary;
            }
        }
#if NEWTONSOFT_JSON_PRESENT
        [JsonIgnore]
#endif
        public List<Dependency> _dependencies = new();
        public string documentationUrl = "https://";
        public string changelogUrl = "https://";
        public string licensesUrl = string.Empty;
        public string[] keywords = new string[] { "Unity Package" };
        public Sample[] samples = new Sample[] { new Sample("Sample", "This is a sample.", "Sample") };
        public Author author = new Author("Author", "author@mail.com", "https://");

        [Serializable]
        public class Dependency
        {
            public string name = "package.name";
            public string version = "1.0.0";
        }

        [Serializable]
        public class Sample
        {
            public string displayName = "Sample";
            public string description = string.Empty;
            public string path = $"Samples~/Sample";

#if NEWTONSOFT_JSON_PRESENT
            [JsonIgnore]
#endif
            public bool Tilde { get; set; } = true; // ToDo: not usable with UI yet

            private string _folder = "Samples";

#if NEWTONSOFT_JSON_PRESENT
            [JsonIgnore]
#endif
            public string Folder
            {
                get => _folder;
                set
                {
                    _folder = value;
                    UpdatePath();
                }
            }
            private string _folderRelatedPath = "Sample";

#if NEWTONSOFT_JSON_PRESENT
            [JsonIgnore]
#endif
            public string FolderRelatedPath
            {
                get => _folderRelatedPath;
                set
                {
                    _folderRelatedPath = value;
                    UpdatePath();
                }
            }

            public Sample(string displayName, string description, string folderRelatedPath, string folder = "Samples")
            {
                this.displayName = displayName;
                this.description = description;
                Folder = folder;
                FolderRelatedPath = folderRelatedPath;
            }

            public void UpdatePath() => path = $"{Folder}{(Tilde ? "~" : string.Empty)}/{FolderRelatedPath}";
        }

        [Serializable]
        public class Author
        {
            public string name = string.Empty;
#if NEWTONSOFT_JSON_PRESENT
            [JsonIgnore]
#endif
            [SerializeField] private bool useSettingsCompanyName = true;
            public string email = string.Empty;
            public string url = string.Empty;

            public bool UseSettingsCompanyNameAsName => useSettingsCompanyName;

            public Author(string name, string email, string url = "")
            {
                this.name = name;
                this.email = email;
                this.url = url;
            }
        }

        private void OnValidate()
        {
            UpdateFields();
        }

        private void UpdateFields()
        {
            if (useSettingsCompanyName) companyName = Application.companyName.ToLower();
            if (useSettingsProductName) packageName = Application.productName.ToLower();
            if (useSettingsVersion) version = Application.version.ToLower();
            if (_useSettingsProductName) displayName = Application.productName;
            string unityVersion = Application.unityVersion;
            int splitIndex = unityVersion.LastIndexOf('.');
            if (useCurrentUnityVersion) unity = unityVersion.Substring(0, splitIndex);
            if (useCurrentUnityRelease) unityRelease = unityVersion.Substring(splitIndex + 1, unityVersion.Length - splitIndex - 1);
            if (author.UseSettingsCompanyNameAsName) author.name = Application.companyName;
        }

        public static PackageUtility FromJson(string json)
        {
#if NEWTONSOFT_JSON_PRESENT
            return JsonConvert.DeserializeObject<PackageUtility>(json);
#else
            return JsonUtility.FromJson<PackageUtility>(json);
#endif
        }

        public static string ToJson(PackageUtility packageUtility)
        {
            packageUtility.UpdateFields();

#if NEWTONSOFT_JSON_PRESENT
            return JsonConvert.SerializeObject(packageUtility, Formatting.Indented);
#else
            return JsonUtility.ToJson(packageUtility, true);
#endif
        }
    }

    [InitializeOnLoad]
    public class PackageUpdater : AssetModificationProcessor
    {
        private const string PACKAGE_FILE_NAME = "package.json";

        private static PackageUtility _packageJson = null;

        static PackageUpdater()
        {
            if(!CheckForNewtonsoftJsonPackage())
                Debug.LogWarning("To make sure the PackageUtility works correctly, add the Newtonsoft package by name using the package manager: com.unity.nuget.newtonsoft-json");
        }

        private static bool CheckForNewtonsoftJsonPackage()
        {
            bool isNewtonsoftJsonPresent = AppDomain.CurrentDomain.GetAssemblies().Any(assembly => assembly.FullName.StartsWith("Newtonsoft.Json"));
            string defineSymbol = "NEWTONSOFT_JSON_PRESENT";

            var defineSymbolsString = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.Standalone);
            var defineSymbols = defineSymbolsString.Split(';').ToList();

            if (isNewtonsoftJsonPresent && !defineSymbols.Contains(defineSymbol))
            {
                defineSymbols.Add(defineSymbol);
                PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Standalone, string.Join(";", defineSymbols));
                Debug.Log("Newtonsoft.Json found. Added NEWTONSOFT_JSON_PRESENT define symbol.");
            }
            else if (!isNewtonsoftJsonPresent && defineSymbols.Contains(defineSymbol))
            {
                defineSymbols.Remove(defineSymbol);
                PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.Standalone, string.Join(";", defineSymbols));
                Debug.Log("Newtonsoft.Json not found. Removed NEWTONSOFT_JSON_PRESENT define symbol.");
            }

            return isNewtonsoftJsonPresent;
        }

        static string[] OnWillSaveAssets(string[] paths)
        {
            CreateMissingPackageFolders();
            CreateMissingPackageFiles();
            UpdatePackageJson();
            return paths;
        }

        private static void CreateMissingPackageFolders()
        {
            string assetFolderPath = Application.dataPath;
            string packageFolder = GetCurrentAssetRelatedFolder();

            // Runtime folder
            string runtimeFolderPath = Path.Combine(assetFolderPath, packageFolder, "Runtime");
            if (Directory.Exists(runtimeFolderPath) is false)
                Directory.CreateDirectory(runtimeFolderPath);
            // Scripts folder
            string scriptsFolderPath = Path.Combine(assetFolderPath, packageFolder, "Runtime/Scripts");
            if (Directory.Exists(scriptsFolderPath) is false)
                Directory.CreateDirectory(scriptsFolderPath);

            // Samples folder // ToDo: There might be bugs regarding the tilde and folder structure
            //if (_packageJson is not null)
            //    if (_packageJson.samples is not null && _packageJson.samples.Length > 0)
            //    {
            //        foreach (var sample in _packageJson.samples)
            //        {
            //            string samplesFolderPath = Path.Combine(assetFolderPath, packageFolder, sample.Folder);
            //            if (Directory.Exists(samplesFolderPath) is false)
            //                Directory.CreateDirectory(samplesFolderPath);
            //        }
            //    }
        }

        private static void CreateMissingPackageFiles()
        {
            string packageFolder = GetCurrentAssetRelatedFolder();
            string path = Path.Combine(Application.dataPath, packageFolder);

            string readmePath = Path.Combine(path, "README.md");
            if (File.Exists(readmePath) is false)
                File.Create(readmePath).Dispose();

            string changelogPath = Path.Combine(path, "CHANGELOG.md");
            if (File.Exists(changelogPath) is false)
                File.Create(changelogPath).Dispose();

            string licensePath = Path.Combine(path, "LICENSE.md");
            if (File.Exists(licensePath) is false)
                File.Create(licensePath).Dispose();

            // ToDo: Does not work yet (add file data using json and make sure its bug-free)
            //string scriptAsmdefPath = Path.Combine(path, "Runtime", 
            //    "Scripts", $"{Application.companyName.Replace(' ', '.')}.{Application.productName.RemoveConsecutiveCharacters(' ')}.asmdef");
            //if (File.Exists(scriptAsmdefPath) is false)
            //{
            //    File.Create(scriptAsmdefPath);
            //}
        }

        private static async void UpdatePackageJson()
        {
            string packageFolder = GetCurrentAssetRelatedFolder();
            string packageFolderPath = Path.Combine(Application.dataPath, packageFolder);
            string packageJsonPath = Path.Combine(packageFolderPath, PACKAGE_FILE_NAME);

            if (_packageJson == null)
            {
                string[] packageJsonAssets = AssetDatabase.FindAssets($"t:{nameof(PackageUtility)}");
                if (packageJsonAssets.Length > 0)
                {
                    _packageJson = (PackageUtility)AssetDatabase.LoadAssetAtPath(
                        AssetDatabase.GUIDToAssetPath(packageJsonAssets[0]), typeof(PackageUtility));
                }
                else
                {
                    _packageJson = (PackageUtility)ScriptableObject.CreateInstance(typeof(PackageUtility));
                    AssetDatabase.CreateAsset(_packageJson, $"Assets/{packageFolder}/PackageSettings.asset");
                    AssetDatabase.SaveAssets();

                    EditorUtility.FocusProjectWindow();

                    Selection.activeObject = _packageJson;
                }
            }

            if (_packageJson.version == Application.version) return;

            if (File.Exists(packageJsonPath))
                File.Delete(packageJsonPath);

            await File.Create(packageJsonPath).DisposeAsync();

            await File.WriteAllTextAsync(packageJsonPath, PackageUtility.ToJson(_packageJson));

            Debug.Log($"UnityPackage: package.json updated with version '{_packageJson.version}'");
        }

        private static string GetCurrentAssetRelatedFolder()
        {
            string[] assets = AssetDatabase.FindAssets($"{nameof(PackageUtility)} t:Script");

            string folderPath = string.Empty;
            if (assets.Length > 0)
            {
                folderPath = AssetDatabase.GUIDToAssetPath(assets[0]);
                var splits = folderPath.Split('/');
                if (splits.Length > 1) { folderPath = splits[1]; }
            }
            return folderPath;
        }
    }
}
#endif