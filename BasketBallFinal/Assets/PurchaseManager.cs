using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla;

namespace Soomla.Store.Example{

public class PurchaseManager : MonoBehaviour
{

	public Button IncreaseMovement;
	public Button IncreaseJump;
	public Button IncreaseHandPower;

	public bool IncreaseMovementBool = false;
	public bool IncreaseJumpBool = false;
	public bool IncreaseHandPowerBool = false;

	public Slider IncreaseMovementSlider;
	public Slider IncreaseJumpSlider;
	public Slider IncreaseHandPowerSlider;

	public static float IncreaseMovementSliderValue = 0;
	public static float IncreaseJumpSliderValue = 0;
	public static float IncreaseHandPowerSliderValue = 0;
	public static int CoinExpense = 0;
		public static int TotalExpense;
		public static int SumToTalCost;

	public GameObject PurchaseConfirm;
	public GameObject PurchaseMainPanel;
	public GameObject PurchaseRejectPanel;

	public Button Ok;
	public Button Back;
	public Button BackFromReject;
	
	public	string ExpenseKey = "TotalCost";
		public	string moveSliderKey = "MoveSlider";
		public	string jumpSliderKey = "JumpSlider";
		public	string handSliderKey = "HandSlider";

		public static float playerMovIncrement;
		public static float playerJumpIncrement;
		public static float playerHandIncrement;

	
	// Use this for initialization
	void Start ()
	{

		TotalExpense = PlayerPrefs.GetInt (ExpenseKey, 0);
		IncreaseMovementSlider.value = PlayerPrefs.GetFloat(moveSliderKey,0f);
		IncreaseJumpSlider.value = PlayerPrefs.GetFloat(jumpSliderKey,0f);
		IncreaseHandPowerSlider.value = PlayerPrefs.GetFloat(handSliderKey,0f);
	
		IncreaseMovement.onClick.AddListener (() => {

			if(ExampleWindow.CurrentBalance>99){
					PurchaseConfirm.GetComponent<CanvasGroup> ().alpha = 1f;
					PurchaseConfirm.GetComponent<CanvasGroup> ().interactable = true;
					PurchaseConfirm.GetComponent<CanvasGroup> ().blocksRaycasts = true;
					
					PurchaseMainPanel.GetComponent<CanvasGroup> ().interactable = false;
					
					
					IncreaseMovementBool = true;
				}
				else
				{
					PurchaseRejectPanel.GetComponent<CanvasGroup> ().alpha = 1f;
					PurchaseRejectPanel.GetComponent<CanvasGroup> ().interactable = true;
					PurchaseRejectPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
					
					PurchaseMainPanel.GetComponent<CanvasGroup> ().interactable = false;
				}
			
		});

		IncreaseJump.onClick.AddListener (() => {
			
				if(ExampleWindow.CurrentBalance>99){
					PurchaseConfirm.GetComponent<CanvasGroup> ().alpha = 1f;
					PurchaseConfirm.GetComponent<CanvasGroup> ().interactable = true;
					PurchaseConfirm.GetComponent<CanvasGroup> ().blocksRaycasts = true;
					
					PurchaseMainPanel.GetComponent<CanvasGroup> ().interactable = false;
					
					
					IncreaseJumpBool = true;
				}
				else
				{
					PurchaseRejectPanel.GetComponent<CanvasGroup> ().alpha = 1f;
					PurchaseRejectPanel.GetComponent<CanvasGroup> ().interactable = true;
					PurchaseRejectPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
					
					PurchaseMainPanel.GetComponent<CanvasGroup> ().interactable = false;
				}
		});

		IncreaseHandPower.onClick.AddListener (() => {
			
				if(ExampleWindow.CurrentBalance>99){
					PurchaseConfirm.GetComponent<CanvasGroup> ().alpha = 1f;
					PurchaseConfirm.GetComponent<CanvasGroup> ().interactable = true;
					PurchaseConfirm.GetComponent<CanvasGroup> ().blocksRaycasts = true;
					
					PurchaseMainPanel.GetComponent<CanvasGroup> ().interactable = false;
					
					
					IncreaseHandPowerBool = true;
				}
				else
				{
					PurchaseRejectPanel.GetComponent<CanvasGroup> ().alpha = 1f;
					PurchaseRejectPanel.GetComponent<CanvasGroup> ().interactable = true;
					PurchaseRejectPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
					
					PurchaseMainPanel.GetComponent<CanvasGroup> ().interactable = false;
				}
		});


		Ok.onClick.AddListener (() => {
			

			if (IncreaseMovementBool) {

				PurchaseConfirm.GetComponent<CanvasGroup> ().alpha = 0f;
				PurchaseConfirm.GetComponent<CanvasGroup> ().interactable = false;
				PurchaseConfirm.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				
					CoinExpense +=100;
					TotalExpense += CoinExpense;
				

				IncreaseMovementSliderValue ++;
				IncreaseMovementSlider.value = IncreaseMovementSliderValue;
					PlayerPrefs.SetFloat(moveSliderKey,IncreaseMovementSliderValue);

				IncreaseMovementBool = false;
					print ("Total Expense:" + TotalExpense);

			} else if (IncreaseJumpBool) {
				PurchaseConfirm.GetComponent<CanvasGroup> ().alpha = 0f;
				PurchaseConfirm.GetComponent<CanvasGroup> ().interactable = false;
				PurchaseConfirm.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				
					CoinExpense +=100;
					TotalExpense += CoinExpense;
				IncreaseJumpSliderValue ++;
				IncreaseJumpSlider.value = IncreaseJumpSliderValue;
					PlayerPrefs.SetFloat(jumpSliderKey,IncreaseJumpSliderValue);

				IncreaseJumpBool = false;
					print ("Coin Expense:" + CoinExpense);


			} else if (IncreaseHandPowerBool) {
				PurchaseConfirm.GetComponent<CanvasGroup> ().alpha = 0f;
				PurchaseConfirm.GetComponent<CanvasGroup> ().interactable = false;
				PurchaseConfirm.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				
					CoinExpense +=100;
					TotalExpense += CoinExpense;
				IncreaseHandPowerSliderValue ++;
				IncreaseHandPowerSlider.value = IncreaseHandPowerSliderValue;
					PlayerPrefs.SetFloat(handSliderKey,IncreaseHandPowerSliderValue);

				IncreaseHandPowerBool = false;
					print ("Coin Expense:" + CoinExpense);


			}

			PurchaseMainPanel.GetComponent<CanvasGroup> ().interactable = true;


		});

		Back.onClick.AddListener (() => {
			
			PurchaseConfirm.GetComponent<CanvasGroup> ().alpha = 0f;
			PurchaseConfirm.GetComponent<CanvasGroup> ().interactable = false;
			PurchaseConfirm.GetComponent<CanvasGroup> ().blocksRaycasts = false;

			PurchaseMainPanel.GetComponent<CanvasGroup> ().interactable = true;

		});

		BackFromReject.onClick.AddListener (() => {
				
				PurchaseRejectPanel.GetComponent<CanvasGroup> ().alpha = 0f;
				PurchaseRejectPanel.GetComponent<CanvasGroup> ().interactable = false;
				PurchaseRejectPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				
				PurchaseMainPanel.GetComponent<CanvasGroup> ().interactable = true;
				
			});


	}


	


	
	// Update is called once per frame
	void Update ()
	{

				PlayerPrefs.SetInt (ExpenseKey, TotalExpense);
				PlayerPrefs.Save ();

			playerMovIncrement = IncreaseMovementSlider.value / 10;
			playerJumpIncrement = IncreaseJumpSlider.value / 10;
			playerHandIncrement = IncreaseHandPowerSlider.value;
		
	}
}
}
