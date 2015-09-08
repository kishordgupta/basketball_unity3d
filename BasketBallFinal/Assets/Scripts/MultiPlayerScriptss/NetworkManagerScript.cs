using UnityEngine;
using System.Collections;
using LostPolygon.BluetoothMultiplayerAndroid.Examples;
using Soomla;

namespace Soomla.Store.Example{
public class NetworkManagerScript : MonoBehaviour {

	public GameObject ServerPlayer;
	public GameObject ClientPlayer;

	public GUISkin CustomSkin;
//	public GameObject BasketBall; 
	
	public static bool connectivityServer = false;
	public static bool connectivityClient = false;
	public static bool clientReady = false;
	public static bool serverReady = false;
	
	//	public bool connectionTest;
	
	private const string LocalIp = "127.0.0.1"; // An IP for Network.Connect(), must always be 127.0.0.1
	private const int Port = 28000; // Local server IP. Must be the same for client and server
	
	private bool _initResult;
	
	#if !UNITY_ANDROID
	private void Awake() {
		Debug.LogError("Build platform is not set to Android. Please choose Android as build Platform in File - Build Settings...");
	}
	
	private void OnGUI() {
		GUI.Label(new Rect(10, 10, Screen.width, 100), "Build platform is not set to Android. Please choose Android as build Platform in File - Build Settings...");
	}
	#else
	private BluetoothMultiplayerModes _desiredMode = BluetoothMultiplayerModes.None;
	
	private void Awake() {

		// Setting the UUID. Must be unique for every application
		_initResult = BluetoothMultiplayerAndroid.Init("8ce255c0-200a-11e0-ac64-0800200c9a66");
		
		// Enabling verbose logging. See log cat!
		BluetoothMultiplayerAndroid.SetVerboseLog(true);
		
		// Registering the event delegates
		BluetoothMultiplayerAndroidManager.onBluetoothListeningStartedEvent += onBluetoothListeningStarted;
		BluetoothMultiplayerAndroidManager.onBluetoothListeningCanceledEvent += onBluetoothListeningCanceled;
		BluetoothMultiplayerAndroidManager.onBluetoothAdapterEnabledEvent += onBluetoothAdapterEnabled;
		BluetoothMultiplayerAndroidManager.onBluetoothAdapterEnableFailedEvent += onBluetoothAdapterEnableFailed;
		BluetoothMultiplayerAndroidManager.onBluetoothAdapterDisabledEvent += onBluetoothAdapterDisabled;
		BluetoothMultiplayerAndroidManager.onBluetoothDiscoverabilityEnabledEvent += onBluetoothDiscoverabilityEnabled;
		BluetoothMultiplayerAndroidManager.onBluetoothDiscoverabilityEnableFailedEvent += onBluetoothDiscoverabilityEnableFailed;
		BluetoothMultiplayerAndroidManager.onBluetoothConnectedToServerEvent += onBluetoothConnectedToServer;
		BluetoothMultiplayerAndroidManager.onBluetoothConnectToServerFailedEvent += onBluetoothConnectToServerFailed;
		BluetoothMultiplayerAndroidManager.onBluetoothDisconnectedFromServerEvent += onBluetoothDisconnectedFromServer;
		BluetoothMultiplayerAndroidManager.onBluetoothClientConnectedEvent += onBluetoothClientConnected;
		BluetoothMultiplayerAndroidManager.onBluetoothClientDisconnectedEvent += onBluetoothClientDisconnected;
		BluetoothMultiplayerAndroidManager.onBluetoothDevicePickedEvent += onBluetoothDevicePicked;
	}
	
