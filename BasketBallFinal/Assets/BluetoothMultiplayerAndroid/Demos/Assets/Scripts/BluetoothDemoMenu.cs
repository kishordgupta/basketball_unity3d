using UnityEngine;
using LostPolygon.BluetoothMultiplayerAndroid.Examples;

public class BluetoothDemoMenu : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void OnGUI() {
        const float width = 250f;
        const float buttonHeight = 35f;
        const float height = 100f + buttonHeight * 2f;

        float scaleFactor = BluetoothExamplesTools.UpdateScaleMobile();
        GUI.color = Color.white;
        GUILayout.BeginArea(
            new Rect(
                Screen.width / 2f / scaleFactor - width / 2f,
                Screen.height / 2f / scaleFactor - height / 2f,
                width,
                height),
            "Android Bluetooth Multiplayer Demo",
            "Window");
        GUILayout.BeginVertical();

        GUILayout.Space(10);
        if (GUILayout.Button("Multiplayer demo", GUILayout.Height(buttonHeight)))
            Application.LoadLevel("BluetoothMultiplayerDemo");
        if (GUILayout.Button("Device discovery demo", GUILayout.Height(buttonHeight)))
            Application.LoadLevel("BluetoothDiscoveryDemo");

        GUILayout.Space(15);
        GUI.color = new Color(1f, 0.6f, 0.6f, 1f);
        if (GUILayout.Button("Quit", GUILayout.Height(buttonHeight))) {
            Application.Quit();
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

}