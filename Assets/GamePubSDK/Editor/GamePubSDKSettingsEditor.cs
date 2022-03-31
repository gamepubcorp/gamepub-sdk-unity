using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace GamePub.PubSDK.Editor
{
    [CustomEditor(typeof(GamePubSDKSettings))]
    public class GamePubSDKSettingsEditor : UnityEditor.Editor
    {
        GUIContent sdkAppIdLabel = new GUIContent("SDK AppID [?]:", "Enter the GamepubSDK Project AppID");
        GUIContent devBuildLabel = new GUIContent("Dev Build [?]:", "Run app with extended debugging");

        const string UnityAssetFolder = "Assets";

        public static GamePubSDKSettings GetOrCreateSettingsAsset()
        {
            string fullPath = Path.Combine(Path.Combine(UnityAssetFolder, GamePubSDKSettings.settingsPath),
                                           GamePubSDKSettings.settingsAssetName + GamePubSDKSettings.settingsAssetExtension);

            GamePubSDKSettings instance = AssetDatabase.LoadAssetAtPath(fullPath, typeof(GamePubSDKSettings)) as GamePubSDKSettings;

            if (instance == null)
            {                
                if (!Directory.Exists(Path.Combine(UnityAssetFolder, GamePubSDKSettings.settingsPath)))
                {
                    AssetDatabase.CreateFolder(Path.Combine(UnityAssetFolder, "GamePubSDK"), "Resources");
                }

                instance = CreateInstance<GamePubSDKSettings>();
                AssetDatabase.CreateAsset(instance, fullPath);
                AssetDatabase.SaveAssets();
            }
            return instance;
        }

        [MenuItem("GamePubSDK/Edit Settings")]
        public static void Edit()
        {
            Selection.activeObject = GetOrCreateSettingsAsset();

            ShowInspector();
        }

        public override void OnInspectorGUI()
        {
            GamePubSDKSettings settings = (GamePubSDKSettings)target;
            GamePubSDKSettings.SetInstance(settings);

            EditorGUILayout.HelpBox("Gamepub SDK version information.", MessageType.Info);
            GUILayout.TextArea("Unity SDK Version : " + GamePubSDKSettings.unitySdkVersion, EditorStyles.wordWrappedLabel);
            GUILayout.TextArea("Android SDK Version : " + GamePubSDKSettings.androidSdkVersion, EditorStyles.wordWrappedLabel);
            GUILayout.TextArea("iOS SDK Version : " + GamePubSDKSettings.iosSdkVersion, EditorStyles.wordWrappedLabel);

            EditorGUILayout.BeginHorizontal();
            GamePubSDKSettings.SdkAppID = EditorGUILayout.TextField(sdkAppIdLabel, GamePubSDKSettings.SdkAppID).Trim();            
            EditorGUILayout.EndHorizontal();
            if(string.IsNullOrEmpty(GamePubSDKSettings.SdkAppID))
            {                
                EditorGUILayout.HelpBox("not working if SdkAppID is empty.", MessageType.Warning);
            }            

            EditorGUILayout.BeginHorizontal();
            GamePubSDKSettings.DevBuild = EditorGUILayout.Toggle(devBuildLabel, GamePubSDKSettings.DevBuild);
            EditorGUILayout.EndHorizontal();


            //GUILayout.TextArea("Get the latest Gamepub SDK version.", EditorStyles.wordWrappedLabel);
            if (GUILayout.Button("Update SDK"))
            {
                Application.OpenURL("https://docs.igamepub.co.kr/gamepub-sdk-guide/resources/downloads");
            }

            if (GUI.changed)
            {                
                EditorUtility.SetDirty(settings);                
                AssetDatabase.SaveAssets();
            }
        }

        private static void ShowInspector()
        {
            try
            {
                var editorAsm = typeof(UnityEditor.Editor).Assembly;
                var type = editorAsm.GetType("UnityEditor.InspectorWindow");
                Object[] findObjectsOfTypeAll = Resources.FindObjectsOfTypeAll(type);

                if (findObjectsOfTypeAll.Length > 0)
                {
                    ((EditorWindow)findObjectsOfTypeAll[0]).Focus();
                }
                else
                {
                    EditorWindow.GetWindow(type);
                }
            }
            catch
            {
                EditorUtility.DisplayDialog("Gamepub SDK", "Unity Inspector Error.", "OK");
            }
        }
    }
}
