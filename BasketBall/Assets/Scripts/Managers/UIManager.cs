using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{

		public Button pauseButton;
		public GameObject pausePanel;
		public Button playButton;
		public Text goal;
		// Use this for initialization
		void Start ()
		{
				pauseButton.onClick.AddListener (() => {


						if (Time.timeScale > 0) {
								Time.timeScale = 0;
								pauseButton.GetComponent<CanvasGroup> ().alpha = 0f;
								pauseButton.GetComponent<CanvasGroup> ().interactable = false;
								pauseButton.GetComponent<CanvasGroup> ().blocksRaycasts = false;


								pausePanel.GetComponent<CanvasGroup> ().alpha = 1f;
								pausePanel.GetComponent<CanvasGroup> ().interactable = true;
								pausePanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

						} 


				});

				playButton.onClick.AddListener (() => {
						Time.timeScale = 1f;
						pauseButton.GetComponent<CanvasGroup> ().alpha = 1f;
						pauseButton.GetComponent<CanvasGroup> ().interactable = true;
						pauseButton.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			
			
						pausePanel.GetComponent<CanvasGroup> ().alpha = 0f;
						pausePanel.GetComponent<CanvasGroup> ().interactable = false;
						pausePanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
				});
		}

		public void GameStart ()
		{
				Time.timeScale = 1f;
		}
	
		public void GameOver ()
		{
				Time.timeScale = 0f;
		}
	
		public void PointCalculation ()
		{
				goal.GetComponent<CanvasGroup> ().alpha = 1f;
		}
	
		void OnDisable ()
		{
				GameEventManager.GameStart -= GameStart;
				GameEventManager.GameOver -= GameOver;
				GameEventManager.GamePointCalculation -= PointCalculation;
		}
	
		void OnEnable ()
		{
		
				GameEventManager.GameStart += GameStart;
				GameEventManager.GameOver += GameOver;
				GameEventManager.GamePointCalculation += PointCalculation;
		}
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void Pause ()
		{
				print ("Pause is pressed");
		}

		void PausePressed ()
		{
				print ("SEcond way");
		}
}
