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

    CardPlayer cardPlayer;

	void Awake() {
		player = this;
	}

	void Start() {
		// Assigns starting stats from tuning object
        player.tuning = Tuning.tuning;
		player.points = tuning.startingPoints;
		player.gold = tuning.startingGold;
		player.salvage = tuning.startingSalvage;

		// Calls UIManager to display the stats
		UImanager.SetStats ();

        player.cardPlayer = GetComponent<CardPlayer>();
        cardPlayer.SetName("Lex");
	}

	// This allows other objects to get stats from Player without reassigning them
    public int[] GetStats()
    {
        return new int[3] { points, gold, salvage };
    }
}
