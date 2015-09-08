using UnityEngine;
using LostPolygon.BluetoothMultiplayerAndroid.Examples;

public class BluetoothDiscoveryDemoGui : MonoBehaviour {
#if !UNITY_ANDROID
    private void Awake() {
        Debug.LogError("Build platform is not set to Android. Please choose Android as build Platform in File - Build Settings...");
    }

    private void OnGUI() {
        GUI.Label(new Rect(10, 10, Screen.width, 100), "Build platform is not set to Android. Please choose Android as build Platform in File - Build Settings...");
    }
#else
    private bool _initResult;
    private string _log;
    private Vector2 _logPosition = Vector2.zero;

    private void HandleLog(string logString, string stackTrace, LogType logType) {
        if (logType == LogType.Error || logType == LogType.Exception) {
            _log += string.Format("Error: {0}, stacktrace: \n {1}", logString, stackTrace);
        } else {
            _log += logString + "\r\n";
        }
    }

    private void Awake() {
        Application.RegisterLogCallback(HandleLog);

        Debug.Log("This demo shows some available methods and the discovery of nearby Bluetooth devices.\r\n");
        // Setting the UUID. Must be unique for every application
        _initResult = BluetoothMultiplayerAndroid.Init("8ce255c0-200a-11e0-ac64-0800200c9a66");
        // Enabling verbose logging. See logcat!
        BluetoothMultiplayerAndroid.SetVerboseLog(true);

        // Registering the event delegates
        BluetoothMultiplayerAndroidManager.onBluetoothAdapterEnabledEvent += onBluetoothAdapterEnabled;
        BluetoothMultiplayerAndroidManager.onBluetoothAdapterEnableFailedEvent += onBluetoothAdapterEnableFailed;
        BluetoothMultiplayerAndroidManager.onBluetoothAdapterDisabledEvent += onBluetoothAdapterDisabled;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoverabilityEnabledEvent += onBluetoothDiscoverabilityEnabled;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoverabilityEnableFailedEvent += onBluetoothDiscoverabilityEnableFailed;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoveryStartedEvent += onBluetoothDiscoveryStarted;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoveryFinishedEvent += onBluetoothDiscoveryFinished;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoveryDeviceFoundEvent += onBluetoothDiscoveryDeviceFound;
    }

