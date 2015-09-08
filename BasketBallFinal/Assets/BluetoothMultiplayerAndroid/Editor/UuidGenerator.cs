using System;
using UnityEditor;
using UnityEngine;

public class UuidGenerator : EditorWindow {
    [MenuItem("Tools/Lost Polygon/Android Bluetooth Multiplayer/UUID generator")]
    private static void ShowWindow() {
#if UNITY_ANDROID
        UuidGenerator window = GetWindow<UuidGenerator>(true, "UUID generator");
        window.minSize = new Vector2(260f, 80f);
        window.maxSize = window.minSize;
#else
        EditorUtility.DisplayDialog("Wrong build platform", "Build platform was not set to Android. Please choose Android as build Platform in File - Build Settings...", "OK");
#endif
    }

#if UNITY_ANDROID
    private string _uuid = "";

    private void OnGUI() {
        EditorGUILayout.LabelField("Random generated UUID: ");
        _uuid = EditorGUILayout.TextField(_uuid);

        if (GUILayout.Button("Generate new UUID") || _uuid == "") {
            _uuid = Guid.NewGuid().ToString();
            Repaint();
        }
    }
#endif
}

