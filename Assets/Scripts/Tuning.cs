/*
 * Attached to Tuning game object
 * 
 * Should be called first
 * 
 * Contains variables for all other scripts to reference
 * These variables are assigned in the Inspector
 */

using UnityEngine;
using System.Collections;

public class Tuning : MonoBehaviour {

    public static Tuning tuning;

	// Win Condition
	public int numOfCardsToWin;

    // Player variables
    public int startingGold;
    public int startingSalvage;
    public int startingPoints;

    // Card Game variables
    public int numOfStartingCards;
    public float scaleFactor;
    public Vector3 cardScale;

	public int travelCost;

	public string defaultDismissButtonText;

    void Awake()
    {
        tuning = this;
    }
}
