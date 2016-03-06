using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehavior : CardPlayer {

	void Awake() {
		base.Awake ();
	}

    void Start()
    {
		cardPlayerName = "Enemy";
		base.Start ();
    }

	//Method to test playability of card in current state
	private bool playable(CardObject card){
        Land[] cardsAcceptedTerrains = card.GetCardInfo().terrains;
        string cardsAcceptedDayTime = card.GetCardInfo().daytime;
        for (int i = 0; i < cardsAcceptedTerrains.Length; i++)
        {
            if (cardsAcceptedTerrains[i] == gameController.currTerrain)//&& (card.GetCardInfo().daytime == gameController.currDayTime)){ taken out for alpha
            {
                return true;
            }
        }
		return false;
	}
	
	//TODO talk with design team to determine how a real player might value their cards
	//TODO Change the behavior of enemy selction depending on what kind of enemy it is.

	//Simple method for selcting card. Will increase complexity as design team completes more work
	public CardObject selectCard(){
		//Temp var to store highest valued playable card.

		int searchIndex = 0;
		CardObject highestCard = hand[searchIndex];

		while (!playable(highestCard) && searchIndex < hand.Count) {
			searchIndex++;
			highestCard = hand[searchIndex];
		}

		//Searches hand for desired card to play. Current criteria is for initial prototype only.
		foreach(CardObject card in hand){

			//Checks playability and relative value of card
			if (playable(card)&&(highestCard.GetCardInfo().aiValue < card.GetCardInfo().aiValue)) {
				//Sets temp variable to highest valued card;
				highestCard = card;
			}
		}
		return highestCard;
	}

	//TODO write enemy preferences & behaviors(post alpha)
	//TODO write planning algorithm for 2 card combos
}
