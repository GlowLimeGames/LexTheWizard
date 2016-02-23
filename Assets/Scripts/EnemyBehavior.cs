using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : MonoBehaviour {

    CardPlayer cardPlayer;

	//Placeholder for the enemy's hand
	List<CardObject> hand = new List<CardObject>();

	GameController gameController;

    void Awake()
    {
		gameController = GameController.gamecontroller;
        cardPlayer = GetComponent<CardPlayer>();
        cardPlayer.SetName("Enemy");
		hand = cardPlayer.GetCards();
    }

	//Method to test playability of card in current state
	private bool playable(CardObject card){
		if((card.GetCardInfo().terrain == gameController.currTerrain.name) &&
			(card.GetCardInfo().daytime == gameController.currDayTime)){
			return true;
		}
		return false;
	}


	//TODO talk with design team to determine how a real player might value their cards
	//TODO Change the behavior of enemy selction depending on what kind of enemy it is.

	//Simple method for selcting card. Will increase complecity as design team completes more work
	public CardObject selectCard(){
		//Temp var to store highest valued playable card.
		CardObject highestCard = null;
		//Searches hand for desired card to play. Current criteria is for initial prototype only.
		for(int i = 0; i < hand.Count; i++){
			//Checks playability and relative value of card
			if (playable(hand[i])&&(highestCard.GetCardInfo().aiValue < hand[i].GetCardInfo().aiValue)) {
				//Sets temp variable to highest valued card;
				highestCard = hand [i];
			}
		}
		return highestCard;
	}

	//TODO write enemy preferences & behaviors(post alpha)
	//TODO write planning algorithm for 2 card combos
}
