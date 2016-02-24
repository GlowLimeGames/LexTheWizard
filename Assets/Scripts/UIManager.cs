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
    public Text goldText;
    public Text salvageText;

	public Button travelButton;
	public Image board;

	public GameObject popupObject;

	// Reference to player
    Player player;

	Tuning tuning;

	Popup popup;

	void Awake() {
		UImanager = this;
	}

	void Start () {
        player = Player.player;
		tuning = Tuning.tuning;
		popup = popupObject.GetComponent<Popup> ();
		popupObject.SetActive(false);

        /*
        pointsText.text = "Points: ";
        goldText.text = "Gold: ";
        salvageText.text = "Salvage: ";
        */
	}

	// This is called from Player
    public void SetStats()
    {
        int[] playerStats = player.GetStats();
        pointsText.text = "Points: " + playerStats[0].ToString();
        goldText.text = "Gold: " + playerStats[1].ToString();
        salvageText.text = "Salvage: " + playerStats[2].ToString();
    }

	public void SetBoard(Land terrain) {
		board.sprite = terrain.boardArt;
	}

	public void Travel() {
		if (tuning.travelCost <= player.GetStats () [2]) {
			// Player can afford
			GameController.gameController.MoveTerrain();
			player.ChangeStats (0, 0, -tuning.travelCost);
		} else {
			showPopup("I'm sorry. You do not have enough salvage to travel.");
		}
	}

	public void DismissPopup() {
		popup.Dimiss ();
	}

	public void showPopup(string message) {
		popupObject.SetActive (true);
		popup.SetText (message);
	}
}
