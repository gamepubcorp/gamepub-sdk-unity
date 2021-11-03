#if UNITY_IOS
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;

namespace GamePub.PubSDK.Editor
{
    public class PlistUpdating
    {
        [PostProcessBuildAttribute(1)]
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS)
            {
                return;
            }
            
            string plistPath = pathToBuiltProject + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));

            PlistElementDict rootDict = plist.root;

            SetupURLScheme(rootDict);
            SetupQueriesSchemes(rootDict);
            SetupFacebookSetting(rootDict);
            SetupGoogleSetting(rootDict);

            File.WriteAllText(plistPath, plist.WriteToString());
                        
        }

        static void SetupURLScheme(PlistElementDict rootDict)
        {
            PlistElementArray array = GetOrCreateArray(rootDict, "CFBundleURLTypes");
            var lineURLScheme = array.AddDict();
            lineURLScheme.SetString("CFBundleTypeRole", "Editor");
            lineURLScheme.SetString("CFBundleURLName", "Client");
            var schemes = lineURLScheme.CreateArray("CFBundleURLSchemes");
            schemes.AddString(PubSDKSettings.GetOrCreateSettings().ReversedClientID);

            if (PubSDKSettings.GetOrCreateSettings().UseFacebookLogin)
                schemes.AddString("fb"+ PubSDKSettings.GetOrCreateSettings().FacebookAppID);
        }

        static void SetupQueriesSchemes(PlistElementDict rootDict)
        {
            if (PubSDKSettings.GetOrCreateSettings().UseFacebookLogin)
            {
                PlistElementArray array = GetOrCreateArray(rootDict, "LSApplicationQueriesSchemes");
                array.AddString("fbapi");
                array.AddString("fbauth2");
            }
        }

        static void SetupGoogleSetting(PlistElementDict rootDict)
        {
            rootDict.SetString("GoogleClientID", PubSDKSettings.GetOrCreateSettings().GoogleClientID);
            //DevServer
        }

        static void SetupFacebookSetting(PlistElementDict rootDict)
        {
            if (PubSDKSettings.GetOrCreateSettings().UseFacebookLogin)
                rootDict.SetString("FacebookAppID", PubSDKSettings.GetOrCreateSettings().FacebookAppID);
        }

        static PlistElementArray GetOrCreateArray(PlistElementDict dict, string key)
        {
            PlistElement array = dict[key];
            if (array != null)
            {
                return array.AsArray();
            }
            else
            {
                return dict.CreateArray(key);
            }
        }
    }
}
#endif