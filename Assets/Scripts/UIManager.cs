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

        SetStats();
	}

    void SetStats()
    {
        pointsText.text += player.points.ToString();
        goldText.text += player.gold.ToString();
        salvageText.text += player.salvage.ToString();
    }
}