	// Don't forget to unregister the event delegates!
	private void OnDestroy() {
		BluetoothMultiplayerAndroidManager.onBluetoothListeningStartedEvent -= onBluetoothListeningStarted;
		BluetoothMultiplayerAndroidManager.onBluetoothListeningCanceledEvent -= onBluetoothListeningCanceled;
		BluetoothMultiplayerAndroidManager.onBluetoothAdapterEnabledEvent -= onBluetoothAdapterEnabled;
		BluetoothMultiplayerAndroidManager.onBluetoothAdapterEnableFailedEvent -= onBluetoothAdapterEnableFailed;
		BluetoothMultiplayerAndroidManager.onBluetoothAdapterDisabledEvent -= onBluetoothAdapterDisabled;
		BluetoothMultiplayerAndroidManager.onBluetoothDiscoverabilityEnabledEvent -= onBluetoothDiscoverabilityEnabled;
		BluetoothMultiplayerAndroidManager.onBluetoothDiscoverabilityEnableFailedEvent -= onBluetoothDiscoverabilityEnableFailed;
		BluetoothMultiplayerAndroidManager.onBluetoothConnectedToServerEvent -= onBluetoothConnectedToServer;
		BluetoothMultiplayerAndroidManager.onBluetoothConnectToServerFailedEvent -= onBluetoothConnectToServerFailed;
		BluetoothMultiplayerAndroidManager.onBluetoothDisconnectedFromServerEvent -= onBluetoothDisconnectedFromServer;
		BluetoothMultiplayerAndroidManager.onBluetoothClientConnectedEvent -= onBluetoothClientConnected;
		BluetoothMultiplayerAndroidManager.onBluetoothClientDisconnectedEvent -= onBluetoothClientDisconnected;
		BluetoothMultiplayerAndroidManager.onBluetoothDevicePickedEvent -= onBluetoothDevicePicked;
	}
	void Start(){
		Time.timeScale = 0;
		//		connectionTest = false;
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
		GUI.skin = CustomSkin;
		float scaleFactor = BluetoothExamplesTools.UpdateScaleMobile();
		// If initialization was successfull, showing the buttons
		if (_initResult) {
			// If there is no current Bluetooth connectivity
			if (BluetoothMultiplayerAndroid.CurrentMode() == BluetoothMultiplayerModes.None) {
				if (GUI.Button(new Rect(175, 75, 150, 50), "Create Game")) {
					// If Bluetooth is enabled, then we can do something right on
					if (BluetoothMultiplayerAndroid.IsBluetoothEnabled()) {
						BluetoothMultiplayerAndroid.RequestDiscoverable(120); 
						Network.Disconnect(); // Just to be sure
						BluetoothMultiplayerAndroid.InitializeServer(Port);
					} else {
						// Otherwise we have to enable Bluetooth first and wait for callback
						_desiredMode = BluetoothMultiplayerModes.Server;
						BluetoothMultiplayerAndroid.RequestDiscoverable(120);
					}
				}
				
				if (GUI.Button(new Rect(175, 135, 150, 50), "Join The Game")) {
					// If Bluetooth is enabled, then we can do something right on
					if (BluetoothMultiplayerAndroid.IsBluetoothEnabled()) {
						Network.Disconnect(); // Just to be sure
						BluetoothMultiplayerAndroid.ShowDeviceList(); // Open device picker dialog
					} else {
						// Otherwise we have to enable Bluetooth first and wait for callback
						_desiredMode = BluetoothMultiplayerModes.Client;
						BluetoothMultiplayerAndroid.RequestBluetoothEnable();
					}
				}
			} else {
				// Stop all networking
				if (GUI.Button(new Rect(10, 10, 150, 50), "Disconnect")) {
					if (Network.peerType != NetworkPeerType.Disconnected)
						Network.Disconnect();
				}
			}
		} else {
			// Showing message if initialization failed for some reason
			GUI.Label(new Rect(10, 10, Screen.width / scaleFactor, 100), "Bluetooth not available. Are you running this on Bluetooth-capable Android device and AndroidManifest.xml is set up correctly?");
		}
		
		if (GUI.Button(new Rect(350, 10, 100, 30), "Back")) {
			// Gracefully closing all Bluetooth connectivity and loading the menu
			try {
				BluetoothMultiplayerAndroid.StopDiscovery();
				BluetoothMultiplayerAndroid.Disconnect();
			} catch {
				// 
			}
			
			Application.LoadLevel("newMainMenu");
		}
	}
	
