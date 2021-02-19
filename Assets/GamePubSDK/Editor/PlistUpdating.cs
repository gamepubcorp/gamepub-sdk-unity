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
            
            //-------
            string googlePlistPath = Application.dataPath + "/Plugins/iOS/GoogleService-Info.plist";
            File.Copy(googlePlistPath, pathToBuiltProject + "/GoogleService-Info.plist");

            //-------
            PlistDocument googlePlist = new PlistDocument();
            googlePlist.ReadFromString(File.ReadAllText(googlePlistPath));
            PlistElementDict googleDict = googlePlist.root;

            //-------
            string plistPath = pathToBuiltProject + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));

            PlistElementDict rootDict = plist.root;
            //-------

            SetupURLScheme(rootDict, googleDict);
            SetupQueriesSchemes(rootDict);

            File.WriteAllText(plistPath, plist.WriteToString());
                        
        }

        static void SetupURLScheme(PlistElementDict rootDict, PlistElementDict googleDict)
        {
            PlistElementArray array = GetOrCreateArray(rootDict, "CFBundleURLTypes");
            var lineURLScheme = array.AddDict();
            lineURLScheme.SetString("CFBundleTypeRole", "Editor");
            lineURLScheme.SetString("CFBundleURLName", "Client");
            var schemes = lineURLScheme.CreateArray("CFBundleURLSchemes");
            schemes.AddString(googleDict["REVERSED_CLIENT_ID"].AsString());
        }

        static void SetupQueriesSchemes(PlistElementDict rootDict)
        {
            PlistElementArray array = GetOrCreateArray(rootDict, "LSApplicationQueriesSchemes");
            array.AddString("fbapi");
            array.AddString("fbauth2");
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