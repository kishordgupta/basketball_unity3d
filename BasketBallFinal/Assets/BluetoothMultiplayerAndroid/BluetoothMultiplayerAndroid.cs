#if UNITY_ANDROID
using System;
using UnityEngine;

public class BluetoothMultiplayerAndroid {
    internal const string Delimiter = "~~~#$%~~~";
    internal const string ZeroBluetoothAddress = "00:00:00:00:00:00";
    private const string PluginClassName = "com.lostpolygon.unity.bluetoothmediator.BluetoothMediator";

    private static readonly AndroidJavaObject Plugin;
    private static readonly bool PluginAvailable;

    private static void AssertIsBluetoothEnabled() {
        if (!IsBluetoothEnabled())
            throw new BluetoothNotEnabledException("Bluetooth not enabled while calling Bluetooth-requiring method");
    }

    static BluetoothMultiplayerAndroid() {
        Plugin = null;
        PluginAvailable = false;

#if !UNITY_EDITOR
        if (Application.platform == RuntimePlatform.Android) {
            try {
                using (AndroidJavaClass mediatorClass = new AndroidJavaClass(PluginClassName)) {
                    if (!IsAndroidJavaClassNull(mediatorClass)) {
                        Plugin = mediatorClass.CallStatic<AndroidJavaObject>("getSingleton");
                        PluginAvailable = !IsAndroidJavaObjectNull(Plugin);
                    } 
                }
            } catch {
                Debug.LogError("BluetoothMultiplayerAndroid initialization failed. Probably .jar not present?");
                throw;
            }
        }
#endif
    }

    #region Methods

    // Initialize the plugin and set the Bluetooth service UUID
    public static bool Init(string uuid) {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("initUuid", uuid);
    }

    // Start server, listening for incoming Bluetooth connections
    public static bool InitializeServer(ushort port) {
        if (!PluginAvailable)
            return false;

        AssertIsBluetoothEnabled();
        return Plugin.Call<bool>("startServer", "127.0.0.1", (int) port);
    }

    // Connect to a Bluetooth device
    public static bool Connect(string hostDeviceAddress, ushort port) {
        if (!PluginAvailable)
            return false;

        AssertIsBluetoothEnabled();
        return Plugin.Call<bool>("startClient", "127.0.0.1", (int) port, hostDeviceAddress);
    }

    // Stop all Bluetooth connectivity
    public static bool Disconnect() {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("stop");
    }

    // Stop listening for new incoming connections
    public static bool StopListen() {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("stopListen");
    }

    // Return the current plugin mode
    public static BluetoothMultiplayerModes CurrentMode() {
        if (!PluginAvailable)
            return BluetoothMultiplayerModes.None;

        return (BluetoothMultiplayerModes) Plugin.Call<byte>("getCurrentMode");
    }

    // Open a dialog asking user to make device discoverable on Bluetooth
    // Will also request the user to turn on Bluetooth if it is not currently enabled
    public static bool RequestDiscoverable(int discoverableDuration = 120) {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("requestDiscoverable", discoverableDuration);
    }

    // Open a dialog asking user to enable Bluetooth
    public static bool RequestBluetoothEnable() {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("requestBluetoothEnable");
    }

    // Enable the Bluetooth adapter, if possible
    public static bool BluetoothEnable() {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("bluetoothEnable");
    }

    // Disable the Bluetooth adapter, if possible
    public static bool BluetoothDisable() {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("bluetoothDisable");
    }

    // Return true of Bluetooth is available on the device
    public static bool IsBluetoothAvailable() {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("isBluetoothAvailable");
    }

    // Return true if Bluetooth is currently enabled 
    public static bool IsBluetoothEnabled() {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("isBluetoothEnabled");
    }

    // Show the Bluetooth device picker dialog
    public static bool ShowDeviceList(bool showAllDeviceTypes = false) {
        if (!PluginAvailable)
            return false;

        AssertIsBluetoothEnabled();
        return Plugin.Call<bool>("showDeviceList", showAllDeviceTypes);
    }

    // Return current Bluetooth device
    public static BluetoothDevice GetCurrentDevice() {
        if (!PluginAvailable)
            return null;

        BluetoothDevice currentDevice = new BluetoothDevice(Plugin.Call<string>("getCurrentDevice"));

        return currentDevice;
    }

