#if UNITY_IOS
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;
using System.Diagnostics;
using System;

namespace GamePub.PubSDK.Editor
{
    public class CocoaPodsInstalling
    {
        [PostProcessBuildAttribute(3)]
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS)
            {
                return;
            }

            if (!PubSDKSettings.GetOrCreateSettings().UseCocoaPods)
            {
                return;
            }

            // Add usual ruby runtime manager path to process.
            ShellCommand.AddPossibleRubySearchPaths();

            var podExisting = ShellCommand.Run("which", "pod");
            if (string.IsNullOrEmpty(podExisting))
            {
                var text = @"Gamepub SDK integrating failed. Building Gamepub SDK for iOS target requires CocoaPods, but it is not installed. Please run ""sudo gem install cocoapods"" and try again.";
                UnityEngine.Debug.LogError(text);
                var clicked = EditorUtility.DisplayDialog("CocoaPods not found", text, "More", "Cancel");
                if (clicked)
                {
                    Application.OpenURL("https://cocoapods.org");
                }
            }

            var currentDirectory = Directory.GetCurrentDirectory();

            var podFileLocation = Path.Combine(pathToBuiltProject, "Podfile");
            if (File.Exists(podFileLocation))
            {
                var text = @"A Podfile is already existing under Xcode project root. Skipping copying of Gamepub SDK's Podfile. Make sure you have setup Podfile correctly if you are using another package also requires CocoaPods.";
                UnityEngine.Debug.Log(text);
            }
            else
            {
                var bundledPodfile = "Assets/GamePubSDK/Editor/CocoaPods/Podfile_2019_4";

                var podfilePath = Path.Combine(currentDirectory, bundledPodfile);
                UnityEngine.Debug.Log(podfilePath);
                File.Copy(podfilePath, podFileLocation);
            }

            Directory.SetCurrentDirectory(pathToBuiltProject);
            var log = ShellCommand.Run("pod", "install");
            UnityEngine.Debug.Log(log);
            Directory.SetCurrentDirectory(currentDirectory);

            ConfigureXcodeForCocoaPods(pathToBuiltProject);
        }

        static void ConfigureXcodeForCocoaPods(string projectRoot)
        {
            var path = PBXProject.GetPBXProjectPath(projectRoot);
            var project = new PBXProject();
            project.ReadFromFile(path);            

            var target = project.GetUnityFrameworkTargetGuid();

            project.SetBuildProperty(target, "GCC_PREPROCESSOR_DEFINITIONS", "$(inherited) PubSDK_COCOAPODS=1");
            
            project.WriteToFile(path);
        }
    }
}
#endif