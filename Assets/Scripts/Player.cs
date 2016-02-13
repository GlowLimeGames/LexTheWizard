using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static Player player;
	public UIManager UImanager;
    Tuning tuning;

    int points;
    int gold;
    int salvage;

	void Awake() {
		player = this;
	}

	void Start() {
		tuning = Tuning.tuning;
		player.points = tuning.startingPoints;
		player.gold = tuning.startingGold;
		player.salvage = tuning.startingSalvage;

		UImanager.SetStats ();
	}

    public int[] GetStats()
    {
        return new int[] { points, gold, salvage };
    }

}
