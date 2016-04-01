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

    // Reference to action icons parent
    public GameObject actionIcons;
    DiscardPile discard;

	// Reference to popups
	public GameObject pauseMenu;
	public GameObject confirmMenu;
	public GameObject notificationPopup; // object itself
	public GameObject gameOver;
	Popup popup; // popup script
    ConfirmationPopup confirmPopup;

	void Awake() {
		UImanager = this;
	}

	public void SetupUI () {
        player = Player.player;
		tuning = Tuning.tuning;
		gameController = GameController.gameController;

        SetStats(tuning.startingPoints);

        popup = notificationPopup.GetComponent<Popup>();
        confirmPopup = confirmMenu.GetComponent<ConfirmationPopup>();
        hideAllPopups();

        discard = actionIcons.GetComponentInChildren<DiscardPile>();
        ShowActionIcons(false);
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

	void showPauseMenu(bool isPaused) {
		pauseMenu.SetActive (isPaused);
	}

	// This is called from the Dismiss Button on the Popup
	public void DismissPopup() {
		popup.Hide ();
	}

	public void ShowPopup(string message) {
		notificationPopup.SetActive (true);
		popup.SetText (message);
	}

    public void ShowActionIcons(bool showIcons)
    {
        actionIcons.SetActive(showIcons);
    }

	// Can be used to hide or show
	public void ShowConfirmMenu(bool showMenu) {
		confirmMenu.SetActive (showMenu);
	}

	public void ConfirmAction(bool confirm) {
		if (confirm) {
			Debug.Log ("Confirmed.");
			player.Confirm(true);
		} else {
			Debug.Log ("Cancelled.");
			player.Confirm(false);
		}
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

    public DiscardPile Discard
    {
        get { return discard; }
    }

	public void PlayButtonPressSFX () {
		EventController.Event("ButtonPress");
	}
}