	private void OnPlayerDisconnected(NetworkPlayer player) {
		Debug.Log("Player disconnected: " + player.GetHashCode());
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
	
	private void OnFailedToConnect(NetworkConnectionError error) {
		Debug.Log("Can't connect to the networking server");
		
		BluetoothMultiplayerAndroid.Disconnect();
	}
	
	private void OnDisconnectedFromServer() {
		Debug.Log("Disconnected from server");
		
		// Stopping all Bluetooth connectivity on Unity networking disconnect event
		BluetoothMultiplayerAndroid.Disconnect();
		
		//		TestActor[] objects = FindObjectsOfType(typeof(TestActor)) as TestActor[];
		//		if (objects != null)
		//		foreach (TestActor obj in objects) {
		//			Destroy(obj.gameObject);
		//		}
		PlayerControlMultiPlayer[] objectss = FindObjectsOfType(typeof(PlayerControlMultiPlayer)) as PlayerControlMultiPlayer[];
		if (objectss != null)
		foreach (PlayerControlMultiPlayer obj in objectss) {
			Destroy(obj.gameObject);
		}
		OpponentPlayerControl[] objects = FindObjectsOfType(typeof(OpponentPlayerControl)) as OpponentPlayerControl[];
		if (objects != null)
		foreach (OpponentPlayerControl obj in objects) {
			Destroy(obj.gameObject);
		}
	}
	
	private void OnConnectedToServer() {
		// Instantiating a simple test actor
		Network.Instantiate(ClientPlayer, new Vector3(5.0f,0.2f), Quaternion.identity, 0);
		clientReady = true;

		//		Network.Instantiate(BasketBall, new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f)), Quaternion.identity, 0);
		//		MultiNextLevelButton();
	}
	
	private void OnServerInitialized() {
		Debug.Log("OnServerInitialized");
		
		// Instantiating a simple test actor
		if (Network.isServer) {
			Network.Instantiate(ServerPlayer, Vector3.zero, Quaternion.identity, 0);
			serverReady = true;
		}
		Time.timeScale = 0;
		Ball.ballPosition = new Vector2 (0f, 4f);
	}
	
	private void onBluetoothListeningStarted() {
		Debug.Log("Event - onBluetoothListeningStarted()");
		
		// Starting Unity networking server if Bluetooth listening started successfully
		Network.InitializeServer(4, Port, false);
	}
	
	private void onBluetoothListeningCanceled() {
		Debug.Log("Event - onBluetoothListeningCanceled()");
		
		// For demo simplicity, stop server if listening was canceled
		BluetoothMultiplayerAndroid.Disconnect();
	}
	
	private void onBluetoothDevicePicked(BluetoothDevice device) {
		Debug.Log("Event - onBluetoothDevicePicked(): " + BluetoothExamplesTools.FormatDevice(device));
		
		// Trying to connect to a device user had picked
		BluetoothMultiplayerAndroid.Connect(device.address, Port);
	}
	
	private void onBluetoothClientDisconnected(BluetoothDevice device) {
		Debug.Log("Event - onBluetoothClientDisconnected(): " + BluetoothExamplesTools.FormatDevice(device));
		connectivityServer = false;
	}
	
	private void onBluetoothClientConnected(BluetoothDevice device) {
		Debug.Log("Event - onBluetoothClientConnected(): " + BluetoothExamplesTools.FormatDevice(device));
		//		connectionTest = true;
		//		MultiNextLevelButton();
		connectivityServer = true;
		Time.timeScale = 1;
	}
	
	private void onBluetoothDisconnectedFromServer(BluetoothDevice device) {
		Debug.Log("Event - onBluetoothDisconnectedFromServer(): " + BluetoothExamplesTools.FormatDevice(device));
		connectivityClient = false;
		// Stopping Unity networking on Bluetooth failure
		Network.Disconnect();
	}
	
	private void onBluetoothConnectToServerFailed(BluetoothDevice device) {
		Debug.Log("Event - onBluetoothConnectToServerFailed(): " + BluetoothExamplesTools.FormatDevice(device));
	}
	
	private void onBluetoothConnectedToServer(BluetoothDevice device) {
		Debug.Log("Event - onBluetoothConnectedToServer(): " + BluetoothExamplesTools.FormatDevice(device));
		Time.timeScale = 1;
		connectivityClient = true;
		//		connectionTest = true;
		// Trying to negotiate a Unity networking connection, 
		// when Bluetooth client connected successfully
		Network.Connect(LocalIp, Port);
	}
	
	private void onBluetoothAdapterDisabled() {
		Debug.Log("Event - onBluetoothAdapterDisabled()");
	}
	
	private void onBluetoothAdapterEnableFailed() {
		Debug.Log("Event - onBluetoothAdapterEnableFailed()");
	}
	
	private void onBluetoothAdapterEnabled() {
		Debug.Log("Event - onBluetoothAdapterEnabled()");
		
		// Resuming desired action after enabling the adapter
		switch (_desiredMode) {
		case BluetoothMultiplayerModes.Server:
			Network.Disconnect();
			BluetoothMultiplayerAndroid.InitializeServer(Port);
			break;
		case BluetoothMultiplayerModes.Client:
			Network.Disconnect();
			BluetoothMultiplayerAndroid.ShowDeviceList();
			break;
		}
		
		_desiredMode = BluetoothMultiplayerModes.None;
	}
	
	private void onBluetoothDiscoverabilityEnableFailed() {
		Debug.Log("Event - onBluetoothDiscoverabilityEnableFailed()");
	}
	
	private void onBluetoothDiscoverabilityEnabled(int discoverabilityDuration) {
		Debug.Log(string.Format("Event - onBluetoothDiscoverabilityEnabled(): {0} seconds", discoverabilityDuration));
	}
	
	//	private void  MultiNextLevelButton(){
	//
	//		Application.LoadLevel (5); 
	////		loadLevelState = true;
	////		InstantiateBall ();
	//		//		Network.Instantiate(NetworkNext, Vector3.zero, Quaternion.identity, 0);
	//	}
	#endif
}
}
