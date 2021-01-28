using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.IO;

namespace GamePub.PubSDK.Editor
{
    class PubSDKSettings : ScriptableObject
    {
        const string assetPath = "Assets/GamePubSDK/Editor/GamePubSDKSettings.asset";

        internal static string[] dependencyManagerOptions = new string[] { "CocoaPods", "Carthage" };

        [SerializeField]
        private string iOSDependencyManager;

        internal static int DependencySelectedIndex(string selected)
        {
            return Array.IndexOf(dependencyManagerOptions, selected);
        }

        internal bool UseCocoaPods { get { return iOSDependencyManager.Equals("CocoaPods"); } }
        internal bool UseCarthage { get { return iOSDependencyManager.Equals("Carthage"); } }

        internal static PubSDKSettings GetOrCreateSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath<PubSDKSettings>(assetPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<PubSDKSettings>();
                settings.iOSDependencyManager = "CocoaPods";

                Directory.CreateDirectory("Assets/Editor/GamePubSDK/");

                AssetDatabase.CreateAsset(settings, assetPath);
                AssetDatabase.SaveAssets();
            }
            return settings;
        }

        internal static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }
    }

    static class PubSDKSettingsProvider
    {

        static SerializedObject settings;

        private class Provider : SettingsProvider
        {
            public Provider(string path, SettingsScope scope = SettingsScope.User) : base(path, scope) { }
            public override void OnGUI(string searchContext)
            {
                DrawPref();
            }
        }
        [SettingsProvider]
        static SettingsProvider MyNewPrefCode()
        {
            return new Provider("Preferences/GamePub SDK");
        }

        static void DrawPref()
        {
            if (settings == null)
            {
                settings = PubSDKSettings.GetSerializedSettings();
            }
            settings.Update();
            EditorGUI.BeginChangeCheck();

            var property = settings.FindProperty("iOSDependencyManager");
            var selected = PubSDKSettings.DependencySelectedIndex(property.stringValue);

            selected = EditorGUILayout.Popup("iOS Dependency Manager", selected, PubSDKSettings.dependencyManagerOptions);

            if (selected < 0)
            {
                selected = 0;
            }
            property.stringValue = PubSDKSettings.dependencyManagerOptions[selected];

            if (EditorGUI.EndChangeCheck())
            {
                settings.ApplyModifiedProperties();
                AssetDatabase.SaveAssets();
            }

        }
    }
}