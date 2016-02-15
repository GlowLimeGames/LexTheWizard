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
    public Text pointsText;
    public Text goldText;
    public Text salvageText;

	// Reference to player
    Player player;

	void Start () {
        player = Player.player;

        pointsText.text = "Points: ";
        goldText.text = "Gold: ";
        salvageText.text = "Salvage: ";
	}

	// This is called from Player
    public void SetStats()
    {
        int[] playerStats = player.GetStats();
        pointsText.text += playerStats[0].ToString();
        goldText.text += playerStats[1].ToString();
        salvageText.text += playerStats[2].ToString();
    }
}
