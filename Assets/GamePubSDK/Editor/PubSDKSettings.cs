using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.IO;

namespace GamePub.PubSDK.Editor
{
    class PubSDKSettings : ScriptableObject
    {
        const string assetPath = "Assets/Editor/GamePubSDK/GamePubSDKSettings.asset";

        internal static string[] dependencyManagerOptions = new string[] { "CocoaPods" };

        [SerializeField]
        private string iOSDependencyManager;        
        [SerializeField]
        private bool appleLogin;
        [SerializeField]
        private bool facebookLogin;
        [SerializeField]
        private string facebookAppID;
        [SerializeField]
        private string reversedClientID;
        [SerializeField]
        private string googleClientID;

        internal static int DependencySelectedIndex(string selected)
        {
            return Array.IndexOf(dependencyManagerOptions, selected);
        }

        internal bool UseCocoaPods { get { return iOSDependencyManager.Equals("CocoaPods"); } }
        internal string FacebookAppID { get { return facebookAppID; } }
        internal string GoogleClientID { get { return googleClientID; } }
        internal string ReversedClientID { get { return reversedClientID; } }
        internal bool UseAppleLogin { get { return appleLogin; } }
        internal bool UseFacebookLogin { get { return facebookLogin; } }

        internal static PubSDKSettings GetOrCreateSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath<PubSDKSettings>(assetPath);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<PubSDKSettings>();
                settings.iOSDependencyManager = "CocoaPods";
                settings.appleLogin = false;
                settings.facebookLogin = false;

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

            var propertyAppleLogin = settings.FindProperty("appleLogin");
            var enableAppleLogin = propertyAppleLogin.boolValue;

            var propertyFacebookLogin = settings.FindProperty("facebookLogin");
            var enableFacebookLogin = propertyFacebookLogin.boolValue;

            var propertyFacebookAppId = settings.FindProperty("facebookAppID");
            var facebookAppId = propertyFacebookAppId.stringValue;
            
            var propertyGoogleClientId = settings.FindProperty("googleClientID");
            var googleClientId = propertyGoogleClientId.stringValue;

            var propertyReversedClientId = settings.FindProperty("reversedClientID");
            var reversedClientId = propertyReversedClientId.stringValue;

            selected = EditorGUILayout.Popup("iOS Dependency Manager", selected, PubSDKSettings.dependencyManagerOptions);
            enableAppleLogin = EditorGUILayout.Toggle("Apple Login Enable", enableAppleLogin);

            GUILayout.Space(20);
            GUI.skin.label.fontSize = 17;
            GUILayout.Label("Facebook", GUILayout.Width(200), GUILayout.Height(30));
            enableFacebookLogin = EditorGUILayout.BeginToggleGroup("Facebook Login Enable", enableFacebookLogin);
            facebookAppId = EditorGUILayout.TextField("Facebook App ID", facebookAppId);
            GUILayout.Label("Google", GUILayout.Width(200), GUILayout.Height(30));
            googleClientId = EditorGUILayout.TextField("Google Client ID", googleClientId);
            reversedClientId = EditorGUILayout.TextField("REVERSED Client ID", reversedClientId);
            EditorGUILayout.EndToggleGroup();

            if (selected < 0)
            {
                selected = 0;
            }
            property.stringValue = PubSDKSettings.dependencyManagerOptions[selected];
            propertyAppleLogin.boolValue = enableAppleLogin;
            propertyFacebookLogin.boolValue = enableFacebookLogin;
            propertyFacebookAppId.stringValue = facebookAppId;
            propertyGoogleClientId.stringValue = googleClientId;
            propertyReversedClientId.stringValue = reversedClientId;

            if (EditorGUI.EndChangeCheck())
            {
                settings.ApplyModifiedProperties();
                AssetDatabase.SaveAssets();
            }

        }
    }
}