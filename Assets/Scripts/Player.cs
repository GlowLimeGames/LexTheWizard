using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int points;
    public int gold;
    public int salvage;

    public static Player player;

    void Awake()
    {
        player = this;
        player.points = points;
        player.gold = gold;
        player.salvage = salvage;
    }

}
