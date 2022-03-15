using UnityEngine;
using UnityEditor;
using System;
using System.Globalization;
using System.Collections.Generic;
using GamePub.PubSDK;
using GamePub.PubSDK.Editor;

public class BuildMenu : ScriptableObject
{
    static string[] SCENES = FindEnabledEditorScenes();

    private static string[] FindEnabledEditorScenes()
    {
        List<string> EditorScenes = new List<string>();

        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled) continue;
            EditorScenes.Add(scene.path);
        }

        return EditorScenes.ToArray();
    }

    static string GetBuildID()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        string buildid = null;
        for (int i = 0; i < args.Length - 1; i++)
        {
            if ("-buildid" == args[i])
            {
                buildid = args[i + 1];
                break;
            }
        }
        if (buildid == null)
        {            
            buildid = string.Format(@"{0:yyyy-MM-dd-HH-mm}", DateTime.Now);            
        }

        return buildid;
    }    

    static string GetBuildServer()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        string buildid = "server";
        for (int i = 0; i < args.Length - 1; i++)
        {
            if ("-server" == args[i])
            {
                buildid = args[i + 1];
                break;
            }
        }

        return buildid;
    }

    static string GetBuildStore()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        string buildid = "store";
        for (int i = 0; i < args.Length - 1; i++)
        {
            if ("-store" == args[i])
            {
                buildid = args[i + 1];
                break;
            }
        }

        return buildid;
    }    

    static string GetAndroidOutputFile()
    {
        string output = string.Format("{0}/{1}_{2}.apk", "AndroidBuild",
                                                     GetBuildStore(),
                                                     GetBuildServer());
        return output;
    }

    static string GetAndroidOutputFile(string name)
    {        
        string output = string.Format("{0}/{1}_{2}.apk", "AndroidBuild",
                                                     name,
                                                     GetBuildID());
        return output;
    }

    static string GetIOSOutputFile()
    {
        string output = string.Format("{0}/{1}_{2}", "iOSBuild",
                                                     "SDKUnityDemo",
                                                     GetBuildID());
        return output;
    }

    [UnityEditor.MenuItem("BuildMenu/TEST", false, 3001)]
    static void Buildmachine_TEST()
    {        
        Debug.Log("-----------------");
        Debug.Log(GetBuildServer());
        Debug.Log("-----------------");
        Debug.Log(GetBuildStore());
        Debug.Log("-----------------");        
    }

    [UnityEditor.MenuItem("BuildMenu/GoogleStore", false, 3001)]
    static void Buildmachine_GoogleStore()
    {
        string name = GetBuildStore() + GetBuildServer();
        PlayerSettings.productName = name;
        PrepareAndroidBuild("com.gamepub.testapp");

        PerformAndroidBuild(GetAndroidOutputFile(), "", false);
    }

    [UnityEditor.MenuItem("BuildMenu/GoogleStore Build And Run", false, 3002)]
    static void Buildmachine_GoogleStoreAuto()
    {
        PlayerSettings.productName = "GoogleDemo";
        PrepareAndroidBuild("com.gamepub.testapp");

        PerformAndroidBuild(GetAndroidOutputFile("GoogleDemo"), "", true);
    }

    [UnityEditor.MenuItem("BuildMenu/OneStore", false, 3003)]
    static void Buildmachine_OneStore()
    {
        string name = GetBuildStore() + GetBuildServer();
        PlayerSettings.productName = name;
        PrepareAndroidBuild("com.gamepub.onestore.sample");

        PerformAndroidBuild(GetAndroidOutputFile(), "", false);
    }

    [UnityEditor.MenuItem("BuildMenu/OneStore Build And Run", false, 3004)]
    static void Buildmachine_OneStoreAuto()
    {
        PlayerSettings.productName = "OneStoreDemo";
        PrepareAndroidBuild("com.gamepub.onestore.sample");

        PerformAndroidBuild(GetAndroidOutputFile("OneStoreDemo"), "", true);
    }

    [UnityEditor.MenuItem("BuildMenu/iOS", false, 3005)]
    static void Buildmachine_iOS()
    {
        PlayerSettings.productName = "SDKUnityDemo";
        PrepareiOSBuild("com.gamepub.ios.testapp");

        PerformiOSBuild(GetIOSOutputFile(), "", false);
    }

    [UnityEditor.MenuItem("BuildMenu/iOS Dev", false, 3006)]
    static void Buildmachine_iOS_Dev()
    {
        //Debug.Log("fb"+PubSDKSettings.GetOrCreateSettings().FacebookAppID);
        PlayerSettings.productName = "SDKUnityDemo";
        PrepareiOSBuild("com.gamepub.ios.testapp");

        PerformiOSBuild(GetIOSOutputFile(), "", false);
    }
    
    static void PrepareAndroidBuild(string bundleID)
    {
        PlayerSettings.Android.keystoreName = "gamepub.keystore";
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, bundleID);
        PlayerSettings.Android.keyaliasName = "gamepub";
        PlayerSettings.keystorePass = "rpdlavjq12";
        PlayerSettings.keyaliasPass = "rpdlavjq12";

        //PlayerSettings.bundleVersion = "";
        //PlayerSettings.Android.bundleVersionCode = 20;
    }

    static void PrepareiOSBuild(string bundleID)
    {                
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, bundleID);
        //PlayerSettings.bundleVersion = "";
        //PlayerSettings.iOS.buildNumber = "";
        PlayerSettings.iOS.appleEnableAutomaticSigning = false;
        PlayerSettings.iOS.appleDeveloperTeamID = "PRPC4C837N";
        PlayerSettings.iOS.iOSManualProvisioningProfileID = "1b218b87-4ae6-4b7e-b746-4fb6f78f4ecc";
        PlayerSettings.iOS.iOSManualProvisioningProfileType = ProvisioningProfileType.Development;
    }

    static string PerformAndroidBuild(string output, string define, bool isDev)
    {
        Debug.Log("PerformAndroidBuild()");
        Debug.Log(output);        

        //PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, define);
        
        BuildPipeline.BuildPlayer(SCENES, output, BuildTarget.Android, isDev ? BuildOptions.AutoRunPlayer : BuildOptions.None);
        return output;
    }

    static void PerformiOSBuild(string output, string define, bool isDev)
    {        
        BuildPlayerOptions opt = new BuildPlayerOptions();
        opt.scenes = FindEnabledEditorScenes();
        opt.locationPathName = output;
        opt.target = BuildTarget.iOS;
        opt.options = BuildOptions.None;        

        //PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, define);               

        BuildPipeline.BuildPlayer(opt);
    }
}
