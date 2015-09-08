#if UNITY_ANDROID
using System;

public class BluetoothNotEnabledException : Exception {
    public BluetoothNotEnabledException(string message) : base(message) {
    }
}
#endif