using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	//Placeholder for the enemy's hand
	int[] currentCards = new int[5];
	int x = 0;

	void Start () {
	//Fills the above array for testing purposes. Delete this and draw from deck when that is complete
		for(int i = 0; i < currentCards.Length; i++){
			currentCards [i] = Random.Range (0, 100);
		}
		x = selectCard(currentCards);
	}
	//TEST
	//Unused for now
	void Update () {
	
	}

	//Simple method for selcting card. Will increase complecity as design team completes more work
	//TODO Change the behavior of enemy selction depending on what it is.
	int selectCard(int[] hand){
		//Currently an int but will change to a Card when code is more complete
		int cardValue = 0;
		//Searches hand for desired card to play. Current criteria is for initial prototype only.
		for(int i = 0; i < hand.Length; i++){
			//When code is more complete; Change this to check card's value variable
			//TODO talk with design team to determine how a real player might value their cards
			if (cardValue < hand[i]) {
				//Sets temp variable to highest valued card;
				cardValue = hand [i];
						}
		}
		return cardValue;
	}

	//TODO write enemy preferences & behaviors
	//TODO write planning algorithm for 2 card combos

}
