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
	public GameObject popupObject; // object itself
	Popup popup; // popup script

	void Awake() {
		UImanager = this;
	}

	public void SetupUI () {
        player = Player.player;
		tuning = Tuning.tuning;
		gameController = GameController.gameController;

		popup = popupObject.GetComponent<Popup> ();
		hideAllPopups ();
		//popupObject.SetActive(false); // Hide popup
	}

	// This is called from Player
    public void SetStats()
    {
        int[] playerStats = player.GetStats();
        pointsText.text = "Points: " + playerStats[0].ToString();
    }

	// This is called from GameController in SetTerrain()
	public void SetBoard(Land terrain) {
		board.sprite = terrain.boardArt;
	}

	// This is called when the Travel Button is pressed
	public void Travel() {
		if (tuning.travelCost <= player.GetStats () [2]) {
			// Player can afford
			EventController.Event("Decrease");
			gameController.MoveTerrain();
			player.ChangeStats (0, 0, -tuning.travelCost);
			GameController.gameController.Turn();
		} else {
			ShowPopup("I'm sorry. You do not have enough salvage to travel.");
		}
	}

	// This is called when Pause Button is pressed (pauseGame = true)
	// Or when ReturnToMenu Button is pressed (pauseGame = false)
	public void Pause(bool pauseGame) {
		showPauseMenu (pauseGame);
		gameController.Pause (pauseGame);
	}

	void showPauseMenu(bool isPaused) {
		pauseMenu.SetActive (isPaused);
	}

	// This is called from the Dismiss Button on the Popup
	public void DismissPopup() {
		popup.Dimiss ();
	}

	public void ShowPopup(string message) {
		popupObject.SetActive (true);
		popup.SetText (message);
	}

	void hideAllPopups() {
		popupObject.SetActive (false);
		pauseMenu.SetActive (false);
	}

	public void PlayButtonPressSFX () {
		EventController.Event("ButtonPress");
	}
}