    // Don't forget to unregister the event delegates!
    private void OnDestroy() {
        BluetoothMultiplayerAndroidManager.onBluetoothAdapterEnabledEvent -= onBluetoothAdapterEnabled;
        BluetoothMultiplayerAndroidManager.onBluetoothAdapterEnableFailedEvent -= onBluetoothAdapterEnableFailed;
        BluetoothMultiplayerAndroidManager.onBluetoothAdapterDisabledEvent -= onBluetoothAdapterDisabled;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoverabilityEnabledEvent -= onBluetoothDiscoverabilityEnabled;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoverabilityEnableFailedEvent -= onBluetoothDiscoverabilityEnableFailed;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoveryStartedEvent -= onBluetoothDiscoveryStarted;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoveryFinishedEvent -= onBluetoothDiscoveryFinished;
        BluetoothMultiplayerAndroidManager.onBluetoothDiscoveryDeviceFoundEvent -= onBluetoothDiscoveryDeviceFound;

        Application.RegisterLogCallback(null);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Gracefully closing all Bluetooth connectivity and loading the menu
            try {
                BluetoothMultiplayerAndroid.StopDiscovery();
                BluetoothMultiplayerAndroid.Disconnect();
            } catch {
                // 
            }
            Application.LoadLevel("BluetoothDemoMenu");
        }
    }

    private void OnGUI() {
        bool isBluetoothEnabled = BluetoothMultiplayerAndroid.IsBluetoothEnabled();
        bool isDiscoverable = isBluetoothEnabled && BluetoothMultiplayerAndroid.IsDiscoverable();
        bool isDiscovering = isBluetoothEnabled && BluetoothMultiplayerAndroid.IsDiscovering();

        float scaleFactor = BluetoothExamplesTools.UpdateScaleMobile();
        // Show the buttons if initialization succeeded
        if (_initResult) {
            // Simple text log view
            GUILayout.Space(190f);
            BluetoothExamplesTools.TouchScroll(ref _logPosition);
            _logPosition = GUILayout.BeginScrollView(_logPosition, GUILayout.MaxHeight(Screen.height/ scaleFactor - 190f), GUILayout.MinWidth(Screen.width/ scaleFactor - 10f), GUILayout.ExpandHeight(false));
            GUILayout.Label(_log, GUILayout.ExpandHeight(true), GUILayout.MaxWidth(Screen.width / scaleFactor));
            GUILayout.EndScrollView();

            // Generic GUI for calling the methods
            GUI.enabled = !isBluetoothEnabled;
            if (GUI.Button(new Rect(10, 10, 140, 50), "Request enable\nBluetooth")) {
                BluetoothMultiplayerAndroid.RequestBluetoothEnable();
            }

            GUI.enabled = isBluetoothEnabled;
            if (GUI.Button(new Rect(160, 10, 140, 50), "Disable Bluetooth")) {
                BluetoothMultiplayerAndroid.BluetoothDisable();
            }
            GUI.enabled = !isBluetoothEnabled || !isDiscoverable;
            if (GUI.Button(new Rect(310, 10, 150, 50), "Request discoverability")) {
                BluetoothMultiplayerAndroid.RequestDiscoverable(120);
            }

            GUI.enabled = isBluetoothEnabled && !isDiscovering;
            if (GUI.Button(new Rect(10, 70, 140, 50), "Start discovery")) {
                BluetoothMultiplayerAndroid.StartDiscovery();
            }

            GUI.enabled = isBluetoothEnabled && isDiscovering;
            if (GUI.Button(new Rect(160, 70, 140, 50), "Stop discovery")) {
                BluetoothMultiplayerAndroid.StopDiscovery();
            }

            GUI.enabled = isBluetoothEnabled;
            if (GUI.Button(new Rect(310, 70, 150, 50), "Get current\ndevice")) {
                Debug.Log("Current device:");
                BluetoothDevice device = BluetoothMultiplayerAndroid.GetCurrentDevice();
                if (device != null) {
                    // Result can be null on error or if Bluetooth is not available
                    Debug.Log(string.Format("Device: " + BluetoothExamplesTools.FormatDevice(device)));
                } else {
                    Debug.LogError("Error while retrieving current device");
                }
            }

            // Just get the device lists and prints them
            if (GUI.Button(new Rect(10, 130, 140, 50), "Show bonded\ndevice list")) {
                Debug.Log("Listing known bonded (paired) devices");
                BluetoothDevice[] list = BluetoothMultiplayerAndroid.GetBondedDevices();

                if (list != null) {
                    // Result can be null on error or if Bluetooth is not available
                    if (list.Length == 0) {
                        Debug.Log("No devices");
                    } else {
                        foreach (BluetoothDevice device in list) {
                            Debug.Log("Device: " + BluetoothExamplesTools.FormatDevice(device));
                        }
                    }
                } else {
                    Debug.LogError("Error while retrieving GetBondedDevices()");
                }
            }

            if (GUI.Button(new Rect(160, 130, 140, 50), "Show new discovered\ndevice list")) {
                Debug.Log("Listing devices discovered during last discovery session...");
                BluetoothDevice[] list = BluetoothMultiplayerAndroid.GetNewDiscoveredDevices();

                if (list != null) {
                    // Result can be null on error or if Bluetooth is not available
                    if (list.Length == 0) {
                        Debug.Log("No devices");
                    } else {
                        foreach (BluetoothDevice device in list) {
                            Debug.Log("Device: " + BluetoothExamplesTools.FormatDevice(device));
                        }
                    }
                } else {
                    Debug.LogError("Error while retrieving GetNewDiscoveredDevices()");
                }
            }

            if (GUI.Button(new Rect(310, 130, 150, 50), "Show full\ndevice list")) {
                Debug.Log("Listing all known or discovered devices...");
                BluetoothDevice[] list = BluetoothMultiplayerAndroid.GetDiscoveredDevices();

                if (list != null) {
                    // Result can be null on error or if Bluetooth is not available
                    if (list.Length == 0) {
                        Debug.Log("No devices");
                    } else {
                        foreach (BluetoothDevice device in list) {
                            Debug.Log("Device: " + BluetoothExamplesTools.FormatDevice(device));
                        }
                    }
                } else {
                    Debug.LogError("Error while retrieving GetDiscoveredDevices()");
                }
            }

            GUI.enabled = true;
            // Showing message if initialization failed for some reason
        } else {
            GUI.Label(new Rect(10, 10, Screen.width / scaleFactor, 50), "Bluetooth not available. Are you running this on Bluetooth-capable Android device and AndroidManifest.xml is set up correctly?");
        }

        if (GUI.Button(new Rect(Screen.width / scaleFactor - 100f - 15f, Screen.height / scaleFactor - 40f - 15f, 100f, 40f), "Back")) {
            try {
                BluetoothMultiplayerAndroid.StopDiscovery();
                BluetoothMultiplayerAndroid.Disconnect();
            } catch {
                // 
            }
            Application.LoadLevel("BluetoothDemoMenu");
        }
    }

    private void onBluetoothDiscoveryDeviceFound(BluetoothDevice device) {
        // For demo purposes, just display the device info
        Debug.Log(
            string.Format(
            "Event - onBluetoothDiscoveryDeviceFound(): {0} [{1}], class: {2}, connectable: {3}", 
            device.name, 
            device.address, 
            device.deviceClass, 
            device.isConnectable)
            );
    }

    private void onBluetoothAdapterDisabled() {
        Debug.Log("Event - onBluetoothAdapterDisabled()");
    }

    private void onBluetoothAdapterEnableFailed() {
        Debug.Log("Event - onBluetoothAdapterEnableFailed()");
    }

    private void onBluetoothAdapterEnabled() {
        Debug.Log("Event - onBluetoothAdapterEnabled()");
    }

    private void onBluetoothDiscoverabilityEnableFailed() {
        Debug.Log("Event - onBluetoothDiscoverabilityEnableFailed()");
    }

    private void onBluetoothDiscoverabilityEnabled(int discoverabilityDuration) {
        Debug.Log(string.Format("Event - onBluetoothDiscoverabilityEnabled(): {0} seconds", discoverabilityDuration));
    }

    private void onBluetoothDiscoveryFinished() {
        Debug.Log("Event - onBluetoothDiscoveryFinished()");
    }

    private void onBluetoothDiscoveryStarted() {
        Debug.Log("Event - onBluetoothDiscoveryStarted()");
    }
#endif
}