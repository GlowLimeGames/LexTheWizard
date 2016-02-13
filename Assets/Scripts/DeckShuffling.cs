using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckShuffling : MonoBehaviour {

	public List<CardInfo> Shuffle (List<CardInfo> initialDeck) {
        int numOfCards = initialDeck.Count;
        CardInfo[] shuffledDeck = new CardInfo[numOfCards];
		
        //fill Cards in array with null
		for (int i = 0; i <= numOfCards - 1; i++) {
			shuffledDeck [i] = null;

		}

		//loop to place all the numbers in the initial deck into a random spot in the shuffled deck
        int randomNum;
		for (int j = 0; j <= numOfCards - 1; j++) {
			bool cardPlaced = false;
			//continues generating random number until an empty spot is found
			while (cardPlaced == false) {
                //generated a random number between 0 and 51
                randomNum = Random.Range(0, numOfCards);
                //checks if the value in the shuffled deck is 0
				if(shuffledDeck[randomNum] == null)

				{
                    //places the number from initial deck in the random index
					shuffledDeck[randomNum].cardNumber = initialDeck[j].cardNumber;
					cardPlaced = true;
				}
			}
		}

        // convert array to list
        List<CardInfo> newDeck = new List<CardInfo>();
        for (int k = 0; k <= numOfCards - 1; k++)
        {
            newDeck.Add(shuffledDeck[k]);
        }

        return newDeck;
	}
}
