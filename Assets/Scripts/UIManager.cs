using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Text pointsText;
    public Text goldText;
    public Text salvageText;

    Player player;

	void Start () {
        player = Player.player;

        pointsText.text = "Points: ";
        goldText.text = "Gold: ";
        salvageText.text = "Salvage: ";
	}

    public void SetStats()
    {
        int[] playerStats = player.GetStats();
        pointsText.text += playerStats[0].ToString();
        goldText.text += playerStats[1].ToString();
        salvageText.text += playerStats[2].ToString();
    }
}
