#if UNITY_ANDROID
using System;
using UnityEngine;

public class BluetoothDevice {
    public enum BondStates : byte {
        None = 10,
        Bonding = 11,
        Bonded = 12
    }

    public readonly string name;
    public readonly string address;
    public readonly BondStates bondState;
    public readonly BluetoothDeviceClass.Class deviceClass;
    public readonly BluetoothDeviceClass.MajorClass deviceMajorClass;
    public readonly bool isConnectable;

    internal BluetoothDevice(string deviceString) {
        try {
            string[] tokens = 
                deviceString.Split(
                    new[] { BluetoothMultiplayerAndroid.Delimiter },
                    StringSplitOptions.None
                    );

            name = tokens[0].Trim();
            address = tokens[1];
            bondState = (BondStates) ushort.Parse(tokens[2]);

            int deviceClassMerged = int.Parse(tokens[3]);
            deviceClass = (BluetoothDeviceClass.Class) deviceClassMerged;
            deviceMajorClass = BluetoothDeviceClass.GetMajorClass(deviceClassMerged);
            isConnectable = deviceClass.IsProbablyHandheldDataCapableDevice();

            if (name == string.Empty)
                name = address;
        } catch {
            Debug.LogError(string.Format("Exception while parsing BluetoothDevice, string was: {0}", deviceString));
            throw;
        }
    }

    internal BluetoothDevice(AndroidJavaObject bluetoothDeviceJavaObject) {
        try {
            if (IsAndroidJavaObjectNull(bluetoothDeviceJavaObject)) {
                throw new ArgumentNullException("bluetoothDeviceJavaObject");
            }
            name = bluetoothDeviceJavaObject.Call<string>("getName").Trim();
            address = bluetoothDeviceJavaObject.Call<string>("getAddress");
            bondState = (BondStates) bluetoothDeviceJavaObject.Call<int>("getBondState");

            AndroidJavaObject deviceClassJavaObject = bluetoothDeviceJavaObject.Call<AndroidJavaObject>("getBluetoothClass");
            int deviceClassMerged = deviceClassJavaObject.Call<int>("getDeviceClass");
            deviceClass = (BluetoothDeviceClass.Class) deviceClassMerged;
            deviceMajorClass = BluetoothDeviceClass.GetMajorClass(deviceClassMerged);
            isConnectable = deviceClass.IsProbablyHandheldDataCapableDevice();

            if (name == string.Empty)
                name = address;
        } catch {
            Debug.LogError("Exception while converting BluetoothDevice");
            throw;
        }
    }

    public override string ToString() {
        return address;
    }

    private static bool IsAndroidJavaObjectNull(AndroidJavaObject androidJavaObject) {
        return androidJavaObject == null || 
               androidJavaObject.GetRawObject().ToInt32() == 0 || 
               androidJavaObject.GetRawClass().ToInt32() == 0;
    }
}
#endif