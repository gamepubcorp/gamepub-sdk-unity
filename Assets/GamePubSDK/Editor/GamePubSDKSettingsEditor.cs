using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace GamePub.PubSDK.Editor
{
    [CustomEditor(typeof(GamePubSDKSettingsEditor))]
    public class GamePubSDKSettingsEditor : UnityEditor.Editor
    {

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
