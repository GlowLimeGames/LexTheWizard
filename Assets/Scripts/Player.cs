using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public static Player player; // Static instance of this class
	public UIManager UImanager;
    List<CardObject> cards = new List<CardObject>();
    Tuning tuning;

	// Stat variables
    int points;
    int gold;
    int salvage;

	void Awake() {
		player = this;
	}

	void Start() {
		tuning = Tuning.tuning;
		// Assigns starting stats from tuning object
		player.points = tuning.startingPoints;
		player.gold = tuning.startingGold;
		player.salvage = tuning.startingSalvage;

		// Calls UIManager to display the stats
		UImanager.SetStats ();
	}

	// This allows other objects to get stats from Player without reassigning them
    public int[] GetStats()
    {
        return new int[] { points, gold, salvage };
    }

    public List<CardObject> GetCards()
    {
        return cards;
    }

    public void AddCardToHand(CardObject cardObject)
    {
        cards.Add(cardObject);
    }
}
