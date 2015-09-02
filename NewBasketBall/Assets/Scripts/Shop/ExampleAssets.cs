//ExampleAssets.cs 
//Alexander Young 
//February 5, 2015
//Description - Creates the IAP assets so that their can be bought and used

using UnityEngine;
using System.Collections;

namespace Soomla.Store.Example															//Allows for access to Soomla API
{
	public class ExampleAssets : IStoreAssets 											//Extend from IStoreAssets (required to define assets)
	{
		public int GetVersion() {														// Get Current Version
			return 0;
		}
		
		public VirtualCurrency[] GetCurrencies() {										// Get/Setup Virtual Currencies
			return new VirtualCurrency[]{MUFFIN_CURRENCY};
		}

		public VirtualGood[] GetGoods() {												// Add "TURN_GREEN" IAP to GetGoods
			return new VirtualGood[]{};
		}
		
		public VirtualCurrencyPack[] GetCurrencyPacks() {								// Get/Setup Currency Packs
			return new VirtualCurrencyPack[]{TENMUFF_PACK};
		}
		
		public VirtualCategory[] GetCategories() {										// Get/ Setup Categories (for In App Purchases)
			return new VirtualCategory[]{};
		}


		public static string MUFFIN_CURRENCY_ITEM_ID = "currency_muffin";

		public static VirtualCurrency MUFFIN_CURRENCY = new VirtualCurrency(
			"Muffins",                                  // Name
			"Muffin currency",                          // Description
			MUFFIN_CURRENCY_ITEM_ID                     // Item id
			);

		public static string TENMUFF_PACK_PRODUCT_ID = "com.siliconorchard.basketball.refunded";
		public static VirtualCurrencyPack TENMUFF_PACK = new VirtualCurrencyPack (
			"10 Muffins",
			"Pack of 10 Muffin currency units",
			"muffins_10",
			10,
			MUFFIN_CURRENCY_ITEM_ID,
			new PurchaseWithMarket(
			TENMUFF_PACK_PRODUCT_ID,
			8.99)
			); 

	}
}