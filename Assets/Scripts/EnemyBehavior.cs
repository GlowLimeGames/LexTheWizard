﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour {

    CardPlayer cardPlayer;

	//Placeholder for the enemy's hand
	List<CardObject> hand = new List<CardObject>();

    void Awake()
    {
        cardPlayer = GetComponent<CardPlayer>();
        cardPlayer.SetName("Enemy");
        hand = cardPlayer.GetCards();
    }

	//TEST
	//Unused for now
    /*
	void Update () {

	}
    */

	//Simple method for selcting card. Will increase complecity as design team completes more work
	//TODO Change the behavior of enemy selction depending on what it is.
	Card selectCard(Card[] hand){
		//Currently an int but will change to a Card when code is more complete
		Card highestCard = new Card();
		//Searches hand for desired card to play. Current criteria is for initial prototype only.
		for(int i = 0; i < hand.Length; i++){
			//When code is more complete; Change this to check card's value variable
			//TODO talk with design team to determine how a real player might value their cards
			if (highestCard.getAIVal() < hand[i].getAIVal()) {
				//Sets temp variable to highest valued card;
				highestCard = hand [i];
			}
		}
		return highestCard;
	}

	//TODO write enemy preferences & behaviors(post alpha)
	//TODO write planning algorithm for 2 card combos
}
