using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public static Player player; // Static instance of this class
	public UIManager UImanager;
    Tuning tuning;

	// Stat variables
    int points;
    int gold;
    int salvage;

	string[] inventory = new string[5];
    CardPlayer cardPlayer;

	void Awake() {
		player = this;
	}

	void Start() {
		UImanager = UIManager.UImanager;

		// Assigns starting stats from tuning object
        player.tuning = Tuning.tuning;
		player.points = tuning.startingPoints;
		player.gold = tuning.startingGold;
		player.salvage = tuning.startingSalvage;
		for (int i = 0; i < inventory.Length; i++){
			player.inventory [i] = "";
		}
		// Calls UIManager to display the stats
		UImanager.SetStats ();

        player.cardPlayer = GetComponent<CardPlayer>();
        cardPlayer.SetName("Lex");
	}

	//TODO add bool functions for item checks.

	// This allows other objects to get stats from Player without reassigning them
    public int[] GetStats()
    {
        return new int[3] { points, gold, salvage };
    }

    public void ChangeStats(int pointsChange, int goldChange, int salvageChange)
    {
        points += pointsChange;
        gold += goldChange;
        salvage += salvageChange;

        UImanager.SetStats();
    }
}