    // Start discovery of nearby discoverable Bluetooth devices
    public static bool StartDiscovery() {
        if (!PluginAvailable)
            return false;

        AssertIsBluetoothEnabled();
        return Plugin.Call<bool>("startDiscovery");
    }

    // Stop discovery of nearby discoverable Bluetooth devices
    public static bool StopDiscovery() {
        if (!PluginAvailable)
            return false;

        AssertIsBluetoothEnabled();
        return Plugin.Call<bool>("stopDiscovery");
    }

    // Return true if Bluetooth device discovery is going on
    public static bool IsDiscovering() {
        if (!PluginAvailable)
            return false;

        AssertIsBluetoothEnabled();
        return Plugin.Call<bool>("isDiscovering");
    }

    // Return true if device is discoverable by other devices
    public static bool IsDiscoverable() {
        if (!PluginAvailable)
            return false;

        AssertIsBluetoothEnabled();
        return Plugin.Call<bool>("isDiscoverable");
    }

    // Return array of bonded (paired) Bluetooth devices
    public static BluetoothDevice[] GetBondedDevices() {
        if (!PluginAvailable)
            return null;

        AndroidJavaObject deviceJavaSet = Plugin.Call<AndroidJavaObject>("getBondedDevices");
        BluetoothDevice[] deviceArray = ConvertJavaBluetoothDeviceSet(deviceJavaSet);

        return deviceArray;
    }

    // Return array of Bluetooth devices discovered during 
    // current discovery session
    public static BluetoothDevice[] GetNewDiscoveredDevices() {
        if (!PluginAvailable)
            return null;

        AndroidJavaObject deviceJavaSet = Plugin.Call<AndroidJavaObject>("getNewDiscoveredDevices");
        BluetoothDevice[] deviceArray = ConvertJavaBluetoothDeviceSet(deviceJavaSet);

        return deviceArray;
    }

    // Return array of bonded (paired) Bluetooth devices and
    // Bluetooth devices discovered during current discovery session
    public static BluetoothDevice[] GetDiscoveredDevices() {
        if (!PluginAvailable)
            return null;

        AndroidJavaObject deviceJavaSet = Plugin.Call<AndroidJavaObject>("getDiscoveredDevices");
        BluetoothDevice[] deviceArray = ConvertJavaBluetoothDeviceSet(deviceJavaSet);

        return deviceArray;
    }

    // Enable or disable raw packets. Use only if you know what you are doing
    public static bool SetRawPackets(bool doEnable) {
        if (!PluginAvailable)
            return false;

        return Plugin.Call<bool>("setRawPackets", doEnable);
    }

    // Enable or disable verbose logging. Useful for debugging
    public static void SetVerboseLog(bool doEnable) {
        if (!PluginAvailable)
            return;

        Plugin.CallStatic("setVerboseLog", doEnable);
    }

    #endregion

    #region Helper methods

    private static BluetoothDevice[] ConvertJavaBluetoothDeviceSet(AndroidJavaObject bluetoothDeviceJavaSet) {
        try {
            if (IsAndroidJavaObjectNull(bluetoothDeviceJavaSet))
                return null;

            AndroidJavaObject[] deviceJavaArray = bluetoothDeviceJavaSet.Call<AndroidJavaObject[]>("toArray");

            BluetoothDevice[] deviceArray = new BluetoothDevice[deviceJavaArray.Length];
            for (int i = 0; i < deviceJavaArray.Length; i++) {
                deviceArray[i] = new BluetoothDevice(deviceJavaArray[i]);
            }

            return deviceArray;
        } catch {
            Debug.LogError("Exception while converting BluetoothDevice Set");
            throw;
        }
    }

    private static bool IsAndroidJavaObjectNull(AndroidJavaObject androidJavaObject) {
        return androidJavaObject == null ||
               androidJavaObject.GetRawClass().ToInt32() == 0;
    }

    private static bool IsAndroidJavaClassNull(AndroidJavaClass androidJavaClass) {
        return androidJavaClass == null ||
               androidJavaClass.GetRawClass().ToInt32() == 0;
    }

    #endregion
}
#endif