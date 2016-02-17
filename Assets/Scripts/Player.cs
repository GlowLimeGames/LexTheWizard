using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static Player player; // Static instance of this class
	public UIManager UImanager;
    Tuning tuning;

	// Stat variables
    int points;
    int gold;
    int salvage;

	string[] inventory = new string[5];
	void Awake() {
		player = this;
	}

	void Start() {
		tuning = Tuning.tuning;
		// Assigns starting stats from tuning object
		player.points = tuning.startingPoints;
		player.gold = tuning.startingGold;
		player.salvage = tuning.startingSalvage;
		for (int i = 0; i < inventory.Length; i++){
			player.inventory [i] = "";
		}
		// Calls UIManager to display the stats
		UImanager.SetStats ();
	}

	//TODO add bool functions for item checks.

	// This allows other objects to get stats from Player without reassigning them
    public int[] GetStats()
    {
        return new int[] { points, gold, salvage };
    }
}
