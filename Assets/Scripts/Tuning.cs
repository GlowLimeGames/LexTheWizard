using UnityEngine;
using System.Collections;

public class Tuning : MonoBehaviour {

    public static Tuning tuning;

    // Player variables
    public int startingGold;
    public int startingSalvage;
    public int startingPoints;

    // Card Game variables
    public int numOfStartingCards;
    public float scaleFactor;

    void Awake()
    {
        tuning = this;
    }

}
