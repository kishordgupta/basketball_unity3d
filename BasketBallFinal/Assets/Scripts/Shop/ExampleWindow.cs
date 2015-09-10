using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla;




namespace Soomla.Store.Example 
{ 																		//Allows for access to Soomla API										
	public class ExampleWindow : MonoBehaviour 
	{	
		private static ExampleWindow instance = null;
//		private Vector2 goodsScrollPosition = Vector2.zero;
//		private Vector2 productScrollPosition = Vector2.zero;
//		private bool isDragging = false;
//		private Vector2 startTouch = Vector2.zero;

		private static bool isVisible = false;

		public GUISkin CustomGuiSkin;
		public static int CurrentBalance; 

		public static int playerPointCount;

		void Awake(){
			if(instance == null){ 	//making sure we only initialize one instance.
				instance = this;
				GameObject.DontDestroyOnLoad(this.gameObject);
			} else {					//Destroying unused instances.
				GameObject.Destroy(this);
			}

		}

		void Start () 
		{

			StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreInitialized;							//Handle the initialization of store events (calls function below - unneeded in this case)
			StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
			StoreEvents.OnUnexpectedStoreError += onUnexpectedStoreError;
			StoreEvents.OnMarketPurchaseStarted += onMarketPurchaseStarted;
			StoreEvents.OnMarketPurchase += onMarketPurchase;
		
			SoomlaStore.Initialize (new ExampleAssets());												//Intialize the store


		}

		public void onMarketPurchase(PurchasableVirtualItem TENMUFF_PACK, string payload, Dictionary<string, string> extra){
		}

		public void onMarketPurchaseStarted(PurchasableVirtualItem pvi) {
		}

		public void onSoomlaStoreInitialized(){
		}

		public void onUnexpectedStoreError(int errorCode) {
//			SoomlaUtils.LogError ("ExampleEventHandler", "error with code: " + errorCode);
		}

		public void onCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded) {
		

		}


		public static void OpenWindow(){

			isVisible = true;
		}


		void Update () 
		{
//		
		}

		void OnGUI(){
			GUI.skin = CustomGuiSkin;
		
			if (MainMenuUI.shopCreate) {

				int BoxWidth = Screen.width/5;
				playerPointCount = timer.playerPoint + VirtualItemStorage.CoinStorage;
				CurrentBalance = playerPointCount - PurchaseManager.TotalExpense;
				GUI.skin.label.fontSize = Mathf.Min(Screen.width,Screen.height)/20;
				GUI.Label(new Rect(Screen.width - BoxWidth, 10, BoxWidth, Screen.height/4),"Current Coins:" + CurrentBalance);

				foreach(VirtualCurrencyPack cp in StoreInfo.CurrencyPacks){
					//We draw a button so we can detect a touch and then draw an image on top of it.
					GUI.skin.button.fontSize = Mathf.Min(Screen.width,Screen.height)/20;
					if(GUI.Button(new Rect(00,10,Screen.width/4,Screen.height/5),"Buy 10 Coins")){
//						Debug.Log("SOOMLA/UNITY Wants to buy: " + cp.Name);
						try {
							StoreInventory.BuyItem(cp.ItemId);
							print(VirtualItemStorage.CoinStorage + "Coins Now");
						} catch (Exception e) {
							Debug.Log ("SOOMLA/UNITY " + e.Message);
						}
					}
				}
			}
		}

//		void currencyScreen()
//		{
//			GUI.skin = CustomGuiSkin;
//
//			foreach(VirtualCurrencyPack cp in StoreInfo.CurrencyPacks){
//				//We draw a button so we can detect a touch and then draw an image on top of it.
//				if(GUI.Button(new Rect(400,10,100,50),"Buy This")){
//					Debug.Log("SOOMLA/UNITY Wants to buy: " + cp.Name);
//					try {
//						StoreInventory.BuyItem(cp.ItemId);
//					} catch (Exception e) {
//						Debug.Log ("SOOMLA/UNITY " + e.Message);
//					}
//				}
//
////				string price = ((PurchaseWithMarket)cp.PurchaseType).MarketItem.MarketPriceAndCurrency;
////				if (string.IsNullOrEmpty(price)) {
////					price = ((PurchaseWithMarket)cp.PurchaseType).MarketItem.Price.ToString("0.00");
////				}
////				GUI.Label(new Rect(Screen.width*3/4f,50*2/3f,Screen.width,50/3f),"price:" + price);
////				GUI.skin.label.alignment = TextAnchor.UpperRight;
////				GUI.Label(new Rect(0,0,Screen.width-10,50),"Click to buy");
////				GUI.color = Color.grey;
//			}
//
////			
////
////			if(GUI.Button(new Rect(Screen.width/2f-50/2f,Screen.height*7f/8f+10,50,50), "back")){
////				Application.Quit();
////			}
//		}

		//GUI ELEMENTS
//		void OnGUI() {
//			//Button To PURCHASE ITEM
//			if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.4f, 150,150),"Make green?")) 
//			{
//				try {
//					Debug.Log("attempt to purchase");
//
//					StoreInventory.BuyItem ("turn_green_item_id");										// if the purchases can be completed sucessfully
//				} 
//				catch (Exception e) 
//				{																						// if the purchase cannot be completed trigger an error message connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
//					Debug.Log ("SOOMLA/UNITY" + e.Message);							
//				}
//			}
//			//Button to RESTORE PURCHASES
//			if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.8f, 150,150),"Restore\nPurchases")) {
//				try 
//				{
//					SoomlaStore.RestoreTransactions();													// restore purchases if possible
//				} 
//				catch (Exception e) 
//				{
//					Debug.Log ("SOOMLA/UNITY" + e.Message);												// if restoring purchases fails (connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
//				}
//			}
//
//			//Button to RESTART LEVEL (ensure it doesnt crash)
//			if (GUI.Button(new Rect(Screen.width * 0.5f, Screen.height * 0.8f, 150,150),"Restart"))  
//			{
//				Application.LoadLevel (Application.loadedLevel);
//			}
//		}
	}
}