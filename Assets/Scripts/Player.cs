using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static Player player;
    Tuning tuning;

    int points;
    int gold;
    int salvage;

    void Start()
    {
        tuning = Tuning.tuning;
        player = this;
        player.points = tuning.startingPoints;
        player.gold = tuning.startingGold;
        player.salvage = tuning.startingSalvage;
    }

    public int[] GetStats()
    {
        return new int[] { points, gold, salvage };
    }

}
