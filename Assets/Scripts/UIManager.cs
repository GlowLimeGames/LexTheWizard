/*
 * Attached to Stats Canvas
 * 
 * Displays number of points, gold, and salvage on the screen
 * Gets this info from Player
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	// Reference to Text components on Stats Canvas
	public static UIManager UImanager;
    public Text pointsText;
	
	public Image board;

	// Reference to player
    Player player;

	// Reference to tuning
	Tuning tuning;

	// Reference to GameController
	GameController gameController;

	// Reference to popups
	public GameObject pauseMenu;
	public GameObject confirmMenu;
	public GameObject notificationPopup; // object itself
	public GameObject gameOver;
	Popup popup; // popup script

	//Used to specify action to confirm
	private ActionType actionType;

	void Awake() {
		UImanager = this;
	}

	public void SetupUI () {
        player = Player.player;
		tuning = Tuning.tuning;
		gameController = GameController.gameController;

		SetStats (tuning.startingPoints);

		popup = notificationPopup.GetComponent<Popup> ();
		hideAllPopups ();
		//notificationPopup.SetActive(false); // Hide popup
	}

	// This is called from Player and SetupUI
    public void SetStats(int points)
    {
        pointsText.text = "Points: " + points.ToString();
    }

	// This is called from GameController in SetTerrain()
	public void SetBoard(Land terrain) {
		board.sprite = terrain.boardArt;
	}

	// This is called when the Travel Button is pressed
	public void Travel() {
		EventController.Event("Decrease");
		gameController.MoveTerrain();
		//player.ChangeStats (0, 0, -tuning.travelCost);
		GameController.gameController.Turn();
	}

	// This is called when Pause Button is pressed (pauseGame = true)
	// Or when ReturnToMenu Button is pressed (pauseGame = false)
	public void Pause(bool pauseGame) {
		showPauseMenu (pauseGame);
		gameController.Pause (pauseGame);
	}

	//Called when the Pass Button is pressed
	public void Pass () {
		actionType = ActionType.Pass;
		UImanager.ShowConfirmMenu(true);
	}

	//Called when the discarding a card
	public void Discard () {
		actionType = ActionType.Discard;
		//TODO set selectedCard based on UI implementation

		UImanager.ShowConfirmMenu(true);
	}

	void showPauseMenu(bool isPaused) {
		pauseMenu.SetActive (isPaused);
	}

	// This is called from the Dismiss Button on the Popup
	public void DismissPopup() {
		popup.Dimiss ();
	}

	public void ShowPopup(string message) {
		notificationPopup.SetActive (true);
		popup.SetText (message);
	}

	// Can be used to hide or show
	public void ShowConfirmMenu(bool showMenu) {
		confirmMenu.SetActive (showMenu);
	}

	public void ConfirmAction(bool confirm) {
		//cases to go by a variable that is reset to -1 at end of this. run whatever.confirm(confirm)
		if (confirm) {
			Debug.Log ("Confirmed.");
		} else {
			Debug.Log ("Cancelled.");
		}

		//Facilitates the different actions that need confirmation
		switch(actionType){
		case ActionType.Play:
			player.Confirm(confirm);
			break;

		case ActionType.Pass:
			if (confirm) {
				gameController.Turn ();
			}
			break;
		case ActionType.Discard:
			if (confirm) {
				//TODO set selectedCard based on UI implementation
				//player.RemoveCardFromHand (TODO);
				gameController.MoveTerrain ();
				gameController.Turn ();
			}
			break;
		}

		actionType = ActionType.None;
		ShowConfirmMenu (false);
	}

	public void ShowGameOver(bool isGameOver) {
		gameOver.SetActive (isGameOver);
	}

	void hideAllPopups() {
		notificationPopup.SetActive (false);
		pauseMenu.SetActive (false);
		confirmMenu.SetActive (false);
		gameOver.SetActive (false);
	}

	public void PlayButtonPressSFX () {
		EventController.Event("ButtonPress");
	}
	public void setActionType(ActionType action){
		actionType = action;
	}
	//Types of actions utilizing confirm menu
	public enum ActionType {
		Pass,
		Play,
		Discard,
		None
	};
}
